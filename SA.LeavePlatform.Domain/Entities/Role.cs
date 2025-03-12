using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Domain.Entities
{
    public class Role
    {
       public int Id { get; set; }
       public string Code { get; set; }
       public string Label { get; set; }
       public string Description { get; set; }
    }
}
