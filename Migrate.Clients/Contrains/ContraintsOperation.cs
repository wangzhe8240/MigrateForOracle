using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrate.Clients.Contrains
{
    public partial class ContraintsOperation : Form
    {
        Application.App.ContraintsApp app = new Application.App.ContraintsApp();

        public ContraintsOperation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 启用约束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableConstraint_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要启用约束吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].FormattedValue.Equals(true))
                {
                    try
                    {
                        app.Enable(Context.connString, dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            MessageBox.Show("启用约束成功");
        }

        private void DisableContraint_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要禁用约束吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;         
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].FormattedValue.Equals(true))
                {
                    try
                    {
                        app.EnaEnable(Context.connString, dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            MessageBox.Show("禁用约束成功");
        } 

        private void Drop_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要删除约束吗？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //List<string> deteleList = new List<string>();        
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].FormattedValue.Equals(true))
                {
                    //deteleList.Add(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    try
                    {
                        app.Drop(Context.connString, dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString());
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
                     
            MessageBox.Show("删除约束成功");
        }

        private void ContraintsOperation_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = app.GetOwnerConstraints(Context.connString);
        }
       
    }
}
