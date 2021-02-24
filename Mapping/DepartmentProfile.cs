using AutoMapper;
using Data;
using DomainModels;
using Interfaces.DomainModels;
using Interfaces.ViewModels;
using System.Collections.Generic;
using ViewModels;

namespace Mapping
{
    public class DepartmentProfile : Profile
    {

        public DepartmentProfile()
        {

            // Maps from Department to the domain model 
            CreateMap<Department, IDepartmentDomainModel>().ConstructUsing(c => new DepartmentDomainModel()); 

            // Maps to domain model include a count of employees, EXCLUDES the employee records
            CreateMap<Department, IDepartmentEmployeeCountDomainModel>()
                .ConstructUsing(c => new DepartmentEmployeeCountDomainModel())
                .ForMember(m => m.EmployeeCount, opt => opt.MapFrom(s => s.Employees.Count));

            // Maps from the domain model to the view model
            CreateMap<IDepartmentDomainModel, IDepartmentViewModel>().ConstructUsing(c => new DepartmentViewModel());
            CreateMap<IDepartmentEmployeeCountDomainModel, IDepartmentEmployeeCountViewModel>().ConstructUsing(c => new DepartmentEmployeeCountViewModel());

        }
    }
}
