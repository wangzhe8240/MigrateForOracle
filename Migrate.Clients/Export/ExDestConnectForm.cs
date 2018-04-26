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
using System.IO;

namespace Migrate.Clients
{
    public partial class ExDestConnectForm : Form
    {
        public ExDestConnectForm()
        {
            InitializeComponent();
        }

        public string TargetFile
        {
            get
            {
                string dir = txtDir.Text;
                string file = Path.GetFileNameWithoutExtension(txtFileName.Text) + ".migx";
                return Path.Combine(dir, file);
            }
        }

        /// <summary>
        /// 表单验证
        /// </summary>
        /// <returns></returns>
        public bool FormValidate()
        {
            if (string.IsNullOrEmpty(txtDir.Text))
            {
                MessageBox.Show("未指定目录", "表单验证");
                txtDir.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("未指定文件名", "表单验证");
                txtFileName.Focus();
                return false;
            }

            return true;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
