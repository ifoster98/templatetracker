using System.Reflection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace Ianf.Gametracker.Webapi.Tests
{
    public class TestDataTests
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "http://localhost";
        private readonly DateTime _currentTime = DateTime.Now;

        [Fact]
        public async System.Threading.Tasks.Task TestAddNewTestDataAsync()
        {
            // Assemble
            var newTestData = new Ianf.Gametracker.Services.Dto.TestData() 
            {
                Name = "TestName",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Address = "TestAddress"
            };
            var url = $"{_baseUrl}/TestData"; 
            var body = JsonConvert.SerializeObject(newTestData);
            var content = new StringContent(body,
                                    Encoding.UTF8, 
                                    "application/json");

            // Act
            var result = await _client.PostAsync(url, content);

            // Assert
            result.EnsureSuccessStatusCode();
            var resultContent = await result.Content.ReadAsStringAsync();
            Assert.Equal("{\"value\":1}", resultContent);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestGetAllTestDataAsync()
        {
            // Assemble
            var url = $"{_baseUrl}/TestData"; 

            // Act
            var result = await _client.GetAsync(url);

            // Assert
            result.EnsureSuccessStatusCode();
            var resultContent = await result.Content.ReadAsStringAsync();
            var testData = JsonConvert.DeserializeObject<List<Gametracker.Services.Dto.TestData>>(resultContent);
            Assert.Equal("TestDataName", testData[0].Name);
        }
    }
}
