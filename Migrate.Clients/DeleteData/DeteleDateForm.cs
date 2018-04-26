using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrate.Clients.DeleteData
{
    public partial class DeteleDateForm : Form
    {
        public bool _chooseAll = false;
        Application.App.TableApp app = new Application.App.TableApp();
        public DeteleDateForm()
        {
            InitializeComponent();
        }
       

        private void Detele_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除表的数据吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            List<string> deteleList = new List<string>();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].FormattedValue.Equals(true))
                {
                    deteleList.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                }
            }

            for (int j = 0; j < deteleList.Count; j++)
            {
                for (int k = 0; k < dataGridView1.Rows.Count; k++)
                {
                    if (dataGridView1.Rows[k].Cells[1].Value.ToString().CompareTo(deteleList[j]) == 0)
                    {
                         
                        try
                        {
                            app.DropDate(Context.connString, deteleList[j]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        dataGridView1.DataSource = app.GetAlltable(Context.connString);
                    }
                }
            }
            MessageBox.Show("删除数据成功");
        }

        private void Seclect_Click(object sender, EventArgs e)
        {
            _chooseAll = !_chooseAll;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[0].EditedFormattedValue)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = false;
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[0].Value = true;
                    }
                }
            }
        }

        private void Date_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = app.GetAlltable(Context.connString);
        }
    }
}
