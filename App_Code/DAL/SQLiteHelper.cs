using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;

/// <summary>
/// Summary description for SQLiteHelper
/// </summary>
namespace GradPath.App_Code.DAL
{
    public abstract class SQLiteHelper
    {
        private static SQLiteConnection Connect()
        {
            SQLiteConnection connection = new SQLiteConnection();

            connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLiteDatabase"].ConnectionString;
            connection.Open();

            return connection;
        }

        public static void Execute(string commandText)
        {
            SQLiteConnection connection = new SQLiteConnection();
            SQLiteCommand command;

            try
            {
                connection = Connect();

                command = connection.CreateCommand();
                command.CommandText = commandText;
                command.ExecuteNonQuery();
            }
            catch
            {
                //handle exceptions
            }
            finally
            {
                connection.Close();
            }
        }

        public static DataTable Retrieve(string commandText)
        {
            SQLiteConnection connection = new SQLiteConnection();
            SQLiteDataAdapter dataAdapter;
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            try
            {
                connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SQLiteDatabase"].ConnectionString;
                connection.Open();

                dataAdapter = new SQLiteDataAdapter(commandText, connection);
                dataSet.Reset();
                dataAdapter.Fill(dataSet);

                dataTable = dataSet.Tables[0];
            }
            catch(Exception e)
            {
                string error_message = e.Message;
                //handle exceptions
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }

    }
}