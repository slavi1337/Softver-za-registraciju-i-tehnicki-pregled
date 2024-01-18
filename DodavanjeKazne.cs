using System.Data;
using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{
    public partial class DodavanjeKazne : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";

        public DodavanjeKazne()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string opis = textBox1.Text;
            string jmbg = textBox2.Text;
            string iznos = textBox3.Text;
            DateTime datumKazne = dateTimePicker1.Value;

            // Validacija JMBG-a
            if (jmbg.Length != 13 || !jmbg.All(char.IsDigit))
            {
                MessageBox.Show("JMBG mora da sadrži tačno 13 cifara.");
                return;
            }

            if (!decimal.TryParse(iznos, out decimal iznosDecimal))
            {
                MessageBox.Show("Iznos mora biti validan decimalni broj.");
                return;
            }
            string query = @"INSERT INTO IstorijaKazni (PenaltyDate, Iznos, Opis, IsPaid, VlasnikJMBG) 
                     VALUES (@PenaltyDate, @Iznos, @Opis, @IsPaid, @VlasnikJMBG)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PenaltyDate", datumKazne.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@Iznos", iznosDecimal);
                command.Parameters.AddWithValue("@Opis", opis);
                command.Parameters.AddWithValue("@IsPaid", false);
                command.Parameters.AddWithValue("@VlasnikJMBG", jmbg);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Kazna je uspjesno dodata.");
                        this.DialogResult = DialogResult.OK; 
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Doslo je do greske pri dodavanju kazne.");
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

