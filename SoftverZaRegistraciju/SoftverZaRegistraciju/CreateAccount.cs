using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{
    public partial class CreateAccount : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";

        public CreateAccount()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
            textBox3.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private bool UsernameExists(string username)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KorisnickiNalozi WHERE Username = @username", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    int userCount = (int)cmd.ExecuteScalar();
                    return (userCount > 0);
                }
            }
        }

        private bool CreateOneAccount(string username, string password, int role)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO KorisnickiNalozi (Username, Password, Role) VALUES (@username, @password, @role)", con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    return (cmd.ExecuteNonQuery() == 1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;

            // Provjera da li se lozinke podudaraju
            if (password != confirmPassword)
            {
                MessageBox.Show("Lozinke se ne podudaraju.");
                return;
            }

            // Provjera da li korisnicko ime vec postoji
            if (UsernameExists(username))
            {
                MessageBox.Show("Korisnicko ime vec postoji.");
                return;
            }

            // Odredjivanje role-a na osnovu izabranog radio buttona
            int role = radioButton1.Checked ? 2 : 1;

            // Kreiranje naloga
            if (CreateOneAccount(username, password, role))
            {
                MessageBox.Show("Nalog je uspjesno kreiran.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Doslo je do greske prilikom kreiranja naloga.");
            }
        }
    }
}
