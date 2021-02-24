using System;

namespace Data
{
    /// <summary>
    /// A base class providing some common properties from which all data models inherit
    /// This will save having to create these in all the generated classes
    /// </summary>
    public abstract class DataModelBase
    {

        /// <summary>
        /// The unique identifier
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The date time the record was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The database rowversion used for concurrency checking
        /// </summary>
        public string RowVersion { get; set; }
    }
}
