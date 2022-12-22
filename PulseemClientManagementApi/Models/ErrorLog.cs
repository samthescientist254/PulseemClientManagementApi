using System;
using System.Collections.Generic;

#nullable disable

namespace PulseemClientManagementApi.Models
{
    public partial class ErrorLog
    {
        public int Id { get; set; }
        public string Error { get; set; }
        public DateTime? Datein { get; set; }
        public int? RequestId { get; set; }
    }
}
