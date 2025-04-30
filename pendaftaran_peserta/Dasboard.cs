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
    public partial class Dasboard : Form
    {
        public Dasboard()
        {
            InitializeComponent();
        }

        private void Dasboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pendaftaran pendaftaranForm = new Pendaftaran();
            pendaftaranForm.Show();
            this.Hide(); // jika ingin dashboard disembunyikan
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Membuka form Data_Peserta
            Data_Peserta dataPesertaForm = new Data_Peserta();
            dataPesertaForm.Show();  // Menampilkan form Data_Peserta
            this.Hide();  // Menyembunyikan form Dasboard (opsional)
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            // Tampilkan form Login
            Login loginForm = new Login();
            loginForm.Show();

            // Tutup form Dasboard saat ini
            this.Close();
        }


    }
}
