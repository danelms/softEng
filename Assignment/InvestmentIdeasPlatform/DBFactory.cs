using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Diagnostics;
using SQLitePCL;
namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Class used to instantiate DBConnection objects
    /// </summary>
    public class DBFactory
    {
        private static DBConnection memInstance = null;

        Dictionary<string, string> memProperties;
        private static string propfile = "properties.dat";

        /// <summary>
        /// DBFactory constructor
        /// </summary>
        private DBFactory() 
        {
            memProperties = new Dictionary<string, string>();
        }

        /// <summary>
        /// DBConnection constructor
        /// </summary>
        /// <returns>An instance of itself</returns>
        public static DBConnection instance() 
        {
            if (null == memInstance) 
            {
                DBFactory factory = new DBFactory();
                memInstance = factory.getConnection();
            }
            return memInstance;
        }

        /// <summary>
        /// Establishes a connection to the database outlined in the properties.dat file.
        /// Gives an error message if the database is not the type outlined in the properties.dat file
        /// </summary>
        /// <returns></returns>
        private DBConnection getConnection()
        {
            memProperties = getProperties();
            string provider = memProperties["Provider"];
            DBConnection connection = null;

            try
            {
                if (provider.Equals("SQLite"))
                    connection = new SqLiteCon(memProperties);
                else
                    throw new DBException("Not supported provider '" + provider + "'");
            }

            catch (FileNotFoundException e) 
            {
                Debug.WriteLine("Error file not found" + e.Message);
                connection = null;
                throw e;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Property file parsing exception thrown : " + e.Message);
                connection = null;
                throw e;
            }
            return connection;
        }

        /// <summary>
        /// Reads in properties from the properties.dat file
        /// </summary>
        /// <returns>Properties as a <b>Dictionary</b> of two <b>string</b>s</returns>
        private Dictionary<string, string> getProperties()
        {
            string fileData = "";
            using (StreamReader sr = new StreamReader(propfile))
            {
                fileData = sr.ReadToEnd().Replace("\r", "");
            }
            Dictionary<string, string> properties = new Dictionary<string, string>();
            string[] kvp;
            string[] records = fileData.Split("\n".ToCharArray());
            foreach (string record in records)
            {
                kvp = record.Split("=".ToCharArray());
                properties.Add(kvp[0], kvp[1]);
            }
            return properties;
        }
    }

    /// <summary>
    /// DBConnection-specific Exception
    /// </summary>
    class DBException : Exception
    {
        public DBException(string message) : base(message) { }
    }

    /// <summary>
    /// DBConnection interface
    /// </summary>
    public interface DBConnection 
    {
        bool OpenConnection();

        bool CloseConnection();

        DbDataReader Select(String query);

        void Insert(int queryType, String query, params String[] values);

        DataSet getDataSet(string sqlStatement);
    }
}
