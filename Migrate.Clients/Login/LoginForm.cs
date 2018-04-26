using Migrate.Client.ClientForms;
using Migrate.Domain.Helper.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Migrate.Application.App;

namespace Migrate.Clients
{
    public partial class LoginForm : Form
    {
        public string _textHost = string.Empty;
        public string _textUserId = string.Empty;
        public string _textPassword = string.Empty;
        public string _textport = string.Empty;
        public string _textInstance = string.Empty;
        public bool _isDBA = false;
        Application.App.LoginApp app = new Application.App.LoginApp();

        public LoginForm()
        {
            InitializeComponent();
        }

        private ConnectString getConnString()
        {
            string _textHost = this.textHost.Text.Trim();
            string _textUserId = this.textUserId.Text.Trim();
            string _textPassword = this.textPassword.Text.Trim();
            string _textport = this.textport.Text.Trim();
            string _textInstance = this.textInstance.Text.Trim();
            if (isDBA.Checked)
            {
                _isDBA = true;
            }
            else
            {
                _isDBA = false;
            }
            return new ConnectString()
            {
                Host = _textHost,
                Port = _textport,
                Instance = _textInstance,
                UserId = _textUserId,
                Password = _textPassword,
                IsDBA = _isDBA
            };
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (CheckMethod())
            {
                ConnectString conn = getConnString();
                try
                {
                    app.LoginConnection(conn);
                    MessageBox.Show("登录成功");
                    this.DialogResult = DialogResult.OK;
                    Context.connString = conn;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void test_Click(object sender, EventArgs e)
        {
            if (CheckMethod())
            {
                ConnectString conn = getConnString();
                try
                {
                    app.TestConnection(conn);
                    MessageBox.Show("连接测试成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("连接测试失败");
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private bool CheckMethod()
        {
            if (textHost.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入主机地址");
                return false;
            }
            if (textUserId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入用户名");
                return false;
            }
            if (textPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入用户密码");
                return false;
            }
            if (textport.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入端口号");
                return false;
            }
            if (textInstance.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入服务实例");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 显示密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                textPassword.PasswordChar = '*';
            else
                textPassword.PasswordChar = (char)0;
        }

    }
}
