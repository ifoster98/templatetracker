using System;
using System.Collections.Generic;

namespace Ianf.Gametracker.Repositories.Entities
{
    public partial class TestData
    {
        public TestData()
        {
            Name = string.Empty;
            Address = string.Empty;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
