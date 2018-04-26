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
    public partial class ExScheduleForm : Form
    {
        public ExScheduleForm()
        {
            InitializeComponent();
            SelectTable = new ExSelectTableForm();
            DestConnect = new ExDestConnectForm();
            Executing = new ExExecutingForm();
        }

        protected ExSelectTableForm SelectTable { get; private set; }

        protected ExDestConnectForm DestConnect { get; private set; }

        protected ExExecutingForm Executing { get; private set; }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            SelectTable.DataSource = new Migrate.Application.App.TableApp().Get(Context.connString);
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
            if (!DestConnect.FormValidate()) return;

            Migrate.Application.Model.MigrateProfile profile = new Application.Model.MigrateProfile();

            profile.SourceConnString = Context.connString;
            profile.TargetFile = DestConnect.TargetFile;

            profile.ImpTables = SelectTable.GetSelected().ToList();

            Migrate.Application.MigrateService service = new Application.ExportService(profile);

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
