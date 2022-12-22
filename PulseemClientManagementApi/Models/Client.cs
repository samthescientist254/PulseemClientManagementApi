using System;
using System.Collections.Generic;

#nullable disable

namespace PulseemClientManagementApi.Models
{
    public partial class Client
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Name { get; set; }
        public string EmailStatus { get; set; }
        public string SmsStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
