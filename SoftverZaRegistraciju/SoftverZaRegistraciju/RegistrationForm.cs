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

namespace SoftverZaRegistraciju
{
    public partial class RegistrationForm : Form
    {

        private Form loginForm;
        public RegistrationForm(Form login)
        {
            InitializeComponent();
            loginForm = login;
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConPassword.Text;
            string jmbg = txtJMBG.Text;
            if (password != confirmPassword)
            {
                MessageBox.Show("Lozinke se ne podudaraju.");
                return;
            }
            if (jmbg.Length != 13 || !jmbg.All(char.IsDigit))
            {
                MessageBox.Show("JMBG mora biti sastavljen od 13 cifara.");
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True"))
            {
                con.Open();

                // Provjera da li korisničko ime već postoji
                string userCheckQuery = "SELECT COUNT(*) FROM KorisnickiNalozi WHERE Username=@username";
                using (SqlCommand userCheckCmd = new SqlCommand(userCheckQuery, con))
                {
                    userCheckCmd.Parameters.AddWithValue("@username", username);
                    int userExists = (int)userCheckCmd.ExecuteScalar();
                    if (userExists > 0)
                    {
                        MessageBox.Show("Korisničko ime je već zauzeto.");
                        return;
                    }
                }

                // Provjera da li JMBG već postoji
                string jmbgCheckQuery = "SELECT COUNT(*) FROM ObicniKorisnickiNalozi WHERE JMBG=@jmbg";
                using (SqlCommand jmbgCheckCmd = new SqlCommand(jmbgCheckQuery, con))
                {
                    jmbgCheckCmd.Parameters.AddWithValue("@jmbg", jmbg);
                    int jmbgExists = (int)jmbgCheckCmd.ExecuteScalar();
                    if (jmbgExists > 0)
                    {
                        MessageBox.Show("Nalog sa unesenim JMBG već postoji.");
                        return;
                    }
                }

                // Dodavanje novog korisnika
                string insertUserQuery = "INSERT INTO KorisnickiNalozi (Username, Password, Role) VALUES (@username, @password, 0)";
                using (SqlCommand insertUserCmd = new SqlCommand(insertUserQuery, con))
                {
                    insertUserCmd.Parameters.AddWithValue("@username", username);
                    insertUserCmd.Parameters.AddWithValue("@password", password); // Razmotrite hashiranje lozinke
                    insertUserCmd.ExecuteNonQuery();
                }

                // Dodavanje u tabelu običnih korisnika
                string insertOrdinaryUserQuery = "INSERT INTO ObicniKorisnickiNalozi (Username, Password, JMBG) VALUES (@username, @password, @jmbg)";
                using (SqlCommand insertOrdinaryUserCmd = new SqlCommand(insertOrdinaryUserQuery, con))
                {
                    insertOrdinaryUserCmd.Parameters.AddWithValue("@username", username);
                    insertOrdinaryUserCmd.Parameters.AddWithValue("@password", password); // Razmotrite hashiranje lozinke
                    insertOrdinaryUserCmd.Parameters.AddWithValue("@jmbg", jmbg);
                    insertOrdinaryUserCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Registracija uspješna.");
                loginForm.Show();
                this.Hide();


            }
        }

        private void passCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !passCheckBox.Checked;
            txtConPassword.UseSystemPasswordChar = !passCheckBox.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtConPassword.Text = "";
            txtJMBG.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Hide();

        }
    }
}
