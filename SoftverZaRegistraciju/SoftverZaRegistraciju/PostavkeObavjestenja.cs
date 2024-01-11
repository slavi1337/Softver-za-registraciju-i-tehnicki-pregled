using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{
    public partial class PostavkeObavjestenja : Form
    {
        private string loggedInUsername;
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";

        public PostavkeObavjestenja(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int notificationDays = Convert.ToInt32(comboBox1.SelectedItem);

            SaveNotificationSettings(loggedInUsername, notificationDays);
            MessageBox.Show("Uspjesno ste sacuvali postavke obavjestenja");
            this.Close();
        }

        private void SaveNotificationSettings(string username, int days)
        { 
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // provjera da li vec postoji opcija za korisnika
                string queryCheck = "SELECT COUNT(*) FROM ObavjestenjaPostavke WHERE Username = @Username";
                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, con))
                {
                    cmdCheck.Parameters.AddWithValue("@Username", username);
                    int exists = (int)cmdCheck.ExecuteScalar();

                    string query;
                    if (exists > 0)
                    {
                        query = "UPDATE ObavjestenjaPostavke SET Broj = @Days WHERE Username = @Username";
                    }
                    else // Ako ne postoji, create novi red
                    {
                        query = "INSERT INTO ObavjestenjaPostavke (Username, Broj) VALUES (@Username, @Days)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Days", days);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
