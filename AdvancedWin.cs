using System;
using System.Windows.Forms;

namespace AutoCGAligner
{
    public partial class AdvancedWin : Form
    {
        public AdvancedWin(Action<int, int, int> callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private readonly Action<int, int, int> callback;

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            callback((int)initStepValue.Value,
                (int)stepDivisorValue.Value,
                (int)extScaleValue.Value);
            Close();
        }

        public void SetValue(int initStep, int stepDivisor, int extScale)
        {
            initStepValue.Value = Math.Min(initStep, initStepValue.Maximum);
            stepDivisorValue.Value = Math.Min(stepDivisor, stepDivisorValue.Maximum);
            extScaleValue.Value = Math.Min(extScale, extScaleValue.Maximum);
        }

        public void SetMaximum(int initStepMax, int stepDivisorMax)
        {
            initStepValue.Maximum = initStepMax;
            stepDivisorValue.Maximum = stepDivisorMax;
        }

        private void StepDivisorValue_ValueChanged(object sender, EventArgs e)
        {
            extScaleValue.Maximum = ((int)stepDivisorValue.Value-1) / 2;
        }
    }
}
