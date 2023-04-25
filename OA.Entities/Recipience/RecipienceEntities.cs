using OA.Entities.Medicine;
using OA.Entities.Patient;
using OA.Entities.RecipienceDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Recipience
{
    public class RecipienceEntities : BaseEntities
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
        public virtual PatientEntities Patient { get; set; }
        public virtual ICollection<RecipienceDetailEntities> RecipienceDetail { get; set; }
    }
}
