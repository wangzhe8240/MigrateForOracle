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
    public partial class DeteleTableSpaceForm : Form
    {
        Application.App.TablespaceApp app = new Application.App.TablespaceApp();

        public DeteleTableSpaceForm()
        {
            InitializeComponent();
        }

        private void Detele_Click(object sender, EventArgs e)
        {

        }

        private void DeteleTableSpace_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = app.GetAllTableSpaces(Context.connString);
        }
    }
}
