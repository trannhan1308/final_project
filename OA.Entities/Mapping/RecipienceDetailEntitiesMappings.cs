using OA.Entities.LoaiBenh;
using OA.Entities.Recipience;
using OA.Entities.RecipienceDetail;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Mapping
{
    public class RecipienceDetailEntitiesMappings : EntityTypeConfiguration<RecipienceDetailEntities>
    {
        public RecipienceDetailEntitiesMappings()
        {
            this.ToTable("RecipienceDetail");
            this.HasKey(z => z.Id);
            this.Property(z => z.MedicineId).IsRequired();
            this.Property(z => z.RecipienceId).IsRequired();
            this.HasRequired(z => z.Medicine).WithMany(z => z.RecipienceDetail).HasForeignKey(z => z.MedicineId);
            this.HasRequired(z => z.Recipience).WithMany(z => z.RecipienceDetail).HasForeignKey(z => z.RecipienceId);
        }
    }
}
