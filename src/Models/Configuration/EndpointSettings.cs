using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sky.Models.Configuration
{
    public class EndpointSettings
    {
        public String ApiEndpoint { get; set; }
        public Int32? DefaultTimeout { get; set; }
    }
}
