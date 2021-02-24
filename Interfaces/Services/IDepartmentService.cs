using Interfaces.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IList<IDepartmentViewModel>> GetAllAsync();
        Task<IDepartmentViewModel> GetAsync(int Id);
    }
}