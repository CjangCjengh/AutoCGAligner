using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCGAligner
{
    public partial class ClearBackgroundWin : Form
    {
        public ClearBackgroundWin(Color bgColor)
        {
            InitializeComponent();
            this.bgColor = bgColor;
            cts = new CancellationTokenSource();
            CGBox.BackgroundImage = Program.LatticeBackground(CGBox.Width, CGBox.Height);
        }

        private readonly Color bgColor;
        private Bitmap tempImg;
        private readonly CancellationTokenSource cts;
        private Task task;
        private void ClearDegree_ValueChanged(object sender, EventArgs e)
        {
            if (task == null)
                task = Task.Run(() => ClearBackground((int)clearDegree.Value));
            else
                task.ContinueWith(t => ClearBackground((int)clearDegree.Value));
        }

        public void ClearBackground(int deg)
        {
            if (cts.IsCancellationRequested)
                return;
            tempImg = (Bitmap)((MainWin)Owner).diffImg.Clone();
            Invoke(new Action(() => Program.ClearBackground(ref tempImg, bgColor, deg)));
            Program.ShowImage(tempImg, CGBox);
        }

        private void ClearBgWin_Load(object sender, EventArgs e)
        {
            ClearBackground(50);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            ((MainWin)Owner).diffImg = tempImg;
            Close();
        }

        private void ClearBgWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }
    }
}
