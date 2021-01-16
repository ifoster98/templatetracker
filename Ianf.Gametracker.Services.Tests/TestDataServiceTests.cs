#nullable disable
using System;
using System.Collections.Generic;
using Ianf.Gametracker.Services.Domain;
using Moq;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using Ianf.Gametracker.Services.Dto;
using Ianf.Gametracker.Services;
using Ianf.Gametracker.Services.Interfaces;

namespace Ianf.Gametracker.UnitTest.Services
{
    public class TestDataServiceTests
    {
        private readonly Mock<ITestDataRepository> _testDataRepository;
        private readonly ITestDataService _testDataService;
        private readonly string name = "TestName";
        private DateTime testDateOfBirth = DateTime.Now;
        private readonly string address = "TestAddress";

        public Gametracker.Services.Dto.TestData GetSampleTestData() =>
            new Gametracker.Services.Dto.TestData() 
            {
                Name = name,
                DateOfBirth = testDateOfBirth,
                Address = address
            };

        public TestDataServiceTests()
        {
            _testDataRepository = new Mock<ITestDataRepository>();
            _testDataService = new TestDataService(_testDataRepository.Object);
        }

        [Fact]
        public async void TestAddNewTestDataAsyncSuccess()
        {
            // Assemble
            var newTestData = GetSampleTestData();
            _testDataRepository
                .Setup(w => w.SaveTestDataAsync(It.IsAny<Gametracker.Services.Domain.TestData>()))
                .Returns(Task.FromResult(PositiveInt.CreatePositiveInt(1).IfNone(new PositiveInt())));

            // Act
            var result = await _testDataService.AddNewTestDataAsync(newTestData);

            // Assert
            _testDataRepository.Verify(w => w.SaveTestDataAsync(It.IsAny<Gametracker.Services.Domain.TestData>()));
            result.Match(
                Left: (err) => Assert.False(true, "Expected no errors to be returned."),
                Right: (newId) => Assert.Equal(1, newId.Value)
            );
        }

        [Fact]
        public async void TestGetNextTestData()
        {
            // Assemble

            // Act

            // Assert
        }
    }
}