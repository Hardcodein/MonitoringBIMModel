
namespace TrackChanges.Services;

public class DbProvider
{
    private static readonly Dictionary<string, string> ConfigParameters;
    private NpgsqlConnection connection;
    private static string dbSchema;
    public DbProvider()
    {
        string _connectionString = $"Server=26.145.134.106; Port=5432; User Id=postgres; Password=MrYoda23; Database=postgres; Timeout=30;";
        dbSchema = "public";
        connection = new NpgsqlConnection(_connectionString);
    }
    public async Task AddDb(int id, string name, string instance, string action)
    {
        try
        {
            await connection.OpenAsync();
            using (var cmd = new NpgsqlCommand($"SET search_path = {dbSchema}; INSERT into object (guid,user_name,instance,action) VALUES (@id,@user_name,@instance,@action);", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@user_name", name != null ? (object)name : DBNull.Value);
                cmd.Parameters.AddWithValue("@instance", instance != null ? (object)instance : DBNull.Value);
                cmd.Parameters.AddWithValue("@action", action != null ? (object)action : DBNull.Value);
                await cmd.ExecuteNonQueryAsync();
            }
            await connection.CloseAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Detailed description of the error: {ex}");
            throw;
        }

    }


    public void Dispose()
    {
        DisposeAsync().GetAwaiter().GetResult();
    }
    public async ValueTask DisposeAsync()
    {
        if (connection != null)
        {
            await connection.DisposeAsync();
            connection = null;
        }
    }
    public async Task<int> GetDb(string login, string password)
    {

        try
        {
            int _id = 0;
            await connection.OpenAsync();
            string query = $"SET search_path = {dbSchema}; SELECT users.id " +
                           $"FROM postgres.\"public\".users WHERE login = {login} AND password= {password}";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        _id = reader.GetInt32(0);

                    }
                }
            }
            await connection.CloseAsync();
            return _id;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Detailed description of the error: {ex}");
            throw;
        }
    }
}