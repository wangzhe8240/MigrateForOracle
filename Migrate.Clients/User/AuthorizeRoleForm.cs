using Migrate.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrate.Client.ClientForms
{
    public partial class AuthorizeRoleForm : Form
    {

        Application.App.UserApp app = new Application.App.UserApp();
        string _UserName = string.Empty;

        public AuthorizeRoleForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 可用角色选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AvailableRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 所选角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Selectrole_SelectIndexChange(object sender, EventArgs e)
        {      
            //MessageBox.Show(listBox2.SelectedItems[0].ToString());
            //this.textBox1.Text = this.listBox2.SelectedItem.ToString();
            //for (int i = 0; i < listBox2.Items.Count;i++)
            //{
            //    MessageBox.Show(listBox2.Items[i].ToString());
            //}
        }

        /// <summary>
        /// 添加角色按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, EventArgs e)
        {
            //listBox2.Items.Clear();
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                listBox2.Items.Add(listBox1.SelectedItems[i]);
                listBox1.Items.RemoveAt(listBox1.FindString(listBox1.SelectedItems[i].ToString()));
                i--;
            }
        }

        /// <summary>
        /// 移除角色按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox2.SelectedItems.Count; i++)
            {
                listBox1.Items.Add(listBox2.SelectedItems[i]);
                listBox2.Items.RemoveAt(listBox2.FindString(listBox2.SelectedItems[i].ToString()));
                i--;
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            string _UserName = this.textUserName.Text.Trim();
            try
            {
                List<string> list = new List<string>();
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    list.Add(listBox2.Items[i].ToString());
                }
                string[] roles = list.ToArray();
                app.Grant(Context.connString, _UserName, roles);
                MessageBox.Show("授权成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
