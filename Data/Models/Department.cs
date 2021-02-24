using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Department : DataModelBase
    {

        public string Name { get; set; }
        public string Description { get; set; }

        //Relationships
        public List<Employee> Employees { get; set; }

    }
}
