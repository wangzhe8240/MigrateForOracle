using Migrate.Clients;
using Migrate.Domain.Helper;
using Migrate.Domain.Helper.Access;
using Migrate.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrate.Client.ClientForms
{
    public partial class CreateTableSpaceForm : Form
    {

        private Migrate.Domain.Model.Tablespace space { get; set; }
        string _Name = string.Empty;
        public bool _isAutoextend = false;
        string _path = "";

        public CreateTableSpaceForm()
        {
            InitializeComponent();
        }
       
        private void Confirm_click(object sender, EventArgs e)
        {
            if (tablespace_Name.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入表空间名称");
                return;
            }
            if (tablespace_size.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入文件大小");
                return;
            }
            if (tablespace_Extendsize.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入增量");
                return;
            }
            if (tablespace_Maxsize.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入最大文件大小");
                return;
            }
            string _Name = this.tablespace_Name.Text.Trim();
            string _path = Tablespaces.GetStorePath(Context.connString);
            //this.tablespace_path.Text = _path;
            //if(this.tablespace_path.Text.Trim().Equals(Tablespaces.GetStorePath(Context.connString)))
            //{
            //     _path = Tablespaces.GetStorePath(Context.connString);
            //}
            //else
            //{
            //     _path = this.tablespace_path.Text.Trim();
            //}
            int _size = int.Parse(this.tablespace_size.Text.ToString()) ;
            if (isAutoextend.Checked==true)
            {
                _isAutoextend = true;
            }
            else
            {
                _isAutoextend = false;
            }
            int _Extendsize = int.Parse(this.tablespace_Extendsize.Text.Trim());
            int _Maxsize = int.Parse(this.tablespace_Maxsize.Text.Trim());
            Migrate.Application.App.TablespaceApp app = new Application.App.TablespaceApp();
            Tablespace space = new Tablespace()
            {
                Name = _Name,
                Path =Path.Combine(_path, _Name+( ".DBF")),
                Size = _size,
                AutoExtend = _isAutoextend,
                ExtendSize = _Extendsize,
                MaxSize = _Maxsize
            };
            try
            {
                app.Create(Context.connString, space);
                MessageBox.Show("创建成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }             
        }

        private void CreateTableSpaceForm_Load(object sender, EventArgs e)
        {
            string _path = Tablespaces.GetStorePath(Context.connString);
            this.tablespace_path.Text = _path;
        }

        private void Fileload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdlg = new FolderBrowserDialog();
            folderBrowserDialog1.ShowDialog();
            this.tablespace_path.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
