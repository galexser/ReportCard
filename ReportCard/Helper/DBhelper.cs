using MySqlConnector;
using System.Configuration;
using System.Data;

namespace ReportCard.Helper
{
    public class DBhelper
    {

        public static MySqlConnection GetConnection() => new MySqlConnection(ConfigurationManager.ConnectionStrings["report"].ConnectionString);

        public static DataTable Select(string tableName)
        {
            DataTable ret = new DataTable();
            using (MySqlConnection conn = DBhelper.GetConnection())
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Open();
                MySqlDataAdapter DA = new MySqlDataAdapter($"SELECT * FROM {tableName}", conn);
                DA.Fill(ret);
            }
            return ret;
        }
    }
}
