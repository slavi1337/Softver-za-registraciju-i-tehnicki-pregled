using System.Data;
using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{
    public partial class DodavanjePrekrsaja : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";

        public DodavanjePrekrsaja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string opis = textBox1.Text;
            string jmbg = textBox2.Text;
            DateTime datumPrekrsaja = dateTimePicker1.Value;
            
            if (jmbg.Length != 13 || !jmbg.All(char.IsDigit))
            {
                MessageBox.Show("JMBG mora da sadrzi tacno 13 cifara.");
                return;
            }

            string query = @"INSERT INTO IstorijaPrekrsaja (DatumPrekrsaja, Opis, VlasnikJMBG) 
                             VALUES (@DatumPrekrsaja, @Opis, @VlasnikJMBG)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DatumPrekrsaja", datumPrekrsaja.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Opis", opis);
                command.Parameters.AddWithValue("@VlasnikJMBG", jmbg);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Prekrsaj je uspjesno dodat.");
                        this.DialogResult = DialogResult.OK; 
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Doslo je do greske pri dodavanju prekrsaja.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Doslo je do greske: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
