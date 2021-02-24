using System;
using Interfaces.ViewModels;

namespace ViewModels
{
    public class EmployeeViewModel : ViewModelBase, IEmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
