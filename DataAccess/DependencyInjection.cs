using DataAccess.DbAccess;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace ProductManagement.Application;

public static class DependencyInjection
{
    public static void AddDataAccessServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IDbConnection>(_ => new SqlConnection(config.GetConnectionString("default")));
        services.AddScoped<ISqlDataAccess, SqlDataAccess>();
        services.AddScoped<IVoucherRepository, VoucherSqlRepository>();
    }
}