using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Onix.Core.Abstraction;

namespace Onix.WebSites.Infrastructure;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private const string Database = "Database";
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection Create() =>
        new NpgsqlConnection(_configuration.GetConnectionString(Database));
}