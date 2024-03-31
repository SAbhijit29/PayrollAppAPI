namespace PayrollApp.Database
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> ExecuteQuery<T>(string query, object parameters, string connectionId = "default");
        Task<T?> ExecuteQueryFirst<T>(string query, object parameters, string connectionId = "default");
        Task ExecuteSubmit(string query, object parameters, string connectionId = "default");
    }
}