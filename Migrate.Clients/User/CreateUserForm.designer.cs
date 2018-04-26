namespace Migrate.Client.ClientForms
{
    partial class CreateUserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.user_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.user_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.user_defaultTablespace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.user_TempTablespace = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(191, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // user_Name
            // 
            this.user_Name.Location = new System.Drawing.Point(320, 64);
            this.user_Name.Multiline = true;
            this.user_Name.Name = "user_Name";
            this.user_Name.Size = new System.Drawing.Size(203, 21);
            this.user_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(191, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // user_password
            // 
            this.user_password.Location = new System.Drawing.Point(320, 134);
            this.user_password.Multiline = true;
            this.user_password.Name = "user_password";
            this.user_password.Size = new System.Drawing.Size(203, 23);
            this.user_password.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(165, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "默认表空间：";
            // 
            // user_defaultTablespace
            // 
            this.user_defaultTablespace.Location = new System.Drawing.Point(320, 210);
            this.user_defaultTablespace.Multiline = true;
            this.user_defaultTablespace.Name = "user_defaultTablespace";
            this.user_defaultTablespace.Size = new System.Drawing.Size(203, 21);
            this.user_defaultTablespace.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(165, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "临时表空间：";
            // 
            // user_TempTablespace
            // 
            this.user_TempTablespace.Location = new System.Drawing.Point(320, 290);
            this.user_TempTablespace.Multiline = true;
            this.user_TempTablespace.Name = "user_TempTablespace";
            this.user_TempTablespace.Size = new System.Drawing.Size(203, 23);
            this.user_TempTablespace.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(564, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Confirm_click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(564, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 21);
            this.button2.TabIndex = 9;
            this.button2.Text = "点击选择";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ChoseDefault_click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(564, 290);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "点击选择";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ChoseTemp_click);
            // 
            // CreateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.user_TempTablespace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.user_defaultTablespace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.user_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.user_Name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateUserForm";
            this.Text = "创建用户";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox user_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox user_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox user_defaultTablespace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox user_TempTablespace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}