
using Importer.Model.SeedData;

namespace Importer.Model.Migrations
{
    using System.Data.Entity.Migrations;
    using Importer.Model;

    public class Configuration : DbMigrationsConfiguration<BusinessDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BusinessDbContext context)
        {
            BusinessModelSeedData.RunSeed(context);
        }

    }
}