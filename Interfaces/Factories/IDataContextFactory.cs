using System;
using Data;

namespace Interfaces.Factories
{
    /// <summary>
    /// Provides factory services for creating a DataContext
    /// </summary>
    public interface IDataContextFactory
    {

        /// <summary>
        /// Creates and returns a new context using the connection string provided when the factory was instantiated
        /// </summary>
        /// <returns>new DataContext</returns>
        DataContext CreateContext();
    }
}
