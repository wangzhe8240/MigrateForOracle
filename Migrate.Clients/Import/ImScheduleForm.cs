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
    public partial class ImScheduleForm : Form
    {
        public ImScheduleForm()
        {
            InitializeComponent();
            SelectTable = new ImSelectFileForm();
            DestConnect = new ImDestConnectForm();
            Executing = new ImExecutingForm();
        }

        protected ImSelectFileForm SelectTable { get; private set; }

        protected ImDestConnectForm DestConnect { get; private set; }

        protected ImExecutingForm Executing { get; private set; }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            ShowForm(SelectTable);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.btnNext.Enabled = false;
            this.btnAct.Enabled = true;
            ShowForm(DestConnect);
        }

        protected void ShowForm(Form form)
        {
            form.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            Migrate.Application.Model.MigrateProfile profile = new Application.Model.MigrateProfile();

            profile.SourceConnString = Context.connString;
            profile.DestConnString = new Domain.Helper.Access.ConnectString()
            {
                Host = DestConnect.Host,
                Instance = DestConnect.Instance,
                Port = DestConnect.Port,
                UserId = DestConnect.UserId,
                Password = DestConnect.Password
            };

            profile.DestTablespace = DestConnect.Tablespace;

            profile.TargetFile = SelectTable.File;

            Migrate.Application.MigrateService service = new Application.ImportService(profile);

            service.UpdateProcessAction = Executing.UpdateProcess;
            service.UpdateMessageAction = Executing.UpdateMessage;
            service.MigrateFinished += FinishedHandler;

            this.btnAct.Enabled = false;
            ShowForm(Executing);

            Task.Run(() =>
            {
                service.Start();
            });
        }

        public void FinishedHandler(Dictionary<string, Migrate.Application.Model.TableMigrateLog> log)
        {
            MessageBox.Show("finished");
        }
    }
}
