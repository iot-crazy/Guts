namespace Interfaces.ViewModels
{
    public interface IDepartmentEmployeeCountViewModel : IViewModelBase
    {
        string Description { get; set; }
        int EmployeeCount { get; set; }
        string Name { get; set; }
    }
}