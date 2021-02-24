using Interfaces.DomainModels;
using System;

namespace DomainModels
{
    public class EmployeeDomainModel : DomainModelBase, IEmployeeDomainModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
