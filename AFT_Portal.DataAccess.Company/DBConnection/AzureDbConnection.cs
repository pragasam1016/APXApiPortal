using System.Data;
using System.Data.SqlClient;

namespace AFT_Portal.DataAccess.Company.DBConnection
{
    public class AzureDbConnection
    {
        private readonly string _connectionString;

        public AzureDbConnection()
        {
            _connectionString = "Server=tcp:aftemployee.database.windows.net,1433;Initial Catalog=Apx_Employee_Prod;Persist Security Info=False;User ID=aft_employee;Password=Falcon2025;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        }

        public async Task<IDbConnection> GetConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString); // Updated to Microsoft.Data.SqlClient.SqlConnection
            await connection.OpenAsync();
            return connection;
        }

        public async Task ExecuteQueryAsync(string query, Action<SqlCommand> configureCommand = null)
        {
            var connection = await GetConnectionAsync();
            var command = (SqlCommand)connection.CreateCommand(); // Updated to Microsoft.Data.SqlClient.SqlCommand
            command.CommandText = query;

            configureCommand?.Invoke(command);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<T> ExecuteScalarAsync<T>(string query, Action<SqlCommand> configureCommand = null)
        {
            var connection = await GetConnectionAsync();
            var command = (SqlCommand)connection.CreateCommand(); // Updated to Microsoft.Data.SqlClient.SqlCommand
            command.CommandText = query;

            configureCommand?.Invoke(command);

            return (T)await command.ExecuteScalarAsync();
        }

        public async Task<DataTable> ExecuteQueryToDataTableAsync(string query, Action<SqlCommand> configureCommand = null)
        {
            var dataTable = new DataTable();

            var connection = await GetConnectionAsync();
            var command = (SqlCommand)connection.CreateCommand(); // Updated to Microsoft.Data.SqlClient.SqlCommand
            command.CommandText = query;

            configureCommand?.Invoke(command);

            await using var reader = await command.ExecuteReaderAsync();
            dataTable.Load(reader);

            return dataTable;
        }
    }
}
