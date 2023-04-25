using OA.DTO.Medicines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.Recipiences
{
    public class RecipienceDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<MedicinesDTO> Medicine { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int PatientId { get; set; }
        public RecipienceDTO()
        {
            this.Medicine = new List<MedicinesDTO>();
        }
    }

    public class RecipienceViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Description { get; set; }
    }
}
