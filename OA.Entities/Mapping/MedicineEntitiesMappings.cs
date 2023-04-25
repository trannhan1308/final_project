using OA.Entities.Medicine;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Mapping
{
    public class MedicineEntitiesMappings : EntityTypeConfiguration<MedicineEntities>
    {
        public MedicineEntitiesMappings()
        {
            this.ToTable("Medicines");
            this.HasKey(z => z.Id);
            this.Property(z => z.Name).HasMaxLength(250).IsRequired();
            this.Property(z => z.Code).HasMaxLength(150).IsRequired();
        }
    }
}
