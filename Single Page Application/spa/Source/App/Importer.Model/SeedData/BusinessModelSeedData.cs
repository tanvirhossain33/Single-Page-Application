using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Importer.Model.SeedData
{
    public static class BusinessModelSeedData
    {

        public static void RunSeed(BusinessDbContext context)
        {
            AddTrade(context);
            AddLevel(context);
        }
        

        private static void AddTrade(BusinessDbContext context)
        {
            if (context.Trades.Any()) return;

            context.Trades.AddOrUpdate(new Trade()
            {
                Id = 1.ToString(),

                Name = "Asphalt Concrete Paving",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.Trades.AddOrUpdate(new Trade()
            {
                Id = 2.ToString(),

                Name = "Bulldozer Operation",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.Trades.AddOrUpdate(new Trade()
            {
                Id = 3.ToString(),

                Name = "Bricklaying",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.Trades.AddOrUpdate(new Trade()
            {
                Id = 4.ToString(),

                Name = "Bored Micro-Piling Operation",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.SaveChanges();
        }

        private static void AddLevel(BusinessDbContext context)
        {
            if (context.Levels.Any()) return;

            context.Levels.AddOrUpdate(new Level()
            {
                Id = Guid.NewGuid().ToString(),

                Name = "SATW",
                TradeId = "1",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = Guid.NewGuid().ToString(),

                Name = "SEC(K)",
                TradeId = "1",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = Guid.NewGuid().ToString(),

                Name = "SATF",
                TradeId = "1",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = Guid.NewGuid().ToString(),

                Name = "SEC(K)",
                TradeId = "2",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = Guid.NewGuid().ToString(),

                Name = "SATW",
                TradeId = "2",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = Guid.NewGuid().ToString(),

                Name = "SEC(K)",
                TradeId = "3",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = Guid.NewGuid().ToString(),

                Name = "SEC(K)",
                TradeId = "4",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });

            context.Levels.AddOrUpdate(new Level()
            {
                Id = Guid.NewGuid().ToString(),

                Name = "SATW",
                TradeId = "4",

                Created = DateTime.Now,
                CreatedBy = "Seed",
                Modified = DateTime.Now,
                ModifiedBy = "Seed",
            });



            context.SaveChanges();
        }
    }
}