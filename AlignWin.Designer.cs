namespace AutoCGAligner
{
    partial class AlignWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlignWin));
            this.fitValue = new System.Windows.Forms.TextBox();
            this.fitLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            this.XValue = new System.Windows.Forms.TextBox();
            this.YValue = new System.Windows.Forms.TextBox();
            this.CGBox = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.CGBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fitValue
            // 
            this.fitValue.Location = new System.Drawing.Point(538, 24);
            this.fitValue.Name = "fitValue";
            this.fitValue.ReadOnly = true;
            this.fitValue.Size = new System.Drawing.Size(79, 31);
            this.fitValue.TabIndex = 12;
            this.fitValue.Text = "0.00%";
            // 
            // fitLabel
            // 
            this.fitLabel.AutoSize = true;
            this.fitLabel.Location = new System.Drawing.Point(468, 27);
            this.fitLabel.Name = "fitLabel";
            this.fitLabel.Size = new System.Drawing.Size(64, 24);
            this.fitLabel.TabIndex = 10;
            this.fitLabel.Text = "吻合度";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(263, 27);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(21, 24);
            this.YLabel.TabIndex = 10;
            this.YLabel.Text = "Y";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(44, 27);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(22, 24);
            this.XLabel.TabIndex = 0;
            this.XLabel.Text = "X";
            // 
            // XValue
            // 
            this.XValue.Location = new System.Drawing.Point(72, 24);
            this.XValue.Name = "XValue";
            this.XValue.ReadOnly = true;
            this.XValue.Size = new System.Drawing.Size(79, 31);
            this.XValue.TabIndex = 13;
            this.XValue.Text = "0";
            // 
            // YValue
            // 
            this.YValue.Location = new System.Drawing.Point(290, 24);
            this.YValue.Name = "YValue";
            this.YValue.ReadOnly = true;
            this.YValue.Size = new System.Drawing.Size(79, 31);
            this.YValue.TabIndex = 14;
            this.YValue.Text = "0";
            // 
            // CGBox
            // 
            this.CGBox.BackColor = System.Drawing.Color.White;
            this.CGBox.Location = new System.Drawing.Point(12, 131);
            this.CGBox.Name = "CGBox";
            this.CGBox.Size = new System.Drawing.Size(640, 360);
            this.CGBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CGBox.TabIndex = 15;
            this.CGBox.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 79);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(640, 28);
            this.progressBar.TabIndex = 16;
            // 
            // AlignWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(664, 514);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.CGBox);
            this.Controls.Add(this.YValue);
            this.Controls.Add(this.XValue);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.fitLabel);
            this.Controls.Add(this.fitValue);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlignWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正在对齐";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlignWin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CGBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox fitValue;
        private System.Windows.Forms.Label fitLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Label XLabel;
        public System.Windows.Forms.TextBox XValue;
        public System.Windows.Forms.TextBox YValue;
        public System.Windows.Forms.PictureBox CGBox;
        public System.Windows.Forms.ProgressBar progressBar;
    }
}