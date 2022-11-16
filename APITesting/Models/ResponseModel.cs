using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace APITesting.Models
{
    public class ResponseModel
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Job")]
        public string Job { get; set; }
    }
}
