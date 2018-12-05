namespace Tab_Lab__2nd_Attempt_
{
    partial class RecordControlPanel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.mediaControlPanel = new System.Windows.Forms.Panel();
            this.stopBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.fforwardBtn = new System.Windows.Forms.Button();
            this.rewindBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.volumePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.outputDeviceLbl = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.inputDeviceLbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.waveChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clearBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.filePathLbl = new System.Windows.Forms.Label();
            this.inDeviceLbl = new System.Windows.Forms.Label();
            this.outDeviceLbl = new System.Windows.Forms.Label();
            this.mediaControlPanel.SuspendLayout();
            this.volumePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waveChart)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // mediaControlPanel
            // 
            this.mediaControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mediaControlPanel.Controls.Add(this.stopBtn);
            this.mediaControlPanel.Controls.Add(this.playBtn);
            this.mediaControlPanel.Controls.Add(this.fforwardBtn);
            this.mediaControlPanel.Controls.Add(this.rewindBtn);
            this.mediaControlPanel.Controls.Add(this.pauseBtn);
            this.mediaControlPanel.Controls.Add(this.recordButton);
            this.mediaControlPanel.Location = new System.Drawing.Point(0, 485);
            this.mediaControlPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mediaControlPanel.Name = "mediaControlPanel";
            this.mediaControlPanel.Size = new System.Drawing.Size(707, 49);
            this.mediaControlPanel.TabIndex = 1;
            // 
            // stopBtn
            // 
            this.stopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stopBtn.BackgroundImage = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Gold_Chrome_Effect;
            this.stopBtn.Image = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Stop_48;
            this.stopBtn.Location = new System.Drawing.Point(472, 2);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(113, 42);
            this.stopBtn.TabIndex = 5;
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playBtn.BackgroundImage = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Gold_Chrome_Effect;
            this.playBtn.Image = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Play_48;
            this.playBtn.Location = new System.Drawing.Point(120, 2);
            this.playBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(113, 42);
            this.playBtn.TabIndex = 4;
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // fforwardBtn
            // 
            this.fforwardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fforwardBtn.BackgroundImage = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Gold_Chrome_Effect;
            this.fforwardBtn.Image = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Fast_Forward_48;
            this.fforwardBtn.Location = new System.Drawing.Point(355, 2);
            this.fforwardBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fforwardBtn.Name = "fforwardBtn";
            this.fforwardBtn.Size = new System.Drawing.Size(113, 42);
            this.fforwardBtn.TabIndex = 3;
            this.fforwardBtn.UseVisualStyleBackColor = true;
            // 
            // rewindBtn
            // 
            this.rewindBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rewindBtn.BackgroundImage = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Gold_Chrome_Effect;
            this.rewindBtn.Image = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Rewind_48;
            this.rewindBtn.Location = new System.Drawing.Point(237, 2);
            this.rewindBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rewindBtn.Name = "rewindBtn";
            this.rewindBtn.Size = new System.Drawing.Size(113, 42);
            this.rewindBtn.TabIndex = 2;
            this.rewindBtn.UseVisualStyleBackColor = true;
            // 
            // pauseBtn
            // 
            this.pauseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseBtn.BackgroundImage = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Gold_Chrome_Effect;
            this.pauseBtn.Image = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Pause_48;
            this.pauseBtn.Location = new System.Drawing.Point(589, 2);
            this.pauseBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(113, 42);
            this.pauseBtn.TabIndex = 1;
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // recordButton
            // 
            this.recordButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordButton.BackgroundImage = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Gold_Chrome_Effect;
            this.recordButton.Image = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Record_48;
            this.recordButton.Location = new System.Drawing.Point(3, 2);
            this.recordButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(113, 42);
            this.recordButton.TabIndex = 0;
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
            // 
            // volumePanel
            // 
            this.volumePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.volumePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.volumePanel.Controls.Add(this.label2);
            this.volumePanel.Controls.Add(this.label1);
            this.volumePanel.Controls.Add(this.volumeTrackBar);
            this.volumePanel.Location = new System.Drawing.Point(723, 485);
            this.volumePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volumePanel.Name = "volumePanel";
            this.volumePanel.Size = new System.Drawing.Size(207, 49);
            this.volumePanel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Image = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Speaker_64;
            this.label2.Location = new System.Drawing.Point(148, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "            ";
            // 
            // label1
            // 
            this.label1.Image = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Mute_64;
            this.label1.Location = new System.Drawing.Point(13, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "            ";
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.AutoSize = false;
            this.volumeTrackBar.Location = new System.Drawing.Point(65, 4);
            this.volumeTrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(87, 33);
            this.volumeTrackBar.TabIndex = 0;
         //   this.volumeTrackBar.ValueChanged += new System.EventHandler(this.volumeTrackBar_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.outDeviceLbl);
            this.panel1.Controls.Add(this.inDeviceLbl);
            this.panel1.Controls.Add(this.filePathLbl);
            this.panel1.Controls.Add(this.fileNameLbl);
            this.panel1.Controls.Add(this.outputDeviceLbl);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.inputDeviceLbl);
            this.panel1.Location = new System.Drawing.Point(5, 130);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 105);
            this.panel1.TabIndex = 3;
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.Location = new System.Drawing.Point(30, 72);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(75, 17);
            this.fileNameLbl.TabIndex = 2;
            this.fileNameLbl.Text = "File Name:";
            // 
            // outputDeviceLbl
            // 
            this.outputDeviceLbl.AutoSize = true;
            this.outputDeviceLbl.Location = new System.Drawing.Point(3, 41);
            this.outputDeviceLbl.Name = "outputDeviceLbl";
            this.outputDeviceLbl.Size = new System.Drawing.Size(102, 17);
            this.outputDeviceLbl.TabIndex = 1;
            this.outputDeviceLbl.Text = "Output Device:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.openFileBtn);
            this.panel4.Location = new System.Drawing.Point(783, -1);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(138, 77);
            this.panel4.TabIndex = 5;
            // 
            // openFileBtn
            // 
            this.openFileBtn.BackgroundImage = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Gold_Chrome_Effect;
            this.openFileBtn.Location = new System.Drawing.Point(21, 15);
            this.openFileBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(96, 43);
            this.openFileBtn.TabIndex = 6;
            this.openFileBtn.Text = "Open File";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // inputDeviceLbl
            // 
            this.inputDeviceLbl.AutoSize = true;
            this.inputDeviceLbl.Location = new System.Drawing.Point(15, 9);
            this.inputDeviceLbl.Name = "inputDeviceLbl";
            this.inputDeviceLbl.Size = new System.Drawing.Size(90, 17);
            this.inputDeviceLbl.TabIndex = 0;
            this.inputDeviceLbl.Text = "Input Device:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.waveChart);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(7, 244);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(925, 237);
            this.panel2.TabIndex = 4;
            // 
            // waveChart
            // 
            this.waveChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.waveChart.ChartAreas.Add(chartArea1);
            this.waveChart.Location = new System.Drawing.Point(-41, -3);
            this.waveChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.waveChart.Name = "waveChart";
            this.waveChart.Size = new System.Drawing.Size(925, 190);
            this.waveChart.TabIndex = 1;
            this.waveChart.Text = "chart1";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.clearBtn);
            this.panel3.Controls.Add(this.saveBtn);
            this.panel3.Location = new System.Drawing.Point(719, 193);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(205, 39);
            this.panel3.TabIndex = 0;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(3, 2);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(96, 33);
            this.clearBtn.TabIndex = 8;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(105, 2);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(96, 33);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackgroundImage = global::Tab_Lab__2nd_Attempt_.Properties.Resources.Blank_fretboard___Music_Recorder;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(5, 2);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(925, 123);
            this.panel5.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.volumePanel);
            this.panel6.Controls.Add(this.mediaControlPanel);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(933, 544);
            this.panel6.TabIndex = 7;
            // 
            // filePathLbl
            // 
            this.filePathLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathLbl.AutoSize = true;
            this.filePathLbl.Location = new System.Drawing.Point(134, 72);
            this.filePathLbl.Name = "filePathLbl";
            this.filePathLbl.Size = new System.Drawing.Size(111, 17);
            this.filePathLbl.TabIndex = 6;
            this.filePathLbl.Text = "No File Selected";
            // 
            // inDeviceLbl
            // 
            this.inDeviceLbl.AutoSize = true;
            this.inDeviceLbl.Location = new System.Drawing.Point(134, 9);
            this.inDeviceLbl.Name = "inDeviceLbl";
            this.inDeviceLbl.Size = new System.Drawing.Size(94, 17);
            this.inDeviceLbl.TabIndex = 7;
            this.inDeviceLbl.Text = "Disconnected";
            // 
            // outDeviceLbl
            // 
            this.outDeviceLbl.AutoSize = true;
            this.outDeviceLbl.Location = new System.Drawing.Point(134, 41);
            this.outDeviceLbl.Name = "outDeviceLbl";
            this.outDeviceLbl.Size = new System.Drawing.Size(94, 17);
            this.outDeviceLbl.TabIndex = 8;
            this.outDeviceLbl.Text = "Disconnected";
            // 
            // RecordControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel6);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RecordControlPanel";
            this.Size = new System.Drawing.Size(933, 544);
            this.mediaControlPanel.ResumeLayout(false);
            this.volumePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waveChart)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.Panel mediaControlPanel;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button rewindBtn;
        private System.Windows.Forms.Button fforwardBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Panel volumePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label inputDeviceLbl;
        private System.Windows.Forms.Label fileNameLbl;
        private System.Windows.Forms.Label outputDeviceLbl;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataVisualization.Charting.Chart waveChart;
        private System.Windows.Forms.Label filePathLbl;
        private System.Windows.Forms.Label inDeviceLbl;
        private System.Windows.Forms.Label outDeviceLbl;
    }
}
