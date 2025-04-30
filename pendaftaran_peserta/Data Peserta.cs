using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pendaftaran_peserta
{
    public partial class Data_Peserta : Form
    {
        private string connString = "Server=localhost;Database=db_pencaksilat;Uid=root;Pwd=;";

        public Data_Peserta()
        {
            InitializeComponent();
        }

        private void Data_Peserta_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["nama"].Value.ToString();
                textBox6.Text = row.Cells["kontingen"].Value.ToString();
                textBox5.Text = row.Cells["umur_berat"].Value.ToString();
                textBox4.Text = row.Cells["prestasi"].Value.ToString();
                textBox3.Text = row.Cells["kelas_pertandingan"].Value.ToString();
            }
        }


        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, nama, kontingen, umur_berat, prestasi, kelas_pertandingan FROM peserta";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void UpdateData()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        string query = @"UPDATE peserta 
                                         SET nama = @nama, kontingen = @kontingen, umur_berat = @umur_berat, 
                                             prestasi = @prestasi, kelas_pertandingan = @kelas 
                                         WHERE id = @id";

                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nama", textBox1.Text);
                        cmd.Parameters.AddWithValue("@kontingen", textBox6.Text);
                        cmd.Parameters.AddWithValue("@umur_berat", textBox5.Text);
                        cmd.Parameters.AddWithValue("@prestasi", textBox4.Text);
                        cmd.Parameters.AddWithValue("@kelas", textBox3.Text);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show
                            ("Data berhasil diupdate!");
                        // <--- WAJIB: Refresh dataGridView setelah update
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void DeleteData()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                DialogResult result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM peserta WHERE id = @id";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Data berhasil dihapus!");

                            LoadData(); // Refresh DataGridView
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error saat hapus: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih baris data yang ingin dihapus!");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Tampilkan form Dasboard
            Dasboard dasboardForm = new Dasboard();
            dasboardForm.Show();

            // Tutup form Data_Peserta saat ini
            this.Close();
        }

    }
}
