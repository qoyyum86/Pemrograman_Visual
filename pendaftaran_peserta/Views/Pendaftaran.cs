using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace pendaftaran_peserta
{
    public partial class Pendaftaran : Form
    {
        public Pendaftaran()
        {
            InitializeComponent();
        }

        private void Pendaftaran_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=db_pencaksilat;port=3306;password=";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string sql = "INSERT INTO peserta (nama, kontingen, umur_berat, prestasi, kelas_pertandingan) " +
                                 "VALUES (@nama, @kontingen, @umur_berat, @prestasi, @kelas_pertandingan)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@nama", textBox1.Text);
                    cmd.Parameters.AddWithValue("@kontingen", textBox5.Text);
                    cmd.Parameters.AddWithValue("@umur_berat", textBox3.Text);
                    cmd.Parameters.AddWithValue("@prestasi", textBox2.Text);
                    cmd.Parameters.AddWithValue("@kelas_pertandingan", textBox4.Text);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Data berhasil disimpan!");
                    }
                    else
                    {
                        MessageBox.Show("Gagal menyimpan data.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Menampilkan kembali form Dashboard
            Dasboard dashboard = new Dasboard();
            dashboard.Show();

            // Menutup form Pendaftaran
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
