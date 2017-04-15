using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace AIS.Database
{
    public abstract class RepositoryBase
    {
        internal IDbConnection LocalDBConnection
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LocalDBConnection"].ToString();
                return string.IsNullOrEmpty(connectionString) ? new MySqlConnection() : new MySqlConnection(connectionString);
            }
        }
    }
}
