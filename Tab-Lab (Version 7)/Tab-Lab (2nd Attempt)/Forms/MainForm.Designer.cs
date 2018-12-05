namespace Tab_Lab__2nd_Attempt_
{
    partial class MainForm
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
            this.menuButtonsBox = new System.Windows.Forms.GroupBox();
            this.tabMakerBtn = new System.Windows.Forms.Button();
            this.menuSettingsBtn = new System.Windows.Forms.Button();
            this.menuRecordBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainDynamicPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MIDIViewBtn = new System.Windows.Forms.Button();
            this.menuButtonsBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuButtonsBox
            // 
            this.menuButtonsBox.Controls.Add(this.MIDIViewBtn);
            this.menuButtonsBox.Controls.Add(this.tabMakerBtn);
            this.menuButtonsBox.Controls.Add(this.menuSettingsBtn);
            this.menuButtonsBox.Controls.Add(this.menuRecordBtn);
            this.menuButtonsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuButtonsBox.Location = new System.Drawing.Point(0, 0);
            this.menuButtonsBox.Margin = new System.Windows.Forms.Padding(2);
            this.menuButtonsBox.Name = "menuButtonsBox";
            this.menuButtonsBox.Padding = new System.Windows.Forms.Padding(2);
            this.menuButtonsBox.Size = new System.Drawing.Size(138, 264);
            this.menuButtonsBox.TabIndex = 0;
            this.menuButtonsBox.TabStop = false;
            this.menuButtonsBox.Text = "Menu Bar";
            // 
            // tabMakerBtn
            // 
            this.tabMakerBtn.Location = new System.Drawing.Point(2, 136);
            this.tabMakerBtn.Margin = new System.Windows.Forms.Padding(2);
            this.tabMakerBtn.Name = "tabMakerBtn";
            this.tabMakerBtn.Size = new System.Drawing.Size(132, 43);
            this.tabMakerBtn.TabIndex = 2;
            this.tabMakerBtn.Text = "Composer";
            this.tabMakerBtn.UseVisualStyleBackColor = true;
            this.tabMakerBtn.Click += new System.EventHandler(this.tabMakerBtn_Click);
            // 
            // menuSettingsBtn
            // 
            this.menuSettingsBtn.Location = new System.Drawing.Point(2, 42);
            this.menuSettingsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.menuSettingsBtn.Name = "menuSettingsBtn";
            this.menuSettingsBtn.Size = new System.Drawing.Size(132, 45);
            this.menuSettingsBtn.TabIndex = 1;
            this.menuSettingsBtn.Text = "Settings";
            this.menuSettingsBtn.UseVisualStyleBackColor = true;
            this.menuSettingsBtn.Click += new System.EventHandler(this.menuSettingsBtn_Click);
            // 
            // menuRecordBtn
            // 
            this.menuRecordBtn.Location = new System.Drawing.Point(2, 89);
            this.menuRecordBtn.Margin = new System.Windows.Forms.Padding(2);
            this.menuRecordBtn.Name = "menuRecordBtn";
            this.menuRecordBtn.Size = new System.Drawing.Size(132, 43);
            this.menuRecordBtn.TabIndex = 0;
            this.menuRecordBtn.Text = "Recording Studio";
            this.menuRecordBtn.UseVisualStyleBackColor = true;
            this.menuRecordBtn.Click += new System.EventHandler(this.menuRecordBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(566, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.devicesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // devicesToolStripMenuItem
            // 
            this.devicesToolStripMenuItem.Name = "devicesToolStripMenuItem";
            this.devicesToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.devicesToolStripMenuItem.Text = "Devices";
            this.devicesToolStripMenuItem.Click += new System.EventHandler(this.devicesToolStripMenuItem_Click);
            // 
            // mainDynamicPanel
            // 
            this.mainDynamicPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainDynamicPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainDynamicPanel.Location = new System.Drawing.Point(142, 21);
            this.mainDynamicPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainDynamicPanel.Name = "mainDynamicPanel";
            this.mainDynamicPanel.Size = new System.Drawing.Size(426, 270);
            this.mainDynamicPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.menuButtonsBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 266);
            this.panel1.TabIndex = 3;
            // 
            // MIDIViewBtn
            // 
            this.MIDIViewBtn.Location = new System.Drawing.Point(4, 185);
            this.MIDIViewBtn.Name = "MIDIViewBtn";
            this.MIDIViewBtn.Size = new System.Drawing.Size(132, 43);
            this.MIDIViewBtn.TabIndex = 3;
            this.MIDIViewBtn.Text = "MIDI Viewer";
            this.MIDIViewBtn.UseVisualStyleBackColor = true;
            this.MIDIViewBtn.Click += new System.EventHandler(this.MIDIViewBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 290);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainDynamicPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Tab-Lab";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuButtonsBox.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox menuButtonsBox;
        private System.Windows.Forms.Button menuSettingsBtn;
        private System.Windows.Forms.Button menuRecordBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel mainDynamicPanel;
        private System.Windows.Forms.ToolStripMenuItem devicesToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button tabMakerBtn;
        private System.Windows.Forms.Button MIDIViewBtn;
    }
}

