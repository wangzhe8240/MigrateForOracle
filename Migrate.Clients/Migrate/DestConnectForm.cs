using Migrate.Domain.Helper.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrate.Clients
{
    public partial class DestConnectForm : Form
    {
        public string _textHost = string.Empty;
        public string _textUserId = string.Empty;
        public string _textPassword = string.Empty;
        public string _textport = string.Empty;
        public string _textInstance = string.Empty;
        public bool _isDBA = false;
        Application.App.LoginApp app = new Application.App.LoginApp();
        public DestConnectForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主机名
        /// </summary>
        public string Host
        {
            get
            {
                return textHost.Text.Trim();
            }
        }

        public string UserId
        {
            get
            {
                return textUserId.Text.Trim();
            }
        }

        public string Password
        {
            get
            {
                return textPassword.Text.Trim();
            }
        }

        public string Port
        {
            get
            {
                return textport.Text.Trim();
            }
        }

        public string Instance
        {
            get
            {
                return textInstance.Text.Trim();
            }
        }

        public string Tablespace
        {
            get
            {
                return textTablespace.Text.Trim();
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (CheckMethod())
            {
                string _textHost = this.textHost.Text.Trim();
                string _textUserId = this.textUserId.Text.Trim();
                string _textPassword = this.textPassword.Text.Trim();
                string _textport = this.textport.Text.Trim();
                string _textInstance = this.textInstance.Text.Trim();
                ConnectString conn = new ConnectString()
                {
                    Host = _textHost,
                    Port = _textport,
                    Instance = _textInstance,
                    UserId = _textUserId,
                    Password = _textPassword
                };
                try
                {
                    app.TestConnection(conn);
                    MessageBox.Show("连接成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("连接失败");
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool CheckMethod()
        {
            if (Host.Length == 0)
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
    }
}
