using OA.Entities.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Entities.Mapping
{
    public class UsersEntitiesMappings : EntityTypeConfiguration<UsersEntities>
    {
        public UsersEntitiesMappings()
        {
            this.ToTable("Users");
            this.HasKey(z => z.Id);
            this.Property(z => z.Code).HasMaxLength(150).IsRequired();
            this.Property(z => z.Name).HasMaxLength(250).IsRequired();
            this.Property(z => z.Password).HasMaxLength(250).IsRequired();
            this.Property(z => z.Email).HasMaxLength(250).IsRequired();
        }
    }
}
