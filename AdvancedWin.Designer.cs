namespace AutoCGAligner
{
    partial class AdvancedWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedWin));
            this.settings = new System.Windows.Forms.Panel();
            this.extScaleLabel = new System.Windows.Forms.Label();
            this.extScaleValue = new System.Windows.Forms.NumericUpDown();
            this.stepDivisorLabel = new System.Windows.Forms.Label();
            this.stepDivisorValue = new System.Windows.Forms.NumericUpDown();
            this.initStepLabel = new System.Windows.Forms.Label();
            this.initStepValue = new System.Windows.Forms.NumericUpDown();
            this.confirmButton = new System.Windows.Forms.Button();
            this.settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extScaleValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepDivisorValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initStepValue)).BeginInit();
            this.SuspendLayout();
            // 
            // settings
            // 
            this.settings.Controls.Add(this.extScaleLabel);
            this.settings.Controls.Add(this.extScaleValue);
            this.settings.Controls.Add(this.stepDivisorLabel);
            this.settings.Controls.Add(this.stepDivisorValue);
            this.settings.Controls.Add(this.initStepLabel);
            this.settings.Controls.Add(this.initStepValue);
            this.settings.Location = new System.Drawing.Point(12, 12);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(249, 113);
            this.settings.TabIndex = 0;
            // 
            // extScaleLabel
            // 
            this.extScaleLabel.AutoSize = true;
            this.extScaleLabel.Location = new System.Drawing.Point(23, 80);
            this.extScaleLabel.Name = "extScaleLabel";
            this.extScaleLabel.Size = new System.Drawing.Size(82, 24);
            this.extScaleLabel.TabIndex = 4;
            this.extScaleLabel.Text = "检测尺度";
            // 
            // extScaleValue
            // 
            this.extScaleValue.Location = new System.Drawing.Point(131, 77);
            this.extScaleValue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.extScaleValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.extScaleValue.Name = "extScaleValue";
            this.extScaleValue.Size = new System.Drawing.Size(95, 31);
            this.extScaleValue.TabIndex = 5;
            this.extScaleValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // stepDivisorLabel
            // 
            this.stepDivisorLabel.AutoSize = true;
            this.stepDivisorLabel.Location = new System.Drawing.Point(23, 43);
            this.stepDivisorLabel.Name = "stepDivisorLabel";
            this.stepDivisorLabel.Size = new System.Drawing.Size(82, 24);
            this.stepDivisorLabel.TabIndex = 2;
            this.stepDivisorLabel.Text = "缩减幅度";
            // 
            // stepDivisorValue
            // 
            this.stepDivisorValue.Location = new System.Drawing.Point(131, 40);
            this.stepDivisorValue.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.stepDivisorValue.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.stepDivisorValue.Name = "stepDivisorValue";
            this.stepDivisorValue.Size = new System.Drawing.Size(95, 31);
            this.stepDivisorValue.TabIndex = 3;
            this.stepDivisorValue.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.stepDivisorValue.ValueChanged += new System.EventHandler(this.StepDivisorValue_ValueChanged);
            // 
            // initStepLabel
            // 
            this.initStepLabel.AutoSize = true;
            this.initStepLabel.Location = new System.Drawing.Point(23, 6);
            this.initStepLabel.Name = "initStepLabel";
            this.initStepLabel.Size = new System.Drawing.Size(82, 24);
            this.initStepLabel.TabIndex = 0;
            this.initStepLabel.Text = "初始步长";
            // 
            // initStepValue
            // 
            this.initStepValue.Location = new System.Drawing.Point(131, 3);
            this.initStepValue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.initStepValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.initStepValue.Name = "initStepValue";
            this.initStepValue.Size = new System.Drawing.Size(95, 31);
            this.initStepValue.TabIndex = 1;
            this.initStepValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(92, 135);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(88, 36);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "确定";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // AdvancedWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(273, 186);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.settings);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "高级设置";
            this.settings.ResumeLayout(false);
            this.settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.extScaleValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepDivisorValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initStepValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel settings;
        private System.Windows.Forms.Label extScaleLabel;
        private System.Windows.Forms.NumericUpDown extScaleValue;
        private System.Windows.Forms.Label stepDivisorLabel;
        private System.Windows.Forms.NumericUpDown stepDivisorValue;
        private System.Windows.Forms.Label initStepLabel;
        private System.Windows.Forms.NumericUpDown initStepValue;
        private System.Windows.Forms.Button confirmButton;
    }
}