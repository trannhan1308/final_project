using OA.Entities.RecipienceDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Medicine
{
    public class MedicineEntities : BaseEntities
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime NgayNhap { get; set; }
        public int Quantity { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaNhap { get; set; }
        public virtual ICollection<RecipienceDetailEntities> RecipienceDetail { get; set; }
    }
}
