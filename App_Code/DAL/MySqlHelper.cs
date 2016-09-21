using MySql.Data.MySqlClient;

namespace GradPath.App_Code.DAL
{
    public abstract class MySqlHelper
    {
        private static MySqlConnection Connect()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection();

                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLDatabase"].ConnectionString;
                connection.Open();

                return connection;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                string errormessage = ex.Message;
                return null;
            }
        }
    }
}