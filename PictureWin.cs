using System.Drawing;
using System.Windows.Forms;

namespace AutoCGAligner
{
    public partial class PictureWin : Form
    {
        public PictureWin(Image img)
        {
            InitializeComponent();
            Size = img.Size;
            BackgroundImage = img;
        }
    }
}
