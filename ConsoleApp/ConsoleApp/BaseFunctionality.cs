using System;
using System.Configuration;
using System.Data;
using Npgsql;

namespace ConsoleApp
{
    public abstract class BaseFunctionality
    {
        protected NpgsqlConnection Connection { get; set; }
        protected NpgsqlCommand Command { get; set; }
        protected NpgsqlDataReader Reader { get; set; }

        protected BaseFunctionality()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MainDataBase"].ToString();
            Connection = new NpgsqlConnection(connectionString);
            Reader = null;
            
            Connect();
        }

        ~BaseFunctionality()
        {
            Disconnect();
        }

        private void Connect()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Disconnect()
        {
            if (Connection == null)
            {
                return;
            }

            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
        
        protected void ExecuteQuery(string query)
        {
            Command = new NpgsqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
        }
    }
}