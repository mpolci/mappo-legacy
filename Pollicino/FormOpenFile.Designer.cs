﻿namespace MapperTool
{
    partial class FormOpenFile
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpenFile));
            this.tb_Dir = new System.Windows.Forms.TextBox();
            this.lw_dircontent = new System.Windows.Forms.ListView();
            this.imglist_Icons = new System.Windows.Forms.ImageList();
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuItem_cancel = new System.Windows.Forms.MenuItem();
            this.menuItem_selectdir = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // tb_Dir
            // 
            this.tb_Dir.Location = new System.Drawing.Point(3, 3);
            this.tb_Dir.Name = "tb_Dir";
            this.tb_Dir.ReadOnly = true;
            this.tb_Dir.Size = new System.Drawing.Size(234, 21);
            this.tb_Dir.TabIndex = 1;
            this.tb_Dir.Text = "\\";
            // 
            // lw_dircontent
            // 
            this.lw_dircontent.Activation = System.Windows.Forms.ItemActivation.OneClick;
            listViewItem1.ImageIndex = 0;
            listViewItem1.Text = "pippo";
            listViewItem1.SubItems.Add("sub1");
            listViewItem1.SubItems.Add("sub2");
            listViewItem1.SubItems.Add("sub3");
            listViewItem2.ImageIndex = 1;
            listViewItem2.Tag = "";
            listViewItem2.Text = "pluto";
            listViewItem3.ImageIndex = 1;
            listViewItem3.Text = "paperino";
            this.lw_dircontent.Items.Add(listViewItem1);
            this.lw_dircontent.Items.Add(listViewItem2);
            this.lw_dircontent.Items.Add(listViewItem3);
            this.lw_dircontent.Location = new System.Drawing.Point(3, 30);
            this.lw_dircontent.Name = "lw_dircontent";
            this.lw_dircontent.Size = new System.Drawing.Size(234, 235);
            this.lw_dircontent.SmallImageList = this.imglist_Icons;
            this.lw_dircontent.TabIndex = 2;
            this.lw_dircontent.View = System.Windows.Forms.View.List;
            this.lw_dircontent.ItemActivate += new System.EventHandler(this.lw_dircontent_ItemActivate);
            this.imglist_Icons.Images.Clear();
            this.imglist_Icons.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imglist_Icons.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imglist_Icons.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.Add(this.menuItem_cancel);
            this.mainMenu.MenuItems.Add(this.menuItem_selectdir);
            // 
            // menuItem_cancel
            // 
            this.menuItem_cancel.Text = "Cancel";
            this.menuItem_cancel.Click += new System.EventHandler(this.menuItem_cancel_Click);
            // 
            // menuItem_selectdir
            // 
            this.menuItem_selectdir.Text = "Select";
            this.menuItem_selectdir.Click += new System.EventHandler(this.menuItem_selectdir_Click);
            // 
            // FormOpenFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.lw_dircontent);
            this.Controls.Add(this.tb_Dir);
            this.Menu = this.mainMenu;
            this.MinimizeBox = false;
            this.Name = "FormOpenFile";
            this.Text = "Select a file";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Dir;
        private System.Windows.Forms.ListView lw_dircontent;
        private System.Windows.Forms.ImageList imglist_Icons;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItem_cancel;
        private System.Windows.Forms.MenuItem menuItem_selectdir;
    }
}
