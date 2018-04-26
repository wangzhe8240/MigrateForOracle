using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrate.Clients
{
    using Client.ClientForms;
    using Domain.Helper.Access;
    using Application = System.Windows.Forms.Application;
     
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm form = new LoginForm();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                Application.Run(new MainForm());
            }          
        }
    }
}
