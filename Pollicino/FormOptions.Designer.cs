﻿namespace MapperTool
{
    partial class FormOptions
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_GPS = new System.Windows.Forms.TabPage();
            this.button_gpslogpath = new System.Windows.Forms.Button();
            this.tb_GPSLogPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_SelectSimulationFile = new System.Windows.Forms.Button();
            this.tb_SimulationFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_GPSPortSpeed = new System.Windows.Forms.TextBox();
            this.cb_Simulation = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_GPSPort = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cb_autodownload = new System.Windows.Forms.CheckBox();
            this.num_DownloadDepth = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_GMapsCacheDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_TileCacheDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_TileServer = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.button_TileCacheDir = new System.Windows.Forms.Button();
            this.button_GMapsCacheDir = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_GPS.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_GPS);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_GPS
            // 
            this.tabPage_GPS.Controls.Add(this.button_gpslogpath);
            this.tabPage_GPS.Controls.Add(this.tb_GPSLogPath);
            this.tabPage_GPS.Controls.Add(this.label8);
            this.tabPage_GPS.Controls.Add(this.button_SelectSimulationFile);
            this.tabPage_GPS.Controls.Add(this.tb_SimulationFile);
            this.tabPage_GPS.Controls.Add(this.label3);
            this.tabPage_GPS.Controls.Add(this.tb_GPSPortSpeed);
            this.tabPage_GPS.Controls.Add(this.cb_Simulation);
            this.tabPage_GPS.Controls.Add(this.label2);
            this.tabPage_GPS.Controls.Add(this.label1);
            this.tabPage_GPS.Controls.Add(this.tb_GPSPort);
            this.tabPage_GPS.Location = new System.Drawing.Point(0, 0);
            this.tabPage_GPS.Name = "tabPage_GPS";
            this.tabPage_GPS.Size = new System.Drawing.Size(240, 245);
            this.tabPage_GPS.Text = "GPS";
            // 
            // button_gpslogpath
            // 
            this.button_gpslogpath.Location = new System.Drawing.Point(216, 77);
            this.button_gpslogpath.Name = "button_gpslogpath";
            this.button_gpslogpath.Size = new System.Drawing.Size(21, 21);
            this.button_gpslogpath.TabIndex = 16;
            this.button_gpslogpath.Text = "...";
            this.button_gpslogpath.Click += new System.EventHandler(this.button_gpslogpath_Click);
            // 
            // tb_GPSLogPath
            // 
            this.tb_GPSLogPath.Location = new System.Drawing.Point(7, 77);
            this.tb_GPSLogPath.Name = "tb_GPSLogPath";
            this.tb_GPSLogPath.Size = new System.Drawing.Size(206, 21);
            this.tb_GPSLogPath.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.Text = "Log path";
            // 
            // button_SelectSimulationFile
            // 
            this.button_SelectSimulationFile.Location = new System.Drawing.Point(216, 167);
            this.button_SelectSimulationFile.Name = "button_SelectSimulationFile";
            this.button_SelectSimulationFile.Size = new System.Drawing.Size(21, 21);
            this.button_SelectSimulationFile.TabIndex = 9;
            this.button_SelectSimulationFile.Text = "...";
            this.button_SelectSimulationFile.Click += new System.EventHandler(this.button_SelectSimulationFile_Click);
            // 
            // tb_SimulationFile
            // 
            this.tb_SimulationFile.Location = new System.Drawing.Point(7, 167);
            this.tb_SimulationFile.Name = "tb_SimulationFile";
            this.tb_SimulationFile.Size = new System.Drawing.Size(206, 21);
            this.tb_SimulationFile.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.Text = "Simulation file";
            // 
            // tb_GPSPortSpeed
            // 
            this.tb_GPSPortSpeed.Location = new System.Drawing.Point(101, 30);
            this.tb_GPSPortSpeed.Name = "tb_GPSPortSpeed";
            this.tb_GPSPortSpeed.Size = new System.Drawing.Size(112, 21);
            this.tb_GPSPortSpeed.TabIndex = 5;
            // 
            // cb_Simulation
            // 
            this.cb_Simulation.Location = new System.Drawing.Point(7, 121);
            this.cb_Simulation.Name = "cb_Simulation";
            this.cb_Simulation.Size = new System.Drawing.Size(148, 20);
            this.cb_Simulation.TabIndex = 4;
            this.cb_Simulation.Text = "GPS Simulation";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.Text = "Speed";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.Text = "Port";
            // 
            // tb_GPSPort
            // 
            this.tb_GPSPort.Location = new System.Drawing.Point(101, 3);
            this.tb_GPSPort.Name = "tb_GPSPort";
            this.tb_GPSPort.Size = new System.Drawing.Size(112, 21);
            this.tb_GPSPort.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_GMapsCacheDir);
            this.tabPage2.Controls.Add(this.button_TileCacheDir);
            this.tabPage2.Controls.Add(this.cb_autodownload);
            this.tabPage2.Controls.Add(this.num_DownloadDepth);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.tb_GMapsCacheDir);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tb_TileCacheDir);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tb_TileServer);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(240, 245);
            this.tabPage2.Text = "Maps";
            // 
            // cb_autodownload
            // 
            this.cb_autodownload.Location = new System.Drawing.Point(7, 126);
            this.cb_autodownload.Name = "cb_autodownload";
            this.cb_autodownload.Size = new System.Drawing.Size(226, 20);
            this.cb_autodownload.TabIndex = 11;
            this.cb_autodownload.Text = "Automatic tiles download";
            // 
            // num_DownloadDepth
            // 
            this.num_DownloadDepth.Location = new System.Drawing.Point(184, 101);
            this.num_DownloadDepth.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.num_DownloadDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_DownloadDepth.Name = "num_DownloadDepth";
            this.num_DownloadDepth.Size = new System.Drawing.Size(49, 22);
            this.num_DownloadDepth.TabIndex = 10;
            this.num_DownloadDepth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(7, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 20);
            this.label7.Text = "Download command depth";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 20);
            this.label6.Text = "GMaps cache path";
            // 
            // tb_GMapsCacheDir
            // 
            this.tb_GMapsCacheDir.Location = new System.Drawing.Point(7, 191);
            this.tb_GMapsCacheDir.Name = "tb_GMapsCacheDir";
            this.tb_GMapsCacheDir.Size = new System.Drawing.Size(199, 21);
            this.tb_GMapsCacheDir.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.Text = "Tiles cache path";
            // 
            // tb_TileCacheDir
            // 
            this.tb_TileCacheDir.Location = new System.Drawing.Point(7, 74);
            this.tb_TileCacheDir.Name = "tb_TileCacheDir";
            this.tb_TileCacheDir.Size = new System.Drawing.Size(199, 21);
            this.tb_TileCacheDir.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.Text = "OSM tiles server";
            // 
            // tb_TileServer
            // 
            this.tb_TileServer.Location = new System.Drawing.Point(7, 27);
            this.tb_TileServer.Name = "tb_TileServer";
            this.tb_TileServer.Size = new System.Drawing.Size(226, 21);
            this.tb_TileServer.TabIndex = 1;
            // 
            // button_TileCacheDir
            // 
            this.button_TileCacheDir.Location = new System.Drawing.Point(212, 74);
            this.button_TileCacheDir.Name = "button_TileCacheDir";
            this.button_TileCacheDir.Size = new System.Drawing.Size(21, 21);
            this.button_TileCacheDir.TabIndex = 17;
            this.button_TileCacheDir.Text = "...";
            this.button_TileCacheDir.Click += new System.EventHandler(this.button_TileCacheDir_Click);
            // 
            // button_GMapsCacheDir
            // 
            this.button_GMapsCacheDir.Location = new System.Drawing.Point(212, 191);
            this.button_GMapsCacheDir.Name = "button_GMapsCacheDir";
            this.button_GMapsCacheDir.Size = new System.Drawing.Size(21, 21);
            this.button_GMapsCacheDir.TabIndex = 18;
            this.button_GMapsCacheDir.Text = "...";
            this.button_GMapsCacheDir.Click += new System.EventHandler(this.button_GMapsCacheDir_Click);
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "FormOptions";
            this.Text = "MapperTool Options";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_GPS.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_GPS;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tb_GPSPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_SimulationFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_GPSPortSpeed;
        private System.Windows.Forms.CheckBox cb_Simulation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button_SelectSimulationFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_TileServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_GMapsCacheDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_TileCacheDir;
        private System.Windows.Forms.NumericUpDown num_DownloadDepth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cb_autodownload;
        private System.Windows.Forms.TextBox tb_GPSLogPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.Button button_gpslogpath;
        private System.Windows.Forms.Button button_GMapsCacheDir;
        private System.Windows.Forms.Button button_TileCacheDir;
    }
}