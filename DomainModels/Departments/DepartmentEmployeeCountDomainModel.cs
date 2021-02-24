using Interfaces.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
    public class DepartmentEmployeeCountDomainModel : DepartmentDomainModel, IDepartmentEmployeeCountDomainModel
    {
        public int EmployeeCount { get; set; }
    }
}
