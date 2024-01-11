using System.Data;
using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{
    public partial class AdminForm : Form
    {
        private string loggedInUsername;
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";
        private CreateAccount? createForm = null;
        private changePass? passChangeForm = null;

        public AdminForm(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            label2.Text = loggedInUsername;
            dataGridView1.DataSource = GetData();
            FormatDataGridViewHeaders();
        }

        private DataTable GetData()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM KorisnickiNalozi";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske prilikom ucitavanja podataka: " + ex.Message);
                }
            }
            return dataTable;
        }

        //odjava->prebacivanje na login formu
        //kad se zatvori login forma, i ova forma se zatvara
        //poziva se close na njoj
        private void button3_Click(object sender, EventArgs e)
        {
            CloseSecondaryForms();
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void CloseSecondaryForms()
        {
            createForm?.Close();
            passChangeForm?.Close();
        }

        //kreairanje naloga->otvaranje forme za kreiranje naloga
        private void button1_Click(object sender, EventArgs e)
        {
            if (createForm == null || createForm.IsDisposed)
            {
                createForm = new CreateAccount();
                createForm.FormClosed += (s, args) => createForm = null;
                createForm.Show();
            }
            else
            {
                MessageBox.Show("Vec imate otvorenu formu za kreiranje naloga.\nZatvorite je, pa je opet mozete pokrenuti.");
            }
        }

        private void DeleteAccount(string username)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM KorisnickiNalozi WHERE Username=@username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Uspjesno ste obrisati nalog sa korisnickim imenom \"" + username + "\".\nPritisnite dugme \"Osvjezi\" za osvjezavanje podataka!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Deklarisanje usernameToDelete kao nullable string
                string? usernameToDelete = dataGridView1.SelectedRows[0].Cells["Username"].Value?.ToString();

                // Provera da li je usernameToDelete null ili prazan string
                if (string.IsNullOrEmpty(usernameToDelete))
                {
                    MessageBox.Show("Korisnicko ime nije odabrano ili je prazno.");
                    return;
                }

                // Provera da li je usernameToDelete isti kao loggedInUsername
                if (usernameToDelete.Equals(loggedInUsername, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Ne mozete obrisati nalog na kojem ste trenutno prijavljeni.");
                    return;
                }

                DeleteAccount(usernameToDelete);
            }
            else
            {
                MessageBox.Show("Morate odabrati nalog za brisanje.");
            }
        }

        //dugme "osvjezi"
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
        }

        //prebacivanje na formu za promjenu sifre
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

        private void dataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Role")
            {
                if (e.Value != null)
                {
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.Value = "Obicni";
                            break;
                        case "1":
                            e.Value = "Radnik";
                            break;
                        case "2":
                            e.Value = "Admin";
                            break;
                    }
                }
            }
        }

        private void FormatDataGridViewHeaders()
        {
            if (dataGridView1.Columns["UserID"] != null)
                dataGridView1.Columns["UserID"].HeaderText = "ID";

            if (dataGridView1.Columns["Username"] != null)
                dataGridView1.Columns["Username"].HeaderText = "Korisnicko Ime";

            if (dataGridView1.Columns["Password"] != null)
                dataGridView1.Columns["Password"].HeaderText = "Lozinka";

            if (dataGridView1.Columns["Role"] != null)
                dataGridView1.Columns["Role"].HeaderText = "Vrsta";
        }

        private void AdminForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if ((createForm != null && !createForm.IsDisposed) || (passChangeForm != null && !passChangeForm.IsDisposed))
            {
                MessageBox.Show("Molimo zatvorite sve otvorene podforme prije nego sto zatvorite ovu formu.");
                e.Cancel = true;  // Ponistava zatvaranje forme

            }
            else
            {
                Application.Exit();
            }

        }

        private void FilterData(string role)
        {
            if (dataGridView1.DataSource is DataTable dataTable)
            {
                if (string.IsNullOrEmpty(role))
                {
                    dataTable.DefaultView.RowFilter = "";
                }
                else
                {
                    dataTable.DefaultView.RowFilter = $"Role = '{role}'";
                }
            }
        }

        //filter admin
        private void button6_Click(object sender, EventArgs e)
        {
            FilterData("2");
        }

        //filter radnik
        private void button7_Click(object sender, EventArgs e)
        {
            FilterData("1");
        }

        //filter obicni korisnik
        private void button8_Click(object sender, EventArgs e)
        {
            FilterData("0");
        }

        //filter svi korisnici
        private void button9_Click(object sender, EventArgs e)
        {
            FilterData("");
        }
    }
}
