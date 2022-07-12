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
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "图片文件|*.png;*.bmp;*.jpg;*.jpeg;*.tif;*.tiff"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                basePath.Text = path;
                LoadFile(basePath.Text, true);
            }
        }

        private void OpenDiff_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "图片文件|*.png;*.bmp;*.jpg;*.jpeg;*.tif;*.tiff"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                diffPath.Text = path;
                LoadFile(diffPath.Text, false);
            }
        }

        private Bitmap baseImage;
        private Bitmap diffImage;
        private Bitmap resultImage;
        private Color[,] baseColors;
        private Color[,] borderColors;
        private PictureWin pictureWin;
        private int npixels;
        private int initStep = 20;
        private int stepDivisor = 10;
        private int extScale = 2;

        private void CheckImageSize()
        {
            if (baseImage.Width < diffImage.Width || baseImage.Height < diffImage.Height)
                MessageBox.Show("差分尺寸大于背景尺寸！", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                baseColors = Program.BitmapToColors(baseImage);
                borderColors = Program.GetBorder(diffImage, out npixels);
                alignBox.Enabled = true;
                alignResult.Enabled = true;
                alignTest.Enabled = true;
                XValue.Maximum = baseImage.Width - diffImage.Width;
                YValue.Maximum = baseImage.Height - diffImage.Height;
                long dis = Program.ImageDistance(baseColors, borderColors, 0, 0);
                fitValue.Text = Program.GetFit(dis, npixels).ToString("f2") + "%";
                ResetRange(0, 0);
            }
        }

        private void AlignAdvanced_Click(object sender, EventArgs e)
        {
            int widthDiff = baseImage.Width - diffImage.Width + 1;
            int heightDiff = baseImage.Height - diffImage.Height + 1;
            AdvancedWin aw = new AdvancedWin((initStep, stepDivisor, extScale) =>
            {
                this.initStep = initStep;
                this.stepDivisor = stepDivisor;
                this.extScale = extScale;
                if (speedMode.Checked)
                    speedMode.Checked = false;
                else if (precisionMode.Checked)
                    precisionMode.Checked = false;
            });
            aw.SetMaximum(widthDiff < heightDiff ? widthDiff : heightDiff,
                widthDiff > heightDiff ? widthDiff : heightDiff);
            aw.SetValue(initStep, stepDivisor, extScale);
            aw.ShowDialog(this);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "图片文件|*.png",
                FileName = "Untitled.png"
            };
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
                pictureWin = new PictureWin(resultImage);
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
                if (Program.AlignImage(baseColors, borderColors,
                    out int x, out int y, out long dis,
                    initStep, stepDivisor, extScale,
                    aw.progressBar, aw.cts, this,
                    (int tx, int ty, long tdis) =>
                    {
                        aw.XValue.Text = tx.ToString();
                        aw.YValue.Text = ty.ToString();
                        aw.fitValue.Text = Program.GetFit(tdis, npixels).ToString("f2") + "%";
                        ProduceResultImage(tx, ty);
                        Program.ShowImage(resultImage, aw.CGBox);
                    }))
                {
                    Invoke(new Action(() =>
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
                    }));
                    double fit = Program.GetFit(dis, npixels);
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
                    Invoke(new Action(() => alignResult.Enabled = true));
            });

            aw.ShowDialog(this);
        }

        private void AlignButton_Click(object sender, EventArgs e)
        {
            AlignImage(initStep, stepDivisor, extScale);
        }

        public void ProduceResultImage(int x = 0, int y = 0)
        {
            resultImage = new Bitmap(baseImage);
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
            long dis = Program.ImageDistance(baseColors, borderColors, x, y);
            fitValue.Text = Program.GetFit(dis, npixels).ToString("f2") + "%";
            ResetRange(x, y);
            ProduceResultImage(x, y);
            Program.ShowImage(resultImage, CGBox);
        }

        private void ResetRange(int x, int y)
        {
            rangeValue.Maximum = Math.Max(Math.Max(x, baseImage.Width - diffImage.Width - x),
                Math.Max(y, baseImage.Height - diffImage.Height - y));
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
                int rangeE = Math.Min(range, baseImage.Width - diffImage.Width - x);
                int rangeN = Math.Min(range, y);
                int rangeS = Math.Min(range, baseImage.Height - diffImage.Height - y);
                Bitmap rangeImg = new Bitmap(diffImage.Width + rangeE + rangeW, diffImage.Height + rangeN + rangeS);
                Bitmap tempImage = new Bitmap(baseImage);
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
            int xEnd = Math.Min(xValue + range, baseImage.Width - diffImage.Width);
            int yStart = Math.Max(yValue - range, 0);
            int yEnd = Math.Min(yValue + range, baseImage.Height - diffImage.Height);
            TestWin tw = new TestWin();
            tw.progressBar.Minimum = xStart;
            tw.progressBar.Maximum = xEnd;

            Task task = Task.Run(() =>
            {
                long minDis = (long)Program.MaxPixelDis * diffImage.Width * diffImage.Height;
                int xAxis = 0, yAxis = 0;
                if (Program.AlignImage(baseColors, borderColors,
                    xStart, xEnd, 1,
                    yStart, yEnd, 1,
                    ref minDis, ref xAxis, ref yAxis,
                    tw.progressBar, tw.cts, this))
                {
                    Invoke(new Action(() =>
                    {
                        XValue.Value = xAxis;
                        YValue.Value = yAxis;
                        ResetRange(xAxis, yAxis);
                        fitValue.Text = Program.GetFit(minDis, npixels).ToString("f2") + "%";
                        ProduceResultImage(xAxis, yAxis);
                        Program.ShowImage(resultImage, CGBox);
                        alignResult.Enabled = true;
                        tw.Close();
                    }));
                    MessageBox.Show($"检测结束！(吻合度：{fitValue.Text})", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    Invoke(new Action(() => alignResult.Enabled = true));
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
            baseImage = new Bitmap(path);
            ClearAll();
            if (diffImage == null)
                resultImage = new Bitmap(baseImage);
            else
            {
                CheckImageSize();
                ProduceResultImage();
            }
        }

        private void LoadDiffFile(string path)
        {
            diffImage = new Bitmap(path);
            CheckDiffImage();
            ClearAll();
            if (baseImage == null)
                resultImage = new Bitmap(diffImage);
            else
            {
                CheckImageSize();
                ProduceResultImage();
            }
        }

        private unsafe void CheckDiffImage()
        {
            if (Program.IsTransparent(diffImage, out Dictionary<Color, int> numOfColor))
                return;
            if (MessageBox.Show("当前差分图片拥有不透明背景，是否去除背景？", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Color bgColor = numOfColor.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
                ClearColorWin cbw = new ClearColorWin(diffImage, bgColor,
                    img => diffImage = new Bitmap(img));
                cbw.ShowDialog(this);
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
