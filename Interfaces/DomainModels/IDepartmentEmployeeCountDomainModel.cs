using Interfaces.DomainModels;

namespace DomainModels
{
    public interface IDepartmentEmployeeCountDomainModel : IDepartmentDomainModel
    {
        int EmployeeCount { get; set; }
    }
}