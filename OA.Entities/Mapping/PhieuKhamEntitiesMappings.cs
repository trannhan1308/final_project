using OA.Entities.PhieuKham;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Mapping
{
    public class PhieuKhamEntitiesMappings : EntityTypeConfiguration<PhieuKhamEntities>
    {
        public PhieuKhamEntitiesMappings()
        {
            this.ToTable("PhieuKham");
            this.HasKey(z => z.Id);
            this.Property(z => z.Code).HasMaxLength(150).IsRequired();
            this.Property(z => z.DoctorId).IsRequired();
            this.Property(z => z.PatientId).IsRequired();
            this.Property(z => z.TrieuChung).IsRequired();
            this.HasRequired(z => z.Patient).WithMany(z => z.PhieuKhams).HasForeignKey(z => z.PatientId);
            this.HasRequired(z => z.Doctor).WithMany(z => z.PhieuKhams).HasForeignKey(z => z.DoctorId);
        }
    }
}
