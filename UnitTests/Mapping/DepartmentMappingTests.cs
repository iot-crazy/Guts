using Xunit;
using Data;
using DomainModels;
using System;
using AutoMapper;
using FluentAssertions;
using Interfaces.DomainModels;
using Mapping;
using System.Collections.Generic;

namespace UnitTests.Mapping
{
    public class DepartmentMappingTests
    {

        private Mapper _mapper;
        public DepartmentMappingTests()
        {
            MapperSetup();
        }

        [Fact]
        public void DataToDomainModelMustMatch()
        {

            var timeStamp = DateTime.Now;

            var sourceDataModel = new Department()
            {
                ID = 1,
                Created = timeStamp,
                RowVersion = "rowversion",
                Description = "This is a Test Department",
                Name ="Test Department"
            };

            var expectedDomainModel = new DepartmentDomainModel()
            {
                ID = 1,
                Created = timeStamp,
                RowVersion = "rowversion",
                Description = "This is a Test Department",
                Name = "Test Department"
            };

            var mappedDomainModel = _mapper.Map<IDepartmentDomainModel>(sourceDataModel);

            mappedDomainModel.Should().BeEquivalentTo(expectedDomainModel);

        }




        [Fact]
        public void DataToEmployeeCountModelMustMatch()
        {
            var timeStamp = DateTime.Now;

            var sourceDataModel = new Department()
            {
                ID = 1,
                Created = timeStamp,
                RowVersion = "rowversion",
                Description = "This is a Test Department",
                Name = "Test Department",
                Employees = new List<Employee>() { new Employee() { ID = 1, FirstName = "john", LastName = "smith", DepartmentID = 1 }, new Employee() { ID = 4, FirstName = "Alex", LastName = "Ander", DepartmentID = 1 } }
            };

            var expectedDomainModel = new DepartmentEmployeeCountDomainModel()
            {
                ID = 1,
                Created = timeStamp,
                RowVersion = "rowversion",
                Description = "This is a Test Department",
                Name = "Test Department",
                EmployeeCount = 2
            };

            var mappedDomainModel = _mapper.Map<IDepartmentEmployeeCountDomainModel>(sourceDataModel);

            mappedDomainModel.Should().BeEquivalentTo(expectedDomainModel);
        }

        private void MapperSetup()
        {
            _mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DepartmentProfile>();
            }));
        }

    }
}
