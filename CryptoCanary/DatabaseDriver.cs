using System.Data.SQLite;
using System;
using System.IO;
using System.Text;

namespace CryptoCanary
{
    public class DatabaseDriver
    {
        private static readonly string DatabaseFileName = "CanaryCrumbs.sqlite";
        private static readonly string LogFileName = "CanaryCrumbsLog.ldf";
        private static readonly string DatabaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CryptoCanary\\";
        private static readonly string DatabaseFilePath = DatabaseDirectory + DatabaseFileName;
        private static readonly string LogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CryptoCanary\\" + LogFileName;
        //private static readonly int InitialDatabaseSize = 50;
        //private static readonly int MaxDatabaseSize = 100;
        private static readonly string ConnectionString = "Data Source =" + DatabaseFilePath;

        public static bool DatabaseExists()
        {
            return File.Exists(DatabaseFilePath);
        }

        public static void CreateInitialDatabase()
        {
            CreateDatabase();
            InitializeDatabase();
        }

        private static void InitializeDatabase()
        {
            CreateCryptocurrencyTable();
            CreateHistoricalTable();
        }

        private static void CreateHistoricalTable()
        {
            string stmt = "CREATE TABLE HISTORICAL (ID varchar(35), DATE varchar(50), PRICE DOUBLE(9,2))";
            ExecuteNonQuery(stmt);
        }

        private static void CreateCryptocurrencyTable()
        {
            string stmt = "CREATE TABLE CRYPTOCURRENCIES (ID varchar(35), NAME varchar(50), SYMBOL varchar(10))";
            ExecuteNonQuery(stmt);
        }

        private static void ExecuteNonQuery(string statement)
        {
            using SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(statement, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }
        }

        private static void CreateDatabase()
        {
            if (!File.Exists(DatabaseFilePath))
            {
                //Ensure that the directory structure exists
                if (!Directory.Exists(DatabaseDirectory))
                {
                    Directory.CreateDirectory(DatabaseDirectory);
                }

                using SQLiteConnection connection = new SQLiteConnection(ConnectionString);
                try
                {
                    connection.Open();

                    //StringBuilder createDatabase = new StringBuilder();
                    //createDatabase.Append("CREATE DATABASE CanaryCrumbs ON PRIMARY (")
                    //              .Append("Name=CanaryCrumbs, ")
                    //              .Append("filename='").Append(DatabaseFilePath).Append("', ")
                    //              .Append("size=").Append(InitialDatabaseSize).Append(", ")
                    //              .Append("maxsize=").Append(MaxDatabaseSize).Append(", ")
                    //              .Append("filegrowth=10%) ")

                    //              .Append("LOG ON (")
                    //              .Append("Name=CanaryCrumbsLog, ")
                    //              .Append("filename='").Append(LogFilePath).Append("', ")
                    //              .Append("size=").Append(InitialDatabaseSize).Append(", ")
                    //              .Append("maxsize=").Append(MaxDatabaseSize).Append(", ")
                    //              .Append("filegrowth=1) ");


                    //SQLiteCommand command = new SQLiteCommand(createDatabase.ToString(), connection);
                    //command.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
