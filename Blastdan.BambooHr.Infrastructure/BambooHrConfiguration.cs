using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blastdan.BambooHr.Infrastructure
{
    public class BambooHrConfiguration
    {
        public const string Section = "bamboo";

        public BambooHrConfiguration()
        {
            ApiKey = string.Empty;
            SubDomain = string.Empty;
        }

        public string ApiKey { get; set; }
        public string SubDomain { get; set; }
    }
}
