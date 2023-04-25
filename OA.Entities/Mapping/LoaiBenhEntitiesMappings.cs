using OA.Entities.LoaiBenh;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Mapping
{
    public class LoaiBenhEntitiesMappings : EntityTypeConfiguration<LoaiBenhEntities>
    {
        public LoaiBenhEntitiesMappings()
        {
            this.ToTable("LoaiBenh");
            this.HasKey(z => z.Id);
            this.Property(z => z.Code).HasMaxLength(150).IsRequired();
            this.Property(z => z.Name).HasMaxLength(500).IsRequired();
        }
    }
}
