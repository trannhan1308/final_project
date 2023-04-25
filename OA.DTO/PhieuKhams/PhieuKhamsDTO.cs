using OA.DTO.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.PhieuKhams
{
    public class PhieuKhamsDTO
    {
        public string Code { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TrieuChung { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public PatientsDTO Patient { get; set; }
    }

    public class PhieuHenDTO
    {
        public int PatientId { get; set; }
        public DateTime NgayHen { get; set; } = DateTime.Now.AddDays(1);
        public string TrieuChung { get; set; }
        public decimal Price { get; set; }
    }

    public class PhieuKhamViewDTO
    {
        public string Code { get; set; }
        public string TrieuChung { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public DateTime? NgayTaiKham { get; set; }
    }
}
