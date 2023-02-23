using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blastdan.BambooHr.Infrastructure.Dto
{
    public partial class EmployeeDto
    {
        public EmployeeDto()
        {
            this.Id = 0;
            this.FirstName = "Unset";
            this.LastName = "Unset";
        }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
    }
}
