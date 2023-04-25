using OA.Entities.LoaiBenh;
using OA.Entities.Recipience;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Mapping
{
    public class RecipienceEntitiesMappings : EntityTypeConfiguration<RecipienceEntities>
    {
        public RecipienceEntitiesMappings()
        {
            this.ToTable("Recipience");
            this.HasKey(z => z.Id);
            this.Property(z => z.PatientId).IsRequired();
            this.HasRequired(z => z.Patient).WithMany(z => z.Recipiences).HasForeignKey(z => z.PatientId);
        }
    }
}
