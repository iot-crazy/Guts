using Interfaces.DomainModels;
using System;

namespace DomainModels
{
    public class DomainModelBase : IDomainModelBase
    {
        public int ID { get; set; }

        public DateTime Created { get; set; }

        public string RowVersion { get; set; }
    }
}
