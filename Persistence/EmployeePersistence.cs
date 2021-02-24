using AutoMapper;
using Interfaces.DomainModels;
using Interfaces.Factories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Persistence;
using System.Linq;

namespace Persistence
{
    public class EmployeePersistence : PersistenceBase, IEmployeePersistence
    {
        private readonly IMapper _mapper;

        public EmployeePersistence(IDataContextFactory dataContextFactory, IMapper mapper) : base(dataContextFactory)
        {
            _mapper = mapper;
        }

        public async Task<IList<IEmployeeDomainModel>> GetAllAsync(int departmentID)
        {
            return new List<IEmployeeDomainModel>(
                await _mapper.ProjectTo<IEmployeeDomainModel>(DBContext.Employees.Where(x => x.DepartmentID == departmentID))
                .AsNoTracking().ToListAsync());
        }

        public async Task<IEmployeeDomainModel> GetAsync(int departmentID, int ID)
        {
            return await _mapper.ProjectTo<IEmployeeDomainModel>(DBContext.Employees.Where(x => x.ID == ID && x.DepartmentID == departmentID))
                .AsNoTracking().FirstOrDefaultAsync();
        }

    }
}
