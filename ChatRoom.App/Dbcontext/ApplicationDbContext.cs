using ChatRoom.App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ChatRoom.App.Dbcontext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base(WebConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
    }
    public class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }

}