using Dapper;
using System.Data;

namespace DataAccess.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IDbConnection _connection;
    public SqlDataAccess(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<T?> Get<T>(string storedProcedure, object? parameters = null)
    {
        var result = await _connection.QueryFirstOrDefaultAsync<T>(storedProcedure,
            parameters, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<IEnumerable<T>> GetMany<T>(string storedProcedure, object? parameters = null)
    {
        var result = await _connection.QueryAsync<T>(storedProcedure,
            parameters, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<int> Execute(string storedProcedure, object? parameters = null, IDbTransaction? transaction = null)
    {
        var result = await _connection.ExecuteAsync(storedProcedure,
            parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
        return result;
    }

    public IDbTransaction StartTransaction()
    {
        _connection.Open();
        return _connection.BeginTransaction();
    }

    public void CommitTransaction(IDbTransaction transaction)
    {
        transaction.Commit();
        _connection.Close();
    }
}