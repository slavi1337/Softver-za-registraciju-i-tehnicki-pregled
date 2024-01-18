using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{
    public partial class RegistracijaVozila : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";

        private string? jmbg;
        private string? brojSasije;
        private string? tablice;
        private string? stiker;
        private Form workerForm;
        bool userInitiatedClose = false;

        public RegistracijaVozila(Form worker)
        {
            InitializeComponent();
            workerForm = worker;
        }

        private void RegistracijaVozila_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            SakrijSveKontrole();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                PrikaziKontroleZaProduzenje();
                ResetujRadioButtonICheckBox();
                groupBox1.Visible = true;
                label13.Visible = true;
                checkBox1.Visible = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                PrikaziKontroleZaPrvuRegistraciju();
                ResetujRadioButtonICheckBox();
                groupBox1.Visible = true;
                label13.Visible = false;
                checkBox1.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                checkBox1.Checked = false;
                textBox10.Text = "";
                checkBox1.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                checkBox1.Visible = true;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label14.Visible = checkBox1.Checked;
            textBox10.Visible = checkBox1.Checked;
            if (!checkBox1.Checked)
            {
                textBox10.Text = "";
                label14.Visible = false;
            }
        }

        private void SakrijSveKontrole()
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;

            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    c.Visible = false;
                }
                if (c is Label && c != label10 && c != label11)
                {
                    c.Visible = false;
                }
            }

        }

        private void PrikaziKontroleZaProduzenje()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && c != textBox1 && c != textBox7)
                {
                    c.Visible = false;
                }
                if (c is Label && c != label10 && c != label11)
                {
                    c.Visible = false;
                }
            }
            checkBox1.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            textBox10.Visible = false;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            textBox1.Visible = true; // Brsasije
            textBox7.Visible = true; // JMBG
            label1.Visible = true;
            label7.Visible = true;
        }

        private void PrikaziKontroleZaPrvuRegistraciju()
        {
            foreach (Control c in this.Controls)
            {
                c.Visible = true;
            }
            radioButton1.Visible = false;
            radioButton2.Visible = true;
            label13.Visible = false;
            label14.Visible = false;
            textBox10.Visible = false;
            textBox10.Text = "";
        }

        private void ResetujRadioButtonICheckBox()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            textBox10.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                if (!ValidirajUnos(conn))
                {
                    return;
                }
                if (radioButton3.Checked) // Produzenje registracije
                {
                    if (ImaNeplacenihKazni(conn))
                    {
                        MessageBox.Show("Nije moguce registrovati vozilo.\nVlasnik ima neplacene kazne.");
                        return;
                    }

                    if (!ProsaoTehnicki(conn))
                    {
                        MessageBox.Show("Nije moguce registrovati vozilo.\nVozilo nije proslo tehnicki pregled.");
                        return;
                    }
                    //stare tablice, update u RegistracijVozila
                    if (radioButton1.Checked)
                    {
                        AzurirajRegistracijuVozila31(conn);
                    }
                    else if (radioButton2.Checked)
                    {
                        if (!checkBox1.Checked)
                        {
                            GenerisiTablice(conn);
                            AzurirajRegistracijuVozila32(conn);
                        }
                        else
                        {
                            tablice = textBox10.Text.Trim().ToUpperInvariant();
                            AzurirajRegistracijuVozila32(conn);
                        }
                    }
                }
                else if (radioButton4.Checked) // Prva registracija
                {
                    if (!radioButton2.Checked)
                    {
                        MessageBox.Show("Za prvu registraciju vozila morate izabrati opciju za nove tablice.");
                        return;
                    }

                    if (ImaNeplacenihKazni(conn))
                    {
                        MessageBox.Show("Nije moguce registrovati vozilo.\nVlasnik ima neplacene kazne.");
                        return;
                    }

                    if (!ProsaoTehnicki(conn))
                    {
                        MessageBox.Show("Nije moguce registrovati vozilo.\nVozilo nije proslo tehnicki pregled.");
                        return;
                    }

                    if (!ProvjeriVlasnikaUBazi(conn))
                    {
                        UpisiVlasnikaUBazu(conn);
                    }

                    UpisiVoziloUBazu(conn);

                    if (radioButton2.Checked)
                    {
                        if (!checkBox1.Checked)
                        {
                            GenerisiTablice(conn);
                            UpisiURegistrovanaVozila(conn);
                        }
                        else
                        {
                            tablice = textBox10.Text.Trim().ToUpperInvariant();
                            UpisiURegistrovanaVozila(conn);
                        }
                    }

                }

                GenerisiStiker(conn);
                UpisiStikerUBazu(conn);
                MessageBox.Show($"Uspjesna registracija za vozilo. Registracioni stiker: {stiker}");
                userInitiatedClose = true;
                workerForm.Show();
                this.Close();
            }


        }

        private bool ValidirajUnos(SqlConnection conn)
        {
            bool validno = true;

            foreach (Control c in this.Controls)
            {
                if (c is TextBox && c.Visible)
                {
                    TextBox tb = (TextBox)c;

                    if (string.IsNullOrWhiteSpace(tb.Text))
                    {
                        validno = false;
                        break;
                    }

                    if (c == textBox10 && checkBox1.Checked && tb.Text.Length > 9)
                    {
                        MessageBox.Show("Tablice moraju da sadrze maksimalno 9 karaktera");
                        validno = false;
                        break;
                    }
                }
            }

            if (groupBox1.Visible)
            {
                if (!radioButton1.Checked && !radioButton2.Checked)
                    validno = false;
            }

            if (!radioButton3.Checked && !radioButton4.Checked)
                validno = false;

            if (!validno)
            {
                MessageBox.Show("Molimo popunite sva prikazana polja.");
                return validno;
            }
            if (textBox7.Text.Length != 13)
            {
                MessageBox.Show("JMBG mora da ima 13 cifara");
                return false;
            }

            if (textBox1.Text.Length != 17)
            {
                MessageBox.Show("Broj sasije mora da ima 17 karaktera");
                return false;
            }

            if (radioButton4.Checked)
            {
                int godinaProizvodnje = 0;
                if (textBox5.Visible && !int.TryParse(textBox5.Text, out godinaProizvodnje) || godinaProizvodnje < 1900 || godinaProizvodnje > DateTime.Now.Year)
                {
                    MessageBox.Show("Godina nije validna!\nUnesite godinu između 1900 i trenutne godine.");
                    return false;
                }
                string query = "SELECT Ime, Prezime FROM VlasniciInformacije WHERE JMBG = @jmbg";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@jmbg", textBox7.Text);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Ako postoji vlasnik sa tim JMBG
                        {
                            string? imeUBazi = reader["Ime"].ToString();
                            string? prezimeUBazi = reader["Prezime"].ToString();

                            if (textBox9.Text != imeUBazi || textBox8.Text != prezimeUBazi)
                            {
                                MessageBox.Show("Ime ili prezime se ne podudaraju sa unesenim JMBG.");
                                return false;
                            }
                        }
                    }
                }
                string queryProvjeriVozilo = "SELECT COUNT(*) FROM RegistrovanaVozila WHERE BrSasije = @BrSasije";
                using (SqlCommand cmdProvjeriVozilo = new SqlCommand(queryProvjeriVozilo, conn))
                {
                    cmdProvjeriVozilo.Parameters.AddWithValue("@BrSasije", textBox1.Text);

                    int brojVozila = (int)cmdProvjeriVozilo.ExecuteScalar();
                    if (brojVozila > 0)
                    {
                        MessageBox.Show("Vozilo sa unijetim brojem šasije vec postoji u bazi. Molimo izaberite opciju za produženje registracije.");
                        return false;
                    }
                }
            }

            if (radioButton3.Checked)
            {
                string queryProveriVozilo = "SELECT COUNT(*) FROM RegistrovanaVozila WHERE BrSasije = @BrSasije";
                using (SqlCommand cmdProveriVozilo = new SqlCommand(queryProveriVozilo, conn))
                {
                    cmdProveriVozilo.Parameters.AddWithValue("@BrSasije", textBox1.Text);

                    int brojVozila = (int)cmdProveriVozilo.ExecuteScalar();
                    if (brojVozila == 0)
                    {
                        MessageBox.Show("Vozilo sa unijetim brojem šasije ne postoji u bazi. Molimo izaberite opciju za prvu registraciju.");
                        return false;
                    }
                }

                // Provjera da li vozilo odgovara unetom JMBG-u
                string queryProveriJMBG = "SELECT COUNT(*) FROM RegistrovanaVozila WHERE BrSasije = @BrSasije AND JMBG = @jmbg";
                using (SqlCommand cmdProveriJMBG = new SqlCommand(queryProveriJMBG, conn))
                {
                    cmdProveriJMBG.Parameters.AddWithValue("@BrSasije", textBox1.Text);
                    cmdProveriJMBG.Parameters.AddWithValue("@jmbg", textBox7.Text);

                    int brojVozilaSaIstimJMBG = (int)cmdProveriJMBG.ExecuteScalar();
                    if (brojVozilaSaIstimJMBG == 0)
                    {
                        MessageBox.Show("Vozilo sa unijetim brojem šasije ne odgovara unetom JMBG-u. Molimo proverite podatke.");
                        return false;
                    }
                }

            }
            if (checkBox1.Visible && checkBox1.Checked)
            {
                string unetiTablice = textBox10.Text.Trim();
                if (string.IsNullOrEmpty(unetiTablice))
                {
                    MessageBox.Show("Molimo unesite personalizovane tablice u polje.");
                    return false;
                }

                if (unetiTablice.Length > 9)
                {
                    MessageBox.Show("Tablice moraju da sadrze maksimalno 9 karaktera");
                    return false;
                }

                string velikaSlovaTablice = unetiTablice.ToUpperInvariant();

                string queryProveriTablice = "SELECT COUNT(*) FROM RegistrovanaVozila WHERE RegTablice = @RegTablice";
                using (SqlCommand cmdProveriTablice = new SqlCommand(queryProveriTablice, conn))
                {
                    cmdProveriTablice.Parameters.AddWithValue("@RegTablice", velikaSlovaTablice);

                    int brojVozilaSaIstimTablicama = (int)cmdProveriTablice.ExecuteScalar();
                    if (brojVozilaSaIstimTablicama > 0)
                    {
                        MessageBox.Show("Tablice koje ste uneli već postoje u bazi. Molimo unesite druge tablice.");
                        return false;
                    }
                }
            }

            return validno;
        }

        private bool ImaNeplacenihKazni(SqlConnection conn)
        {

            jmbg = textBox7.Text;
            string query = "SELECT COUNT(*) FROM IstorijaKazni WHERE VlasnikJMBG = @JMBG AND IsPaid = 0";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@JMBG", jmbg);

                int brojNeplacenihKazni = (int)cmd.ExecuteScalar();

                return brojNeplacenihKazni > 0;
            }
        }

        private bool ProsaoTehnicki(SqlConnection conn)
        {
            brojSasije = textBox1.Text;
            // Datum pregleda treba da bude unutar zadnjih 30 dana
            DateTime tridesetDanaAgo = DateTime.Now.AddDays(-30);

            string query = "SELECT RezultatTehnickog, Datum FROM RezultatiTehnickog WHERE BrSasije = @BrojSasije";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BrojSasije", brojSasije);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DateTime datumPregleda = reader.GetDateTime(1);
                        bool rezultatTehnickog = reader.GetBoolean(0);

                        if (rezultatTehnickog)
                        {
                            if (datumPregleda >= tridesetDanaAgo)
                            {
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Vozilo nije proslo tehnicki pregled u zadnjih 30 dana.");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vozilo nije proslo tehnicki pregled.");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nema informacija o tehnickom pregledu za unijeti broj sasije.");
                        return false;
                    }
                }
            }
        }

        private void AzurirajRegistracijuVozila31(SqlConnection conn)
        {
            if (radioButton3.Checked && radioButton1.Checked)
            {
                string query = "UPDATE RegistrovanaVozila SET RegistrationDate = GETDATE() WHERE BrSasije = @brojSasije";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@brojSasije", brojSasije);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registracija vozila je uspjesno produzena.");
                    }
                    else
                    {
                        MessageBox.Show("Vozilo sa unijetim brojem sasije nije pronadjeno u bazi RegistrovanaVozila.");
                    }
                }
            }
        }

        private void AzurirajRegistracijuVozila32(SqlConnection conn)
        {
            if (radioButton3.Checked && radioButton2.Checked)
            {
                string query = "UPDATE RegistrovanaVozila SET RegistrationDate = GETDATE(), RegTablice = @noveTablice WHERE BrSasije = @brojSasije";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@brojSasije", brojSasije);
                    cmd.Parameters.AddWithValue("@noveTablice", tablice);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registracija vozila je uspjesno produzena.");
                    }
                    else
                    {
                        MessageBox.Show("Vozilo sa unijetim brojem sasije nije pronadjeno u bazi RegistrovanaVozila.");
                    }
                }
            }
        }

        private void UpisiURegistrovanaVozila(SqlConnection conn)
        {
            string registrationDate = DateTime.Now.ToString("yyyy-MM-dd");

            string query = "INSERT INTO RegistrovanaVozila (RegistrationDate, JMBG, BrSasije, RegTablice) VALUES (@registrationDate, @jmbg, @brSasije, @regTablice)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@registrationDate", registrationDate);
                cmd.Parameters.AddWithValue("@jmbg", jmbg);
                cmd.Parameters.AddWithValue("@brSasije", brojSasije);
                cmd.Parameters.AddWithValue("@regTablice", tablice);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Podaci o registrovanom vozilu su uspešno upisani u bazu RegistrovanaVozila.");
                }
                else
                {
                    MessageBox.Show("Greška prilikom upisa podataka o registrovanom vozilu u bazu RegistrovanaVozila.");
                }
            }
        }

        private void UpisiStikerUBazu(SqlConnection conn)
        {
            string registrationDate = DateTime.Now.ToString("yyyy-MM-dd");
            string? regTablice = GetRegTabliceFromBazaRegistrovanaVozila(conn);
            bool status = true; 

            string updateQuery = "UPDATE StikerInformacije SET Status = 0 WHERE BrSasije = @brSasije AND Status = 1";

            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
            {
                updateCmd.Parameters.AddWithValue("@brSasije", brojSasije);
                updateCmd.ExecuteNonQuery();
            }

            string insertQuery = "INSERT INTO StikerInformacije (RegistrationDate, BrSasije, RegTablice, Stiker, Status) " +
                                 "VALUES (@registrationDate, @brSasije, @regTablice, @stiker, @status)";

            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
            {
                insertCmd.Parameters.AddWithValue("@registrationDate", registrationDate);
                insertCmd.Parameters.AddWithValue("@brSasije", brojSasije);
                insertCmd.Parameters.AddWithValue("@regTablice", regTablice);
                insertCmd.Parameters.AddWithValue("@stiker", stiker);
                insertCmd.Parameters.AddWithValue("@status", status);

                int rowsAffected = insertCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Stiker je uspešno upisan u bazu StikerInformacije.");
                }
                else
                {
                    MessageBox.Show("Greška prilikom upisa stikera u bazu StikerInformacije.");
                }
            }
        }

        private string? GetRegTabliceFromBazaRegistrovanaVozila(SqlConnection conn)
        {
            string? regTablice = "";

            string query = "SELECT RegTablice FROM RegistrovanaVozila WHERE BrSasije = @brSasije";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@brSasije", brojSasije);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    regTablice = reader["RegTablice"].ToString();
                }

                reader.Close();
            }

            return regTablice;
        }

        private bool ProvjeriVlasnikaUBazi(SqlConnection conn)
        {
            string query = "SELECT COUNT(1) FROM VlasniciInformacije WHERE JMBG = @jmbg";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@jmbg", jmbg);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void UpisiVlasnikaUBazu(SqlConnection conn)
        {
            string? ime = textBox9.Text;
            string? prezime = textBox8.Text;
            string query = "INSERT INTO VlasniciInformacije (Ime, Prezime, JMBG) VALUES (@ime, @prezime, @jmbg)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ime", ime);
                cmd.Parameters.AddWithValue("@prezime", prezime);
                cmd.Parameters.AddWithValue("@jmbg", jmbg);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Novi vlasnik je uspešno upisan u bazu.");
                }
                else
                {
                    MessageBox.Show("Greška prilikom upisa vlasnika u bazu.");
                }
            }
        }

        private void UpisiVoziloUBazu(SqlConnection conn)
        {
            string brojSasije = textBox1.Text;
            string vlasnikJMBG = textBox7.Text;
            string imeVozila = textBox2.Text;
            string boja = textBox3.Text;
            int jacinaMotora = Convert.ToInt32(textBox4.Text);
            int godinaProizvodnje = Convert.ToInt32(textBox5.Text);
            int zapreminaMotora = Convert.ToInt32(textBox6.Text);

            string query = "INSERT INTO VozilaInformacije (BrSasije, VlasnikJMBG, ImeVozila, Boja, JacinaMotora, GodinaProizvodnje, ZapreminaMotora) VALUES (@brojSasije, @vlasnikJMBG, @imeVozila, @boja, @jacinaMotora, @godinaProizvodnje, @zapreminaMotora)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@brojSasije", brojSasije);
                cmd.Parameters.AddWithValue("@vlasnikJMBG", vlasnikJMBG);
                cmd.Parameters.AddWithValue("@imeVozila", imeVozila);
                cmd.Parameters.AddWithValue("@boja", boja);
                cmd.Parameters.AddWithValue("@jacinaMotora", jacinaMotora);
                cmd.Parameters.AddWithValue("@godinaProizvodnje", godinaProizvodnje);
                cmd.Parameters.AddWithValue("@zapreminaMotora", zapreminaMotora);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Novo vozilo je uspešno upisano u bazu.");
                }
                else
                {
                    MessageBox.Show("Greška prilikom upisa vozila u bazu.");
                }
            }
        }

        private bool TablicePostojeUBazi(SqlConnection conn)
        {
            string query = "SELECT COUNT(1) FROM RegistrovanaVozila WHERE RegTablice = @tablice";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tablice", tablice);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void GenerisiTablice(SqlConnection conn)
        {

            Random rand = new Random();
            char[] abeceda = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            do
            {
                tablice = "";
                tablice += rand.Next(10).ToString();
                tablice += rand.Next(10).ToString();
                tablice += rand.Next(10).ToString();
                tablice += "-";
                tablice += abeceda[rand.Next(abeceda.Length)];
                tablice += "-";
                tablice += rand.Next(10).ToString();
                tablice += rand.Next(10).ToString();
                tablice += rand.Next(10).ToString();
            }
            while (TablicePostojeUBazi(conn));

        }

        private bool StikerPostojiUBazi(SqlConnection conn)
        {
            string query = "SELECT COUNT(1) FROM StikerInformacije WHERE Stiker = @stiker";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@stiker", stiker);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        private void GenerisiStiker(SqlConnection conn)
        {
            // generisanje stikera sve dok se ne generise neki koji ne postoji u bazi

            Random rand = new Random();
            do
            {
                stiker = "";
                stiker += (rand.Next(9) + 1).ToString(); //prva cifra uvijek >0
                for (int i = 0; i < 7; i++)
                {
                    stiker += rand.Next(10).ToString();
                }
            }
            while (StikerPostojiUBazi(conn));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            userInitiatedClose = true;
            workerForm.Show();
            this.Close();
        }

        private void RegistracijaVozila_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!userInitiatedClose)
            {
                Application.Exit();
            }
        }
    }
}
