using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ianf.Gametracker.Services.Domain;

namespace Ianf.Gametracker.Services.Interfaces
{
    public interface ITestDataRepository
    {
        Task<PositiveInt> SaveTestDataAsync(TestData workout);

        Task<List<TestData>> GetAllTestDataAsync();
    }
}
