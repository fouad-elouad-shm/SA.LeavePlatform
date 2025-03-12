using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Domain.Entities
{
    public class LeaveDoc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int LeaveRequestId { get; set; }
        [JsonIgnore]
        public virtual LeaveRequest? LeaveRequest { get; set; }
    }
}
