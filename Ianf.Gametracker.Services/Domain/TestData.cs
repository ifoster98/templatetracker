using System;

namespace Ianf.Gametracker.Services.Domain
{
    public record TestData(Name Name, DateTime DateOfBirth, Address Address)
    { 
        public Dto.TestData ToDto()  =>
            new Dto.TestData() {
                Name = this.Name.Value,
                DateOfBirth = this.DateOfBirth,
                Address = this.Address.Value
            };
    }
}
