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
    public class DepartmentPersistence : PersistenceBase, IDepartmentPersistence
    {

        private readonly IMapper _mapper;

        public DepartmentPersistence(IDataContextFactory dataContextFactory, IMapper mapper) : base(dataContextFactory)
        {
            _mapper = mapper;
        }

        public async Task<IList<IDepartmentDomainModel>> GetAllAsync()
        {
            return new List<IDepartmentDomainModel>(
                await _mapper.ProjectTo<IDepartmentDomainModel>(DBContext.Departments)
                .AsNoTracking()
                .ToListAsync()
                );
        }

        public async Task<IDepartmentDomainModel> GetAsync(int ID)
        {
            return await _mapper.ProjectTo<IDepartmentDomainModel>(
                DBContext.Departments.Where(x => x.ID == ID)
                )
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

    }
}
