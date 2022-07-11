namespace AutoCGAligner
{
    partial class BatchAlignWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchAlignWin));
            this.baseBar = new System.Windows.Forms.ProgressBar();
            this.baseProgress = new System.Windows.Forms.Label();
            this.diffProgress = new System.Windows.Forms.Label();
            this.diffBar = new System.Windows.Forms.ProgressBar();
            this.alignProgress = new System.Windows.Forms.Label();
            this.alignBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // baseBar
            // 
            this.baseBar.Location = new System.Drawing.Point(12, 45);
            this.baseBar.Name = "baseBar";
            this.baseBar.Size = new System.Drawing.Size(640, 28);
            this.baseBar.TabIndex = 17;
            // 
            // baseProgress
            // 
            this.baseProgress.AutoSize = true;
            this.baseProgress.Location = new System.Drawing.Point(30, 18);
            this.baseProgress.Name = "baseProgress";
            this.baseProgress.Size = new System.Drawing.Size(50, 24);
            this.baseProgress.TabIndex = 18;
            this.baseProgress.Text = "0 / 0";
            // 
            // diffProgress
            // 
            this.diffProgress.AutoSize = true;
            this.diffProgress.Location = new System.Drawing.Point(30, 76);
            this.diffProgress.Name = "diffProgress";
            this.diffProgress.Size = new System.Drawing.Size(50, 24);
            this.diffProgress.TabIndex = 20;
            this.diffProgress.Text = "0 / 0";
            // 
            // diffBar
            // 
            this.diffBar.Location = new System.Drawing.Point(12, 103);
            this.diffBar.Name = "diffBar";
            this.diffBar.Size = new System.Drawing.Size(640, 28);
            this.diffBar.TabIndex = 19;
            // 
            // alignProgress
            // 
            this.alignProgress.AutoSize = true;
            this.alignProgress.Location = new System.Drawing.Point(30, 134);
            this.alignProgress.Name = "alignProgress";
            this.alignProgress.Size = new System.Drawing.Size(63, 24);
            this.alignProgress.TabIndex = 22;
            this.alignProgress.Text = "0.00%";
            // 
            // alignBar
            // 
            this.alignBar.Location = new System.Drawing.Point(12, 161);
            this.alignBar.Name = "alignBar";
            this.alignBar.Size = new System.Drawing.Size(640, 28);
            this.alignBar.TabIndex = 21;
            // 
            // BatchAlignWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(664, 212);
            this.Controls.Add(this.alignProgress);
            this.Controls.Add(this.alignBar);
            this.Controls.Add(this.diffProgress);
            this.Controls.Add(this.diffBar);
            this.Controls.Add(this.baseProgress);
            this.Controls.Add(this.baseBar);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchAlignWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正在合成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BatchAlignWin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar baseBar;
        public System.Windows.Forms.Label baseProgress;
        public System.Windows.Forms.Label diffProgress;
        public System.Windows.Forms.ProgressBar diffBar;
        public System.Windows.Forms.Label alignProgress;
        public System.Windows.Forms.ProgressBar alignBar;
    }
}