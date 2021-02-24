using Interfaces.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Persistence
{
    public interface IDepartmentPersistence
    {
        Task<IList<IDepartmentDomainModel>> GetAllAsync();
        Task<IDepartmentDomainModel> GetAsync(int Id);
    }
}