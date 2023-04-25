using OA.Entities.LoaiBenh;
using OA.Entities.Medicine;
using OA.Entities.Patient;
using OA.Entities.PhieuKham;
using OA.Entities.Recipience;
using OA.Entities.RecipienceDetail;
using OA.Entities.Users;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace OA.Entities
{
    public class CoreContext : DbContext
    {
        public CoreContext() : base("name=Core_Context")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                            .Where(type => !String.IsNullOrEmpty(type.Namespace))
                                            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                                            type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            Database.SetInitializer<CoreContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UsersEntities> Users { get; set; }
        public DbSet<LoaiBenhEntities> LoaiBenhs { get; set; }
        public DbSet<MedicineEntities> Medicines { get; set; }
        public DbSet<PatientEntities> Patients { get; set; }
        public DbSet<PhieuKhamEntities> PhieuKhams { get; set; }
        public DbSet<RecipienceEntities> Recipiences { get; set; }
        public DbSet<RecipienceDetailEntities> RecipienceDetails { get; set; }

    }
}
