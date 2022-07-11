using System.Threading;
using System.Windows.Forms;

namespace AutoCGAligner
{
    public partial class TestWin : Form
    {
        public TestWin()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
        }

        public CancellationTokenSource cts;

        private void TestWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }
    }
}
