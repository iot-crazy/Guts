using Interfaces.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Persistence
{
    public interface IEmployeePersistence
    {
        Task<IList<IEmployeeDomainModel>> GetAllAsync(int DepartmentID);
        Task<IEmployeeDomainModel> GetAsync(int DepartmentID, int Id);
    }
}