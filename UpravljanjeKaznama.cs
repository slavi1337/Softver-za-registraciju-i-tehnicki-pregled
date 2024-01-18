using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftverZaRegistraciju
{
    public partial class UpravljanjeKaznama : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";
        bool userInitiatedClose = false;
        private Form workerForm;
        public UpravljanjeKaznama(Form worker)
        {
            InitializeComponent();
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            workerForm = worker;
        }

        private void UcitajSveKazne()
        {
            DataTable dataTable = new DataTable();
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "SELECT ID, PenaltyDate, VlasnikJMBG, Iznos, Opis, IsPaid FROM IstorijaKazni";
                using (var cmd = new SqlCommand(query, con))
                {
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

        private void UpravljanjeKaznama_Load(object sender, EventArgs e)
        {
            UcitajSveKazne();
        }

        private void dataGridView1_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                switch (col.DataPropertyName)
                {
                    case "ID":
                        col.HeaderText = "ID Kazne";
                        break;
                    case "PenaltyDate":
                        col.HeaderText = "Datum Kazne";
                        break;
                    case "VlasnikJMBG":
                        col.HeaderText = "JMBG";
                        break;
                    case "Iznos":
                        col.HeaderText = "Iznos";
                        break;
                    case "Opis":
                        col.HeaderText = "Opis";
                        break;
                    case "Status":
                        col.HeaderText = "Status";
                        break;
                }
            }
        }

        private void IzbrisiKaznu(int idKazne)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "DELETE FROM IstorijaKazni WHERE ID = @ID";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", idKazne);
                    cmd.ExecuteNonQuery();
                }
            }
            UcitajSveKazne();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Da li ste sigurni da zelite da izbrisete kaznu?", "Potvrda", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    var idKazne = (int)selectedRow.Cells["ID"].Value;
                    IzbrisiKaznu(idKazne);
                }
            }
            else
            {
                MessageBox.Show("Morate selektovati ceo red da biste izbrisali kaznu.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //prejaka stvar, ne moram sam praviti logiku da se glavna forma ne moze
            //zatvoriti dok se ove manje forme otvorene ne zatvore, ovo rijesava problem
            var formaZaDodavanjeKazne = new DodavanjeKazne();
            formaZaDodavanjeKazne.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UcitajSveKazne();
            textBox1.Text = "";
        }

        private void FiltrirajPoJMBG(string jmbg)
        {
            if (dataGridView1.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = $"VlasnikJMBG = '{jmbg}'";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string jmbg = textBox1.Text;
            if (jmbg.Length == 13)
            {
                FiltrirajPoJMBG(jmbg);
            }
            else
            {
                MessageBox.Show("JMBG mora imati 13 cifara.");
            }
        }

        // Metoda za prikaz svih neplaćenih kazni za uneti JMBG
        private void PrikaziNeplaceneKazne(string jmbg)
        {
            if (dataGridView1.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = $"VlasnikJMBG = '{jmbg}' AND Status = 'NEPLACENA'";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Ako je textBox1 prazan, filtriraj sve neplacene kazne
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                FiltrirajKaznePoStatusu("NEPLACENA");
            }
            else if (textBox1.Text.Length == 13)
            {
                PrikaziNeplaceneKazne(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Unesite JMBG od 13 cifara ili ostavite prazno za prikaz svih kazni.");
            }
        }

        private void FiltrirajKaznePoStatusu(string status)
        {
            FiltrirajKazne("Status = '" + status + "'");
        }

        private void FiltrirajKazne(string filter)
        {
            if (dataGridView1.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = filter;
            }
        }

        private void PrikaziSveKazneZaJMBG(string jmbg)
        {
            FiltrirajKazne("VlasnikJMBG = '" + jmbg + "'");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                // Ako je textBox1 prazan, ukloni filtere i prikazi sve kazne
                UcitajSveKazne();
            }
            else if (textBox1.Text.Length == 13)
            {
                // Ako je unet JMBG od 13 cifara, filtriraj kazne za taj JMBG
                PrikaziSveKazneZaJMBG(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Unesite JMBG od 13 cifara ili ostavite prazno za prikaz svih kazni.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userInitiatedClose = true;
            workerForm.Show();
            this.Close();
        }

        private void UpravljanjeKaznama_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!userInitiatedClose)
            {
                Application.Exit();
            }
        }
    }
}
