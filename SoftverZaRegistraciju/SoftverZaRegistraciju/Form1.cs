using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void regButton_Click(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm(this);
            regForm.Show();
            this.Hide();


        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    string query = "SELECT Role FROM KorisnickiNalozi WHERE Username=@username AND Password=@password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text); // Razmotrite upotrebu hashirane lozinke

                        object roleObj = cmd.ExecuteScalar();

                        if (roleObj != null)
                        {
                            int role = Convert.ToInt32(roleObj);
                            this.Hide();
                            string loggedInUsername = txtUsername.Text;
                            // Ovisno o ulozi, otvorite odgovarajuæu formu
                            if (role == 0) // Obièni korisnik
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
                            MessageBox.Show("Neispravno korisnièko ime ili lozinka.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške: " + ex.Message);
                }
            }
        }

        private void passCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !passCheckBox.Checked;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}