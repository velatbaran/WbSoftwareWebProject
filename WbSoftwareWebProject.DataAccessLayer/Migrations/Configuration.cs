namespace WbSoftwareWebProject.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WbSoftwareWebProject.DataAccessLayer.EntitiyFramework.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WbSoftwareWebProject.DataAccessLayer.EntitiyFramework.DatabaseContext";
        }

        protected override void Seed(WbSoftwareWebProject.DataAccessLayer.EntitiyFramework.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
