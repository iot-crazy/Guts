using Interfaces.ViewModels;

namespace ViewModels
{
    public class DepartmentEmployeeCountViewModel : DepartmentViewModel, IDepartmentEmployeeCountViewModel
    {
        public int EmployeeCount { get; set; }
    }
}
