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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Di sini kamu bisa tambahkan logika menyimpan data (misalnya ke database, file, dll)
            string nama = textBox1.Text;
            string password = textBox2.Text;

            // Validasi sederhana
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Nama dan Password tidak boleh kosong.");
                return;
            }

            // Simulasi penyimpanan berhasil (ganti dengan logika penyimpanan sebenarnya)
            MessageBox.Show("Pendaftaran berhasil! Silakan login.");

            // Pindah ke form login
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide(); // Menyembunyikan form Register
        }


    }
}
