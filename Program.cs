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
        public static int MaxPixelDis = 255 * 255 * 3;

        /// <summary>
        /// 将图片等比例拉伸后展示在框中
        /// </summary>
        /// <param name="img">要展示的图片</param>
        /// <param name="box">展示图片的框</param>
        public static void ShowImage(Image img, PictureBox box)
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
        /// <returns>距离</returns>
        public static int PixelDistance(Color p1, Color p2)
        {
            int R = p1.R - p2.R;
            int G = p1.G - p2.G;
            int B = p1.B - p2.B;
            return R * R + G * G + B * B;
        }

        /// <summary>
        /// 获取图片边缘的像素点
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="npixels">边缘像素点的数量</param>
        /// <returns>边缘像素点的数组</returns>
        public static unsafe Color[,] GetBorder(Bitmap img, out int npixels)
        {
            npixels = 0;
            Color[,] borderColors = new Color[img.Width, img.Height];
            BitmapData imgData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* imgRow = (byte*)imgData.Scan0.ToPointer();
            int bpp = 4;
            int stride = imgData.Stride;
            for (int y = 0; y < img.Height; y++)
            {
                int bi = 0, gi = 1, ri = 2, ai = 3;
                for (int x = 0; x < img.Width; x++)
                {
                    if (imgRow[ai] == 0)
                        borderColors[x, y] = Color.FromArgb(0);
                    else if ((x - 1 >= 0 && imgRow[ai - bpp] != 0) &&
                        (x + 1 < img.Width && imgRow[ai + bpp] != 0) &&
                        (y - 1 >= 0 && (imgRow - stride)[ai] != 0) &&
                        (y + 1 < img.Height && (imgRow + stride)[ai] != 0))
                        borderColors[x, y] = Color.FromArgb(0);
                    else
                    {
                        borderColors[x, y] = Color.FromArgb(imgRow[ai], imgRow[ri], imgRow[gi], imgRow[bi]);
                        npixels++;
                    }
                    ai += bpp;
                    bi += bpp;
                    gi += bpp;
                    ri += bpp;
                }
                imgRow += stride;
            }
            img.UnlockBits(imgData);
            return borderColors;
        }

        public static bool AlignImage(Color[,] baseColors, Color[,] borderColors,
            out int xAxis, out int yAxis, out long minDis,
            in int initStep, in int stepDivisor, in int extScale,
            ProgressBar bar, CancellationTokenSource cts,
            Form owner, Action<int, int, long> display)
        {
            int width = borderColors.GetLength(0);
            int height = borderColors.GetLength(1);
            minDis = (long)MaxPixelDis * width * height;
            xAxis = 0;
            yAxis = 0;
            int xRange = baseColors.GetLength(0) - width;
            int yRange = baseColors.GetLength(1) - height;
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

                if (!AlignImage(baseColors, borderColors,
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

        public static bool AlignImage(in Color[,] baseColors, in Color[,] borderColors,
            in int xStart, in int xEnd, in int xStep,
            in int yStart, in int yEnd, in int yStep,
            ref long minDis, ref int xAxis, ref int yAxis,
            ProgressBar bar, in CancellationTokenSource cts, Form owner)
        {
            int width = borderColors.GetLength(0);
            int height = borderColors.GetLength(1);
            for (int i = xStart; i <= xEnd; i += xStep)
            {
                owner.Invoke(new Action(() => bar.Value = i));
                for (int j = yStart; j <= yEnd; j += yStep)
                {
                    if (cts.IsCancellationRequested)
                        return false;
                    long dis = 0;
                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                            if (borderColors[x, y].A != 0)
                                dis += PixelDistance(baseColors[i + x, j + y], borderColors[x, y]);
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

        public static unsafe bool IsTransparent(in Bitmap img,
            out Dictionary<Color, int> numOfColor)
        {
            numOfColor = new Dictionary<Color, int>();
            BitmapData imgData = img.LockBits(new Rectangle(0, 0,
                img.Width, img.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* row = (byte*)imgData.Scan0.ToPointer();
            int bpp = 4;
            int stride = imgData.Stride;
            for (int y = 0; y < img.Height; y++)
            {
                int bi = 0, gi = 1, ri = 2, ai = 3;
                for (int x = 0; x < img.Width; x++)
                {
                    Color color = Color.FromArgb(row[ai], row[ri], row[gi], row[bi]);
                    if (color.A == 0)
                    {
                        img.UnlockBits(imgData);
                        return true;
                    }
                    if (!numOfColor.ContainsKey(color))
                        numOfColor.Add(color, 1);
                    else
                        numOfColor[color]++;
                    ai += bpp;
                    bi += bpp;
                    gi += bpp;
                    ri += bpp;
                }
                row += stride;
            }
            img.UnlockBits(imgData);
            return false;
        }

        public static unsafe Dictionary<Color, int> CountColors(in Bitmap img)
        {
            Dictionary<Color, int> numOfColor = new Dictionary<Color, int>();
            BitmapData imgData = img.LockBits(new Rectangle(0, 0,
                img.Width, img.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* row = (byte*)imgData.Scan0.ToPointer();
            int bpp = 4;
            int stride = imgData.Stride;
            for (int y = 0; y < img.Height; y++)
            {
                int bi = 0, gi = 1, ri = 2, ai = 3;
                for (int x = 0; x < img.Width; x++)
                {
                    Color color = Color.FromArgb(row[ai], row[ri], row[gi], row[bi]);
                    if (!numOfColor.ContainsKey(color))
                        numOfColor.Add(color, 1);
                    else
                        numOfColor[color]++;
                    ai += bpp;
                    bi += bpp;
                    gi += bpp;
                    ri += bpp;
                }
                row += stride;
            }
            img.UnlockBits(imgData);
            return numOfColor;
        }

        public static unsafe void ClearColor(ref Bitmap img, Color color, int distance)
        {
            if (img.PixelFormat != PixelFormat.Format32bppArgb)
                img = img.Clone(new Rectangle(0, 0, img.Width, img.Height),
                    PixelFormat.Format32bppArgb);
            BitmapData imgData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            byte* row = (byte*)imgData.Scan0.ToPointer();
            int bpp = 4;
            int stride = imgData.Stride;
            for (int y = 0; y < img.Height; y++)
            {
                int bi = 0, gi = 1, ri = 2, ai = 3;
                for (int x = 0; x < img.Width; x++)
                {
                    int a = row[ai], r = row[ri], b = row[bi], g = row[gi];
                    if (r * r + b * b + g * g < distance)
                    {
                        row[ri] = row[gi] = row[bi] = row[ai] = 0;
                    }
                    ai += bpp;
                    bi += bpp;
                    gi += bpp;
                    ri += bpp;
                }
                row += stride;
            }
            img.UnlockBits(imgData);
        }

        public static unsafe Bitmap LatticeImage(in int width, in int height)
        {
            Bitmap bg = new Bitmap(width, height);
            BitmapData bgData = bg.LockBits(new Rectangle(0, 0, width, height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte* row = (byte*)bgData.Scan0.ToPointer();
            int bpp = 3;
            int stride = bgData.Stride;
            for (int y = 0; y < height; y++)
            {
                int bi = 0, gi = 1, ri = 2;
                for (int x = 0; x < width; x++)
                {
                    if ((x / 10 + y / 10) % 2 == 0)
                        row[ri] = row[gi] = row[bi] = 255;
                    else
                        row[ri] = row[gi] = row[bi] = 211;
                    bi += bpp;
                    gi += bpp;
                    ri += bpp;
                }
                row += stride;
            }
            bg.UnlockBits(bgData);
            return bg;
        }

        public static unsafe Color[,] BitmapToColors(Bitmap img)
        {
            Color[,] imgColors = new Color[img.Width, img.Height];
            BitmapData imgData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* imgRow = (byte*)imgData.Scan0.ToPointer();
            int bpp = 4;
            int stride = imgData.Stride;
            for (int y = 0; y < img.Height; y++)
            {
                int bi = 0, gi = 1, ri = 2, ai = 3;
                for (int x = 0; x < img.Width; x++)
                {
                    imgColors[x, y] = Color.FromArgb(imgRow[ai], imgRow[ri], imgRow[gi], imgRow[bi]);
                    ai += bpp;
                    bi += bpp;
                    gi += bpp;
                    ri += bpp;
                }
                imgRow += stride;
            }
            img.UnlockBits(imgData);
            return imgColors;
        }

        public static long ImageDistance(Color[,] img1, Color[,] img2, int x, int y)
        {
            int width = img2.GetLength(0);
            int height = img2.GetLength(1);
            long dis = 0;
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    if (img2[i, j].A != 0)
                        dis += PixelDistance(img1[x + i, y + j], img2[i, j]);
            return dis;
        }

        public static double GetFit(long distance, int npixels)
        {
            return (1 - Math.Sqrt((double)distance / npixels / MaxPixelDis)) * 100;
        }
    }
}
