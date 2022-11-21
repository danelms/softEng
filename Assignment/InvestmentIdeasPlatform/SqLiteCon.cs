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
    class SqLiteCon : DBConnection
    {
        Dictionary<string, string> memProperties;
        private SQLiteConnection connection;
        private string database;

        public SqLiteCon(Dictionary<string, string> properties) 
        {
            memProperties = properties;
            initialize();
        }

        private void initialize() 
        {
            database = memProperties["Database"];
            setConnection();
        }

        private void setConnection() 
        {
            string connectionString;
            connectionString = "Data Source=" + database + "; Version = 3; New = True; Compress = True; ";
            connection = new SQLiteConnection(connectionString);
        }

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

        public DataSet getDataSet(string sqlStatement) 
        {
            DataSet dataSet;

            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sqlStatement, connection);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

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

    }

    
}
