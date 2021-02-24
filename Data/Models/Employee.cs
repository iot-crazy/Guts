using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Employee : DataModelBase
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int DepartmentID { get; set; }

        // Relationships
        public Department Department { get; set; }

    }
}
