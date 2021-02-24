using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.DomainModels
{
    public interface IEmployeeDomainModel : IDomainModelBase
    {

        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime? DateOfBirth { get; set; }

    }
}
