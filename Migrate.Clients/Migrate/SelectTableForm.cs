using Migrate.Application.Model;
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
    public partial class SelectTableForm : Form
    {
        public bool _chooseAll = false;
        Application.App.TableApp app = new Application.App.TableApp();
        public SelectTableForm()
        {
            InitializeComponent();
        }

        public IEnumerable<TableProfile> DataSource
        {
            get
            {
                return (IEnumerable<TableProfile>)dataGridView1.DataSource;
            }
            set
            {
                dataGridView1.DataSource = value;
            }
        }

        public IEnumerable<TableProfile> GetSelected()
        {
            IList<TableProfile> list = new List<TableProfile>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].FormattedValue.Equals(true))
                {
                    string name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    list.Add(DataSource.Where(item => item.TableName == name).FirstOrDefault());
                }
            }
            return list;
        }

        public void UpdateDateGridView()
        {
            List<string> Exportlist = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].FormattedValue.Equals(true))
                {
                    Exportlist.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    string _name = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    IEnumerable<Migrate.Application.Model.TableProfile> list = (IEnumerable<Migrate.Application.Model.TableProfile>)dataGridView1.DataSource;
                    var li = list.Where(item => item.TableName == _name).FirstOrDefault();

                    IList<TableProfile> ImpTables = new List<TableProfile>()
                    {

                    };
                }


            }
        }
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
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
