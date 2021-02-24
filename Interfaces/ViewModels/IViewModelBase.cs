using System;

namespace Interfaces.ViewModels
{
    public interface IViewModelBase
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// The date time the record was created
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// The database rowversion used for concurrency checking
        /// </summary>
        string RowVersion { get; set; }
    }
}
