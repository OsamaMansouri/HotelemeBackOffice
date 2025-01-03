using MySql.Data.MySqlClient;


    public class Database
    {
        private static string connectionString = "server=localhost;database=HotelManagementSystem;uid=root;pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }

