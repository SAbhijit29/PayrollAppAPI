using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace PayrollApp.Database
{
    public class DatabaseUtilities:IDataAccess
    {
        private readonly IConfiguration _configuration;
        public DatabaseUtilities(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Method to return the first object based on query form table
        public async Task<T?> ExecuteQueryFirst<T>(string query, object parameters, string connectionId = "default")
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            return await dbConnection.QueryFirstOrDefaultAsync<T>(query, parameters);
        }

        public async Task<IEnumerable<T>> ExecuteQuery<T>(string query, object parameters, string connectionId = "default")
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            return await dbConnection.QueryAsync<T>(query, parameters);
        }

        public async Task ExecuteSubmit(string query, object parameters, string connectionId = "default")
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            await dbConnection.ExecuteAsync(query, parameters);
        }
    }
}
