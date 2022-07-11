using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCGAligner
{
    public partial class BatchWin : Form
    {
        public BatchWin()
        {
            InitializeComponent();
            baseFullPath = new Dictionary<string, string>();
            diffFullPath = new Dictionary<string, Dictionary<string, string>>();
            baseToDiff = new Dictionary<string, ArrayList>();
        }

        public int initStep = 20;
        public int stepDivisor = 10;
        public int extScale = 2;
        private readonly Dictionary<string, string> baseFullPath;
        private readonly Dictionary<string, Dictionary<string, string>> diffFullPath;
        private readonly Dictionary<string, ArrayList> baseToDiff;
        private Bitmap baseImg;
        private Bitmap diffImg;
        private Image resultImg;

        private void ClearLabel_CheckedChanged(object sender, EventArgs e)
        {
            degreeLabel.Enabled = !degreeLabel.Enabled;
            degreeValue.Enabled = !degreeValue.Enabled;
        }

        private void AlignAdvanced_Click(object sender, EventArgs e)
        {
            AdvancedWin aw = new AdvancedWin();
            aw.initStepValue.Maximum = 50;
            aw.stepDivisorValue.Maximum = 30;
            aw.SetValue(initStep, stepDivisor, extScale);
            aw.ShowDialog(this);
        }

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog(this) == DialogResult.OK)
                savePath.Text = fbd.SelectedPath;
        }
        private bool CreateFolder(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请指定保存路径！", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!Directory.Exists(path))
            {
                if (MessageBox.Show("当前文件夹不存在，是否新建文件夹？", "",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information) == DialogResult.OK)
                {
                    string[] folders = path.Split('\\');
                    string fpath = "";
                    foreach (string folder in folders)
                    {
                        fpath += folder + "/";
                        if (Directory.Exists(fpath))
                            continue;
                        try
                        {
                            Directory.CreateDirectory(fpath);
                        }
                        catch
                        {
                            MessageBox.Show("路径名称不合法！", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                if (!Directory.Exists(path))
                {
                    MessageBox.Show("新建文件夹失败！", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            return true;
        }

        private void SavePath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                CreateFolder(savePath.Text);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (!CreateFolder(savePath.Text))
                return;
            BatchAlignWin baw = new BatchAlignWin();
            baw.baseBar.Maximum = baseFullPath.Count;
            baw.baseProgress.Text = $"0 / {baw.baseBar.Maximum}";

            Task t1 = Task.Run(() =>
            {
                foreach (string bpath in baseFullPath.Values)
                {
                    string baseName = Path.GetFileName(bpath);
                    try
                    {
                        baseImg = (Bitmap)Image.FromFile(bpath);
                    }
                    catch
                    {
                        if (MessageBox.Show($"{baseName}读取失败，是否跳过该文件？", "",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.Yes)
                            continue;
                        else
                        {
                            baw.Close();
                            return;
                        }
                    }

                    Invoke(new Action(() =>
                    {
                        baw.diffBar.Value = 0;
                        baw.diffBar.Maximum = diffFullPath[baseName].Count;
                        baw.diffProgress.Text = $"0 / {baw.diffBar.Maximum}";
                    }));

                    foreach (string dpath in diffFullPath[baseName].Values)
                    {
                        string diffName = Path.GetFileName(dpath);
                        try
                        {
                            diffImg = (Bitmap)Image.FromFile(dpath);
                        }
                        catch
                        {
                            if (MessageBox.Show($"{diffName}读取失败，是否跳过该文件？", "",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
                                continue;
                            else
                            {
                                baw.Close();
                                return;
                            }
                        }

                        if (clearLabel.Checked)
                        {
                            Dictionary<Color, int> colorList = Program.CountColors(diffImg);
                            Color bgColor = colorList.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
                            Program.ClearBackground(ref diffImg, bgColor, (int)degreeValue.Value);
                        }

                        Color[,] border = Program.GetBorder(diffImg, out int npixels);
                        if (!Program.AlignImage(baseImg, border,
                            out int x, out int y, out double dis,
                            initStep, stepDivisor, extScale,
                            baw.alignBar, baw.cts, this, null))
                            return;
                        resultImg = (Image)baseImg.Clone();
                        Graphics g = Graphics.FromImage(resultImg);
                        g.DrawImage(diffImg, x, y);
                        resultImg.Save(Path.Combine(savePath.Text,
                            Path.GetFileNameWithoutExtension(baseName) + "+" +
                            Path.GetFileNameWithoutExtension(diffName) + ".png"));

                        Invoke(new Action(() =>
                        {
                            baw.diffProgress.Text = $"{++baw.diffBar.Value} / {baw.diffBar.Maximum}";
                        }));
                    }

                    Invoke(new Action(() =>
                    {
                        baw.baseProgress.Text = $"{++baw.baseBar.Value} / {baw.baseBar.Maximum}";
                    }));
                }

                Invoke(new Action(() =>
                {
                    baw.Close();
                }));

                MessageBox.Show("合成结束！", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            });

            Task t2 = Task.Run(() =>
            {
                while (!baw.cts.IsCancellationRequested)
                {
                    Thread.Sleep(100);
                    Invoke(new Action(() =>
                    {
                        baw.alignProgress.Text = ((double)baw.alignBar.Value /
                        baw.alignBar.Maximum * 100).ToString("f2") + "%";
                    }));
                }
            });

            baw.ShowDialog(this);
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

        private void BaseFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            diffFiles.Items.Clear();
            if (!string.IsNullOrEmpty(baseFiles.Text))
                foreach (string file in baseToDiff[baseFiles.Text])
                    diffFiles.Items.Add(file);
        }

        private void BaseFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "图片文件|*.png;*.bmp;*.jpg;*.jpeg;*.tif;*.tiff";
            if (ofd.ShowDialog() == DialogResult.OK)
                LoadFiles(ofd.FileNames, true);
        }

        private void DiffFiles_DoubleClick(object sender, EventArgs e)
        {
            if (!CheckBaseSelected())
                return;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "图片文件|*.png;*.bmp;*.jpg;*.jpeg;*.tif;*.tiff";
            if (ofd.ShowDialog() == DialogResult.OK)
                LoadFiles(ofd.FileNames, false);
        }

        private void FilesDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void BaseFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                LoadFiles((string[])e.Data.GetData(DataFormats.FileDrop), true);
        }

        private void DiffFiles_DragDrop(object sender, DragEventArgs e)
        {
            if (!CheckBaseSelected())
                return;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                LoadFiles((string[])e.Data.GetData(DataFormats.FileDrop), false);
        }

        private void LoadFiles(string[] paths, bool isBaseFiles)
        {
            foreach (string path in paths)
                if (File.Exists(path))
                    if (isBaseFiles)
                        LoadBaseFile(path);
                    else
                        LoadDiffFile(path);
                else if (Directory.Exists(path))
                    if (MessageBox.Show($"是否读取文件夹{path}中的所有文件？", "",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        DirectoryInfo info = new DirectoryInfo(path);
                        foreach (FileInfo file in info.GetFiles())
                            if (isBaseFiles)
                                LoadBaseFile(file.FullName);
                            else
                                LoadDiffFile(file.FullName);
                    }
            CheckFiles();
        }

        private void LoadBaseFile(string path)
        {
            string fileName = Path.GetFileName(path);
            if (!baseFiles.Items.Contains(fileName))
            {
                baseFullPath.Add(fileName, path);
                diffFullPath.Add(fileName, new Dictionary<string, string>());
                baseToDiff.Add(fileName, new ArrayList());
                baseFiles.Items.Add(fileName);
            }
        }

        private void LoadDiffFile(string path)
        {
            string fileName = Path.GetFileName(path);
            if (!diffFiles.Items.Contains(fileName))
            {
                string baseName = baseFiles.Text;
                diffFullPath[baseName].Add(fileName, path);
                baseToDiff[baseName].Add(fileName);
                diffFiles.Items.Add(fileName);
            }
        }

        private bool CheckBaseSelected()
        {
            if (string.IsNullOrEmpty(baseFiles.Text))
            {
                MessageBox.Show("请先选择对应的CG背景！", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void BaseFiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            string baseName = baseFiles.Text;
            if (!string.IsNullOrEmpty(baseName) && e.KeyChar == '\b')
            {
                baseFullPath.Remove(baseName);
                diffFullPath.Remove(baseName);
                baseToDiff.Remove(baseName);
                baseFiles.Items.Remove(baseName);
                CheckFiles();
            }
        }

        private void DiffFiles_KeyPress(object sender, KeyPressEventArgs e)
        {
            string diffName = diffFiles.Text;
            Console.WriteLine(baseFiles.Text + diffName);
            if (!string.IsNullOrEmpty(diffName) && e.KeyChar == '\b')
            {
                string baseName = baseFiles.Text;
                diffFullPath[baseName].Remove(diffName);
                baseToDiff[baseName].Remove(diffName);
                diffFiles.Items.Remove(diffName);
                CheckFiles();
            }
        }

        private void CheckFiles()
        {
            confirmButton.Enabled = false;
            if (baseToDiff.Count > 0)
            {
                foreach (string baseFile in baseToDiff.Keys)
                    if (baseToDiff[baseFile].Count == 0)
                        return;
                confirmButton.Enabled = true;
            }
        }

        private void BatchWin_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("添加图片：双击白框或直接拖动\n" +
                "移除图片：选中后按backspace", "帮助",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
