using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;
using System.Reflection;

/// <summary>
/// Summary description for SQLiteHelper
/// </summary>
public abstract class SQLiteHelper
{
    /**
        SQLiteConnection
        SQLiteCommand
        SQLiteDataAdapter
        DataSet DS = new DataSet();
        DataTable DT = new DataTable();
    */

    public void Execute(string commandText)
    {
        SQLiteConnection connection = new SQLiteConnection();
        SQLiteCommand command = new SQLiteCommand();

        try
        {
            connection.ConnectionString = "Data Source=/data/gradpath.db";
            connection.Open();
            
            command = connection.CreateCommand();
            command.CommandText = commandText;

            command.ExecuteNonQuery();
        }
        catch
        {
            //display any exeptions
        }
        finally
        {
            connection.Close();
        }
    }

    private DataTable Retrieve(string commandText)
    {
        SQLiteConnection connection = new SQLiteConnection();
        SQLiteCommand command = new SQLiteCommand();
        SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter();

        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();

        try
        {
            connection.ConnectionString = "Data Source=/data/gradpath.db";
            connection.Open();

            command = connection.CreateCommand();
            dataAdapter = new SQLiteDataAdapter(commandText, connection);

            dataSet.Reset();
            dataAdapter.Fill(dataSet);
            dataTable = dataSet.Tables[0];
        }
        catch
        {
            //display any exeptions
        }
        finally
        {
            connection.Close();
        }

        return dataTable; //dataTable.DataTableToList<int>
    }

}

public static class Helper
{
    private static readonly IDictionary<Type, ICollection<PropertyInfo>> _Properties = new Dictionary<Type, ICollection<PropertyInfo>>();

    /// <summary>
    /// Converts a DataTable to a list with generic objects
    /// </summary>
    /// <typeparam name="T">Generic object</typeparam>
    /// <param name="table">DataTable</param>
    /// <returns>List with generic objects</returns>
    public static IEnumerable<T> DataTableToList<T>(this DataTable table) where T : class, new()
    {
        try
        {
            var objType = typeof(T);
            ICollection<PropertyInfo> properties;

            lock (_Properties)
            {
                if (!_Properties.TryGetValue(objType, out properties))
                {
                    properties = objType.GetProperties().Where(property => property.CanWrite).ToList();
                    _Properties.Add(objType, properties);
                }
            }

            var list = new List<T>(table.Rows.Count);

            foreach (var row in table.AsEnumerable().Skip(1))
            {
                var obj = new T();

                foreach (var prop in properties)
                {
                    try
                    {
                        var propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        var safeValue = row[prop.Name] == null ? null : Convert.ChangeType(row[prop.Name], propType);

                        prop.SetValue(obj, safeValue, null);
                    }
                    catch
                    {
                        // ignored
                    }
                }

                list.Add(obj);
            }

            return list;
        }
        catch
        {
            return Enumerable.Empty<T>();
        }
    }
}