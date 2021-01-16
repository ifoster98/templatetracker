using System;
using System.Collections.Generic;
using System.Linq;
using LanguageExt;

namespace Ianf.Gametracker.Services.Domain
{
    public static class Validator
    {
        public static Either<IEnumerable<DtoValidationError>, TestData> ValidateDto(this Dto.TestData testData)
        {
            var errors = new List<DtoValidationError>();
            var name = new Name();
            Name.CreateName(testData.Name)
                .Match(
                    None: () => errors.Add(new DtoValidationError("Invalid amount for name.", "TestData", "Name") ),
                    Some: (s) => name = s
                );
            var address = new Address();
            Address.CreateAddress(testData.Address)
                .Match(
                    None: () => errors.Add(new DtoValidationError("Invalid amount for address.", "TestData", "Address")),
                    Some: (s) => address = s
                );
            if(errors.Any()) return errors;
            return new TestData(name, testData.DateOfBirth, address);
        }
    }
}