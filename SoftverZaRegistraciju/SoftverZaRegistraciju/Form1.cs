using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        //prebacivanje na formu za registraciju
        //mora se proslijediti ova forma, zbog dugmeta "nazad" na formi za reg
        private void regButton_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm(this);
            regForm.Show();
            this.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT Role FROM KorisnickiNalozi WHERE Username=@username AND Password=@password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        object roleObj = cmd.ExecuteScalar();

                        if (roleObj != null)
                        {
                            int role = Convert.ToInt32(roleObj);
                            this.Hide();
                            string loggedInUsername = txtUsername.Text;

                            // U zavisnosti od uloge otvara odgovarajucu formu
                            if (role == 0) // Obicni korisnik
                            {
                                UserForm userForm = new UserForm(loggedInUsername);
                                userForm.Show();
                            }
                            else if (role == 1) // Radnik
                            {
                                WorkerForm workerForm = new WorkerForm(loggedInUsername);
                                workerForm.Show();
                            }
                            else if (role == 2) // Admin
                            {
                                AdminForm adminForm = new AdminForm(loggedInUsername);
                                adminForm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Neispravno korisnicko ime ili lozinka.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske: " + ex.Message);
                }
            }
        }

        //prikaz lozinke kad se pritisne checkBox
        private void passCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !passCheckBox.Checked;
        }
    }
}
