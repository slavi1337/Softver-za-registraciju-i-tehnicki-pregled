using System.Data.SqlClient;
using System.Data;

namespace SoftverZaRegistraciju
{
    public partial class WorkerForm : Form
    {
        private string loggedInUsername;
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";
        private CalcForm? calcForm = null;
        private changePass? passChangeForm = null;
        private RegistracijaVozila? registracijaForm = null;

        public WorkerForm(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CloseSecondaryForms();
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (passChangeForm == null || passChangeForm.IsDisposed)
            {
                passChangeForm = new changePass(loggedInUsername);
                passChangeForm.FormClosed += (s, args) => passChangeForm = null;
                passChangeForm.Show();
            }
            else
            {
                MessageBox.Show("Vec imate otvorenu formu za mijenjanje sifre.\nZatvorite je, pa je opet mozete pokrenuti.");
            }
        }

        private void FormatDataGridViewHeaders()
        {

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

                switch (col.Name)
                {
                    case "Boja":
                        col.HeaderText = "BOJA";
                        break;
                    case "BrSasije":
                        col.HeaderText = "Broj sasije";
                        break;
                    case "ImeVozila":
                        col.HeaderText = "Vozilo";
                        break;
                    case "GodinaProizvodnje":
                        col.HeaderText = "Godina proizvodnje";
                        break;
                    case "JacinaMotora":
                        col.HeaderText = "Jacina motora [kW]";
                        break;
                    case "ZapreminaMotora":
                        col.HeaderText = "Zapremina motora [ccm]";
                        break;
                    case "DatumIstekaRegistracije":
                        col.HeaderText = "Datum isteka reg.";
                        col.DefaultCellStyle.Format = "dd.MM.yyyy";
                        break;
                    case "RegistarskeTablice":
                        col.HeaderText = "Tablice";
                        break;
                    case "ImeVlasnika":
                        col.HeaderText = "Ime vlasnika";
                        break;
                    case "PrezimeVlasnika":
                        col.HeaderText = "Prezime vlasnika";
                        break;

                }
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void OsveziPodatke()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var query = @"
                SELECT rv.BrSasije, vi.ImeVozila as 'Vozilo', vi.Boja, vi.GodinaProizvodnje, vi.JacinaMotora, 
                vi.ZapreminaMotora, rv.ExpiryDate as 'DatumIstekaRegistracije', rv.RegTablice as 'Tablice', 
                vl.Ime as 'ImeVlasnika', vl.Prezime as 'PrezimeVlasnika', vl.JMBG as 'JMBG Vlasnika'
                FROM RegistrovanaVozila rv
                JOIN VozilaInformacije vi ON rv.BrSasije = vi.BrSasije
                JOIN VlasniciInformacije vl ON vi.VlasnikJMBG = vl.JMBG";

                var adapter = new SqlDataAdapter(query, con);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                FormatDataGridViewHeaders();
            }
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            label3.Text = loggedInUsername;
            OsveziPodatke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OsveziPodatke();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (calcForm == null || calcForm.IsDisposed)
            {
                calcForm = new CalcForm();
                calcForm.FormClosed += (s, args) => calcForm = null;
                calcForm.Show();
            }
            else
            {
                MessageBox.Show("Vec imate otvorenu formu za kalkulator.\nZatvorite je, pa je opet mozete pokrenuti.");
            }
        }

        private void CloseSecondaryForms()
        {
            calcForm?.Close();
            passChangeForm?.Close();
            registracijaForm?.Close();
        }

        private void WorkerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (calcForm != null || passChangeForm != null || registracijaForm != null)
            {
                MessageBox.Show("Molimo zatvorite sve otvorene podforme prije zatvaranja ove forme.");
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (registracijaForm == null || registracijaForm.IsDisposed)
            {
                registracijaForm = new RegistracijaVozila();
                registracijaForm.FormClosed += (s, args) => registracijaForm = null;
                registracijaForm.Show();
            }
            else
            {
                MessageBox.Show("Vec imate otvorenu formu za registrovanje vozila.\nZatvorite je, pa je opet mozete pokrenuti.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form upravljanjeKaznama = new UpravljanjeKaznama(this);
            upravljanjeKaznama.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form upravljanjePrekrsajima = new UpravljanjePrekrsajima(this);
            upravljanjePrekrsajima.Show();
            this.Hide();
        }
    }
}
