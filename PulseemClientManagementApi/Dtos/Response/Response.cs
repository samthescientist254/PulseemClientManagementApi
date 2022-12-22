using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PulseemClientManagementApi.Dtos.Response
{
    public class Response
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        /// <summary>
        /// codes:-
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool status { get; set; }
  
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int code { get; set; }
    }
}
