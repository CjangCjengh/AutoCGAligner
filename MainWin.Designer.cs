namespace AutoCGAligner
{
    partial class MainWin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.CGBox = new System.Windows.Forms.PictureBox();
            this.openDiff = new System.Windows.Forms.Button();
            this.openBase = new System.Windows.Forms.Button();
            this.filePanel = new System.Windows.Forms.Panel();
            this.diffPath = new System.Windows.Forms.TextBox();
            this.basePath = new System.Windows.Forms.TextBox();
            this.alignButton = new System.Windows.Forms.Button();
            this.alignBox = new System.Windows.Forms.GroupBox();
            this.alignAdvanced = new System.Windows.Forms.Button();
            this.precisionMode = new System.Windows.Forms.RadioButton();
            this.speedMode = new System.Windows.Forms.RadioButton();
            this.fileBox = new System.Windows.Forms.GroupBox();
            this.alignResult = new System.Windows.Forms.GroupBox();
            this.XValue = new System.Windows.Forms.NumericUpDown();
            this.YValue = new System.Windows.Forms.NumericUpDown();
            this.fitValue = new System.Windows.Forms.TextBox();
            this.fitLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            this.alignTest = new System.Windows.Forms.GroupBox();
            this.testButton = new System.Windows.Forms.Button();
            this.rangeValue = new System.Windows.Forms.NumericUpDown();
            this.rangeLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.batchProcess = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.CGBox)).BeginInit();
            this.filePanel.SuspendLayout();
            this.alignBox.SuspendLayout();
            this.fileBox.SuspendLayout();
            this.alignResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YValue)).BeginInit();
            this.alignTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rangeValue)).BeginInit();
            this.SuspendLayout();
            // 
            // CGBox
            // 
            this.CGBox.BackColor = System.Drawing.Color.White;
            this.CGBox.Location = new System.Drawing.Point(578, 29);
            this.CGBox.Name = "CGBox";
            this.CGBox.Size = new System.Drawing.Size(512, 347);
            this.CGBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CGBox.TabIndex = 0;
            this.CGBox.TabStop = false;
            this.CGBox.Click += new System.EventHandler(this.CGBox_Click);
            // 
            // openDiff
            // 
            this.openDiff.Location = new System.Drawing.Point(3, 43);
            this.openDiff.Name = "openDiff";
            this.openDiff.Size = new System.Drawing.Size(171, 34);
            this.openDiff.TabIndex = 3;
            this.openDiff.Text = "打开CG（差分）";
            this.openDiff.UseVisualStyleBackColor = true;
            this.openDiff.Click += new System.EventHandler(this.OpenDiff_Click);
            // 
            // openBase
            // 
            this.openBase.Location = new System.Drawing.Point(3, 3);
            this.openBase.Name = "openBase";
            this.openBase.Size = new System.Drawing.Size(171, 34);
            this.openBase.TabIndex = 1;
            this.openBase.Text = "打开CG（背景）";
            this.openBase.UseVisualStyleBackColor = true;
            this.openBase.Click += new System.EventHandler(this.OpenBase_Click);
            // 
            // filePanel
            // 
            this.filePanel.Controls.Add(this.diffPath);
            this.filePanel.Controls.Add(this.basePath);
            this.filePanel.Controls.Add(this.openBase);
            this.filePanel.Controls.Add(this.openDiff);
            this.filePanel.Location = new System.Drawing.Point(6, 29);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(538, 82);
            this.filePanel.TabIndex = 5;
            // 
            // diffPath
            // 
            this.diffPath.Location = new System.Drawing.Point(180, 45);
            this.diffPath.Name = "diffPath";
            this.diffPath.Size = new System.Drawing.Size(355, 31);
            this.diffPath.TabIndex = 5;
            this.diffPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiffPath_KeyPress);
            // 
            // basePath
            // 
            this.basePath.Location = new System.Drawing.Point(180, 5);
            this.basePath.Name = "basePath";
            this.basePath.Size = new System.Drawing.Size(355, 31);
            this.basePath.TabIndex = 4;
            this.basePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BasePath_KeyPress);
            // 
            // alignButton
            // 
            this.alignButton.Location = new System.Drawing.Point(418, 27);
            this.alignButton.Name = "alignButton";
            this.alignButton.Size = new System.Drawing.Size(123, 34);
            this.alignButton.TabIndex = 6;
            this.alignButton.Text = "开始对齐";
            this.alignButton.UseVisualStyleBackColor = true;
            this.alignButton.Click += new System.EventHandler(this.AlignButton_Click);
            // 
            // alignBox
            // 
            this.alignBox.Controls.Add(this.alignAdvanced);
            this.alignBox.Controls.Add(this.precisionMode);
            this.alignBox.Controls.Add(this.speedMode);
            this.alignBox.Controls.Add(this.alignButton);
            this.alignBox.Enabled = false;
            this.alignBox.Location = new System.Drawing.Point(12, 140);
            this.alignBox.Name = "alignBox";
            this.alignBox.Size = new System.Drawing.Size(552, 77);
            this.alignBox.TabIndex = 7;
            this.alignBox.TabStop = false;
            this.alignBox.Text = "对齐";
            // 
            // alignAdvanced
            // 
            this.alignAdvanced.Location = new System.Drawing.Point(280, 27);
            this.alignAdvanced.Name = "alignAdvanced";
            this.alignAdvanced.Size = new System.Drawing.Size(123, 34);
            this.alignAdvanced.TabIndex = 8;
            this.alignAdvanced.Text = "高级设置";
            this.alignAdvanced.UseVisualStyleBackColor = true;
            this.alignAdvanced.Click += new System.EventHandler(this.AlignAdvanced_Click);
            // 
            // precisionMode
            // 
            this.precisionMode.AutoSize = true;
            this.precisionMode.Location = new System.Drawing.Point(142, 30);
            this.precisionMode.Name = "precisionMode";
            this.precisionMode.Size = new System.Drawing.Size(107, 28);
            this.precisionMode.TabIndex = 8;
            this.precisionMode.Text = "精确模式";
            this.precisionMode.UseVisualStyleBackColor = true;
            this.precisionMode.CheckedChanged += new System.EventHandler(this.PrecisionMode_CheckedChanged);
            // 
            // speedMode
            // 
            this.speedMode.AutoSize = true;
            this.speedMode.Checked = true;
            this.speedMode.Location = new System.Drawing.Point(14, 30);
            this.speedMode.Name = "speedMode";
            this.speedMode.Size = new System.Drawing.Size(107, 28);
            this.speedMode.TabIndex = 8;
            this.speedMode.TabStop = true;
            this.speedMode.Text = "快速模式";
            this.speedMode.UseVisualStyleBackColor = true;
            this.speedMode.CheckedChanged += new System.EventHandler(this.SpeedMode_CheckedChanged);
            // 
            // fileBox
            // 
            this.fileBox.Controls.Add(this.filePanel);
            this.fileBox.Location = new System.Drawing.Point(12, 17);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(552, 117);
            this.fileBox.TabIndex = 7;
            this.fileBox.TabStop = false;
            this.fileBox.Text = "图片文件";
            // 
            // alignResult
            // 
            this.alignResult.Controls.Add(this.XValue);
            this.alignResult.Controls.Add(this.YValue);
            this.alignResult.Controls.Add(this.fitValue);
            this.alignResult.Controls.Add(this.fitLabel);
            this.alignResult.Controls.Add(this.YLabel);
            this.alignResult.Controls.Add(this.XLabel);
            this.alignResult.Enabled = false;
            this.alignResult.Location = new System.Drawing.Point(12, 223);
            this.alignResult.Name = "alignResult";
            this.alignResult.Size = new System.Drawing.Size(202, 153);
            this.alignResult.TabIndex = 9;
            this.alignResult.TabStop = false;
            this.alignResult.Text = "对齐结果";
            // 
            // XValue
            // 
            this.XValue.Location = new System.Drawing.Point(101, 29);
            this.XValue.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.XValue.Name = "XValue";
            this.XValue.Size = new System.Drawing.Size(79, 31);
            this.XValue.TabIndex = 14;
            this.XValue.ValueChanged += new System.EventHandler(this.XYValueChanged);
            // 
            // YValue
            // 
            this.YValue.Location = new System.Drawing.Point(101, 66);
            this.YValue.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.YValue.Name = "YValue";
            this.YValue.Size = new System.Drawing.Size(79, 31);
            this.YValue.TabIndex = 13;
            this.YValue.ValueChanged += new System.EventHandler(this.XYValueChanged);
            // 
            // fitValue
            // 
            this.fitValue.Location = new System.Drawing.Point(101, 103);
            this.fitValue.Name = "fitValue";
            this.fitValue.ReadOnly = true;
            this.fitValue.Size = new System.Drawing.Size(79, 31);
            this.fitValue.TabIndex = 12;
            this.fitValue.Text = "0.00%";
            // 
            // fitLabel
            // 
            this.fitLabel.AutoSize = true;
            this.fitLabel.Location = new System.Drawing.Point(15, 106);
            this.fitLabel.Name = "fitLabel";
            this.fitLabel.Size = new System.Drawing.Size(64, 24);
            this.fitLabel.TabIndex = 10;
            this.fitLabel.Text = "吻合度";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(37, 69);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(21, 24);
            this.YLabel.TabIndex = 10;
            this.YLabel.Text = "Y";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(36, 32);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(22, 24);
            this.XLabel.TabIndex = 0;
            this.XLabel.Text = "X";
            // 
            // alignTest
            // 
            this.alignTest.Controls.Add(this.testButton);
            this.alignTest.Controls.Add(this.rangeValue);
            this.alignTest.Controls.Add(this.rangeLabel);
            this.alignTest.Enabled = false;
            this.alignTest.Location = new System.Drawing.Point(220, 223);
            this.alignTest.Name = "alignTest";
            this.alignTest.Size = new System.Drawing.Size(344, 77);
            this.alignTest.TabIndex = 11;
            this.alignTest.TabStop = false;
            this.alignTest.Text = "对齐检测";
            // 
            // testButton
            // 
            this.testButton.Enabled = false;
            this.testButton.Location = new System.Drawing.Point(210, 27);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(123, 34);
            this.testButton.TabIndex = 2;
            this.testButton.Text = "开始检测";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // rangeValue
            // 
            this.rangeValue.Location = new System.Drawing.Point(99, 29);
            this.rangeValue.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.rangeValue.Name = "rangeValue";
            this.rangeValue.Size = new System.Drawing.Size(91, 31);
            this.rangeValue.TabIndex = 1;
            this.rangeValue.ValueChanged += new System.EventHandler(this.RangeValue_ValueChanged);
            // 
            // rangeLabel
            // 
            this.rangeLabel.AutoSize = true;
            this.rangeLabel.Location = new System.Drawing.Point(13, 32);
            this.rangeLabel.Name = "rangeLabel";
            this.rangeLabel.Size = new System.Drawing.Size(82, 24);
            this.rangeLabel.TabIndex = 0;
            this.rangeLabel.Text = "检测范围";
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(237, 323);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(143, 34);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "保存结果";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // batchProcess
            // 
            this.batchProcess.Location = new System.Drawing.Point(401, 323);
            this.batchProcess.Name = "batchProcess";
            this.batchProcess.Size = new System.Drawing.Size(143, 34);
            this.batchProcess.TabIndex = 14;
            this.batchProcess.Text = "批量合成";
            this.batchProcess.UseVisualStyleBackColor = true;
            this.batchProcess.Click += new System.EventHandler(this.BatchProcess_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1105, 397);
            this.Controls.Add(this.batchProcess);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.alignTest);
            this.Controls.Add(this.alignResult);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.alignBox);
            this.Controls.Add(this.CGBox);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoCGAligner";
            ((System.ComponentModel.ISupportInitialize)(this.CGBox)).EndInit();
            this.filePanel.ResumeLayout(false);
            this.filePanel.PerformLayout();
            this.alignBox.ResumeLayout(false);
            this.alignBox.PerformLayout();
            this.fileBox.ResumeLayout(false);
            this.alignResult.ResumeLayout(false);
            this.alignResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YValue)).EndInit();
            this.alignTest.ResumeLayout(false);
            this.alignTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rangeValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CGBox;
        private System.Windows.Forms.Button openDiff;
        private System.Windows.Forms.Button openBase;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.TextBox basePath;
        private System.Windows.Forms.TextBox diffPath;
        private System.Windows.Forms.Button alignButton;
        private System.Windows.Forms.GroupBox alignBox;
        private System.Windows.Forms.GroupBox fileBox;
        private System.Windows.Forms.RadioButton speedMode;
        private System.Windows.Forms.RadioButton precisionMode;
        private System.Windows.Forms.Button alignAdvanced;
        private System.Windows.Forms.GroupBox alignResult;
        private System.Windows.Forms.Label fitLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.GroupBox alignTest;
        private System.Windows.Forms.TextBox fitValue;
        private System.Windows.Forms.NumericUpDown rangeValue;
        private System.Windows.Forms.Label rangeLabel;
        private System.Windows.Forms.NumericUpDown XValue;
        private System.Windows.Forms.NumericUpDown YValue;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button batchProcess;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

