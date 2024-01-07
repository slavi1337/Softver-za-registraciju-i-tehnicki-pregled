using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SoftverZaRegistraciju
{
    public partial class AdminForm : Form
    {
        private string loggedInUsername;
        public AdminForm(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }



        private void AdminForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
            FormatDataGridViewHeaders();
        }
        private DataTable GetData()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    // Pretpostavimo da želite učitati sve kolone iz tabele koja se zove 'Accounts'
                    string query = "SELECT * FROM KorisnickiNalozi";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške prilikom učitavanja podataka: " + ex.Message);
                }
            }
            return dataTable;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //odjava->prebacivanje na login formu
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kreairanje naloga->otvaranje forme za kreiranje naloga
            CreateAccount createForm = new CreateAccount();
            createForm.Show();
        }

        private void DeleteAccount(string username)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True"))
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
                    MessageBox.Show("Uspješno ste obrisati nalog sa korisnickim imenom \"" + username + "\".\nPritisnite dugme \"Osvjezi\" za osvjezavanje podataka!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške: " + ex.Message);
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
                    MessageBox.Show("Korisničko ime nije odabrano ili je prazno.");
                    return;
                }

                // Provera da li je usernameToDelete isti kao loggedInUsername
                if (usernameToDelete.Equals(loggedInUsername, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Ne možete obrisati nalog na kojem ste trenutno ulogovani.");
                    return;
                }

                DeleteAccount(usernameToDelete);
            }
            else
            {
                MessageBox.Show("Morate odabrati nalog za brisanje.");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            changePass passChange = new changePass(loggedInUsername);
            passChange.Show();
        }


        //Da biste rešili ovo upozorenje, možete dodati nullable anotaciju na parametar
        //sender tako što ćete ga označiti kao tip koji može biti null. U C# 8.0 i
        //novijim verzijama, možete eksplicitno navesti da parametar može biti null
        //pomoću ? operatera
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
            // Provjerite da li kolone postoje pre nego što pokušate da pristupite njihovim svojstvima
            if (dataGridView1.Columns["UserID"] != null)
                dataGridView1.Columns["UserID"].HeaderText = "ID";

            if (dataGridView1.Columns["Username"] != null)
                dataGridView1.Columns["Username"].HeaderText = "Korisnicko Ime";

            if (dataGridView1.Columns["Password"] != null)
                dataGridView1.Columns["Password"].HeaderText = "Lozinka";

            if (dataGridView1.Columns["Role"] != null)
                dataGridView1.Columns["Role"].HeaderText = "Vrsta";
        }
    }
}
