namespace ConsoleApp;
using System.Configuration;
using System.Data;
using Npgsql;

public abstract class ConnectionFunctionality
{
    protected NpgsqlConnection Connection { get; set; }
    protected NpgsqlCommand? Command { get; set; }
    protected NpgsqlDataReader? Reader { get; set; }

    protected ConnectionFunctionality()
    {
        //var connectionString = ConfigurationManager.ConnectionStrings["MainDataBase"].ToString(); 
        const string connectionString = "Host=mymm.gq;Port=5432;Username=rsscargo;Password=cargo228;Database=rsscargo";
        Connection = new NpgsqlConnection(connectionString);
        Reader = null;
            
        Connect();
    }

    ~ConnectionFunctionality()
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