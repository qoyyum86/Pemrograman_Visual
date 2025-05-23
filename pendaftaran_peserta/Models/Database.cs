using MySql.Data.MySqlClient;

namespace pendaftaran_peserta
{
    public static class Database
    {
        private static string connString = "Server=localhost;Database=db_pencaksilat;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
    }
}
 