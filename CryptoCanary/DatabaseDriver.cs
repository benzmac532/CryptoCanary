using System.Data.SQLite;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CryptoCanary
{
    public class DatabaseDriver
    {
        private static readonly string DatabaseFileName = "CanaryCrumbs.sqlite";
        private static readonly string DatabaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CryptoCanary\\";
        private static readonly string DatabaseFilePath = DatabaseDirectory + DatabaseFileName;
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
            Logger.LogDebug("Creating HISTORICAL table.");
            ExecuteNonQuery(stmt);
        }

        private static void CreateCryptocurrencyTable()
        {
            string stmt = "CREATE TABLE CRYPTOCURRENCIES (ID varchar(35), NAME varchar(50), SYMBOL varchar(10))";
            Logger.LogDebug("Creating CRYPTOCURRENCIES table.");
            ExecuteNonQuery(stmt);
        }

        public static async Task UpdateCryptocurrencyData()
        {
            var list = await APIDriver.GetCurrentCryptocurrencyList();

            await Task.Run(() =>
            {                
                foreach (CryptoCurrency c in list)
                {
                    if (CryptocurrencyExistsInDatabase(c) == false)
                    {
                        AddCryptocurrencyToDatabase(c);
                    }
                }
            });
        }

        public static async Task UpdateHistoricalData()
        {
            var list = await APIDriver.GetCurrentCryptocurrencyList();

            await Task.Run(() =>
            {
                foreach(CryptoCurrency c in list)
                {
                    RefreshHistoricalData(c);
                }
            });
        }

        private static void RefreshHistoricalData(CryptoCurrency c)
        {
            DateTime now = DateTime.Now;
            int daysInMonth = 30;

            for(int i=daysInMonth; i>0; i--)
            {
                DateTime dateToCheck = now.AddDays(i * -1);
                if (!CryptocurrencyHasHistoricalData(dateToCheck, c.ID))
                {
                    AddHistoricalDataForCryptocurrency(c, dateToCheck);
                }
            }
        }

        private static void AddHistoricalDataForCryptocurrency(CryptoCurrency c, DateTime date)
        {
            string d = GetFormattedDate(date);
            Logger.LogDebug("Adding historical data for " + c.Name + " on date " + d);
        }

        private static bool CryptocurrencyHasHistoricalData(DateTime date, string id)
        {
            bool hasData = false;
            string d = GetFormattedDate(date);
            string query = "SELECT ID FROM HISTORICAL WHERE ID = '" + id + "' AND DATE = '" + d + "'";

            using SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                hasData = !string.IsNullOrEmpty(command.ExecuteScalar() as string);
            }
            catch(Exception e)
            {
                Logger.LogException(e);
            }
            finally
            {
                connection.Close();
            }

            return hasData;
        }

        private static string GetFormattedDate(DateTime date)
        {
            return date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
        }

        private static bool CryptocurrencyExistsInDatabase(CryptoCurrency c) 
        {
            bool exists = false;

            string query = "SELECT NAME FROM CRYPTOCURRENCIES WHERE ID = :id";

            using SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("ID", c.ID));
                string id = command.ExecuteScalar() as string;
                exists = !string.IsNullOrEmpty(id);
            }
            catch(Exception e)
            {
                Logger.LogException(e);
            }
            finally
            {
                connection?.Close();
            }

            return exists;
        }

        private static void AddCryptocurrencyToDatabase(CryptoCurrency c)
        {
            string insertStatement = "INSERT INTO CRYPTOCURRENCIES (ID, NAME, SYMBOL) VALUES ('" + c.ID + "', '" + c.Name + "', '" + c.Symbol + "')";
            Logger.LogDebug("First time seeing " + c.Name + ". Adding to the database.");

            using SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(insertStatement, connection);
                command.Parameters.Add(new SQLiteParameter("ID", c.ID));
                command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Logger.LogException(e);
            }
            finally
            {
                connection?.Close();
            }
        }

        private static void ExecuteNonQuery(string statement)
        {
            Logger.LogDebug("Executing Non Query: " + statement);

            using SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            try
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(statement, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Logger.LogException(e);
            }
            finally
            {
                connection?.Close();
            }
        }

        private static void CreateDatabase()
        {
            if (!File.Exists(DatabaseFilePath))
            {
                Logger.LogDebug("Database: " + DatabaseFilePath + " doesn't exist. Creating...");

                //Ensure that the directory structure exists
                if (!Directory.Exists(DatabaseDirectory))
                {
                    Directory.CreateDirectory(DatabaseDirectory);
                }

                using SQLiteConnection connection = new SQLiteConnection(ConnectionString);
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    Logger.LogException(e);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
