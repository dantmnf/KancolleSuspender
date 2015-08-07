namespace KancolleSuspender
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.windowSelector = new System.Windows.Forms.ComboBox();
            this.selectWindowLabel = new System.Windows.Forms.Label();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.intervalInput = new System.Windows.Forms.NumericUpDown();
            this.startButton = new System.Windows.Forms.Button();
            this.detectionTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.intervalInput)).BeginInit();
            this.SuspendLayout();
            // 
            // windowSelector
            // 
            this.windowSelector.DropDownHeight = 256;
            this.windowSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowSelector.FormattingEnabled = true;
            this.windowSelector.IntegralHeight = false;
            this.windowSelector.ItemHeight = 15;
            this.windowSelector.Location = new System.Drawing.Point(12, 27);
            this.windowSelector.MaxDropDownItems = 12;
            this.windowSelector.Name = "windowSelector";
            this.windowSelector.Size = new System.Drawing.Size(240, 23);
            this.windowSelector.TabIndex = 0;
            // 
            // selectWindowLabel
            // 
            this.selectWindowLabel.AutoSize = true;
            this.selectWindowLabel.Location = new System.Drawing.Point(12, 9);
            this.selectWindowLabel.Name = "selectWindowLabel";
            this.selectWindowLabel.Size = new System.Drawing.Size(83, 15);
            this.selectWindowLabel.TabIndex = 1;
            this.selectWindowLabel.Text = "Select window";
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(12, 62);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(113, 15);
            this.intervalLabel.TabIndex = 2;
            this.intervalLabel.Text = "Detection interval(s)";
            // 
            // intervalInput
            // 
            this.intervalInput.Location = new System.Drawing.Point(131, 60);
            this.intervalInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intervalInput.Name = "intervalInput";
            this.intervalInput.Size = new System.Drawing.Size(56, 23);
            this.intervalInput.TabIndex = 1;
            this.intervalInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startButton.Location = new System.Drawing.Point(206, 60);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(113, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // detectionTimer
            // 
            this.detectionTimer.Tick += new System.EventHandler(this.detectionTimer_Tick);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(258, 27);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(60, 23);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resumeButton.Location = new System.Drawing.Point(206, 89);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(112, 23);
            this.resumeButton.TabIndex = 5;
            this.resumeButton.Text = "Resume && Show";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 93);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(10, 15);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = " ";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(8, 8);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(331, 121);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.intervalInput);
            this.Controls.Add(this.intervalLabel);
            this.Controls.Add(this.selectWindowLabel);
            this.Controls.Add(this.windowSelector);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KanColleSuspender";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.intervalInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox windowSelector;
        private System.Windows.Forms.Label selectWindowLabel;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown intervalInput;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer detectionTimer;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}

