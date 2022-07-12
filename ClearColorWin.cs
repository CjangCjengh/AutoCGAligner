using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoCGAligner
{
    public partial class ClearColorWin : Form
    {
        public ClearColorWin(Image image, Color color, Action<Image> callback)
        {
            InitializeComponent();
            this.color = color;
            this.image = new Bitmap(image);
            this.callback = callback;
            CGBox.BackgroundImage = Program.LatticeImage(CGBox.Width, CGBox.Height);
        }

        private readonly Color color;
        private readonly Bitmap image;
        private Bitmap tempImage;
        private readonly Action<Image> callback;
        private void ClearDegree_ValueChanged(object sender, EventArgs e)
        {
            double ratio = (double)degreeValue.Value / (double)degreeValue.Maximum;
            ClearColor((int)(ratio * ratio * Program.MaxPixelDis));
        }

        public void ClearColor(int distance)
        {
            tempImage = new Bitmap(image);
            Program.ClearColor(ref tempImage, color, distance);
            Program.ShowImage(tempImage, CGBox);
        }

        private void ClearColorWin_Load(object sender, EventArgs e)
        {
            ClearColor(Program.MaxPixelDis / 100);
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            callback(tempImage);
            Close();
        }
    }
}
