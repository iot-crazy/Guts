using Interfaces.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
    public class DepartmentDomainModel : DomainModelBase, IDepartmentDomainModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
