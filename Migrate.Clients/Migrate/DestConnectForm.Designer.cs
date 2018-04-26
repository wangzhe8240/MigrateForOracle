namespace Migrate.Clients
{
    partial class DestConnectForm
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
            this.host = new System.Windows.Forms.Label();
            this.textHost = new System.Windows.Forms.TextBox();
            this.userid = new System.Windows.Forms.Label();
            this.textUserId = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.Label();
            this.textport = new System.Windows.Forms.TextBox();
            this.instace = new System.Windows.Forms.Label();
            this.textInstance = new System.Windows.Forms.TextBox();
            this.test = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textTablespace = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // host
            // 
            this.host.AutoSize = true;
            this.host.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.host.Location = new System.Drawing.Point(194, 51);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(70, 12);
            this.host.TabIndex = 1;
            this.host.Text = "主机地址：";
            // 
            // textHost
            // 
            this.textHost.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textHost.Location = new System.Drawing.Point(311, 48);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(207, 21);
            this.textHost.TabIndex = 2;
            this.textHost.Text = "localhost";
            // 
            // userid
            // 
            this.userid.AutoSize = true;
            this.userid.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userid.Location = new System.Drawing.Point(194, 97);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(57, 12);
            this.userid.TabIndex = 3;
            this.userid.Text = "用户名：";
            // 
            // textUserId
            // 
            this.textUserId.AutoCompleteCustomSource.AddRange(new string[] {
            "SYSTEM",
            "SCOTT"});
            this.textUserId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textUserId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textUserId.Location = new System.Drawing.Point(311, 88);
            this.textUserId.Name = "textUserId";
            this.textUserId.Size = new System.Drawing.Size(207, 21);
            this.textUserId.TabIndex = 8;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password.Location = new System.Drawing.Point(194, 144);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(44, 12);
            this.password.TabIndex = 9;
            this.password.Text = "密码：";
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPassword.Location = new System.Drawing.Point(311, 133);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(207, 23);
            this.textPassword.TabIndex = 10;
            // 
            // port
            // 
            this.port.AutoSize = true;
            this.port.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.port.Location = new System.Drawing.Point(194, 190);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(57, 12);
            this.port.TabIndex = 11;
            this.port.Text = "端口号：";
            // 
            // textport
            // 
            this.textport.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textport.Location = new System.Drawing.Point(311, 181);
            this.textport.Name = "textport";
            this.textport.Size = new System.Drawing.Size(207, 21);
            this.textport.TabIndex = 12;
            this.textport.Text = "1521";
            // 
            // instace
            // 
            this.instace.AutoSize = true;
            this.instace.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.instace.Location = new System.Drawing.Point(194, 235);
            this.instace.Name = "instace";
            this.instace.Size = new System.Drawing.Size(70, 12);
            this.instace.TabIndex = 13;
            this.instace.Text = "服务实例：";
            // 
            // textInstance
            // 
            this.textInstance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textInstance.Location = new System.Drawing.Point(311, 232);
            this.textInstance.Name = "textInstance";
            this.textInstance.Size = new System.Drawing.Size(207, 21);
            this.textInstance.TabIndex = 14;
            this.textInstance.Text = "orcl";
            // 
            // test
            // 
            this.test.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.test.Location = new System.Drawing.Point(580, 285);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(72, 25);
            this.test.TabIndex = 15;
            this.test.Text = "测试";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.Connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(54, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 14);
            this.label1.TabIndex = 16;
            this.label1.Text = "目标数据库连接：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(194, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "表空间：";
            // 
            // textTablespace
            // 
            this.textTablespace.Location = new System.Drawing.Point(311, 285);
            this.textTablespace.Name = "textTablespace";
            this.textTablespace.Size = new System.Drawing.Size(207, 21);
            this.textTablespace.TabIndex = 18;
            // 
            // DestConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 340);
            this.Controls.Add(this.textTablespace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.test);
            this.Controls.Add(this.textInstance);
            this.Controls.Add(this.instace);
            this.Controls.Add(this.textport);
            this.Controls.Add(this.port);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.password);
            this.Controls.Add(this.textUserId);
            this.Controls.Add(this.userid);
            this.Controls.Add(this.textHost);
            this.Controls.Add(this.host);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DestConnectForm";
            this.Text = "目标数据库登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label host;
        private System.Windows.Forms.TextBox textHost;
        private System.Windows.Forms.Label userid;
        private System.Windows.Forms.TextBox textUserId;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label port;
        private System.Windows.Forms.TextBox textport;
        private System.Windows.Forms.Label instace;
        private System.Windows.Forms.TextBox textInstance;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTablespace;
    }
}