using System.Threading;
using System.Windows.Forms;

namespace AutoCGAligner
{
    public partial class AlignWin : Form
    {
        public AlignWin()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
        }

        public CancellationTokenSource cts;

        private void AlignWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }
    }
}
