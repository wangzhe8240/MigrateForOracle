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
    public partial class DeteleUserForm : Form
    {
        Application.App.UserApp app = new Application.App.UserApp();

        public DeteleUserForm()
        {
            InitializeComponent();
        }

        private void Detele_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            List<string> deteleuserList = new List<string>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].FormattedValue.Equals(true))
                {
                    deteleuserList.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                }
            }

            for (int j = 0; j < deteleuserList.Count; j++)
            {
                for (int k = 0; k < dataGridView1.Rows.Count; k++)
                {
                    if (dataGridView1.Rows[k].Cells[1].Value.ToString().CompareTo(deteleuserList[j]) == 0)
                    {
                        try
                        {
                            app.Drop(Context.connString, deteleuserList[j]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }               
                        dataGridView1.DataSource = app.GetAllUser(Context.connString);
                    }
                }
            }
            MessageBox.Show("删除表成功");
        }

        private void DeteleUser_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = app.GetAllUser(Context.connString);
        }
    }
}
