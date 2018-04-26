using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Migrate.Application.App;
using Migrate.Clients;
using Migrate.Domain.Model;

namespace Migrate.Client.ClientForms
{
    public partial class CreateUserForm : Form
    {

        string _user_Name = string.Empty;
        string _user_password = string.Empty;
        string _user_defaultTablespace = string.Empty;
        string _user_TempTablespace = string.Empty;

        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void ChoseDefault_click(object sender, EventArgs e)
        {
            ChooseTableSpace choose = new ChooseTableSpace();
            choose.ShowDialog();
        }

        private void ChoseTemp_click(object sender, EventArgs e)
        {
            ChooseTableSpace choose = new ChooseTableSpace();
            choose.ShowDialog();
        }

        private void Confirm_click(object sender, EventArgs e)
        {
            string _user_Name = this.user_Name.Text.Trim();
            string _user_password = this.user_password.Text.Trim();
            string _user_defaultTablespace = this.user_defaultTablespace.Text.Trim();
            string _user_TempTablespace = this.user_TempTablespace.Text.Trim();

            Application.App.UserApp app = new Application.App.UserApp();
            User user = new User()
            {
                Name=_user_Name,
                Password=_user_password,
                DefaultTablespace=_user_defaultTablespace,
                TempTablespace=_user_TempTablespace
            };
            try
            {
                app.Create(Context.connString, user);
                MessageBox.Show("创建用户成功");
                Context.UserName = Name;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
