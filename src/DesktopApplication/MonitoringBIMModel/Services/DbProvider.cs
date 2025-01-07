

namespace MonitoringBIMModel.Services;

public class DbProvider
{
    private static readonly Dictionary<string, string>? ConfigParameters;
    private NpgsqlConnection connection;
    private static string? dbSchema;
    public DbProvider()
    {
        string _connectionString = $"Server=26.222.244.141; Port=5432; User Id=postgres; Password=denned233; Database=postgres; Timeout=30;";
        dbSchema = "cringe";
        connection = new NpgsqlConnection(_connectionString);
    }
    public async Task AddDb(int id, string name, string instance, string action)
    {
        try
        {
            await connection.OpenAsync();
            using (var cmd = new NpgsqlCommand($"SET search_path = {dbSchema}; INSERT into object (guid,user_name,instance,action) VALUES (@id_element,@user_name,@instance,@action);", connection))
            {
                cmd.Parameters.AddWithValue("@id_element", id);
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
    public async Task<List<DataObject>> GetDbData()
    {

        try
        {
            List<DataObject> mas = [];
            DataObject dataObject = new DataObject();
            await connection.OpenAsync();
            string query = $"SELECT id, user_name, instance, action " +
                           $"FROM postgres.cringe.object";
            using (NpgsqlCommand command = new(query, connection))
            {
                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    dataObject.Id = reader.GetInt32(0);
                    dataObject.UserName = reader.GetString(1);
                    dataObject.Instance = reader.GetString(2);
                    dataObject.Action = reader.GetString(3);
                    DataObject _dataObject = new DataObject()
                    {
                        Id = dataObject.Id,
                        UserName = dataObject.UserName,
                        Instance = dataObject.Instance,
                        Action = dataObject.Action
                    };
                    mas.Add(_dataObject);

                }
            }
            await connection.CloseAsync();
            return mas;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Detailed description of the error: {ex}");
            throw;
        }
    }
    public async Task<List<string>> GetDbDataProject()
    {

        try
        {
            List<string> mas = new List<string>();
            DataObject dataObject = new DataObject();
            await connection.OpenAsync();
            string query = $"SELECT project " +
                           $"FROM postgres.cringe.object";
            using (NpgsqlCommand command = new(query, connection))
            {
                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    string project = reader.GetString(0);
                    mas.Add(project);

                }
            }
            await connection.CloseAsync();
            return mas;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Detailed description of the error: {ex}");
            throw;
        }
    }
    public async Task<List<DataObject>> GetDbDataOnProject(string project)
    {

        try
        {
            List<DataObject> mas = [];
            DataObject dataObject = new DataObject();
            await connection.OpenAsync();
            string query = $"SELECT id, user_name, instance, action " +
                           $"FROM postgres.cringe.object WHERE project ='{project}'";
            using (NpgsqlCommand command = new(query, connection))
            {
                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    dataObject.Id = reader.GetInt32(0);
                    dataObject.UserName = reader.GetString(1);
                    dataObject.Instance = reader.GetString(2);
                    dataObject.Action = reader.GetString(3);
                    DataObject _dataObject = new DataObject()
                    {
                        Id = dataObject.Id,
                        UserName = dataObject.UserName,
                        Instance = dataObject.Instance,
                        Action = dataObject.Action
                    };
                    mas.Add(_dataObject);

                }
            }
            await connection.CloseAsync();
            return mas;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Detailed description of the error: {ex}");
            throw;
        }
    }

    public async Task<List<DataObject>> GetDbDataFilter(string user, int guid, Action action)
    {

        try
        {
            List<DataObject> mas = [];
            DataObject dataObject = new DataObject();
            await connection.OpenAsync();
            string result = "";
            if (user != default || guid != default)
            {
                var conditions = new List<string>();

                if (user != default)
                {
                    conditions.Add($"user_name = '{user}'");
                }

                if (guid != default)
                {
                    conditions.Add($"guid = '{guid}'");
                }
                if (action != default)
                {
                    conditions.Add($"action = '{action.ToString()}'");
                }

                result = string.Join(" AND ", conditions);
            }
            string query = $"SELECT id, user_name, instance, action " +
                           $"FROM postgres.cringe.object WHERE {result}";
            using (NpgsqlCommand command = new(query, connection))
            {
                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    dataObject.Id = reader.GetInt32(0);
                    dataObject.UserName = reader.GetString(1);
                    dataObject.Instance = reader.GetString(2);
                    dataObject.Action = reader.GetString(3);
                    DataObject _dataObject = new DataObject()
                    {
                        Id = dataObject.Id,
                        UserName = dataObject.UserName,
                        Instance = dataObject.Instance,
                        Action = dataObject.Action
                    };
                    mas.Add(_dataObject);

                }
            }
            await connection.CloseAsync();
            return mas;
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
                           $"FROM users WHERE login = '{login}' AND password= '{password}'";
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
