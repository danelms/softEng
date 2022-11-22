using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;

namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Class used to instantiate SqLiteCon
    /// </summary>
    class SqLiteCon : DBConnection
    {
        Dictionary<string, string> memProperties;
        private SQLiteConnection connection;
        private string database;

        /// <summary>
        /// Constructor
        /// </summary>
        public SqLiteCon(Dictionary<string, string> properties) 
        {
            memProperties = properties;
            initialise();
        }

        /// <summary>
        /// Initialises the connection to the database
        /// </summary>
        private void initialise() 
        {
            database = memProperties["Database"];
            setConnection();
        }

        /// <summary>
        /// Establishes database connection properties as a connection string and connects to the database
        /// </summary>
        private void setConnection() 
        {
            string connectionString;
            connectionString = "Data Source=" + database + "; Version = 3; New = True; Compress = True; ";
            connection = new SQLiteConnection(connectionString);
        }

        /// <summary>
        /// Closes the database connection
        /// </summary>
        /// <returns><b>bool</b> that reflects whether or not the database connection has successfully closed</returns>
        public bool CloseConnection() 
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SQLiteException ex) 
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Fetches and returns a dataset using an SQL statement
        /// </summary>
        /// <param name="sqlStatement"><b>string</b> containing the SQL statement</param>
        /// <returns></returns>
        public DataSet getDataSet(string sqlStatement) 
        {
            DataSet dataSet;

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sqlStatement, connection);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        /// <summary>
        /// Opens the connection to the database
        /// </summary>
        /// <returns><b>bool</b> that reflects whether or not the database connection has succesfully opened</returns>
        public bool OpenConnection() 
        {
            bool connected = false;
            try
            {
                connection.Open();
                connected = true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Cannot connect to a database. \n" + ex.Message);
            }
            return connected;
        }

        /// <summary>
        /// Used to execute an SQL select query
        /// </summary>
        /// <param name="query"></param>
        /// <returns>The results of the query</returns>
        public DbDataReader Select(string query)
        {
            DbDataReader dr = null;

            if (null != connection)
            {
                //Create Command
                SQLiteCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                //Create a data reader and Execute the command
                dr = cmd.ExecuteReader();
            }
            return dr;
        }

        public void Insert(string query, int accountType, String username, String password)
        {
            if (null != connection)
            {
                //Create Command
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.Add("@accountType", DbType.Int64).Value = accountType;
                cmd.Parameters.Add("@username", DbType.String).Value = username;
                cmd.Parameters.Add("@password", DbType.String).Value = password;
                //Create a data reader and Execute the command
                cmd.ExecuteNonQuery();
            }
        }
    }

    
}
