using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Persistence;
using Interfaces.Services;
using Interfaces.ViewModels;

namespace Services
{
    public class EmployeeService : ServiceBase, IEmployeeService
    {
        private readonly IEmployeePersistence _employeePersistence;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeePersistence persistence, IMapper mapper)
        {
            _employeePersistence = persistence;
            _mapper = mapper;
        }

        public async Task<IEmployeeViewModel> GetAsync(int departmentID, int ID)
        {
            return _mapper.Map<IEmployeeViewModel>(await _employeePersistence.GetAsync(departmentID, ID));
        }

        public async Task<IList<IEmployeeViewModel>> GetAllAsync(int departmentID)
        {
            return _mapper.Map<List<IEmployeeViewModel>>(await _employeePersistence.GetAllAsync(departmentID));
        }
    }
}
