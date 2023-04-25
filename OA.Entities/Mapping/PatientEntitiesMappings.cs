using OA.Entities.Patient;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Mapping
{
    public class PatientEntitiesMappings : EntityTypeConfiguration<PatientEntities>
    {
        public PatientEntitiesMappings()
        {
            this.ToTable("Patients");
            this.HasKey(z => z.Id);
            this.Property(z => z.Name).HasMaxLength(250).IsRequired();
            this.Property(z => z.Code).HasMaxLength(150).IsRequired();
            this.Property(z => z.Room).HasMaxLength(150).IsRequired();
        }
    }
}
