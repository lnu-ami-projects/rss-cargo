using System;
using Npgsql;
using ConsoleTables;

namespace ConsoleApp
{
    public class InteractionFunctionality: ConnectionFunctionality
    {
        private readonly RandomGenerator _randomGenerator = new();
        private int TableSize(string tableName)
        {
            ExecuteQuery($"SELECT COUNT(*) FROM {tableName}");
            Reader.Read();
            var res = Reader[0];
            Reader.Close();
            return Convert.ToInt32((Int64)res);
        }
        
        public void TablesInsertion(int n)
        {
            for (var i = 0; i < n; ++i)
            {
                UsersTableInsertion();
                CargosTableInsertion();
            }

            for (var i = 0; i < n; ++i)
            {
                UserFeedsTableInsertion();
                CargoFeedsInsertion();
                UserGargosTableInsertion();
            }
            
        }
        
        public void UsersTableInsertion()
        {
            var name = _randomGenerator.RandomString(10);
            var email = name.ToLower() + _randomGenerator.RandomEmailService();
            var password = _randomGenerator.RandomPassword();
            try                                            
            {
                Command = new NpgsqlCommand($"INSERT INTO users(username, email, password) VALUES ('{name}', '{email}', '{password}')", Connection);
                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception:\tEmail is already in database.\n");
            }
        }
        
        public void CargosTableInsertion()
        {
            var name = _randomGenerator.RandomString(16);
            try                                            
            {
                Command = new NpgsqlCommand($"INSERT INTO cargos(name) VALUES ('{name}')", Connection);
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception:\t {e.Message}\n");
            }
        }
        
        public void UserFeedsTableInsertion()
        {
            var userId = _randomGenerator.RandomNumber(TableSize("users"));
            var rssFeed = "https://"+_randomGenerator.RandomString(30) + ".com";
            try                                            
            {
                Command = new NpgsqlCommand($"INSERT INTO user_feeds(user_id,rss_feed) VALUES ('{userId}', '{rssFeed}')", Connection);
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception:\t {e.Message}\n");
            }
        }
        
        public void UserGargosTableInsertion()
        {
            var userId = _randomGenerator.RandomNumber(TableSize("users"));
            var cargoId = _randomGenerator.RandomNumber(TableSize("cargos"));
            try                                            
            {
                Command = new NpgsqlCommand($"INSERT INTO user_cargos(user_id,cargo_id) VALUES ('{userId}', '{cargoId}')", Connection);
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception:\t{e.Message}\n");
            }
        }

        public void CargoFeedsInsertion()
        {
            var cargoId = _randomGenerator.RandomNumber(TableSize("cargos"));
            var rssFeed = "https://" + _randomGenerator.RandomString(30) + ".com";
            try                                            
            {
                Command = new NpgsqlCommand($"INSERT INTO cargo_feeds(cargo_id,rss_feed) VALUES ('{cargoId}', '{rssFeed}')", Connection);
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception:\t{e.Message}\n");
            }
        }
        
        public void PrintAllData()
        {
            Print("users");
            Print("cargos");
            Print("user_feeds");
            Print("user_cargos");
            Print("cargo_feeds");
        }

        public void Print(string tableName)
        {
            ExecuteQuery($"select count(*) from information_schema.columns where table_name='{tableName}';");
            Reader.Read();
            var amountColumns = Convert.ToInt32(Reader[0]);
            Reader.Close();

            ExecuteQuery($"SELECT * FROM {tableName}");
            Console.WriteLine($"{tableName} table:");
            var names = new string[amountColumns];
            for (var i = 0; i < amountColumns; ++i)
            {
                names[i] = Reader.GetName(i);
            }
            
            var table = new ConsoleTable();
            table.AddColumn(names);
            
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    var row = new string[amountColumns];
                    for (var i = 0; i < amountColumns; ++i)
                    {
                        row[i] = Convert.ToString(Reader[i]);
                    }
                    table.AddRow(row);
                }
            }            
            table.Write(Format.Alternative);

            Reader.Close();
        }
        
        public void TablesDeletion()
        {
            Deletion("users");
            Deletion("cargos");
            Deletion("user_feeds");
            Deletion("user_cargos");
            Deletion("cargo_feeds");
        }

        public void Deletion(string tableName)
        {
            Command = new NpgsqlCommand($"DELETE FROM {tableName};", Connection);
            Command.ExecuteNonQuery();
            Command = new NpgsqlCommand($"ALTER SEQUENCE {tableName}_id_seq RESTART WITH 1;", Connection); 
            Command.ExecuteNonQuery();
        }
    }
}