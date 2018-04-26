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
    public partial class ExecutingForm : Form
    {
        public ExecutingForm()
        {
            InitializeComponent();
        }

        public void UpdateProcess(float value)
        {
            // 跨线程调用控件
            if (progressBar.InvokeRequired)
            {
                Action<float> dele = (x) =>
                {
                    progressBar.Value = (int)(value * 100);
                };
                txtMsg.BeginInvoke(dele, value);
            }
            else
            {
                progressBar.Value = (int)(value * 100);
            }
        }

        public void UpdateMessage(string msg)
        {
            if (txtMsg.InvokeRequired)
            {
                Action<string> dele = (x) =>
                 {
                     txtMsg.AppendText($"{msg}\r\n");
                     txtMsg.ScrollToCaret();
                 };
                txtMsg.BeginInvoke(dele, msg);
            }
            else
            {
                txtMsg.AppendText($"{msg}\r\n");
                txtMsg.ScrollToCaret();
            }


        }
    }
}
