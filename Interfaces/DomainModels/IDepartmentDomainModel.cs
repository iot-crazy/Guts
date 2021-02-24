using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.DomainModels
{
    public interface IDepartmentDomainModel : IDomainModelBase
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}
