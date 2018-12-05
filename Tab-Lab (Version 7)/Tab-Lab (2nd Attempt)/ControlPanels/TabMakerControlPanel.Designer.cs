namespace Tab_Lab__2nd_Attempt_
{
    partial class TabMakerControlPanel
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sMVCPView = new System.Windows.Forms.Panel();
            this.noteListView = new System.Windows.Forms.ListView();
            this.noteListLbl = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.stopBtn = new System.Windows.Forms.Button();
            this.measureSettingsBox = new System.Windows.Forms.GroupBox();
            this.btmUpDownBox = new System.Windows.Forms.NumericUpDown();
            this.topUpDownBox = new System.Windows.Forms.NumericUpDown();
            this.btmSignatureLbl = new System.Windows.Forms.Label();
            this.topSignatureLbl = new System.Windows.Forms.Label();
            this.songPropertiesBox = new System.Windows.Forms.GroupBox();
            this.fileSaveLocationLbl = new System.Windows.Forms.Label();
            this.saveLocationLbl = new System.Windows.Forms.Label();
            this.saveSelectBtn = new System.Windows.Forms.Button();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.songTitleLbl = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.noteLbl = new System.Windows.Forms.Label();
            this.noteValueLbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pFrequencyLbl = new System.Windows.Forms.Label();
            this.pFrequencyValueLbl = new System.Windows.Forms.Label();
            this.pFrequencyUnitsLbl = new System.Windows.Forms.Label();
            this.composerBtn = new System.Windows.Forms.Button();
            this.centsValueLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.sMVCPView.SuspendLayout();
            this.panel3.SuspendLayout();
            this.measureSettingsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btmUpDownBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topUpDownBox)).BeginInit();
            this.songPropertiesBox.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sMVCPView);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 442);
            this.panel1.TabIndex = 0;
            // 
            // sMVCPView
            // 
            this.sMVCPView.Controls.Add(this.noteListView);
            this.sMVCPView.Controls.Add(this.noteListLbl);
            this.sMVCPView.Location = new System.Drawing.Point(11, 300);
            this.sMVCPView.Name = "sMVCPView";
            this.sMVCPView.Size = new System.Drawing.Size(683, 112);
            this.sMVCPView.TabIndex = 2;
            // 
            // noteListView
            // 
            this.noteListView.Location = new System.Drawing.Point(249, 12);
            this.noteListView.Name = "noteListView";
            this.noteListView.Size = new System.Drawing.Size(121, 97);
            this.noteListView.TabIndex = 1;
            this.noteListView.UseCompatibleStateImageBehavior = false;
            // 
            // noteListLbl
            // 
            this.noteListLbl.AutoSize = true;
            this.noteListLbl.Location = new System.Drawing.Point(163, 44);
            this.noteListLbl.Name = "noteListLbl";
            this.noteListLbl.Size = new System.Drawing.Size(35, 13);
            this.noteListLbl.TabIndex = 0;
            this.noteListLbl.Text = "label1";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.stopBtn);
            this.panel3.Controls.Add(this.measureSettingsBox);
            this.panel3.Controls.Add(this.songPropertiesBox);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.composerBtn);
            this.panel3.Controls.Add(this.centsValueLbl);
            this.panel3.Location = new System.Drawing.Point(4, 106);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 178);
            this.panel3.TabIndex = 1;
            // 
            // stopBtn
            // 
            this.stopBtn.Enabled = false;
            this.stopBtn.Location = new System.Drawing.Point(629, 133);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(60, 41);
            this.stopBtn.TabIndex = 11;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // measureSettingsBox
            // 
            this.measureSettingsBox.Controls.Add(this.btmUpDownBox);
            this.measureSettingsBox.Controls.Add(this.topUpDownBox);
            this.measureSettingsBox.Controls.Add(this.btmSignatureLbl);
            this.measureSettingsBox.Controls.Add(this.topSignatureLbl);
            this.measureSettingsBox.Location = new System.Drawing.Point(210, 97);
            this.measureSettingsBox.Name = "measureSettingsBox";
            this.measureSettingsBox.Size = new System.Drawing.Size(333, 69);
            this.measureSettingsBox.TabIndex = 10;
            this.measureSettingsBox.TabStop = false;
            this.measureSettingsBox.Text = "Measure:";
            // 
            // btmUpDownBox
            // 
            this.btmUpDownBox.Location = new System.Drawing.Point(105, 35);
            this.btmUpDownBox.Name = "btmUpDownBox";
            this.btmUpDownBox.Size = new System.Drawing.Size(48, 20);
            this.btmUpDownBox.TabIndex = 3;
            this.btmUpDownBox.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // topUpDownBox
            // 
            this.topUpDownBox.Location = new System.Drawing.Point(105, 14);
            this.topUpDownBox.Name = "topUpDownBox";
            this.topUpDownBox.Size = new System.Drawing.Size(48, 20);
            this.topUpDownBox.TabIndex = 2;
            this.topUpDownBox.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // btmSignatureLbl
            // 
            this.btmSignatureLbl.AutoSize = true;
            this.btmSignatureLbl.Location = new System.Drawing.Point(8, 37);
            this.btmSignatureLbl.Name = "btmSignatureLbl";
            this.btmSignatureLbl.Size = new System.Drawing.Size(91, 13);
            this.btmSignatureLbl.TabIndex = 1;
            this.btmSignatureLbl.Text = "Bottom Signature:";
            // 
            // topSignatureLbl
            // 
            this.topSignatureLbl.AutoSize = true;
            this.topSignatureLbl.Location = new System.Drawing.Point(22, 16);
            this.topSignatureLbl.Name = "topSignatureLbl";
            this.topSignatureLbl.Size = new System.Drawing.Size(77, 13);
            this.topSignatureLbl.TabIndex = 0;
            this.topSignatureLbl.Text = "Top Signature:";
            // 
            // songPropertiesBox
            // 
            this.songPropertiesBox.Controls.Add(this.fileSaveLocationLbl);
            this.songPropertiesBox.Controls.Add(this.saveLocationLbl);
            this.songPropertiesBox.Controls.Add(this.saveSelectBtn);
            this.songPropertiesBox.Controls.Add(this.titleBox);
            this.songPropertiesBox.Controls.Add(this.songTitleLbl);
            this.songPropertiesBox.Location = new System.Drawing.Point(210, 7);
            this.songPropertiesBox.Name = "songPropertiesBox";
            this.songPropertiesBox.Size = new System.Drawing.Size(372, 80);
            this.songPropertiesBox.TabIndex = 9;
            this.songPropertiesBox.TabStop = false;
            this.songPropertiesBox.Text = "Song Properties";
            // 
            // fileSaveLocationLbl
            // 
            this.fileSaveLocationLbl.AutoSize = true;
            this.fileSaveLocationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileSaveLocationLbl.Location = new System.Drawing.Point(173, 40);
            this.fileSaveLocationLbl.Name = "fileSaveLocationLbl";
            this.fileSaveLocationLbl.Size = new System.Drawing.Size(186, 13);
            this.fileSaveLocationLbl.TabIndex = 15;
            this.fileSaveLocationLbl.Text = "Please Select file save location";
            // 
            // saveLocationLbl
            // 
            this.saveLocationLbl.AutoSize = true;
            this.saveLocationLbl.Location = new System.Drawing.Point(7, 39);
            this.saveLocationLbl.Name = "saveLocationLbl";
            this.saveLocationLbl.Size = new System.Drawing.Size(79, 13);
            this.saveLocationLbl.TabIndex = 14;
            this.saveLocationLbl.Text = "Save Location:";
            // 
            // saveSelectBtn
            // 
            this.saveSelectBtn.Location = new System.Drawing.Point(91, 40);
            this.saveSelectBtn.Name = "saveSelectBtn";
            this.saveSelectBtn.Size = new System.Drawing.Size(75, 21);
            this.saveSelectBtn.TabIndex = 13;
            this.saveSelectBtn.Text = "Select";
            this.saveSelectBtn.UseVisualStyleBackColor = true;
            this.saveSelectBtn.Click += new System.EventHandler(this.saveSelectBtn_Click);
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(92, 13);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(100, 20);
            this.titleBox.TabIndex = 1;
            // 
            // songTitleLbl
            // 
            this.songTitleLbl.AutoSize = true;
            this.songTitleLbl.Location = new System.Drawing.Point(56, 13);
            this.songTitleLbl.Name = "songTitleLbl";
            this.songTitleLbl.Size = new System.Drawing.Size(30, 13);
            this.songTitleLbl.TabIndex = 0;
            this.songTitleLbl.Text = "Title:";
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.noteLbl);
            this.panel5.Controls.Add(this.noteValueLbl);
            this.panel5.Location = new System.Drawing.Point(6, 74);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(199, 46);
            this.panel5.TabIndex = 8;
            // 
            // noteLbl
            // 
            this.noteLbl.AutoSize = true;
            this.noteLbl.Location = new System.Drawing.Point(0, 0);
            this.noteLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noteLbl.Name = "noteLbl";
            this.noteLbl.Size = new System.Drawing.Size(33, 13);
            this.noteLbl.TabIndex = 5;
            this.noteLbl.Text = "Note:";
            // 
            // noteValueLbl
            // 
            this.noteValueLbl.AutoSize = true;
            this.noteValueLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.noteValueLbl.Location = new System.Drawing.Point(186, 0);
            this.noteValueLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noteValueLbl.Name = "noteValueLbl";
            this.noteValueLbl.Size = new System.Drawing.Size(13, 13);
            this.noteValueLbl.TabIndex = 2;
            this.noteValueLbl.Text = "?";
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.pFrequencyLbl);
            this.panel4.Controls.Add(this.pFrequencyValueLbl);
            this.panel4.Controls.Add(this.pFrequencyUnitsLbl);
            this.panel4.Location = new System.Drawing.Point(2, 7);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(199, 46);
            this.panel4.TabIndex = 7;
            // 
            // pFrequencyLbl
            // 
            this.pFrequencyLbl.AutoSize = true;
            this.pFrequencyLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.pFrequencyLbl.Location = new System.Drawing.Point(0, 0);
            this.pFrequencyLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pFrequencyLbl.Name = "pFrequencyLbl";
            this.pFrequencyLbl.Size = new System.Drawing.Size(87, 13);
            this.pFrequencyLbl.TabIndex = 0;
            this.pFrequencyLbl.Text = "Pitch Frequency:";
            // 
            // pFrequencyValueLbl
            // 
            this.pFrequencyValueLbl.AutoSize = true;
            this.pFrequencyValueLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pFrequencyValueLbl.Location = new System.Drawing.Point(173, 0);
            this.pFrequencyValueLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pFrequencyValueLbl.Name = "pFrequencyValueLbl";
            this.pFrequencyValueLbl.Size = new System.Drawing.Size(13, 13);
            this.pFrequencyValueLbl.TabIndex = 1;
            this.pFrequencyValueLbl.Text = "?";
            // 
            // pFrequencyUnitsLbl
            // 
            this.pFrequencyUnitsLbl.AutoSize = true;
            this.pFrequencyUnitsLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pFrequencyUnitsLbl.Location = new System.Drawing.Point(186, 0);
            this.pFrequencyUnitsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pFrequencyUnitsLbl.Name = "pFrequencyUnitsLbl";
            this.pFrequencyUnitsLbl.Size = new System.Drawing.Size(13, 13);
            this.pFrequencyUnitsLbl.TabIndex = 6;
            this.pFrequencyUnitsLbl.Text = "?";
            // 
            // composerBtn
            // 
            this.composerBtn.Location = new System.Drawing.Point(548, 133);
            this.composerBtn.Margin = new System.Windows.Forms.Padding(2);
            this.composerBtn.Name = "composerBtn";
            this.composerBtn.Size = new System.Drawing.Size(77, 41);
            this.composerBtn.TabIndex = 4;
            this.composerBtn.Text = "Start";
            this.composerBtn.UseVisualStyleBackColor = true;
            this.composerBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // centsValueLbl
            // 
            this.centsValueLbl.AutoSize = true;
            this.centsValueLbl.Location = new System.Drawing.Point(87, 122);
            this.centsValueLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.centsValueLbl.Name = "centsValueLbl";
            this.centsValueLbl.Size = new System.Drawing.Size(13, 13);
            this.centsValueLbl.TabIndex = 3;
            this.centsValueLbl.Text = "?";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackgroundImage = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Blank_fretboard___Tab_Creator;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(4, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 100);
            this.panel2.TabIndex = 0;
            // 
            // TabMakerControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TabMakerControlPanel";
            this.Size = new System.Drawing.Size(700, 442);
            this.panel1.ResumeLayout(false);
            this.sMVCPView.ResumeLayout(false);
            this.sMVCPView.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.measureSettingsBox.ResumeLayout(false);
            this.measureSettingsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btmUpDownBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topUpDownBox)).EndInit();
            this.songPropertiesBox.ResumeLayout(false);
            this.songPropertiesBox.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label pFrequencyValueLbl;
        private System.Windows.Forms.Label pFrequencyLbl;
        private System.Windows.Forms.Label noteValueLbl;
        private System.Windows.Forms.Label centsValueLbl;
        private System.Windows.Forms.Button composerBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label pFrequencyUnitsLbl;
        private System.Windows.Forms.Label noteLbl;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox measureSettingsBox;
        private System.Windows.Forms.Label btmSignatureLbl;
        private System.Windows.Forms.Label topSignatureLbl;
        private System.Windows.Forms.GroupBox songPropertiesBox;
        private System.Windows.Forms.Label songTitleLbl;
        private System.Windows.Forms.TextBox titleBox;
        public System.Windows.Forms.NumericUpDown btmUpDownBox;
        public System.Windows.Forms.NumericUpDown topUpDownBox;
        private System.Windows.Forms.Panel sMVCPView;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Label noteListLbl;
        private System.Windows.Forms.ListView noteListView;
        private System.Windows.Forms.Label saveLocationLbl;
        private System.Windows.Forms.Button saveSelectBtn;
        private System.Windows.Forms.Label fileSaveLocationLbl;
    }
}
