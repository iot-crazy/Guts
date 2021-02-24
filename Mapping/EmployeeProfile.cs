using AutoMapper;
using DomainModels;
using Interfaces.DomainModels;
using Data;
using Interfaces.ViewModels;
using ViewModels;

namespace Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, IEmployeeDomainModel>().ConstructUsing(c => new EmployeeDomainModel());
            CreateMap<IEmployeeDomainModel, IEmployeeViewModel>().ConstructUsing(c => new EmployeeViewModel());
        }
    }
}
