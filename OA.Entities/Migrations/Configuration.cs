namespace OA.Entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OA.Entities.CoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OA.Entities.CoreContext context)
        {
            context.Users.AddOrUpdate(z => z.Email, new Users.UsersEntities
            {
                Email = "admin@gmail.com",
                Password = "123456",
                Name = "Admin",
                Code = "0001",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Gender = 1,
                IsActive = true,
                Position = 1,
            });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
