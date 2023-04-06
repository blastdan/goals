using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace Blastdan.BambooHr.Infrastructure.Dto
{
    public partial class CreateGoalResponseDto
    {
        [JsonPropertyName("goal")]
        public GoalDto Goal { get; set; }
    }
}
