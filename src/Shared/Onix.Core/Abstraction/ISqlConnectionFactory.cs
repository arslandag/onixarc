using System.Data;

namespace Onix.Core.Abstraction;

public interface ISqlConnectionFactory
{
    IDbConnection Create();
}