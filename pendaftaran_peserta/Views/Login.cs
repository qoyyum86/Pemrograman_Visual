using System;
using System.Data;
using MySql.Data.MySqlClient; 
using System.Windows.Forms;

namespace pendaftaran_peserta
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text;
            string password = textBox2.Text;

            MySqlConnection conn = Database.GetConnection();

            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM pengguna WHERE nama = @nama AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@password", password);

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int count) && count > 0)
                {
                    Dasboard dashboard = new Dasboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nama atau Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide(); // Menyembunyikan form login
        }
    }
}
