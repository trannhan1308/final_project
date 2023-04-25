using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.Patients
{
    public class PatientsDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string IdentityCard { get; set; }
        public int Gender { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
