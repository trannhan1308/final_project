using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.Medicines
{
    public class MedicinesDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime NgayNhap { get; set; }
        public int Quantity { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaNhap { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
