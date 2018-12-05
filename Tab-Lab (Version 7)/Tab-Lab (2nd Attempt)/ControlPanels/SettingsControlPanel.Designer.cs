namespace Tab_Lab__2nd_Attempt_
{
    partial class SettingsControlPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputDeviceList = new System.Windows.Forms.ListView();
            this.deviceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.channelColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.refreshOutputsButton = new System.Windows.Forms.Button();
            this.outputDeviceList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bufferSaveLbl = new System.Windows.Forms.Label();
            this.bufferSaveTextBox = new System.Windows.Forms.TextBox();
            this.bufferSaveLocEditBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.applyButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.refreshInputsButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1128, 656);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(8, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 213);
            this.panel2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.refreshInputsButton);
            this.groupBox1.Controls.Add(this.inputDeviceList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(535, 213);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Device";
            // 
            // inputDeviceList
            // 
            this.inputDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDeviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.deviceColumn,
            this.channelColumn});
            this.inputDeviceList.Location = new System.Drawing.Point(3, 18);
            this.inputDeviceList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputDeviceList.Name = "inputDeviceList";
            this.inputDeviceList.Size = new System.Drawing.Size(442, 173);
            this.inputDeviceList.TabIndex = 0;
            this.inputDeviceList.UseCompatibleStateImageBehavior = false;
            this.inputDeviceList.View = System.Windows.Forms.View.Details;
            // 
            // deviceColumn
            // 
            this.deviceColumn.Text = "Device";
            this.deviceColumn.Width = 200;
            // 
            // channelColumn
            // 
            this.channelColumn.Text = "Channels";
            this.channelColumn.Width = 120;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.refreshOutputsButton);
            this.groupBox3.Controls.Add(this.outputDeviceList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(573, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(535, 213);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Device";
            // 
            // refreshOutputsButton
            // 
            this.refreshOutputsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshOutputsButton.Location = new System.Drawing.Point(451, 18);
            this.refreshOutputsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refreshOutputsButton.Name = "refreshOutputsButton";
            this.refreshOutputsButton.Size = new System.Drawing.Size(79, 41);
            this.refreshOutputsButton.TabIndex = 0;
            this.refreshOutputsButton.Text = "Refresh";
            this.refreshOutputsButton.UseVisualStyleBackColor = true;
            this.refreshOutputsButton.Click += new System.EventHandler(this.refreshOutputsButton_Click);
            // 
            // outputDeviceList
            // 
            this.outputDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDeviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.outputDeviceList.Location = new System.Drawing.Point(3, 18);
            this.outputDeviceList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.outputDeviceList.Name = "outputDeviceList";
            this.outputDeviceList.Size = new System.Drawing.Size(442, 173);
            this.outputDeviceList.TabIndex = 0;
            this.outputDeviceList.UseCompatibleStateImageBehavior = false;
            this.outputDeviceList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Device";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Channels";
            this.columnHeader2.Width = 120;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bufferSaveLbl);
            this.groupBox2.Controls.Add(this.bufferSaveTextBox);
            this.groupBox2.Controls.Add(this.bufferSaveLocEditBtn);
            this.groupBox2.Location = new System.Drawing.Point(8, 350);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(637, 140);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // bufferSaveLbl
            // 
            this.bufferSaveLbl.AutoSize = true;
            this.bufferSaveLbl.Location = new System.Drawing.Point(7, 31);
            this.bufferSaveLbl.Name = "bufferSaveLbl";
            this.bufferSaveLbl.Size = new System.Drawing.Size(144, 17);
            this.bufferSaveLbl.TabIndex = 3;
            this.bufferSaveLbl.Text = "Buffer Save Location:";
            // 
            // bufferSaveTextBox
            // 
            this.bufferSaveTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bufferSaveTextBox.Location = new System.Drawing.Point(159, 27);
            this.bufferSaveTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bufferSaveTextBox.Name = "bufferSaveTextBox";
            this.bufferSaveTextBox.Size = new System.Drawing.Size(375, 22);
            this.bufferSaveTextBox.TabIndex = 4;
            // 
            // bufferSaveLocEditBtn
            // 
            this.bufferSaveLocEditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bufferSaveLocEditBtn.Location = new System.Drawing.Point(540, 23);
            this.bufferSaveLocEditBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bufferSaveLocEditBtn.Name = "bufferSaveLocEditBtn";
            this.bufferSaveLocEditBtn.Size = new System.Drawing.Size(91, 30);
            this.bufferSaveLocEditBtn.TabIndex = 5;
            this.bufferSaveLocEditBtn.Text = "Edit";
            this.bufferSaveLocEditBtn.UseVisualStyleBackColor = true;
            this.bufferSaveLocEditBtn.Click += new System.EventHandler(this.bufferSaveLocEditBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.applyButton);
            this.panel3.Location = new System.Drawing.Point(1038, 601);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(88, 53);
            this.panel3.TabIndex = 2;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(0, 0);
            this.applyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(85, 50);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackgroundImage = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Blank_fretboard___Settings;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(5, 2);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1120, 123);
            this.panel4.TabIndex = 2;
            // 
            // refreshInputsButton
            // 
            this.refreshInputsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshInputsButton.Location = new System.Drawing.Point(451, 19);
            this.refreshInputsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refreshInputsButton.Name = "refreshInputsButton";
            this.refreshInputsButton.Size = new System.Drawing.Size(79, 41);
            this.refreshInputsButton.TabIndex = 1;
            this.refreshInputsButton.Text = "Refresh";
            this.refreshInputsButton.UseVisualStyleBackColor = true;
            this.refreshInputsButton.Click += new System.EventHandler(this.refreshInputsButton_Click);
            // 
            // SettingsControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SettingsControlPanel";
            this.Size = new System.Drawing.Size(1128, 656);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label bufferSaveLbl;
        private System.Windows.Forms.Button bufferSaveLocEditBtn;
        private System.Windows.Forms.TextBox bufferSaveTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView inputDeviceList;
        private System.Windows.Forms.ColumnHeader deviceColumn;
        private System.Windows.Forms.ColumnHeader channelColumn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button refreshOutputsButton;
        private System.Windows.Forms.ListView outputDeviceList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button refreshInputsButton;
    }
}
