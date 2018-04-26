namespace Migrate.Client.ClientForms
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.创建表空间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建表空间ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.创建用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建用户ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.授权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.角色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deteleDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d2dToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.约束操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启用约束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EXITToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建表空间ToolStripMenuItem,
            this.创建用户ToolStripMenuItem,
            this.授权ToolStripMenuItem,
            this.表操作ToolStripMenuItem,
            this.ProfileToolStripMenuItem,
            this.约束操作ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(817, 25);
            this.menuStrip2.TabIndex = 5;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 创建表空间ToolStripMenuItem
            // 
            this.创建表空间ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建表空间ToolStripMenuItem1});
            this.创建表空间ToolStripMenuItem.Name = "创建表空间ToolStripMenuItem";
            this.创建表空间ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.创建表空间ToolStripMenuItem.Text = "表空间操作";
            // 
            // 创建表空间ToolStripMenuItem1
            // 
            this.创建表空间ToolStripMenuItem1.Name = "创建表空间ToolStripMenuItem1";
            this.创建表空间ToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.创建表空间ToolStripMenuItem1.Text = "创建表空间";
            this.创建表空间ToolStripMenuItem1.Click += new System.EventHandler(this.Createtablespace_click);
            // 
            // 创建用户ToolStripMenuItem
            // 
            this.创建用户ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建用户ToolStripMenuItem1});
            this.创建用户ToolStripMenuItem.Name = "创建用户ToolStripMenuItem";
            this.创建用户ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.创建用户ToolStripMenuItem.Text = "用户操作";
            // 
            // 创建用户ToolStripMenuItem1
            // 
            this.创建用户ToolStripMenuItem1.Name = "创建用户ToolStripMenuItem1";
            this.创建用户ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.创建用户ToolStripMenuItem1.Text = "创建用户";
            this.创建用户ToolStripMenuItem1.Click += new System.EventHandler(this.CreateUser_Click);
            // 
            // 授权ToolStripMenuItem
            // 
            this.授权ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.角色ToolStripMenuItem});
            this.授权ToolStripMenuItem.Name = "授权ToolStripMenuItem";
            this.授权ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.授权ToolStripMenuItem.Text = "授权";
            // 
            // 角色ToolStripMenuItem
            // 
            this.角色ToolStripMenuItem.Name = "角色ToolStripMenuItem";
            this.角色ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.角色ToolStripMenuItem.Text = "角色";
            this.角色ToolStripMenuItem.Click += new System.EventHandler(this.CreateRole_click);
            // 
            // 表操作ToolStripMenuItem
            // 
            this.表操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除表ToolStripMenuItem,
            this.deteleDateToolStripMenuItem});
            this.表操作ToolStripMenuItem.Name = "表操作ToolStripMenuItem";
            this.表操作ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.表操作ToolStripMenuItem.Text = "数据删除操作";
            // 
            // 删除表ToolStripMenuItem
            // 
            this.删除表ToolStripMenuItem.Name = "删除表ToolStripMenuItem";
            this.删除表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除表ToolStripMenuItem.Text = "删除表";
            this.删除表ToolStripMenuItem.Click += new System.EventHandler(this.OpeationTable_click);
            // 
            // deteleDateToolStripMenuItem
            // 
            this.deteleDateToolStripMenuItem.Name = "deteleDateToolStripMenuItem";
            this.deteleDateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deteleDateToolStripMenuItem.Text = "删除数据";
            this.deteleDateToolStripMenuItem.Click += new System.EventHandler(this.DeteleDate_Click);
            // 
            // ProfileToolStripMenuItem
            // 
            this.ProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d2dToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem});
            this.ProfileToolStripMenuItem.Name = "ProfileToolStripMenuItem";
            this.ProfileToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.ProfileToolStripMenuItem.Text = "数据迁移";
            // 
            // d2dToolStripMenuItem
            // 
            this.d2dToolStripMenuItem.Name = "d2dToolStripMenuItem";
            this.d2dToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.d2dToolStripMenuItem.Text = "数据库到数据库...";
            this.d2dToolStripMenuItem.Click += new System.EventHandler(this.D2D_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exportToolStripMenuItem.Text = "数据库到文件...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.importToolStripMenuItem.Text = "文件到数据库...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // 约束操作ToolStripMenuItem
            // 
            this.约束操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启用约束ToolStripMenuItem});
            this.约束操作ToolStripMenuItem.Name = "约束操作ToolStripMenuItem";
            this.约束操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.约束操作ToolStripMenuItem.Text = "约束操作";
            // 
            // 启用约束ToolStripMenuItem
            // 
            this.启用约束ToolStripMenuItem.Name = "启用约束ToolStripMenuItem";
            this.启用约束ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.启用约束ToolStripMenuItem.Text = "约束信息";
            this.启用约束ToolStripMenuItem.Click += new System.EventHandler(this.ConstraintsInfo_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newLoginToolStripMenuItem,
            this.EXITToolStripMenuItem1});
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.退出ToolStripMenuItem.Text = "系统操作";
            // 
            // newLoginToolStripMenuItem
            // 
            this.newLoginToolStripMenuItem.Name = "newLoginToolStripMenuItem";
            this.newLoginToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.newLoginToolStripMenuItem.Text = "重新登录";
            this.newLoginToolStripMenuItem.Click += new System.EventHandler(this.LoginAgain_Click);
            // 
            // EXITToolStripMenuItem1
            // 
            this.EXITToolStripMenuItem1.Name = "EXITToolStripMenuItem1";
            this.EXITToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.EXITToolStripMenuItem1.Text = "退出";
            this.EXITToolStripMenuItem1.Click += new System.EventHandler(this.Exit_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 450);
            this.panel1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 478);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "客户端";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 创建表空间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 授权ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 角色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除表ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 创建表空间ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 创建用户ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem d2dToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EXITToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deteleDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 约束操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启用约束ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
    }
}