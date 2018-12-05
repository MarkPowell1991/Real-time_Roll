namespace Tab_Lab__2nd_Attempt_
{
    partial class DeviceSettingsForm
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
            this.outputDeviceBox = new System.Windows.Forms.GroupBox();
            this.outputDeviceList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.outputRefreshBtn = new System.Windows.Forms.Button();
            this.outputSelectBtn = new System.Windows.Forms.Button();
            this.inputDeviceBox = new System.Windows.Forms.GroupBox();
            this.inputDeviceList = new System.Windows.Forms.ListView();
            this.Device = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Channels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deviceRefreshBtn = new System.Windows.Forms.Button();
            this.deviceSelectBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.outputDeviceBox.SuspendLayout();
            this.inputDeviceBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputDeviceBox
            // 
            this.outputDeviceBox.Controls.Add(this.outputDeviceList);
            this.outputDeviceBox.Controls.Add(this.outputRefreshBtn);
            this.outputDeviceBox.Controls.Add(this.outputSelectBtn);
            this.outputDeviceBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outputDeviceBox.Location = new System.Drawing.Point(0, 329);
            this.outputDeviceBox.Name = "outputDeviceBox";
            this.outputDeviceBox.Size = new System.Drawing.Size(1314, 318);
            this.outputDeviceBox.TabIndex = 4;
            this.outputDeviceBox.TabStop = false;
            this.outputDeviceBox.Text = "Output Device";
            // 
            // outputDeviceList
            // 
            this.outputDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDeviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.outputDeviceList.Location = new System.Drawing.Point(9, 30);
            this.outputDeviceList.MultiSelect = false;
            this.outputDeviceList.Name = "outputDeviceList";
            this.outputDeviceList.Size = new System.Drawing.Size(720, 190);
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
            // outputRefreshBtn
            // 
            this.outputRefreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputRefreshBtn.Location = new System.Drawing.Point(735, 27);
            this.outputRefreshBtn.Name = "outputRefreshBtn";
            this.outputRefreshBtn.Size = new System.Drawing.Size(575, 67);
            this.outputRefreshBtn.TabIndex = 2;
            this.outputRefreshBtn.Text = "Refresh";
            this.outputRefreshBtn.UseVisualStyleBackColor = true;
            this.outputRefreshBtn.Click += new System.EventHandler(this.outputRefreshBtn_Click);
            // 
            // outputSelectBtn
            // 
            this.outputSelectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputSelectBtn.Location = new System.Drawing.Point(735, 100);
            this.outputSelectBtn.Name = "outputSelectBtn";
            this.outputSelectBtn.Size = new System.Drawing.Size(575, 65);
            this.outputSelectBtn.TabIndex = 1;
            this.outputSelectBtn.Text = "Select";
            this.outputSelectBtn.UseVisualStyleBackColor = true;
            this.outputSelectBtn.Click += new System.EventHandler(this.outputSelectBtn_Click);
            // 
            // inputDeviceBox
            // 
            this.inputDeviceBox.Controls.Add(this.inputDeviceList);
            this.inputDeviceBox.Controls.Add(this.deviceRefreshBtn);
            this.inputDeviceBox.Controls.Add(this.deviceSelectBtn);
            this.inputDeviceBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputDeviceBox.Location = new System.Drawing.Point(0, 0);
            this.inputDeviceBox.Name = "inputDeviceBox";
            this.inputDeviceBox.Size = new System.Drawing.Size(1314, 257);
            this.inputDeviceBox.TabIndex = 3;
            this.inputDeviceBox.TabStop = false;
            this.inputDeviceBox.Text = "Input Device";
            // 
            // inputDeviceList
            // 
            this.inputDeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDeviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Device,
            this.Channels});
            this.inputDeviceList.Location = new System.Drawing.Point(0, 45);
            this.inputDeviceList.MultiSelect = false;
            this.inputDeviceList.Name = "inputDeviceList";
            this.inputDeviceList.Size = new System.Drawing.Size(727, 224);
            this.inputDeviceList.TabIndex = 0;
            this.inputDeviceList.UseCompatibleStateImageBehavior = false;
            this.inputDeviceList.View = System.Windows.Forms.View.Details;
            // 
            // Device
            // 
            this.Device.Text = "Device";
            this.Device.Width = 200;
            // 
            // Channels
            // 
            this.Channels.Text = "Channels";
            this.Channels.Width = 120;
            // 
            // deviceRefreshBtn
            // 
            this.deviceRefreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceRefreshBtn.Location = new System.Drawing.Point(736, 27);
            this.deviceRefreshBtn.Name = "deviceRefreshBtn";
            this.deviceRefreshBtn.Size = new System.Drawing.Size(572, 67);
            this.deviceRefreshBtn.TabIndex = 2;
            this.deviceRefreshBtn.Text = "Refresh";
            this.deviceRefreshBtn.UseVisualStyleBackColor = true;
            this.deviceRefreshBtn.Click += new System.EventHandler(this.deviceRefreshBtn_Click);
            // 
            // deviceSelectBtn
            // 
            this.deviceSelectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceSelectBtn.Location = new System.Drawing.Point(736, 100);
            this.deviceSelectBtn.Name = "deviceSelectBtn";
            this.deviceSelectBtn.Size = new System.Drawing.Size(572, 65);
            this.deviceSelectBtn.TabIndex = 1;
            this.deviceSelectBtn.Text = "Select";
            this.deviceSelectBtn.UseVisualStyleBackColor = true;
            this.deviceSelectBtn.Click += new System.EventHandler(this.deviceSelectBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(1168, 12);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(125, 70);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.Location = new System.Drawing.Point(1037, 12);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(125, 70);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.inputDeviceBox);
            this.panel2.Controls.Add(this.outputDeviceBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1314, 647);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Cancel);
            this.panel1.Controls.Add(this.okBtn);
            this.panel1.Location = new System.Drawing.Point(12, 555);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1299, 95);
            this.panel1.TabIndex = 5;
            // 
            // DeviceSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 647);
            this.Controls.Add(this.panel2);
            this.Name = "DeviceSettingsForm";
            this.Text = "DevicePanel";
            this.outputDeviceBox.ResumeLayout(false);
            this.inputDeviceBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button deviceSelectBtn;
        private System.Windows.Forms.ListView inputDeviceList;
        private System.Windows.Forms.ColumnHeader Device;
        private System.Windows.Forms.ColumnHeader Channels;
        private System.Windows.Forms.GroupBox inputDeviceBox;
        private System.Windows.Forms.Button deviceRefreshBtn;
        private System.Windows.Forms.GroupBox outputDeviceBox;
        private System.Windows.Forms.ListView outputDeviceList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button outputRefreshBtn;
        private System.Windows.Forms.Button outputSelectBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}