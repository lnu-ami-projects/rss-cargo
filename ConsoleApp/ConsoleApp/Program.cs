namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var inserter = new InsertFunctionality();
            inserter.TablesInsertion(30);
            
            var printer = new PrintFunctionality();
            printer.PrintAllData();
            
        }
    }
}

// string sql = "DELETE FROM cargos;"; 
// NpgsqlCommand command = new NpgsqlCommand(sql, Connection); 
// command.ExecuteNonQuery();
// sql = "DELETE FROM users;"; 
// command = new NpgsqlCommand(sql, Connection); 
// command.ExecuteNonQuery();
// sql = "DELETE FROM user_feeds;"; 
// command = new NpgsqlCommand(sql, Connection); 
// command.ExecuteNonQuery();
// sql = "DELETE FROM user_cargos;"; 
// command = new NpgsqlCommand(sql, Connection); 
// command.ExecuteNonQuery();
// sql = "DELETE FROM cargo_feeds;"; 
// command = new NpgsqlCommand(sql, Connection); 
// command.ExecuteNonQuery();
//
// sql = "ALTER SEQUENCE users_id_seq RESTART WITH 1;"; 
// command = new NpgsqlCommand(sql, Connection); 
// command.ExecuteNonQuery();
// sql = "ALTER SEQUENCE cargos_id_seq RESTART WITH 1;"; 
// command = new NpgsqlCommand(sql, Connection); 
// command.ExecuteNonQuery();
// sql = "ALTER SEQUENCE cargo_feeds_id_seq RESTART WITH 1;"; 
// command = new NpgsqlCommand(sql, Connection); 
// command.ExecuteNonQuery();
// sql = "ALTER SEQUENCE user_feeds_id_seq RESTART WITH 1;"; 
// command = new NpgsqlCommand(sql, Connection); 
// command.ExecuteNonQuery();
// sql = "ALTER SEQUENCE user_cargos_id_seq RESTART WITH 1;"; 
// command = new NpgsqlCommand(sql, Connection); 
// command.ExecuteNonQuery();