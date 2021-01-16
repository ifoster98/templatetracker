using Ianf.Gametracker.Services.Domain;
using Ianf.Gametracker.Services.Interfaces;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LanguageExt.Prelude;
using static Ianf.Gametracker.Services.Domain.Validator;

namespace Ianf.Gametracker.Services
{
    public class TestDataService : ITestDataService
    {
        private readonly ITestDataRepository _testDataRepository;

        public TestDataService(ITestDataRepository testDataRepository)
        {
            _testDataRepository = testDataRepository;
        }

        public async Task<Either<IEnumerable<DtoValidationError>, PositiveInt>> AddNewTestDataAsync(Dto.TestData testData) =>
            await testData
                .ValidateDto()
                .BindAsync(ValidateTestDataToAdd)
                .MapAsync(w => _testDataRepository.SaveTestDataAsync(w));

        protected async Task<Either<IEnumerable<DtoValidationError>, TestData>> ValidateTestDataToAdd(TestData testData)
        {
            var errors = new List<DtoValidationError>();
            // Validation checks here.
            if (errors.Any()) return errors;
            return testData;
        }

        public async Task<List<Dto.TestData>> GetAllTestDataAsync()
        {
            return new List<Dto.TestData>
            {
                new Dto.TestData
                {
                    Name = "TestDataName",
                    DateOfBirth = DateTime.Now.AddYears(-42),
                    Address = "TestDataAddress"
                }
            };
        }
    }
}