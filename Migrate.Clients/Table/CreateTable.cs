using Migrate.Domain.Model;
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
    public partial class CreateTable : Form
    {
        public CreateTable()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Application.App.TableApp app = new Application.App.TableApp();
            Table table = new Table()
            {
                
            };
            try
            {
                app.Create(Context.connString, table);
                MessageBox.Show("创建表成功");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
