namespace AutoCGAligner
{
    partial class ClearBackgroundWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClearBackgroundWin));
            this.CGBox = new System.Windows.Forms.PictureBox();
            this.degreeLabel = new System.Windows.Forms.Label();
            this.clearDegree = new System.Windows.Forms.NumericUpDown();
            this.confirmButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CGBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearDegree)).BeginInit();
            this.SuspendLayout();
            // 
            // CGBox
            // 
            this.CGBox.BackColor = System.Drawing.Color.White;
            this.CGBox.Location = new System.Drawing.Point(12, 76);
            this.CGBox.Name = "CGBox";
            this.CGBox.Size = new System.Drawing.Size(640, 360);
            this.CGBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CGBox.TabIndex = 16;
            this.CGBox.TabStop = false;
            // 
            // degreeLabel
            // 
            this.degreeLabel.AutoSize = true;
            this.degreeLabel.Location = new System.Drawing.Point(75, 27);
            this.degreeLabel.Name = "degreeLabel";
            this.degreeLabel.Size = new System.Drawing.Size(82, 24);
            this.degreeLabel.TabIndex = 17;
            this.degreeLabel.Text = "去除强度";
            // 
            // clearDegree
            // 
            this.clearDegree.Location = new System.Drawing.Point(163, 24);
            this.clearDegree.Maximum = new decimal(new int[] {
            442,
            0,
            0,
            0});
            this.clearDegree.Name = "clearDegree";
            this.clearDegree.Size = new System.Drawing.Size(99, 31);
            this.clearDegree.TabIndex = 18;
            this.clearDegree.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.clearDegree.ValueChanged += new System.EventHandler(this.ClearDegree_ValueChanged);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(456, 21);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(126, 36);
            this.confirmButton.TabIndex = 19;
            this.confirmButton.Text = "确定";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ClearBgWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(664, 448);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.clearDegree);
            this.Controls.Add(this.degreeLabel);
            this.Controls.Add(this.CGBox);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClearBgWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "去除背景";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClearBgWin_FormClosing);
            this.Load += new System.EventHandler(this.ClearBgWin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CGBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearDegree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox CGBox;
        private System.Windows.Forms.Label degreeLabel;
        private System.Windows.Forms.NumericUpDown clearDegree;
        private System.Windows.Forms.Button confirmButton;
    }
}