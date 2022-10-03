using System;
using Npgsql;

namespace ConsoleApp
{
    public class ChangeFunctionality: BaseFunctionality
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
        
        public void TablesDeletion()
        {
            UsersDeletion();
            CargosDeletion();
            UserFeedsDeletion();
            UserCargosDeletion();
            CargoFeedsDeletion();
        }

        public void UsersDeletion()
        {
            Command = new NpgsqlCommand("DELETE FROM users;", Connection); 
            Command.ExecuteNonQuery();
            Command = new NpgsqlCommand("ALTER SEQUENCE users_id_seq RESTART WITH 1;", Connection); 
            Command.ExecuteNonQuery();
        }
        
        public void CargosDeletion()
        {
            Command = new NpgsqlCommand("DELETE FROM cargos;", Connection);
            Command.ExecuteNonQuery();
            Command = new NpgsqlCommand("ALTER SEQUENCE cargos_id_seq RESTART WITH 1;", Connection); 
            Command.ExecuteNonQuery();
        }
        
        public void UserFeedsDeletion()
        {
            Command = new NpgsqlCommand("DELETE FROM user_feeds;", Connection); 
            Command.ExecuteNonQuery();
            Command = new NpgsqlCommand("ALTER SEQUENCE user_feeds_id_seq RESTART WITH 1;", Connection); 
            Command.ExecuteNonQuery();
        }
        
        public void UserCargosDeletion()
        {
            Command = new NpgsqlCommand("DELETE FROM user_cargos;", Connection);
            Command.ExecuteNonQuery();
            Command = new NpgsqlCommand("ALTER SEQUENCE user_cargos_id_seq RESTART WITH 1;", Connection); 
            Command.ExecuteNonQuery();
        }
        
        public void CargoFeedsDeletion()
        {
            Command = new NpgsqlCommand("DELETE FROM cargo_feeds;", Connection);
            Command.ExecuteNonQuery();
            Command = new NpgsqlCommand("ALTER SEQUENCE cargo_feeds_id_seq RESTART WITH 1;", Connection); 
            Command.ExecuteNonQuery();
        }
    }
}