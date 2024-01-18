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
    public partial class UpravljanjePrekrsajima : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-0THU24A\\SQLEXPRESS;Initial Catalog=KorisnickiNalozi;Integrated Security=True";
        bool userInitiatedClose = false;
        private Form workerForm;

        public UpravljanjePrekrsajima(Form worker)
        {
            InitializeComponent();
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
            workerForm = worker;
        }

        private void UcitajSvePrekrsaje()
        {
            DataTable dataTable = new DataTable();
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "SELECT ID, DatumPrekrsaja, VlasnikJMBG, Opis FROM IstorijaPrekrsaja";
                using (var cmd = new SqlCommand(query, con))
                {
                    var adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }
            dataGridView1.DataSource = dataTable;
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
                        col.HeaderText = "ID Prekršaja";
                        break;
                    case "DatumPrekrsaja":
                        col.HeaderText = "Datum Prekršaja";
                        break;
                    case "VlasnikJMBG":
                        col.HeaderText = "JMBG";
                        break;
                    case "Opis":
                        col.HeaderText = "Opis";
                        break;
                }
            }
        }

        private void IzbrisiPrekrsaj(int idPrekrsaja)
        {
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "DELETE FROM IstorijaPrekrsaja WHERE ID = @ID";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", idPrekrsaja);
                    cmd.ExecuteNonQuery();
                }
            }
            UcitajSvePrekrsaje();
        }

        private void FiltrirajPoJMBG(string jmbg)
        {
            if (dataGridView1.DataSource is DataTable dataTable)
            {
                dataTable.DefaultView.RowFilter = $"VlasnikJMBG = '{jmbg}'";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userInitiatedClose = true;
            workerForm.Show();
            this.Close();
        }

        private void UpravljanjePrekrsajima_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (!userInitiatedClose)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UcitajSvePrekrsaje();
            textBox1.Text = "";
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
                MessageBox.Show("JMBG mora imati 13 cifara");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var formaZaDodavanjePrekrsaja = new DodavanjePrekrsaja();
            formaZaDodavanjePrekrsaja.ShowDialog();

            UcitajSvePrekrsaje();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Da li ste sigurni da želite da izbrišete prekršaj?", "Potvrda", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var selectedRow = dataGridView1.SelectedRows[0];
                    var idPrekrsaja = (int)selectedRow.Cells["ID"].Value;
                    IzbrisiPrekrsaj(idPrekrsaja);
                }
            }
            else
            {
                MessageBox.Show("Morate selektovati ceo red da biste izbrisali prekršaj.");
            }
        }

        private void UpravljanjePrekrsajima_Load_1(object sender, EventArgs e)
        {
            UcitajSvePrekrsaje();
        }
    }
}
