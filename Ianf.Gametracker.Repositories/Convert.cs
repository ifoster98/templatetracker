using System;
using System.Linq;
using System.Reflection.Metadata;
using Ianf.Gametracker.Services.Domain;

namespace Ianf.Gametracker.Repositories
{
    public static class Convert
    {
        public static TestData ToDomain(this Entities.TestData testData) =>
            new TestData(
                Name.CreateName(testData.Name).IfNone(new Name()),
                testData.DateOfBirth,
                Address.CreateAddress(testData.Address).IfNone(new Address())
            );

        public static Entities.TestData ToEntity(this TestData testData)  =>
            new Entities.TestData() {
                Name = testData.Name.Value,
                DateOfBirth = testData.DateOfBirth,
                Address = testData.Address.Value
            };
    }
}