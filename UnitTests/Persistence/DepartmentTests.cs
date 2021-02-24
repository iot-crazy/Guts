using Data;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using UnitTests.Attributes;
using DomainModels;
using Interfaces.Persistence;
using Persistence;
using Interfaces.Factories;
using AutoMapper;
using Mapping;
using FluentAssertions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.Persistence
{
    public class DepartmentTests
    {

        Mock<DataContext> _contextMock;
        Mock<IDataContextFactory> _contextFactoryMock;
        Mapper _mapper;


        public DepartmentTests()
        {
            SeedContext();
            MapperSetup();
        }


        [Fact]
        public async void GetMustMatch()
        {
            var domainmodels = GetDepartmentDomainModels();
            var persistence = new DepartmentPersistence(_contextFactoryMock.Object, _mapper);
            var getdepts = await persistence.GetAllAsync();
            getdepts.Should().BeEquivalentTo(domainmodels);
        }



        private void SeedContext()
        {
            _contextMock = new Mock<DataContext>();
            var departments = GetTestDepartments(); //.AsQueryable<Department>();
            //var dbSet = new Mock<DbSet<Department>>();
            //dbSet.As<IQueryable<Department>>().Setup(x => x.Provider).Returns(departments.Provider);
            //dbSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(departments.Expression);
            //dbSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(departments.ElementType);
            //dbSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(departments.GetEnumerator());
           // _contextMock.Setup(x => x.Departments).ReturnsAsyncDbSet(GetQueryableMockDbSet(departments));
            _contextFactoryMock = new Mock<IDataContextFactory>();
            _contextFactoryMock.Setup(x => x.CreateContext()).Returns(_contextMock.Object);
        }


        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }

        private List<Department> GetTestDepartments()
        {

            var departments =  new List<Department>();
            departments.Add(new Department()
            {
                ID = 1,
                Created = DateTime.UtcNow,
                Description = "the HR Department",
                Name = "HR",
                Employees = null,
                RowVersion = "abc123"
            });

            departments.Add(new Department()
            {
                ID = 1,
                Created = DateTime.UtcNow,
                Description = "The Scrooges",
                Name = "Bean COunting",
                Employees = null,
                RowVersion = "abc12345"
            });
            return departments;
        }

        private List<DepartmentDomainModel> GetDepartmentDomainModels()
        {
            var departments = new List<DepartmentDomainModel>();
            departments.Add(new DepartmentDomainModel()
            {
                ID = 1,
                Created = DateTime.UtcNow,
                Description = "the HR Department",
                Name = "HR",
                RowVersion = "abc123"
            });

            departments.Add(new DepartmentDomainModel()
            {
                ID = 1,
                Created = DateTime.UtcNow,
                Description = "The Scrooges",
                Name = "Bean COunting",
                RowVersion = "abc12345"
            });
            return departments;
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
