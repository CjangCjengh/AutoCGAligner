using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace AutoCGAligner
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWin());
        }

        /// <summary>
        /// 两个个像素点RGB向量的最大距离
        /// </summary>
        static public double MaxPixelDis = Math.Sqrt(Math.Pow(255, 2) * 3);

        /// <summary>
        /// 将图片等比例拉伸后展示在框中
        /// </summary>
        /// <param name="img">要展示的图片</param>
        /// <param name="box">展示图片的框</param>
        static public void ShowImage(Image img, PictureBox box)
        {
            float widthRatio = (float)img.Width / box.Width;
            float heightRatio = (float)img.Height / box.Height;
            int newWidth, newHeight;
            if (widthRatio < heightRatio)
            {
                newWidth = (int)(img.Width / heightRatio);
                newHeight = box.Height;
            }
            else
            {
                newWidth = box.Width;
                newHeight = (int)(img.Height / widthRatio);
            }
            box.Image = img.GetThumbnailImage(newWidth, newHeight, () => false, IntPtr.Zero);
        }

        /// <summary>
        /// 求两个像素点RGB向量的距离
        /// </summary>
        /// <param name="p1">像素1</param>
        /// <param name="p2">像素2</param>
        /// <returns></returns>
        static public double PixelDistance(Color p1, Color p2)
        {
            int R = p1.R - p2.R;
            int G = p1.G - p2.G;
            int B = p1.B - p2.B;
            return Math.Sqrt(R * R + G * G + B * B);
        }

        /// <summary>
        /// 获取图片边缘的像素点
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="npixels">边缘像素点的数量</param>
        /// <returns></returns>
        static public Color[,] GetBorder(Bitmap img, out int npixels)
        {
            Color[,] border = new Color[img.Width, img.Height];
            npixels = 0;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    if (img.GetPixel(i, j).A == 0)
                        border[i, j] = Color.FromArgb(0);
                    else if ((i - 1 >= 0 && img.GetPixel(i - 1, j).A != 0) &&
                        (i + 1 < img.Width && img.GetPixel(i + 1, j).A != 0) &&
                        (j - 1 >= 0 && img.GetPixel(i, j - 1).A != 0) &&
                        (j + 1 < img.Height && img.GetPixel(i, j + 1).A != 0))
                        border[i, j] = Color.FromArgb(0);
                    else
                    {
                        border[i, j] = img.GetPixel(i, j);
                        npixels++;
                    }
                }
            }
            return border;
        }

        static public bool AlignImage(Bitmap baseImg, Color[,] border,
            out int xAxis, out int yAxis, out double minDis,
            in int initStep, in int stepDivisor, in int extScale,
            ProgressBar bar, CancellationTokenSource cts,
            Form owner, Action<int, int, double> display)
        {
            int width = border.GetLength(0);
            int height = border.GetLength(1);
            minDis = MaxPixelDis * width * height;
            xAxis = 0;
            yAxis = 0;
            int xRange = baseImg.Width - width;
            int yRange = baseImg.Height - height;
            int xStart = 0;
            int xEnd = xRange;
            int yStart = 0;
            int yEnd = yRange;
            int xStep = Math.Min((xEnd - xStart) / stepDivisor, initStep);
            int yStep = Math.Min((yEnd - yStart) / stepDivisor, initStep);
            bool xFlag = true;
            bool yFlag = true;
            if (xStep == 0)
                xStep = 1;
            if (yStep == 0)
                yStep = 1;
            while (xFlag || yFlag)
            {
                owner.Invoke(new Action(() =>
                {
                    bar.Minimum = xStart;
                    bar.Maximum = xEnd;
                }));

                if (!AlignImage(baseImg, border,
                    xStart, xEnd, xStep,
                    yStart, yEnd, yStep,
                    ref minDis, ref xAxis, ref yAxis,
                    bar, cts, owner))
                    return false;

                if (display != null)
                    owner.Invoke(display, xAxis, yAxis, minDis);

                xStart = Math.Max(xAxis - xStep * extScale, 0);
                xEnd = Math.Min(xAxis + xStep * extScale, xRange);
                yStart = Math.Max(yAxis - yStep * extScale, 0);
                yEnd = Math.Min(yAxis + yStep * extScale, yRange);
                if (xStep == 1)
                    xFlag = false;
                if (xFlag)
                {
                    xStep = (xEnd - xStart) / stepDivisor;
                    if (xStep == 0)
                        xStep = 1;
                }
                if (yStep == 1)
                    yFlag = false;
                if (yFlag)
                {
                    yStep = (yEnd - yStart) / stepDivisor;
                    if (yStep == 0)
                        yStep = 1;
                }
            }
            return true;
        }

        static public bool AlignImage(in Bitmap baseImg, in Color[,] border,
            in int xStart, in int xEnd, in int xStep,
            in int yStart, in int yEnd, in int yStep,
            ref double minDis, ref int xAxis, ref int yAxis,
            ProgressBar bar, in CancellationTokenSource cts, Form owner)
        {
            int width = border.GetLength(0);
            int height = border.GetLength(1);
            for (int i = xStart; i <= xEnd; i += xStep)
            {
                owner.Invoke(new Action(() =>
                {
                    bar.Value = i;
                }));
                for (int j = yStart; j <= yEnd; j += yStep)
                {
                    if (cts.IsCancellationRequested)
                        return false;
                    double dis = 0;
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                            if (border[x, y].A != 0)
                                dis += PixelDistance(baseImg.GetPixel(i + x, j + y), border[x, y]);
                        if (dis >= minDis)
                            break;
                    }
                    if (dis < minDis)
                    {
                        minDis = dis;
                        xAxis = i;
                        yAxis = j;
                    }
                }
            }
            return true;
        }

        static public Dictionary<Color, int> CountColors(in Bitmap img)
        {
            Dictionary<Color, int> colorList = new Dictionary<Color, int>();
            for (int i = 0; i < img.Width; i++)
                for (int j = 0; j < img.Height; j++)
                    if (!colorList.ContainsKey(img.GetPixel(i, j)))
                        colorList.Add(img.GetPixel(i, j), 1);
                    else
                        colorList[img.GetPixel(i, j)]++;
            return colorList;
        }

        static public void ClearBackground(ref Bitmap img, in Color color, in int deg)
        {
            if (img.PixelFormat != PixelFormat.Format32bppArgb)
                img = img.Clone(new Rectangle(0, 0, img.Width, img.Height),
                    PixelFormat.Format32bppArgb);
            Color trn = Color.FromArgb(0);
            for (int i = 0; i < img.Width; i++)
                for (int j = 0; j < img.Height; j++)
                    if (PixelDistance(img.GetPixel(i, j), color) < deg)
                        img.SetPixel(i, j, trn);
        }

        static public Bitmap LatticeBackground(in int width, in int height)
        {
            Bitmap bg = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    int x = i / 10;
                    int y = j / 10;
                    if ((x + y) % 2 == 0)
                        bg.SetPixel(i, j, Color.White);
                    else
                        bg.SetPixel(i, j, Color.LightGray);
                }
            return bg;
        }
    }
}
