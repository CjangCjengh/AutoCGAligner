namespace AutoCGAligner
{
    partial class BatchWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchWin));
            this.baseFiles = new System.Windows.Forms.ListBox();
            this.diffFiles = new System.Windows.Forms.ListBox();
            this.baseFilesLabel = new System.Windows.Forms.Label();
            this.diffFilesLabel = new System.Windows.Forms.Label();
            this.fileBox = new System.Windows.Forms.GroupBox();
            this.alignBox = new System.Windows.Forms.GroupBox();
            this.alignAdvanced = new System.Windows.Forms.Button();
            this.precisionMode = new System.Windows.Forms.RadioButton();
            this.speedMode = new System.Windows.Forms.RadioButton();
            this.diffProcess = new System.Windows.Forms.GroupBox();
            this.degreeValue = new System.Windows.Forms.NumericUpDown();
            this.degreeLabel = new System.Windows.Forms.Label();
            this.clearLabel = new System.Windows.Forms.CheckBox();
            this.pathPanel = new System.Windows.Forms.GroupBox();
            this.savePath = new System.Windows.Forms.TextBox();
            this.openFolder = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.fileBox.SuspendLayout();
            this.alignBox.SuspendLayout();
            this.diffProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.degreeValue)).BeginInit();
            this.pathPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseFiles
            // 
            this.baseFiles.AllowDrop = true;
            this.baseFiles.FormattingEnabled = true;
            this.baseFiles.ItemHeight = 24;
            this.baseFiles.Location = new System.Drawing.Point(20, 54);
            this.baseFiles.Name = "baseFiles";
            this.baseFiles.Size = new System.Drawing.Size(200, 196);
            this.baseFiles.TabIndex = 1;
            this.baseFiles.SelectedIndexChanged += new System.EventHandler(this.BaseFiles_SelectedIndexChanged);
            this.baseFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.BaseFiles_DragDrop);
            this.baseFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilesDragEnter);
            this.baseFiles.DoubleClick += new System.EventHandler(this.BaseFiles_DoubleClick);
            this.baseFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BaseFiles_KeyPress);
            // 
            // diffFiles
            // 
            this.diffFiles.AllowDrop = true;
            this.diffFiles.FormattingEnabled = true;
            this.diffFiles.ItemHeight = 24;
            this.diffFiles.Location = new System.Drawing.Point(242, 54);
            this.diffFiles.Name = "diffFiles";
            this.diffFiles.Size = new System.Drawing.Size(200, 196);
            this.diffFiles.TabIndex = 3;
            this.diffFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.DiffFiles_DragDrop);
            this.diffFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilesDragEnter);
            this.diffFiles.DoubleClick += new System.EventHandler(this.DiffFiles_DoubleClick);
            this.diffFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DiffFiles_KeyPress);
            // 
            // baseFilesLabel
            // 
            this.baseFilesLabel.AutoSize = true;
            this.baseFilesLabel.Location = new System.Drawing.Point(16, 27);
            this.baseFilesLabel.Name = "baseFilesLabel";
            this.baseFilesLabel.Size = new System.Drawing.Size(107, 24);
            this.baseFilesLabel.TabIndex = 0;
            this.baseFilesLabel.Text = "CG（背景）";
            // 
            // diffFilesLabel
            // 
            this.diffFilesLabel.AutoSize = true;
            this.diffFilesLabel.Location = new System.Drawing.Point(238, 27);
            this.diffFilesLabel.Name = "diffFilesLabel";
            this.diffFilesLabel.Size = new System.Drawing.Size(107, 24);
            this.diffFilesLabel.TabIndex = 2;
            this.diffFilesLabel.Text = "CG（差分）";
            // 
            // fileBox
            // 
            this.fileBox.Controls.Add(this.baseFiles);
            this.fileBox.Controls.Add(this.diffFilesLabel);
            this.fileBox.Controls.Add(this.diffFiles);
            this.fileBox.Controls.Add(this.baseFilesLabel);
            this.fileBox.Location = new System.Drawing.Point(12, 17);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(462, 271);
            this.fileBox.TabIndex = 0;
            this.fileBox.TabStop = false;
            this.fileBox.Text = "图片文件";
            // 
            // alignBox
            // 
            this.alignBox.Controls.Add(this.alignAdvanced);
            this.alignBox.Controls.Add(this.precisionMode);
            this.alignBox.Controls.Add(this.speedMode);
            this.alignBox.Location = new System.Drawing.Point(12, 294);
            this.alignBox.Name = "alignBox";
            this.alignBox.Size = new System.Drawing.Size(462, 77);
            this.alignBox.TabIndex = 1;
            this.alignBox.TabStop = false;
            this.alignBox.Text = "对齐";
            // 
            // alignAdvanced
            // 
            this.alignAdvanced.Location = new System.Drawing.Point(305, 27);
            this.alignAdvanced.Name = "alignAdvanced";
            this.alignAdvanced.Size = new System.Drawing.Size(123, 34);
            this.alignAdvanced.TabIndex = 2;
            this.alignAdvanced.Text = "高级设置";
            this.alignAdvanced.UseVisualStyleBackColor = true;
            this.alignAdvanced.Click += new System.EventHandler(this.AlignAdvanced_Click);
            // 
            // precisionMode
            // 
            this.precisionMode.AutoSize = true;
            this.precisionMode.Location = new System.Drawing.Point(167, 30);
            this.precisionMode.Name = "precisionMode";
            this.precisionMode.Size = new System.Drawing.Size(107, 28);
            this.precisionMode.TabIndex = 1;
            this.precisionMode.Text = "精确模式";
            this.precisionMode.UseVisualStyleBackColor = true;
            this.precisionMode.CheckedChanged += new System.EventHandler(this.PrecisionMode_CheckedChanged);
            // 
            // speedMode
            // 
            this.speedMode.AutoSize = true;
            this.speedMode.Checked = true;
            this.speedMode.Location = new System.Drawing.Point(38, 30);
            this.speedMode.Name = "speedMode";
            this.speedMode.Size = new System.Drawing.Size(107, 28);
            this.speedMode.TabIndex = 0;
            this.speedMode.TabStop = true;
            this.speedMode.Text = "快速模式";
            this.speedMode.UseVisualStyleBackColor = true;
            this.speedMode.CheckedChanged += new System.EventHandler(this.SpeedMode_CheckedChanged);
            // 
            // diffProcess
            // 
            this.diffProcess.Controls.Add(this.degreeValue);
            this.diffProcess.Controls.Add(this.degreeLabel);
            this.diffProcess.Controls.Add(this.clearLabel);
            this.diffProcess.Location = new System.Drawing.Point(12, 377);
            this.diffProcess.Name = "diffProcess";
            this.diffProcess.Size = new System.Drawing.Size(462, 77);
            this.diffProcess.TabIndex = 2;
            this.diffProcess.TabStop = false;
            this.diffProcess.Text = "差分处理";
            // 
            // degreeValue
            // 
            this.degreeValue.Enabled = false;
            this.degreeValue.Location = new System.Drawing.Point(305, 29);
            this.degreeValue.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.degreeValue.Name = "degreeValue";
            this.degreeValue.Size = new System.Drawing.Size(123, 31);
            this.degreeValue.TabIndex = 2;
            this.degreeValue.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // degreeLabel
            // 
            this.degreeLabel.AutoSize = true;
            this.degreeLabel.Enabled = false;
            this.degreeLabel.Location = new System.Drawing.Point(217, 32);
            this.degreeLabel.Name = "degreeLabel";
            this.degreeLabel.Size = new System.Drawing.Size(82, 24);
            this.degreeLabel.TabIndex = 1;
            this.degreeLabel.Text = "去除强度";
            // 
            // clearLabel
            // 
            this.clearLabel.AutoSize = true;
            this.clearLabel.Location = new System.Drawing.Point(38, 30);
            this.clearLabel.Name = "clearLabel";
            this.clearLabel.Size = new System.Drawing.Size(108, 28);
            this.clearLabel.TabIndex = 0;
            this.clearLabel.Text = "去除背景";
            this.clearLabel.UseVisualStyleBackColor = true;
            this.clearLabel.CheckedChanged += new System.EventHandler(this.ClearLabel_CheckedChanged);
            // 
            // pathPanel
            // 
            this.pathPanel.Controls.Add(this.savePath);
            this.pathPanel.Controls.Add(this.openFolder);
            this.pathPanel.Location = new System.Drawing.Point(12, 460);
            this.pathPanel.Name = "pathPanel";
            this.pathPanel.Size = new System.Drawing.Size(462, 77);
            this.pathPanel.TabIndex = 3;
            this.pathPanel.TabStop = false;
            this.pathPanel.Text = "保存路径";
            // 
            // savePath
            // 
            this.savePath.Location = new System.Drawing.Point(32, 29);
            this.savePath.Name = "savePath";
            this.savePath.Size = new System.Drawing.Size(258, 31);
            this.savePath.TabIndex = 0;
            this.savePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SavePath_KeyPress);
            // 
            // openFolder
            // 
            this.openFolder.Location = new System.Drawing.Point(305, 27);
            this.openFolder.Name = "openFolder";
            this.openFolder.Size = new System.Drawing.Size(123, 34);
            this.openFolder.TabIndex = 1;
            this.openFolder.Text = "打开文件夹";
            this.openFolder.UseVisualStyleBackColor = true;
            this.openFolder.Click += new System.EventHandler(this.OpenFolder_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Enabled = false;
            this.confirmButton.Location = new System.Drawing.Point(187, 554);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(113, 34);
            this.confirmButton.TabIndex = 4;
            this.confirmButton.Text = "开始合成";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // BatchWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(486, 608);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.pathPanel);
            this.Controls.Add(this.diffProcess);
            this.Controls.Add(this.alignBox);
            this.Controls.Add(this.fileBox);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量合成";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.BatchWin_HelpButtonClicked);
            this.fileBox.ResumeLayout(false);
            this.fileBox.PerformLayout();
            this.alignBox.ResumeLayout(false);
            this.alignBox.PerformLayout();
            this.diffProcess.ResumeLayout(false);
            this.diffProcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.degreeValue)).EndInit();
            this.pathPanel.ResumeLayout(false);
            this.pathPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox baseFiles;
        private System.Windows.Forms.ListBox diffFiles;
        private System.Windows.Forms.Label baseFilesLabel;
        private System.Windows.Forms.Label diffFilesLabel;
        private System.Windows.Forms.GroupBox fileBox;
        private System.Windows.Forms.GroupBox alignBox;
        private System.Windows.Forms.Button alignAdvanced;
        private System.Windows.Forms.RadioButton precisionMode;
        private System.Windows.Forms.RadioButton speedMode;
        private System.Windows.Forms.GroupBox diffProcess;
        private System.Windows.Forms.CheckBox clearLabel;
        private System.Windows.Forms.NumericUpDown degreeValue;
        private System.Windows.Forms.Label degreeLabel;
        private System.Windows.Forms.GroupBox pathPanel;
        private System.Windows.Forms.Button openFolder;
        private System.Windows.Forms.TextBox savePath;
        private System.Windows.Forms.Button confirmButton;
    }
}