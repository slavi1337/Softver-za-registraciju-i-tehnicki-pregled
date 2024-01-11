using System.Data;
using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{

    public partial class UserForm : Form
    {
        private string loggedInUsername;
        private CalcForm? calcForm = null;
        private changePass? passChangeForm = null;
        private IstorijaKazni? istorijaKazniForm = null;
        private PostavkeObavjestenja? postavkeObavjestenjaForm = null;
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";

        public UserForm(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);
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

        //odjava
        private void button3_Click(object sender, EventArgs e)
        {
            CloseSecondaryForms();
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private DataTable GetData(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", loggedInUsername);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            label3.Text = loggedInUsername;
            string queryRegistrovanaVozila = "SELECT BrSasije, RegistrationDate, ExpiryDate, RegTablice FROM RegistrovanaVozila WHERE JMBG = (SELECT JMBG FROM ObicniKorisnickiNalozi WHERE Username = @Username)";
            string queryVozilaInformacije = "SELECT BrSasije, ImeVozila, Boja, GodinaProizvodnje, JacinaMotora, ZapreminaMotora FROM VozilaInformacije";

            var registrovanaVozilaData = GetData(queryRegistrovanaVozila);
            var vozilaInformacijeData = GetData(queryVozilaInformacije);

            var spojeniPodaci = from rv in registrovanaVozilaData.AsEnumerable()
                                join vi in vozilaInformacijeData.AsEnumerable()
                                on rv["BrSasije"] equals vi["BrSasije"]
                                select new
                                {
                                    BrSasije = rv["BrSasije"],
                                    ImeVozila = vi["ImeVozila"],
                                    Boja = vi["Boja"],
                                    GodinaProizvodnje = vi["GodinaProizvodnje"],
                                    JacinaMotora = vi["JacinaMotora"],
                                    ZapreminaMotora = vi["ZapreminaMotora"],
                                    DatumIstekaRegistracije = rv["ExpiryDate"],
                                    RegistarskeTablice = rv["RegTablice"]
                                };

            dataGridView1.DataSource = spojeniPodaci.ToList();
            SendRegistrationNotifications();
        }

        private void SendRegistrationNotifications()
        {
            int notificationDays = GetNotificationDays(loggedInUsername);
            DateTime today = DateTime.Today;

            // za svaku registraciju se provjerava da li se treba slati notifikacija
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DateTime expiryDate = Convert.ToDateTime(row.Cells["DatumIstekaRegistracije"].Value);
                string vehicleName = row.Cells["ImeVozila"].Value?.ToString() ?? "Nepoznato vozilo";
                int daysUntilExpiry = (expiryDate - today).Days;

                if (daysUntilExpiry <= notificationDays)
                {
                    MessageBox.Show($"Obavjestenje: Registracija za vozilo '{vehicleName}' istice za {daysUntilExpiry} dana.");
                }
            }
        }

        private int GetNotificationDays(string username)
        {
            int notificationDays = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Broj FROM ObavjestenjaPostavke WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        notificationDays = Convert.ToInt32(result);
                    }
                }
            }
            return notificationDays;
        }

        private void dataGridView1_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (col.Name == "BrSasije")
                {
                    col.HeaderText = "Broj Sasije";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    col.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                }
                else
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                }

                switch (col.Name)
                {
                    case "ImeVozila":
                        col.HeaderText = "Vozilo";
                        break;
                    case "GodinaProizvodnje":
                        col.HeaderText = "Godina Proizvodnje";
                        break;
                    case "JacinaMotora":
                        col.HeaderText = "Jacina Motora";
                        break;
                    case "ZapreminaMotora":
                        col.HeaderText = "Zapremina Motora";
                        break;
                    case "DatumIstekaRegistracije":
                        col.HeaderText = "Datum Isteka Reg.";
                        col.DefaultCellStyle.Format = "dd.MM.yyyy";
                        break;
                    case "RegistarskeTablice":
                        col.HeaderText = "Tablice";
                        break;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (istorijaKazniForm == null || istorijaKazniForm.IsDisposed)
            {
                istorijaKazniForm = new IstorijaKazni(loggedInUsername);
                istorijaKazniForm.FormClosed += (s, args) => istorijaKazniForm = null;
                istorijaKazniForm.Show();
            }
            else
            {
                MessageBox.Show("Vec imate otvorenu formu za istoriju kaznu.\nZatvorite je, pa je opet mozete pokrenuti.");
            }
        }

        private void btnNotif_Click(object sender, EventArgs e)
        {
            if (postavkeObavjestenjaForm == null || postavkeObavjestenjaForm.IsDisposed)
            {
                postavkeObavjestenjaForm = new PostavkeObavjestenja(loggedInUsername);
                postavkeObavjestenjaForm.FormClosed += (s, args) => postavkeObavjestenjaForm = null;
                postavkeObavjestenjaForm.Show();
            }
            else
            {
                MessageBox.Show("Vec imate otvorenu formu za postavke obavjestenja.\nZatvorite je, pa je opet mozete pokrenuti.");
            }
        }

        private void CloseSecondaryForms()
        {
            calcForm?.Close();
            passChangeForm?.Close();
            istorijaKazniForm?.Close();
            postavkeObavjestenjaForm?.Close();
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((calcForm != null && !calcForm.IsDisposed) ||
            (passChangeForm != null && !passChangeForm.IsDisposed) ||
            (istorijaKazniForm != null && !istorijaKazniForm.IsDisposed) ||
            (postavkeObavjestenjaForm != null && !postavkeObavjestenjaForm.IsDisposed))
            {
                MessageBox.Show("Molimo zatvorite sve otvorene podforme prije nego sto zatvorite ovu formu.");
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
