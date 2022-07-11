using System;
using System.Windows.Forms;

namespace AutoCGAligner
{
    public partial class AdvancedWin : Form
    {
        public AdvancedWin()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (Owner.GetType() == typeof(MainWin))
            {
                MainWin owner = Owner as MainWin;
                owner.initStep = (int)initStepValue.Value;
                owner.stepDivisor = (int)stepDivisorValue.Value;
                owner.extScale = (int)extScaleValue.Value;
                if (owner.speedMode.Checked)
                    owner.speedMode.Checked = false;
                else if (owner.precisionMode.Checked)
                    owner.precisionMode.Checked = false;
            }
            else if (Owner.GetType() == typeof(BatchWin))
            {
                BatchWin owner = Owner as BatchWin;
                owner.initStep = (int)initStepValue.Value;
                owner.stepDivisor = (int)stepDivisorValue.Value;
                owner.extScale = (int)extScaleValue.Value;
                if (owner.speedMode.Checked)
                    owner.speedMode.Checked = false;
                else if (owner.precisionMode.Checked)
                    owner.precisionMode.Checked = false;
            }
            Close();
        }

        public void SetValue(int initStep, int stepDivisor, int extScale)
        {
            initStepValue.Value = Math.Min(initStep, initStepValue.Maximum);
            stepDivisorValue.Value = Math.Min(stepDivisor, stepDivisorValue.Maximum);
            extScaleValue.Value = Math.Min(extScale, extScaleValue.Maximum);
        }

        private void InitStepValue_ValueChanged(object sender, EventArgs e)
        {
            extScaleValue.Maximum = (initStepValue.Value - 1) / 2;
        }
    }
}
