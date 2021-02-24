using Xunit;
using Data;
using DomainModels;
using System;
using AutoMapper;
using FluentAssertions;
using Interfaces.DomainModels;
using Mapping;

namespace UnitTests.Mapping
{
    public class EmployeeMappingTests
    {

        private Mapper _mapper;
        public EmployeeMappingTests()
        {
            MapperSetup();
        }

        [Fact]
        public void DataToDomaonModelMustMatch()
        {

            var timeStamp = DateTime.Now;

            var sourceDataModel = new Employee()
            {
                ID = 1,
                Created = timeStamp,
                RowVersion = "rowversion",
                FirstName = "John",
                LastName = "Smith",
                Department = null
            };

            var expectedDomainModel = new EmployeeDomainModel()
            {
                ID = 1,
                Created = timeStamp,
                RowVersion = "rowversion",
                FirstName = "John",
                LastName = "Smith",
            };

            var mappedDomainModel = _mapper.Map<IEmployeeDomainModel>(sourceDataModel);

            mappedDomainModel.Should().BeEquivalentTo(expectedDomainModel);

        }



        private void MapperSetup()
        {
            _mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EmployeeProfile>();
            }));
        }

    }
}
