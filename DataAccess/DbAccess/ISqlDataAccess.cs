using System.Data;

namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<int> Execute(string storedProcedure, object? parameters = null, IDbTransaction? transaction = null);
    Task<T?> Get<T>(string storedProcedure, object? parameters = null);
    Task<IEnumerable<T>> GetMany<T>(string storedProcedure, object? parameters = null);
    IDbTransaction StartTransaction();
    void CommitTransaction(IDbTransaction transaction);
}