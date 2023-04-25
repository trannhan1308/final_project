using OA.Entities.PhieuKham;
using OA.Entities.Recipience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Patient
{
    public class PatientEntities : BaseEntities
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Room { get; set; }

        public ICollection<PhieuKhamEntities> PhieuKhams { get; set; }
        public ICollection<RecipienceEntities> Recipiences { get; set; }

        public PatientEntities()
        {
            this.PhieuKhams = new List<PhieuKhamEntities>();
            this.Recipiences = new List<RecipienceEntities>();
        }
    }
}
