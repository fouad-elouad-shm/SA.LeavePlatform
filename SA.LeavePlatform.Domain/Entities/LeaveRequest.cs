using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Domain.Entities
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public DateOnly DateDebut { get; set; }
        public DateOnly DateFIn { get; set; }
        public int StatusId { get; set; }
        public int LeaveTypeId { get; set; }
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public virtual Status? Status { get; set; }
        [JsonIgnore]

        public virtual LeaveType? LeaveType { get; set; }
        [JsonIgnore]

        public virtual Employee? Employee { get; set; }
        
    }
}
