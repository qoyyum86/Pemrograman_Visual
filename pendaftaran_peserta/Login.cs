using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pendaftaran_peserta
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text;
            string password = textBox2.Text;

            // Contoh validasi login sederhana
            if (nama == "admin" && password == "123")
            {
                Dasboard dashboard = new Dasboard(); // panggil form dashboard
                dashboard.Show(); // tampilkan dashboard
                this.Hide(); // sembunyikan form login
            }
            else
            {
                MessageBox.Show("Nama atau Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
