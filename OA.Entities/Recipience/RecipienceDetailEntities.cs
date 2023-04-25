using OA.Entities.Medicine;
using OA.Entities.Recipience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.RecipienceDetail
{
    public class RecipienceDetailEntities : BaseEntities
    {
        public int RecipienceId { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual RecipienceEntities Recipience { get; set; }
        public virtual MedicineEntities Medicine { get; set; }
    }
}
