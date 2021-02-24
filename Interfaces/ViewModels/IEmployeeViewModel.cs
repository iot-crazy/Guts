using System;

namespace Interfaces.ViewModels
{
    public interface IEmployeeViewModel : IViewModelBase
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime? DateOfBirth { get; set; }
    }
}
