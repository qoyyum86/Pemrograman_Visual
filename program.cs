using System;
using System.Windows.Forms;

namespace PendaftaranPesilatApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Form Pendaftaran Peserta Pertandingan";
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbBuktiBayar.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void btnKirim_Click(object sender, EventArgs e)
        {
            string info =
                $"Nama Atlet: {txtNama.Text}\n" +
                $"Kontingen: {txtKontingen.Text}\n" +
                $"Tinggi & Berat: {txtTinggiBerat.Text}\n" +
                $"Kelas Pertandingan: {txtKelas.Text}\n" +
                $"Prestasi/Pemasalan: {txtPrestasi.Text}\n" +
                $"Bukti: {(pbBuktiBayar.ImageLocation != null ? "Sudah diupload" : "Belum diupload")}";

            MessageBox.Show(info, "Data Terkirim", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
