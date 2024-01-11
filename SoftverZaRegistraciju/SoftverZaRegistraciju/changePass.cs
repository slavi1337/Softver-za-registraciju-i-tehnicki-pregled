using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{
    public partial class changePass : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";
        private string loggedInUsername;

        public changePass(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }

        private bool IsOldPasswordCorrect(string username, string oldPassword)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                //sa select count(*) broji broj redova oji zadovoljavaju dati uslov
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KorisnickiNalozi WHERE Username = @username AND Password = @password", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", oldPassword);
                    int result = (int)cmd.ExecuteScalar();
                    return (result > 0);
                }
            }
        }

        private bool ChangePassword(string username, string newPassword)
        {
            if (newPassword.Length < 8)
            {
                MessageBox.Show("Nova lozinka mora da bude duzine od bar 8 karaktera.");
                return false;
            }

            bool passwordChanged = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE KorisnickiNalozi SET Password = @password WHERE Username = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    //da li je samo 1 red izmijenjen?
                    passwordChanged = (cmd.ExecuteNonQuery() == 1);
                }

                if (passwordChanged)
                {
                    using (SqlCommand roleCheckCmd = new SqlCommand("SELECT Role FROM KorisnickiNalozi WHERE Username = @username", con))
                    {
                        roleCheckCmd.Parameters.AddWithValue("@username", username);
                        int role = (int)roleCheckCmd.ExecuteScalar();

                        if (role == 0)
                        {
                            using (SqlCommand updateCmd = new SqlCommand("UPDATE ObicniKorisnickiNalozi SET Password = @password WHERE Username = @username", con))
                            {
                                updateCmd.Parameters.AddWithValue("@username", username);
                                updateCmd.Parameters.AddWithValue("@password", newPassword);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            return passwordChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldPassword = textBox1.Text;
            string newPassword = textBox2.Text;
            string confirmNewPassword = textBox3.Text;

            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Nove lozinke se ne podudaraju.");
                return;
            }

            if (!IsOldPasswordCorrect(loggedInUsername, oldPassword))
            {
                MessageBox.Show("Stara lozinka nije tacna.");
                return;
            }

            if (ChangePassword(loggedInUsername, newPassword))
            {
                MessageBox.Show("Lozinka je uspjesno promijenjena.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Doslo je do greske prilikom promjene lozinke.");
            }
        }

        //prikaz lozinki kad se pritisne checkBox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.UseSystemPasswordChar = !checkBox1.Checked;
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
            textBox3.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
