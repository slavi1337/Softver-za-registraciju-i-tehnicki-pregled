using System.Data.SqlClient;
using System.Globalization;

namespace SoftverZaRegistraciju
{
    public partial class PaymentForm : Form
    {
        private string datumKazne, iznos, opis, loggedInUsername;
        private DateTime datumKazneDateTime;
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";

        public PaymentForm(string s1, string s2, string s3, string username)
        {
            InitializeComponent();
            datumKazne = s1;
            iznos = s2;
            opis = s3;
            loggedInUsername = username;
            datumKazneDateTime = DateTime.ParseExact(datumKazne, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            label10.Text = opis;
            label11.Text = datumKazne;

            // ako se kazna placa u roku od 8 dana, za 50% je jeftinija
            if (DateTime.Now <= datumKazneDateTime.AddDays(8))
            {
                label9.Text = (double.Parse(iznos) / 2).ToString("0.00");
            }
            else
            {
                label9.Text = (double.Parse(iznos)).ToString("0.00");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cardNumber = textBox1.Text.Trim();
            string cvv = textBox2.Text.Trim();
            string expiryMonth = comboBox1.SelectedItem?.ToString() ?? string.Empty;
            string expiryYear = comboBox2.SelectedItem?.ToString() ?? string.Empty;
            string expiryDate = expiryMonth + "/" + expiryYear;
            double iznosZaPlacanje = double.Parse(label9.Text);

            // provjera da li je broj kartice validan (ima 16 cifara i sadrzi samo brojeve)
            if (cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
            {
                MessageBox.Show("Broj kartice mora imati 16 cifara.");
                return;
            }

            // provjera da li je CVV validan (ima 3 cifre i sadrzi samo brojeve)
            if (cvv.Length != 3 || !cvv.All(char.IsDigit))
            {
                MessageBox.Show("CVV mora imati 3 cifre.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // preuzimanje JMBG trenutnog korisnika
                string jmbg;
                using (SqlCommand cmd = new SqlCommand("SELECT JMBG FROM ObicniKorisnickiNalozi WHERE Username = @Username", con))
                {
                    cmd.Parameters.AddWithValue("@Username", loggedInUsername);
                    jmbg = cmd.ExecuteScalar()?.ToString() ?? "";
                }

                // provjera da li kartica postoji i da li se podaci poklapaju
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KarticeInformacije WHERE BrojKartice = @CardNumber AND CVV = @CVV AND DatumIsteka = @ExpiryDate AND VlasnikJMBG = @JMBG", con))
                {
                    cmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                    cmd.Parameters.AddWithValue("@CVV", cvv);
                    cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                    cmd.Parameters.AddWithValue("@JMBG", jmbg);

                    int exists = (int)cmd.ExecuteScalar();

                    if (exists == 0)
                    {
                        MessageBox.Show("Podaci o kartici nisu ispravni ili kartica ne odgovara trenutnom korisniku.");
                        return;
                    }
                }

                // provjera da li ima dovoljno sredstava na kartici
                double stanjeNaKartici;
                using (SqlCommand cmd = new SqlCommand("SELECT Stanje FROM KarticeInformacije WHERE BrojKartice = @CardNumber", con))
                {
                    cmd.Parameters.AddWithValue("@CardNumber", cardNumber);

                    object result = cmd.ExecuteScalar();


                    if (result != null)
                    {
                        stanjeNaKartici = Convert.ToDouble(result);

                        if (stanjeNaKartici < iznosZaPlacanje)
                        {
                            MessageBox.Show("Nemate dovoljno novca na kartici.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nije moguce proveriti stanje kartice.");
                        return;
                    }
                }

                // updejt stanja kartice i oznacavanje kazne kao placena
                using (SqlCommand cmd = new SqlCommand("UPDATE KarticeInformacije SET Stanje = Stanje - @Amount WHERE BrojKartice = @CardNumber", con))
                {
                    cmd.Parameters.AddWithValue("@CardNumber", cardNumber);
                    cmd.Parameters.AddWithValue("@Amount", iznosZaPlacanje);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("UPDATE IstorijaKazni SET isPaid = 1 WHERE PenaltyDate = @PenaltyDate AND VlasnikJMBG = @JMBG", con))
                {
                    DateTime parsedDate = DateTime.ParseExact(datumKazne, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                    string formattedDateForDb = parsedDate.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@PenaltyDate", formattedDateForDb);
                    cmd.Parameters.AddWithValue("@JMBG", jmbg);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Kazna je uspjesno placena. Stanje na kartici je azurirano.");
            this.Close();
        }
    }
}
