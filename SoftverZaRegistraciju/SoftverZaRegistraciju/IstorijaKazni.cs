using System.Data;
using System.Data.SqlClient;

namespace SoftverZaRegistraciju
{
    public partial class IstorijaKazni : Form
    {
        private string loggedInUsername;
        private PaymentForm? paymentForm = null;
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";

        public IstorijaKazni(string username)
        {
            InitializeComponent();
            loggedInUsername = username;
            dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);
        }

        // Ucitavanje kazni za korisnika
        private void LoadPenaltiesForUser()
        {
            DataTable dataTable = new DataTable();
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = @"
                SELECT PenaltyDate, Iznos, Opis, IsPaid
                FROM IstorijaKazni
                WHERE VlasnikJMBG = (SELECT JMBG FROM ObicniKorisnickiNalozi WHERE Username = @Username)";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", loggedInUsername);
                    var adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }

            dataTable.Columns.Add("Status", typeof(string));
            foreach (DataRow row in dataTable.Rows)
            {
                row["Status"] = (bool)row["IsPaid"] ? "PLACENA" : "NEPLACENA";
            }
            dataTable.Columns.Remove("IsPaid");
            dataGridView1.DataSource = dataTable;
        }

        private void IstorijaKazni_Load(object sender, EventArgs e)
        {
            LoadPenaltiesForUser();
        }

        // Filtriranje neplacenih kazni
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = "Status = 'NEPLACENA'";
            }
            else
            {
                MessageBox.Show("Podaci nisu ucitani.");
            }
        }

        // Prikaz svih kazni
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = "";
            }
            else
            {
                MessageBox.Show("Podaci nisu ucitani.");
            }
        }

        // Otvori formu za placanje kazne
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Cells["Status"].Value.ToString() == "NEPLACENA")
                {
                    DateTime penaltyDate = (DateTime)selectedRow.Cells["PenaltyDate"].Value;
                    // Treba formatirani datum jer se u bazi cuva u drugom formatu, pa ne mogu porediti
                    string formattedDate = penaltyDate.ToString("dd.MM.yyyy");
                    string iznos = selectedRow.Cells["Iznos"].Value?.ToString() ?? string.Empty;
                    string opis = selectedRow.Cells["Opis"].Value?.ToString() ?? string.Empty;

                    if (paymentForm == null || paymentForm.IsDisposed)
                    {
                        paymentForm = new PaymentForm(formattedDate, iznos, opis, loggedInUsername);
                        paymentForm.FormClosed += (s, args) => paymentForm = null;
                        paymentForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Vec imate otvorenu formu za placanje kazni.");
                    }
                }
                else
                {
                    MessageBox.Show("Kazna je vec placena.");
                }
            }
            else
            {
                MessageBox.Show("Morate selektovati kaznu za placanje.");
            }
        }

        // Podesavanje izgleda DataGridView-a
        private void dataGridView1_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                if (col.DataPropertyName == "PenaltyDate")
                    col.HeaderText = "Datum kazne";
                else if (col.DataPropertyName == "Status")
                    col.HeaderText = "Status";
                else if (col.DataPropertyName == "Iznos")
                    col.HeaderText = "Iznos";
                else if (col.DataPropertyName == "Opis")
                    col.HeaderText = "Opis";
            }
        }

        // Osvezavanje podataka
        private void button4_Click(object sender, EventArgs e)
        {
            LoadPenaltiesForUser();
        }

        // Sprijecavanje zatvaranja forme ako je forma za placanje otvorena
        private void IstorijaKazni_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (paymentForm != null && !paymentForm.IsDisposed)
            {
                MessageBox.Show("Molimo zatvorite formu za placanje kazni pre zatvaranja ove forme.");
                e.Cancel = true;
            }
        }
    }
}
