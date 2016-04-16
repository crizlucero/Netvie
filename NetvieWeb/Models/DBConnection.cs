using MySql.Data.MySqlClient;

namespace NetvieWeb.Models
{
    class DBConnection
    {
        
        static public string Connection()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.Port = 3306;
            conn_string.UserID = "root";
            conn_string.Password = "";
            conn_string.Database = "netvie";
            return conn_string.ToString();
        }
    }
}
