using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Ianf.Gametracker.Services.Domain;
using Ianf.Gametracker.Services.Interfaces;

namespace Ianf.Gametracker.Repositories
{
    public class TestDataRepository : ITestDataRepository
    {
        protected GametrackerDbContext _dbContext { get; }

        public TestDataRepository(GametrackerDbContext context) => _dbContext = context;

        public async Task<PositiveInt> SaveTestDataAsync(TestData testData)
        {
            var entity = testData.ToEntity();
            _dbContext.TestDatas.Add(entity);
            await _dbContext.SaveChangesAsync();
            return PositiveInt.CreatePositiveInt(entity.Id).IfNone(new PositiveInt());
        }

        public async Task<List<TestData>> GetAllTestDataAsync() =>
            await _dbContext.TestDatas
                .Select(s => s.ToDomain())
                .ToListAsync();
    }
}