using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Persistence;
using Interfaces.Services;
using Interfaces.ViewModels;

namespace Services
{
    public class DepartmentService : ServiceBase, IDepartmentService
    {
        private readonly IDepartmentPersistence _departmentPersistence;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentPersistence persistence, IMapper mapper)
        {
            _departmentPersistence = persistence;
            _mapper = mapper;
        }

        public async Task<IDepartmentViewModel> GetAsync(int Id)
        {
            return _mapper.Map<IDepartmentViewModel>(await _departmentPersistence.GetAsync(Id));
        }

        public async Task<IList<IDepartmentViewModel>> GetAllAsync()
        {
            return _mapper.Map<List<IDepartmentViewModel>>(await _departmentPersistence.GetAllAsync());
        }
    }
}
