using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using InvestmentIdeasPlatform;
using System.Data.Entity;

namespace UnitTestProject1
{
    [TestClass]
    public class DatabaseTester
    {

        [TestMethod]
        public void TestSQLiteConnection() 
        {   
            SQLiteConnection sqlCon = new SQLiteConnection("Data Source=testDB.db; Version = 3; New = True; Compress = True; ");
            sqlCon.Open();
            SQLiteCommand cmd = sqlCon.CreateCommand();
            string createTable1 = "CREATE TABLE table_1 (first_column INT, second_column INT)";
            string createTable2 = "CREATE TABLE table_2 (first_column INT, second_column INT)";
            string deleteTable1 = "DROP TABLE table_1";
            string deleteTable2 = "DROP TABLE table_2";
            cmd.CommandText = createTable1;
            cmd.ExecuteNonQuery();
            cmd.CommandText = createTable2;
            cmd.ExecuteNonQuery();
            cmd.CommandText = deleteTable1;
            cmd.ExecuteNonQuery();
            cmd.CommandText = deleteTable2;
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        [TestMethod]
        public void TestSQLiteInsert()
        {
            SQLiteConnection sqlCon = new SQLiteConnection("Data Source=testInsertDB.db; Version = 3; New = True; Compress = True; ");
            sqlCon.Open();
            SQLiteCommand cmd = sqlCon.CreateCommand();
            string createTable1 = "CREATE TABLE table_1 (first_column INT, second_column INT)";
            string createTable2 = "CREATE TABLE table_2 (first_column INT, second_column INT)";
            string insertFullName = "INSERT INTO table_1([first_column], [second_column]) VALUES ('Sevdalin', 'Marinov') ";
            string deleteTable1 = "DROP TABLE table_1";
            string deleteTable2 = "DROP TABLE table_2";
            cmd.CommandText = createTable1;
            cmd.ExecuteNonQuery();
            cmd.CommandText = createTable2;
            cmd.ExecuteNonQuery();
            cmd.CommandText = insertFullName;
            cmd.ExecuteNonQuery();
            cmd.CommandText = deleteTable1;
            cmd.ExecuteNonQuery();
            cmd.CommandText = deleteTable2;
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }


    }
}
