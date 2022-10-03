using System;
using ConsoleTables;
using Npgsql;

namespace ConsoleApp
{
    public class PrintFunctionality: BaseFunctionality
    {
        private void ExecuteQuery(string query)
        {
            Command = new NpgsqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
        }
        
        public void PrintAllData()
        {
            PrintUsers();
            PrintCargos();
            PrintUserFeeds();
            PrintUserCargos();
            PrintCargoFeeds();
        }

        public void PrintUsers()
        {
            ExecuteQuery("SELECT * FROM users");
            Console.WriteLine("Users Table:");
            var table = new ConsoleTable(Reader.GetName(0), Reader.GetName(1), Reader.GetName(2), Reader.GetName(3));
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    table.AddRow(Reader[0], Reader[1], Reader[2], Reader[3]);
                }
            }            
            table.Write(Format.Alternative);

            Reader.Close();
        }
        public void PrintUserFeeds()
        {
            ExecuteQuery("SELECT * FROM user_feeds");
            Console.WriteLine("User's Feeds Table:");
            var table = new ConsoleTable(Reader.GetName(0), Reader.GetName(1), Reader.GetName(2));
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    table.AddRow(Reader[0], Reader[1], Reader[2]);
                }
            }
            table.Write(Format.Alternative);
            Reader.Close();
        }
        
        public void PrintUserCargos()
        {
            ExecuteQuery("SELECT * FROM user_cargos");
            Console.WriteLine("User's Cargos Table:");
            var table = new ConsoleTable(Reader.GetName(0), Reader.GetName(1), Reader.GetName(2));
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    table.AddRow(Reader[0], Reader[1], Reader[2]);
                }
            }
            table.Write(Format.Alternative);
            Reader.Close();
        }
        
        public void PrintCargos()
        {
            ExecuteQuery("SELECT * FROM cargos");
            Console.WriteLine("Cargos Table:");
            var table = new ConsoleTable(Reader.GetName(0), Reader.GetName(1));
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    table.AddRow(Reader[0], Reader[1]);
                }
            }
            table.Write(Format.Alternative);
            Reader.Close();
        }
        
        public void PrintCargoFeeds()
        {
            ExecuteQuery("SELECT * FROM cargo_feeds");
            Console.WriteLine("Cargo's Feeds Table:");
            var table = new ConsoleTable(Reader.GetName(0), Reader.GetName(1), Reader.GetName(2));
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    table.AddRow(Reader[0], Reader[1], Reader[2]);
                }
            }
            table.Write(Format.Alternative);
            Reader.Close();
        }
    }
}