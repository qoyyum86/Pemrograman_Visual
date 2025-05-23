using System;
using System.Data;
using System.Windows.Forms;

namespace pendaftaran_peserta
{
    public partial class Data_Peserta : Form
    {
        PesertaRepository repo = new PesertaRepository();

        public Data_Peserta()
        {
            InitializeComponent();
        }

        private void Data_Peserta_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void LoadData()
        {
            try
            {
                dataGridView1.DataSource = repo.GetAllPeserta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        private void UpdateData()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                try
                {
                    repo.UpdatePeserta(id, textBox1.Text, textBox6.Text, textBox5.Text, textBox4.Text, textBox3.Text);
                    MessageBox.Show("Data berhasil diupdate!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang ingin diupdate!");
            }
        }

        private void DeleteData()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                DialogResult result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        repo.DeletePeserta(id);
                        MessageBox.Show("Data berhasil dihapus!");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saat hapus: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih baris data yang ingin dihapus!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kosongkan atau tambahkan sesuai kebutuhan
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dasboard dasboardForm = new Dasboard();
            dasboardForm.Show();
            this.Close();
        }
    }
}
