using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Importer.Model.Migrations;

namespace Importer.Model
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Document> Documents { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Level> Levels { get; set; }

    }
}