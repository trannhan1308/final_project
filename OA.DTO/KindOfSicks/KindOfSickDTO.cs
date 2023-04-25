using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.DTO.KindOfSicks
{
    public class KindOfSickDTO
    {
        public string Code { get; set; }
        [Required(ErrorMessage = "Thông tin bắt buộc.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public KindOfSickDTO()
        {
           
        }
    }
}
