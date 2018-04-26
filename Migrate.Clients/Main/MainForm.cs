using Migrate.Clients;
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
using Migrate.Domain.Helper;

namespace Migrate.Client.ClientForms
{
    using Clients.Contrains;
    using Clients.DeleteData;
    using Application = System.Windows.Forms.Application;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }       
        
        private void Createtablespace_click(object sender, EventArgs e)
        {
            CreateTableSpaceForm tablespace = new CreateTableSpaceForm();
            tablespace.MdiParent = this;
            tablespace.Parent = this.panel1;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(tablespace);
            tablespace.Dock = DockStyle.Fill;
            tablespace.Show();         
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            CreateUserForm user = new CreateUserForm();
            user.MdiParent = this;
            user.Parent = this.panel1;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(user);
            user.Dock = DockStyle.Fill;
            user.Show();
        }

        private void CreateRole_click(object sender, EventArgs e)
        {
            AuthorizeRoleForm role = new AuthorizeRoleForm();
            role.MdiParent = this;
            role.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(role);
            role.Dock = DockStyle.Fill;
            role.Show();         
        }

        private void OpeationTable_click(object sender, EventArgs e)
        {
            OperationTableForm deleteTable = new OperationTableForm();
            deleteTable.MdiParent = this;
            deleteTable.Parent = this.panel1;
            deleteTable.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(deleteTable);
            deleteTable.Dock = DockStyle.Fill;
            deleteTable.Show();
            
        }

        private void CreateTable_Click(object sender, EventArgs e)
        {
            CreateTable table = new CreateTable();
            table.MdiParent = this;
            table.Parent = this.panel1;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(table);
            table.Dock = DockStyle.Fill;
            table.Show();
        }

        private void D2D_Click(object sender, EventArgs e)
        {
            ScheduleForm export = new ScheduleForm();
            export.MdiParent = this;
            export.Parent = this.panel1;
            export.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(export);
            export.Dock = DockStyle.Fill;
            export.Show();

            //Migrate.Clients.Login.FormMain form = new Clients.Login.FormMain();
            //form.Show();
        }   

        private void DeteleUser_Click(object sender, EventArgs e)
        {
            DeteleUserForm user = new DeteleUserForm();
            user.MdiParent = this;
            user.Parent = this.panel1;
            user.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(user);
            user.Dock = DockStyle.Fill;
            user.Show();
        }

        private void DeteleDate_Click(object sender, EventArgs e)
        {
            DeteleDateForm date = new DeteleDateForm();
            date.MdiParent = this;
            date.Parent = this.panel1;
            date.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(date);
            date.Dock = DockStyle.Fill;
            date.Show();
        }
        private void ConstraintsInfo_Click(object sender, EventArgs e)
        {
            ContraintsOperation date = new ContraintsOperation();
            date.MdiParent = this;
            date.Parent = this.panel1;
            date.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(date);
            date.Dock = DockStyle.Fill;
            date.Show();
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void DeteleTableSpace_Click(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// 重新登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void LoginAgain_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            Application.Restart();
        }

        /// <summary>
        /// 系统退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Dispose();
                this.Close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
               
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExScheduleForm export = new ExScheduleForm();
            export.MdiParent = this;
            export.Parent = this.panel1;
            export.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(export);
            export.Dock = DockStyle.Fill;
            export.Show();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImScheduleForm export = new ImScheduleForm();
            export.MdiParent = this;
            export.Parent = this.panel1;
            export.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(export);
            export.Dock = DockStyle.Fill;
            export.Show();
        }
    }
}
