using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ianf.Gametracker.Services.Interfaces;
using Ianf.Gametracker.Services.Dto;

namespace Ianf.Gametracker.Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDataController : ControllerBase
    {
        private readonly ITestDataService _testDataService;

        public TestDataController(ITestDataService testDataService)
        {
            _testDataService = testDataService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddNewTestDataAsync(Ianf.Gametracker.Services.Dto.TestData testData)
        {
            var result = await _testDataService.AddNewTestDataAsync(testData);
            ActionResult<int> returnValue = Ok();
            result.Match(
                Left: (err) => returnValue = BadRequest(err),
                Right: (newTestDataId) => returnValue = Ok(newTestDataId)
            );

            return returnValue;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTestDataAsync()
        {
            var result = await _testDataService.GetAllTestDataAsync();
            return Ok(result);
        }
    }
}