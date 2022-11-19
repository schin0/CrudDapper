using Microsoft.Extensions.Configuration;
using System.Data;

namespace Data.Repositories
{
    public abstract class RepositoryBase
    {
        public RepositoryBase(IDbConnection _connection, IConfiguration _configuration)
        {
            _connection = connection;
            _configuration = configuration;
        }

        public IDbConnection connection { get;  }
        protected IConfiguration configuration { get; }
    }
}
