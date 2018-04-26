using Migrate.Application.Model;
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
    public partial class ImSelectFileForm : Form
    {
        public bool _chooseAll = false;
        Application.App.TableApp app = new Application.App.TableApp();
        public ImSelectFileForm()
        {
            InitializeComponent();
        }

        public string File
        {
            get
            {
                return txtFile.Text;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "迁移文件|*.migx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog1.FileName;
            }
        }
    }
}
