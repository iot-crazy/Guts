using Interfaces.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IList<IEmployeeViewModel>> GetAllAsync(int departmentID);
        Task<IEmployeeViewModel> GetAsync(int departmentID, int ID);
    }
}