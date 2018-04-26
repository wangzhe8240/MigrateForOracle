namespace Migrate.Clients
{
    partial class LoginForm
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
            this.password = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.Label();
            this.instace = new System.Windows.Forms.Label();
            this.textUserId = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.textport = new System.Windows.Forms.TextBox();
            this.textInstance = new System.Windows.Forms.TextBox();
            this.test = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.isDBA = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // host
            // 
            this.host.AutoSize = true;
            this.host.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.host.Location = new System.Drawing.Point(131, 25);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(70, 12);
            this.host.TabIndex = 0;
            this.host.Text = "主机地址：";
            // 
            // textHost
            // 
            this.textHost.Location = new System.Drawing.Point(250, 20);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(175, 23);
            this.textHost.TabIndex = 1;
            this.textHost.Text = "localhost";
            // 
            // userid
            // 
            this.userid.AutoSize = true;
            this.userid.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userid.Location = new System.Drawing.Point(131, 66);
            this.userid.Name = "userid";
            this.userid.Size = new System.Drawing.Size(57, 12);
            this.userid.TabIndex = 2;
            this.userid.Text = "用户名：";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password.Location = new System.Drawing.Point(131, 109);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(44, 12);
            this.password.TabIndex = 3;
            this.password.Text = "密码：";
            // 
            // port
            // 
            this.port.AutoSize = true;
            this.port.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.port.Location = new System.Drawing.Point(131, 155);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(57, 12);
            this.port.TabIndex = 4;
            this.port.Text = "端口号：";
            // 
            // instace
            // 
            this.instace.AutoSize = true;
            this.instace.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.instace.Location = new System.Drawing.Point(131, 201);
            this.instace.Name = "instace";
            this.instace.Size = new System.Drawing.Size(70, 12);
            this.instace.TabIndex = 5;
            this.instace.Text = "服务实例：";
            // 
            // textUserId
            // 
            this.textUserId.AutoCompleteCustomSource.AddRange(new string[] {
            "SYSTEM",
            "SCOTT"});
            this.textUserId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textUserId.Location = new System.Drawing.Point(250, 61);
            this.textUserId.Name = "textUserId";
            this.textUserId.Size = new System.Drawing.Size(175, 23);
            this.textUserId.TabIndex = 7;
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPassword.Location = new System.Drawing.Point(250, 104);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(175, 23);
            this.textPassword.TabIndex = 8;
            // 
            // textport
            // 
            this.textport.Location = new System.Drawing.Point(250, 150);
            this.textport.Name = "textport";
            this.textport.Size = new System.Drawing.Size(175, 23);
            this.textport.TabIndex = 9;
            this.textport.Text = "1521";
            // 
            // textInstance
            // 
            this.textInstance.Location = new System.Drawing.Point(250, 196);
            this.textInstance.Name = "textInstance";
            this.textInstance.Size = new System.Drawing.Size(175, 23);
            this.textInstance.TabIndex = 10;
            this.textInstance.Text = "orcl";
            // 
            // test
            // 
            this.test.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.test.Location = new System.Drawing.Point(409, 267);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(72, 33);
            this.test.TabIndex = 12;
            this.test.Text = "测试";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login.Location = new System.Drawing.Point(503, 267);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(68, 33);
            this.login.TabIndex = 13;
            this.login.Text = "登录";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.Login_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(461, 109);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "显示";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // isDBA
            // 
            this.isDBA.AutoSize = true;
            this.isDBA.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.isDBA.Location = new System.Drawing.Point(250, 239);
            this.isDBA.Name = "isDBA";
            this.isDBA.Size = new System.Drawing.Size(80, 18);
            this.isDBA.TabIndex = 15;
            this.isDBA.Text = "DBA登录";
            this.isDBA.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 307);
            this.Controls.Add(this.isDBA);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.login);
            this.Controls.Add(this.test);
            this.Controls.Add(this.textInstance);
            this.Controls.Add(this.textport);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUserId);
            this.Controls.Add(this.instace);
            this.Controls.Add(this.port);
            this.Controls.Add(this.password);
            this.Controls.Add(this.userid);
            this.Controls.Add(this.textHost);
            this.Controls.Add(this.host);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label host;
        private System.Windows.Forms.TextBox textHost;
        private System.Windows.Forms.Label userid;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label port;
        private System.Windows.Forms.Label instace;
        private System.Windows.Forms.TextBox textUserId;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textport;
        private System.Windows.Forms.TextBox textInstance;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Button login;
        private System.Windows.Forms.CheckBox isDBA;
    }
}