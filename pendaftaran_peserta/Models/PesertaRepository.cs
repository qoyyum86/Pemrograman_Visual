using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace pendaftaran_peserta
{
    public class PesertaRepository
    {
        public DataTable GetAllPeserta()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conn = Database.GetConnection())
            {
                string query = "SELECT id, nama, kontingen, umur_berat, prestasi, kelas_pertandingan FROM peserta";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }

            return dt;
        }

        public void UpdatePeserta(int id, string nama, string kontingen, string umurBerat, string prestasi, string kelas)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE peserta 
                                 SET nama = @nama, kontingen = @kontingen, umur_berat = @umur_berat, 
                                     prestasi = @prestasi, kelas_pertandingan = @kelas 
                                 WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@kontingen", kontingen);
                cmd.Parameters.AddWithValue("@umur_berat", umurBerat);
                cmd.Parameters.AddWithValue("@prestasi", prestasi);
                cmd.Parameters.AddWithValue("@kelas", kelas);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePeserta(int id)
        {
            using (MySqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM peserta WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
