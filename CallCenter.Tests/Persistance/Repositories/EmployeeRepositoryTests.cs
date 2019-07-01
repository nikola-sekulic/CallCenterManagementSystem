using System;
using System.Collections.Generic;
using System.Data.Entity;
using CallCenter.Tests.Extensions;
using CallCenterManagementSystem.Models;
using CallCenterManagementSystem.Persistance.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CallCenter.Tests.Persistance.Repositories
{
    [TestClass]
    public class EmployeeRepositoryTests
    {
        private EmployeeRepository _repository;
        private Mock<DbSet<Employee>> _mockEmployees;
        private Mock<DbSet<Specialist>> _mockSpecialists;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockEmployees = new Mock<DbSet<Employee>>();
            _mockSpecialists = new Mock<DbSet<Specialist>>();

            var mockConext = new Mock<IApplicationDbContext>();
            mockConext.SetupGet(c => c.Employees).Returns(_mockEmployees.Object);
            mockConext.SetupGet(c => c.Specialists).Returns(_mockSpecialists.Object);

            _repository = new EmployeeRepository(mockConext.Object);
        }

        [TestMethod]
        public void GetActiveSpecialists_SpecialistDoesntWork_ShouldNotBeReturned()
        {
            var employee = new Specialist() { Name = "Nikola",DateEnded=DateTime.Now };

            _mockSpecialists.SetSource(new [] { employee });

            var employees = _repository.GetActiveSpecialists("Nikola");

            employees.Should().BeEmpty();
        }
    }
}
