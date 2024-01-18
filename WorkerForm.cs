using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace SoftverZaRegistraciju
{
    public partial class WorkerForm : Form
    {
        private string loggedInUsername;
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";
        private CalcForm? calcForm = null;
        private changePass? passChangeForm = null;

        public WorkerForm(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CloseSecondaryForms();
            this.Hide();
            Form1 loginForm = new Form1();
            loginForm.Closed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (passChangeForm == null || passChangeForm.IsDisposed)
            {
                passChangeForm = new changePass(loggedInUsername);
                passChangeForm.FormClosed += (s, args) => passChangeForm = null;
                passChangeForm.Show();
            }
            else
            {
                MessageBox.Show("Vec imate otvorenu formu za mijenjanje sifre.\nZatvorite je, pa je opet mozete pokrenuti.");
            }
        }

        private void FormatDataGridViewHeaders()
        {

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

                switch (col.Name)
                {
                    case "Boja":
                        col.HeaderText = "BOJA";
                        break;
                    case "BrSasije":
                        col.HeaderText = "Broj sasije";
                        break;
                    case "ImeVozila":
                        col.HeaderText = "Vozilo";
                        break;
                    case "GodinaProizvodnje":
                        col.HeaderText = "Godina proizvodnje";
                        break;
                    case "JacinaMotora":
                        col.HeaderText = "Jacina motora [kW]";
                        break;
                    case "ZapreminaMotora":
                        col.HeaderText = "Zapremina motora [ccm]";
                        break;
                    case "DatumIstekaRegistracije":
                        col.HeaderText = "Datum isteka reg.";
                        col.DefaultCellStyle.Format = "dd.MM.yyyy";
                        break;
                    case "RegistarskeTablice":
                        col.HeaderText = "Tablice";
                        break;
                    case "ImeVlasnika":
                        col.HeaderText = "Ime vlasnika";
                        break;
                    case "PrezimeVlasnika":
                        col.HeaderText = "Prezime vlasnika";
                        break;

                }
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void OsveziPodatke()
        {
            using (var con = new SqlConnection(connectionString))
            {
                var query = @"
                SELECT rv.BrSasije, vi.ImeVozila as 'Vozilo', vi.Boja, vi.GodinaProizvodnje, vi.JacinaMotora, 
                vi.ZapreminaMotora, rv.ExpiryDate as 'DatumIstekaRegistracije', rv.RegTablice as 'Tablice', 
                vl.Ime as 'ImeVlasnika', vl.Prezime as 'PrezimeVlasnika', vl.JMBG as 'JMBG Vlasnika'
                FROM RegistrovanaVozila rv
                JOIN VozilaInformacije vi ON rv.BrSasije = vi.BrSasije
                JOIN VlasniciInformacije vl ON vi.VlasnikJMBG = vl.JMBG";

                var adapter = new SqlDataAdapter(query, con);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                FormatDataGridViewHeaders();
            }
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            label3.Text = loggedInUsername;
            OsveziPodatke();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OsveziPodatke();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (calcForm == null || calcForm.IsDisposed)
            {
                calcForm = new CalcForm();
                calcForm.FormClosed += (s, args) => calcForm = null;
                calcForm.Show();
            }
            else
            {
                MessageBox.Show("Vec imate otvorenu formu za kalkulator.\nZatvorite je, pa je opet mozete pokrenuti.");
            }
        }

        private void CloseSecondaryForms()
        {
            calcForm?.Close();
            passChangeForm?.Close();
        }

        private void WorkerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (calcForm != null || passChangeForm != null)
            {
                MessageBox.Show("Molimo zatvorite sve otvorene podforme prije zatvaranja ove forme.");
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form registracijaForm = new RegistracijaVozila(this);
            registracijaForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form upravljanjeKaznama = new UpravljanjeKaznama(this);
            upravljanjeKaznama.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form upravljanjePrekrsajima = new UpravljanjePrekrsajima(this);
            upravljanjePrekrsajima.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Trebate selektovati red u tabeli.");
                return;
            }

            string? brojSasije = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            string? vozilo = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string? boja = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string? godinaProizvodnje = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string? jacinaMotora = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string? zapreminaMotora = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            string? datumRegistracije = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            string? tablice = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            string? imeVlasnika = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            string? prezimeVlasnika = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            string? jmbgVlasnika = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

            string? registracioniStiker = PronadjiStikerUBazi(brojSasije); 
            if (registracioniStiker == null) registracioniStiker = "Nije pronadjen";
            string? izvjestaj = $"Izvjestaj o registraciji vozila\n" +
                               $"Broj sasije: {brojSasije}\n" +
                               $"Vozilo: {vozilo}\n" +
                               $"Boja: {boja}\n" +
                               $"Godina proizvodnje: {godinaProizvodnje}\n" +
                               $"Jacina motora: {jacinaMotora}\n" +
                               $"Zapremina motora: {zapreminaMotora}\n" +
                               $"Datum isteka registracije: {datumRegistracije}\n" +
                               $"Tablice: {tablice}\n" +
                               $"Ime vlasnika: {imeVlasnika}\n" +
                               $"Prezime vlasnika: {prezimeVlasnika}\n" +
                               $"JMBG vlasnika: {jmbgVlasnika}\n" +
                               $"Registracioni stiker: {registracioniStiker}";

            string? imeFajla = $"{brojSasije}.txt";
            string? putanjaFajla = @"C:\Users\Korisnik\Desktop\Softver Za Registraciju\Potvrde\"+imeFajla;

            try
            {
                File.WriteAllText(putanjaFajla, izvjestaj);
                MessageBox.Show($"Izvjestaj je sacuvan u fajlu: {imeFajla}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske pri cuvanju izvestaja: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Trebate selektovati red u tabeli.");
                return;
            }

            string? textZaTablice = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

            string? putanjaSlike = @"C:\Users\Korisnik\Desktop\Softver Za Registraciju\Tablice\tablice_blank.png";

            Font fontZaTablice = new Font("Car-Go", 120);
            Color bojaTeksta = Color.Black;

            try
            {
                using (Bitmap bitmap = (Bitmap)Image.FromFile(putanjaSlike))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        int sirinaSlike = bitmap.Width;
                        int visinaSlike = bitmap.Height;
                        Point centarSlike = new Point(sirinaSlike / 2, visinaSlike / 2);

                        SizeF textSize = graphics.MeasureString(textZaTablice, fontZaTablice);
                        Point lokacijaTeksta = new Point(centarSlike.X - (int)(textSize.Width / 2) + 50, centarSlike.Y - (int)(textSize.Height / 2) + 20);

                        graphics.DrawString(textZaTablice, fontZaTablice, new SolidBrush(bojaTeksta), lokacijaTeksta);
                    }

                    string? putanjaZaCuvanje = @"C:\Users\Korisnik\Desktop\Softver Za Registraciju\Tablice\" + textZaTablice + ".png";
                    bitmap.Save(putanjaZaCuvanje, System.Drawing.Imaging.ImageFormat.Png);

                    Process.Start(new ProcessStartInfo(putanjaZaCuvanje) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske: " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Trebate selektovati red u tabeli.");
                return;
            }

            string? brojSasije = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            string? putanjaSlike = @"C:\Users\Korisnik\Desktop\Softver Za Registraciju\Stikeri\stiker_blank.jpg";

            try
            {
                string? stikerVrednost = PronadjiStikerUBazi(brojSasije);
                if (stikerVrednost == null)
                {
                    MessageBox.Show("Nema stikera");
                    return;
                }
                if (!string.IsNullOrEmpty(stikerVrednost))
                {
                    Font fontZaTablice = new Font("Arial", 20);
                    Color bojaTeksta = Color.Black;

                    using (Bitmap bitmap = (Bitmap)Image.FromFile(putanjaSlike))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            int sirinaSlike = bitmap.Width;
                            int visinaSlike = bitmap.Height;
                            Point centarSlike = new Point(sirinaSlike / 2, 20);

                            SizeF textSize = graphics.MeasureString(stikerVrednost, fontZaTablice);
                            Point lokacijaTeksta = new Point(centarSlike.X - (int)(textSize.Width / 2), 20);

                            graphics.DrawString(stikerVrednost, fontZaTablice, new SolidBrush(bojaTeksta), lokacijaTeksta);
                        }

                        string putanjaZaCuvanje = @"C:\Users\Korisnik\Desktop\Softver Za Registraciju\Stikeri\"+stikerVrednost+".jpg";
                        bitmap.Save(putanjaZaCuvanje, System.Drawing.Imaging.ImageFormat.Png);

                        Process.Start(new ProcessStartInfo(putanjaZaCuvanje) { UseShellExecute = true });
                    }
                }
                else
                {
                    MessageBox.Show("Stiker nije pronadjen ili nije aktivan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske: " + ex.Message);
            }

        }

        private string? PronadjiStikerUBazi(string? brojSasije)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlUpit = "SELECT Stiker FROM StikerInformacije WHERE BrSasije = @BrojSasije AND Status = 1";

                    using (SqlCommand command = new SqlCommand(sqlUpit, connection))
                    {
                        command.Parameters.AddWithValue("@BrojSasije", brojSasije);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string stikerVrednost = reader.GetString(0);
                                return stikerVrednost;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doslo je do greske pri pristupu bazi podataka: " + ex.Message);
                return null;
            }

            return null;
        }
    }
}
