using System.Threading.Tasks;
using LanguageExt;
using System.Collections.Generic;
using Ianf.Gametracker.Services.Domain;

namespace Ianf.Gametracker.Services.Interfaces
{
    public interface ITestDataService
    {
        Task<Either<IEnumerable<DtoValidationError>, PositiveInt>> AddNewTestDataAsync(Dto.TestData testData);
        Task<List<Dto.TestData>> GetAllTestDataAsync();
    }
}
