namespace GameServer
{
    partial class GameServerForm
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowed = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlBrowser = new System.Windows.Forms.Panel();
            this.tbxWatchURL = new System.Windows.Forms.TextBox();
            this.btnWatchServer = new System.Windows.Forms.Button();
            this.btnHostServer = new System.Windows.Forms.Button();
            this.tbxLog = new System.Windows.Forms.TextBox();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Enabled = false;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(784, 24);
            this.mnuMain.TabIndex = 5;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(92, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "Edit";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(151, 22);
            this.mnuSettings.Text = "Server Settings";
            this.mnuSettings.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFullScreen,
            this.mnuWindowed});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "View";
            // 
            // mnuFullScreen
            // 
            this.mnuFullScreen.Name = "mnuFullScreen";
            this.mnuFullScreen.Size = new System.Drawing.Size(165, 22);
            this.mnuFullScreen.Text = "Full Screen Mode";
            this.mnuFullScreen.Click += new System.EventHandler(this.FullScreen_Click);
            // 
            // mnuWindowed
            // 
            this.mnuWindowed.Name = "mnuWindowed";
            this.mnuWindowed.Size = new System.Drawing.Size(165, 22);
            this.mnuWindowed.Text = "Windowed Mode";
            this.mnuWindowed.Click += new System.EventHandler(this.Windowed_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlBrowser);
            this.splitContainer1.Panel1.Controls.Add(this.tbxWatchURL);
            this.splitContainer1.Panel1.Controls.Add(this.btnWatchServer);
            this.splitContainer1.Panel1.Controls.Add(this.btnHostServer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbxLog);
            this.splitContainer1.Size = new System.Drawing.Size(784, 534);
            this.splitContainer1.SplitterDistance = 437;
            this.splitContainer1.TabIndex = 6;
            // 
            // pnlBrowser
            // 
            this.pnlBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBrowser.Location = new System.Drawing.Point(3, 32);
            this.pnlBrowser.Name = "pnlBrowser";
            this.pnlBrowser.Size = new System.Drawing.Size(778, 402);
            this.pnlBrowser.TabIndex = 8;
            // 
            // tbxWatchURL
            // 
            this.tbxWatchURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxWatchURL.Location = new System.Drawing.Point(475, 5);
            this.tbxWatchURL.Name = "tbxWatchURL";
            this.tbxWatchURL.Size = new System.Drawing.Size(216, 20);
            this.tbxWatchURL.TabIndex = 7;
            // 
            // btnWatchServer
            // 
            this.btnWatchServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWatchServer.Location = new System.Drawing.Point(697, 3);
            this.btnWatchServer.Name = "btnWatchServer";
            this.btnWatchServer.Size = new System.Drawing.Size(84, 23);
            this.btnWatchServer.TabIndex = 6;
            this.btnWatchServer.Text = "Watch Server";
            this.btnWatchServer.UseVisualStyleBackColor = true;
            // 
            // btnHostServer
            // 
            this.btnHostServer.Enabled = false;
            this.btnHostServer.Location = new System.Drawing.Point(3, 3);
            this.btnHostServer.Name = "btnHostServer";
            this.btnHostServer.Size = new System.Drawing.Size(84, 23);
            this.btnHostServer.TabIndex = 5;
            this.btnHostServer.Text = "Host Server";
            this.btnHostServer.UseVisualStyleBackColor = true;
            this.btnHostServer.Click += new System.EventHandler(this.HostServer_Click);
            // 
            // tbxLog
            // 
            this.tbxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLog.Location = new System.Drawing.Point(3, 3);
            this.tbxLog.Multiline = true;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxLog.Size = new System.Drawing.Size(778, 87);
            this.tbxLog.TabIndex = 2;
            // 
            // GameServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "GameServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Island Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameServerForm_FormClosing);
            this.Load += new System.EventHandler(this.GameServerForm_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlBrowser;
        private System.Windows.Forms.TextBox tbxWatchURL;
        private System.Windows.Forms.Button btnWatchServer;
        private System.Windows.Forms.Button btnHostServer;
        private System.Windows.Forms.TextBox tbxLog;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuFullScreen;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowed;
    }
}

