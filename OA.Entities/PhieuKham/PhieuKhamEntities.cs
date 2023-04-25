using OA.Entities.Patient;
using OA.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.PhieuKham
{
    public class PhieuKhamEntities : BaseEntities
    {
        public string Code { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TrieuChung { get; set; }
        public decimal Price { get; set; }
        public DateTime? NgayTaiKham { get; set; }

        public virtual PatientEntities Patient { get; set; } 
        public virtual UsersEntities Doctor { get; set; }
    }
}
