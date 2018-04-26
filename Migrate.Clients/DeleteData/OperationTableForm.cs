using Migrate.Clients;
using Migrate.Domain.Helper.Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Migrate.Client.ClientForms
{
    public partial class OperationTableForm : Form
    {
        //public List<string> list = new List<string>();
        public bool _chooseAll = false;
        Application.App.TableApp app = new Application.App.TableApp();

        public OperationTableForm()
        {
            InitializeComponent();
        }

        private void OperTable_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= app.GetAlltable(Context.connString);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detele_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                            app.Drop(Context.connString, deteleList[j]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        //dataGridView1.Rows.RemoveAt(k);
                        dataGridView1.DataSource= app.GetAlltable(Context.connString);
                    }
                }
            }
            MessageBox.Show("删除表成功");
        }


        /// <summary>
        /// 全选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseAll_Click(object sender, EventArgs e)
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
    }
}
