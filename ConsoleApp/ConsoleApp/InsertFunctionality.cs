using System;
using Npgsql;

namespace ConsoleApp
{
    public class InsertFunctionality: BaseFunctionality
    {
        private readonly RandomGenerator _randomGenerator = new();
        
        public void TablesInsertion(int n)
        {
            for (var i = 0; i < n; ++i)
            {
                UsersTableInsertion();
                CargosTableInsertion();
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
        
        public void UserFeedsTableInsertion()
        {
            var userId = _randomGenerator.RandomNumber(30);
            var rssFeed = "https://"+_randomGenerator.RandomString(30) + ".com";
            try                                            
            {
                Command = new NpgsqlCommand($"INSERT INTO user_feeds(user_id,rss_feed) VALUES ('{userId}', '{rssFeed}')", Connection);
                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception:\tUserFeeds is already in database.\n");
            }
        }
        
        public void UserGargosTableInsertion()
        {
            var userId = _randomGenerator.RandomNumber(30);
            var cargoId = _randomGenerator.RandomNumber(30);
            try                                            
            {
                Command = new NpgsqlCommand($"INSERT INTO user_cargos(user_id,cargo_id) VALUES ('{userId}', '{cargoId}')", Connection);
                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception:\tUserGargos is already in database.\n");
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
            catch (Exception)
            {
               Console.WriteLine("Exception:\tCargos is already in database.\n");
            }
        }
        
        public void CargoFeedsInsertion()
        {
            var cargoId = _randomGenerator.RandomNumber(30);
            var rssFeed = "https://" + _randomGenerator.RandomString(30) + ".com";
            try                                            
            {
                Command = new NpgsqlCommand($"INSERT INTO cargo_feeds(cargo_id,rss_feed) VALUES ('{cargoId}', '{rssFeed}')", Connection);
                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Exception:\tCargoFeeds is already in database.\n");
            }
        }
    }
}