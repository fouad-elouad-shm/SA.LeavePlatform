using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SA.LeavePlatform.Domain.Entities
{
    public class Affectation
    {
        public int Id { get; set; }
        public bool IsSupervisor { get; set; }
        public DateOnly DateDebut { get; set; }
        public DateOnly DateFin { get; set; }
        public int ProjetId { get; set; }
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public virtual Projet? Projet { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }


    }

}
