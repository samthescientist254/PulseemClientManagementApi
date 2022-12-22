using System;
using System.Collections.Generic;

#nullable disable

namespace PulseemClientManagementApi.Models
{
    public partial class Trace
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public string Action { get; set; }
        public DateTime? DateIn { get; set; }
    }
}
