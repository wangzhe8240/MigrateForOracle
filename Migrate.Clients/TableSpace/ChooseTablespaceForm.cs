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
    public partial class ChooseTableSpace : Form
    {
        Application.App.TablespaceApp app = new Application.App.TablespaceApp();
        public ChooseTableSpace()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tablespace_Load(object sender, EventArgs e)
        {
                  
                
        }


        private void Select_Click(object sender, EventArgs e)
        {

        }
    }
}
