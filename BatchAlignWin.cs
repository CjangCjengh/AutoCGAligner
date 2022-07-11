using System.Threading;
using System.Windows.Forms;

namespace AutoCGAligner
{
    public partial class BatchAlignWin : Form
    {
        public BatchAlignWin()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
        }

        public CancellationTokenSource cts;

        private void BatchAlignWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }
    }
}
