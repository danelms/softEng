using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentIdeasPlatform
{
    internal class DBConnection
    {
        private static DBConnection instance;
        private static String connectionString;
        private SqlConnection connectionToDB;

        /// <summary>
        /// Establishes a connection to the database
        /// </summary>
        private DBConnection()
        {
            String directory = Directory.GetCurrentDirectory();
            connectionString = "Data Source=" + directory + "Database.db";
        }

        public static DBConnection GetDBConnection()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }

        public DataSet dataSet (string SQLStatement)
        {
            DataSet dataSet = new DataSet();

            using (connectionToDB = new SqlConnection(connectionString))
            {
                connectionToDB.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SQLStatement, connectionToDB);
                dataAdapter.Fill(dataSet);
                connectionToDB.Close();
            }
            
            return dataSet;
        }
    }
}
