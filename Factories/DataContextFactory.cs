using Interfaces.Factories;
using Data;

namespace Factories
{
    public class DataContextFactory : IDataContextFactory
    {

        private readonly string _connectionString;

        public DataContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataContext CreateContext()
        {
            return new DataContext(_connectionString);
        }

    }
}
