using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WbSoftwareWebProject.DataAccessLayer.EntityFramework;
using WbSoftwareWebProject.DataAccessLayer.Migrations;
using WbSoftwareWebProject.Entities.Entity;

namespace WbSoftwareWebProject.DataAccessLayer.EntitiyFramework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<About> About { get; set; }
        public DbSet<References> Comments { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Resume> Resume { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>("DatabaseContext"));
            // Database.SetInitializer(new MyInitializer());
        }
    }
}
