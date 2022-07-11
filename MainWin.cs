using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCGAligner
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
        }

        private void OpenBase_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.png;*.bmp;*.jpg;*.jpeg;*.tif;*.tiff";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                basePath.Text = path;
                LoadFile(basePath.Text, true);
            }
        }

        private void OpenDiff_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.png;*.bmp;*.jpg;*.jpeg;*.tif;*.tiff";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                diffPath.Text = path;
                LoadFile(diffPath.Text, false);
            }
        }

        private Image baseImage;
        private Image diffImage;
        public Image resultImage;
        private Bitmap baseImg;
        public Bitmap diffImg;
        private Color[,] border;
        private int npixels;
        public int initStep = 20;
        public int stepDivisor = 10;
        public int extScale = 2;

        private void CheckImageSize()
        {
            if (baseImage.Width < diffImage.Width || baseImage.Height < diffImage.Height)
                MessageBox.Show("差分尺寸大于背景尺寸！", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                baseImg = new Bitmap(baseImage);
                diffImg = new Bitmap(diffImage);
                border = Program.GetBorder(diffImg, out npixels);
                alignBox.Enabled = true;
                alignResult.Enabled = true;
                alignTest.Enabled = true;
                XValue.Maximum = baseImage.Width - diffImage.Width;
                YValue.Maximum = baseImage.Height - diffImage.Height;
            }
        }

        private void AlignAdvanced_Click(object sender, EventArgs e)
        {
            AdvancedWin aw = new AdvancedWin();
            int widthDiff = baseImage.Width - diffImage.Width + 1;
            int heightDiff = baseImage.Height - diffImage.Height + 1;
            aw.initStepValue.Maximum = widthDiff < heightDiff ? widthDiff : heightDiff;
            aw.stepDivisorValue.Maximum = widthDiff > heightDiff ? widthDiff : heightDiff;
            aw.SetValue(initStep, stepDivisor, extScale);
            aw.ShowDialog(this);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "图片文件|*.png";
            sfd.FileName = "Untitled.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                resultImage.Save(sfd.FileName);
                MessageBox.Show("保存成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CGBox_Click(object sender, EventArgs e)
        {
            if (resultImage != null)
            {
                if (pictureWin != null)
                    pictureWin.Close();
                pictureWin = new PictureWin();
                pictureWin.Size = resultImage.Size;
                pictureWin.BackgroundImage = resultImage;
                pictureWin.Show();
            }
        }

        private void ClearAll()
        {
            alignBox.Enabled = false;
            speedMode.Checked = true;
            alignResult.Enabled = false;
            XValue.Value = 0;
            YValue.Value = 0;
            fitValue.Text = "0.00%";
            alignTest.Enabled = false;
            rangeValue.Value = 0;
            testButton.Enabled = false;
            saveButton.Enabled = false;
        }

        private void AlignImage(int initStep, int stepDivisor, int extScale)
        {
            alignResult.Enabled = false;

            AlignWin aw = new AlignWin();
            Program.ShowImage(resultImage, aw.CGBox);

            Task task = Task.Run(() =>
            {
                if (Program.AlignImage(baseImg, border,
                    out int x, out int y, out double dis,
                    initStep, stepDivisor, extScale,
                    aw.progressBar, aw.cts, this,
                    (int tx, int ty, double tdis) =>
                    {
                        aw.XValue.Text = tx.ToString();
                        aw.YValue.Text = ty.ToString();
                        aw.fitValue.Text = ((1 - tdis / npixels /
                            Program.MaxPixelDis) * 100).ToString("f2") + "%";
                        ProduceResultImage(tx, ty);
                        Program.ShowImage(resultImage, aw.CGBox);
                    }))
                {
                    XValue.Value = x;
                    YValue.Value = y;
                    ResetRange(x, y);
                    fitValue.Text = aw.fitValue.Text;
                    ProduceResultImage(x, y);
                    Program.ShowImage(resultImage, CGBox);
                    alignResult.Enabled = true;
                    alignTest.Enabled = true;
                    rangeValue.Value = 0;
                    saveButton.Enabled = true;
                    aw.Close();
                    double fit = (1 - dis / npixels / Program.MaxPixelDis) * 100;
                    if (fit > 90)
                        MessageBox.Show($"对齐成功！(吻合度：{fitValue.Text})", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (!precisionMode.Checked)
                        MessageBox.Show($"对齐失败，请使用精确模式！(吻合度：{fitValue.Text})", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show($"对齐失败！(吻合度：{fitValue.Text})", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    alignResult.Enabled = true;
            });

            aw.ShowDialog(this);
        }

        private void AlignButton_Click(object sender, EventArgs e)
        {
            AlignImage(initStep, stepDivisor, extScale);
        }

        public void ProduceResultImage(int x = 0, int y = 0)
        {
            resultImage = (Image)baseImage.Clone();
            Graphics g = Graphics.FromImage(resultImage);
            g.DrawImage(diffImage, x, y);
            g.Dispose();
        }

        private void XYValueChanged(object sender, EventArgs e)
        {
            if (!alignResult.Enabled)
                return;
            int x = (int)XValue.Value;
            int y = (int)YValue.Value;
            double dis = 0;
            for (int i = 0; i < diffImg.Width; i++)
                for (int j = 0; j < diffImg.Height; j++)
                    if (border[i, j].A != 0)
                        dis += Program.PixelDistance(baseImg.GetPixel(x + i, y + j), border[i, j]);
            fitValue.Text = ((1 - dis / npixels / Program.MaxPixelDis) * 100).ToString("f2") + "%";
            ResetRange(x, y);
            ProduceResultImage(x, y);
            Program.ShowImage(resultImage, CGBox);
        }

        private void ResetRange(int x, int y)
        {
            rangeValue.Maximum = Math.Max(Math.Max(x, baseImg.Width - diffImg.Width - x),
                Math.Max(y, baseImg.Height - diffImg.Height - y));
            rangeValue.Value = 0;
        }

        private void RangeValue_ValueChanged(object sender, EventArgs e)
        {
            int range = (int)rangeValue.Value;
            if (range == 0)
            {
                testButton.Enabled = false;
                Program.ShowImage(resultImage, CGBox);
            }
            else
            {
                testButton.Enabled = true;
                int x = (int)XValue.Value;
                int y = (int)YValue.Value;
                int rangeW = Math.Min(range, x);
                int rangeE = Math.Min(range, baseImg.Width - diffImg.Width - x);
                int rangeN = Math.Min(range, y);
                int rangeS = Math.Min(range, baseImg.Height - diffImg.Height - y);
                Bitmap rangeImg = new Bitmap(diffImg.Width + rangeE + rangeW, diffImg.Height + rangeN + rangeS);
                Image tempImage = (Image)baseImage.Clone();
                Graphics g = Graphics.FromImage(rangeImg);
                g.Clear(Color.FromArgb(50, 0, 255, 0));
                g.DrawImage(diffImage, rangeW, rangeN);
                g = Graphics.FromImage(tempImage);
                g.DrawImage(rangeImg, x - rangeW, y - rangeN);
                Program.ShowImage(tempImage, CGBox);
            }
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            alignResult.Enabled = false;
            int range = (int)rangeValue.Value;
            int xValue = (int)XValue.Value;
            int yValue = (int)YValue.Value;
            int xStart = Math.Max(xValue - range, 0);
            int xEnd = Math.Min(xValue + range, baseImg.Width - diffImg.Width);
            int yStart = Math.Max(yValue - range, 0);
            int yEnd = Math.Min(yValue + range, baseImg.Height - diffImg.Height);
            TestWin tw = new TestWin();
            tw.progressBar.Minimum = xStart;
            tw.progressBar.Maximum = xEnd;

            Task task = Task.Run(() =>
            {
                double minDis = Program.MaxPixelDis * diffImg.Width * diffImg.Height;
                int xAxis = 0, yAxis = 0;
                if (Program.AlignImage(baseImg, border,
                    xStart, xEnd, 1,
                    yStart, yEnd, 1,
                    ref minDis, ref xAxis, ref yAxis,
                    tw.progressBar, tw.cts, this))
                {
                    XValue.Value = xAxis;
                    YValue.Value = yAxis;
                    ResetRange(xAxis, yAxis);
                    fitValue.Text = ((1 - minDis / npixels
                        / Program.MaxPixelDis) * 100).ToString("f2") + "%";
                    ProduceResultImage(xAxis, yAxis);
                    Program.ShowImage(resultImage, CGBox);
                    alignResult.Enabled = true;
                    tw.Close();
                    MessageBox.Show($"检测结束！(吻合度：{fitValue.Text})", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    alignResult.Enabled = true;
            });

            tw.ShowDialog(this);
            rangeValue.Value = 0;
        }

        private void BatchProcess_Click(object sender, EventArgs e)
        {
            BatchWin bw = new BatchWin();
            bw.ShowDialog(this);
        }

        private void BasePath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                LoadFile(basePath.Text, true);
        }

        private void DiffPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                LoadFile(diffPath.Text, false);
        }

        private void LoadFile(string path, bool isBaseFile)
        {
            try
            {
                if (isBaseFile)
                    LoadBaseFile(path);
                else
                    LoadDiffFile(path);
                Program.ShowImage(resultImage, CGBox);
                saveButton.Enabled = true;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("文件不存在！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("图片读取失败！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBaseFile(string path)
        {
            baseImage = Image.FromFile(path);
            ClearAll();
            if (diffImage == null)
                resultImage = (Image)baseImage.Clone();
            else
            {
                CheckImageSize();
                ProduceResultImage();
            }
        }

        private void LoadDiffFile(string path)
        {
            diffImage = Image.FromFile(path);
            CheckDiffImage();
            ClearAll();
            if (baseImage == null)
                resultImage = (Image)diffImage.Clone();
            else
            {
                CheckImageSize();
                ProduceResultImage();
            }
        }

        private void CheckDiffImage()
        {
            diffImg = new Bitmap(diffImage);
            Dictionary<Color, int> colorList = new Dictionary<Color, int>();
            for (int i = 0; i < diffImg.Width; i++)
                for (int j = 0; j < diffImg.Height; j++)
                {
                    if (diffImg.GetPixel(i, j).A == 0)
                        return;
                    if (!colorList.ContainsKey(diffImg.GetPixel(i, j)))
                        colorList.Add(diffImg.GetPixel(i, j), 1);
                    else
                        colorList[diffImg.GetPixel(i, j)]++;
                }
            if (MessageBox.Show("当前差分图片拥有不透明背景，是否去除背景？", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Color bgColor = colorList.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
                ClearBackgroundWin clr = new ClearBackgroundWin(bgColor);
                clr.ShowDialog(this);
                diffImage = diffImg;
            }
        }

        private void SpeedMode_CheckedChanged(object sender, EventArgs e)
        {
            if (speedMode.Checked)
            {
                initStep = 20;
                stepDivisor = 10;
                extScale = 2;
            }
        }

        private void PrecisionMode_CheckedChanged(object sender, EventArgs e)
        {
            if (precisionMode.Checked)
            {
                initStep = 10;
                stepDivisor = 5;
                extScale = 1;
            }
        }
    }
}
