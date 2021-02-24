using Data;
using Interfaces.Factories;
using Interfaces.Persistence;
using System;
namespace Persistence
{
    public class PersistenceBase : IPersistenceBase
    {
        private readonly IDataContextFactory _contextFactory;

        public PersistenceBase(IDataContextFactory dataContextFactory)
        {
            _contextFactory = dataContextFactory;
        }
       
        protected DataContext DBContext
        {
            get { return _contextFactory.CreateContext();  }
        }

    }
}
