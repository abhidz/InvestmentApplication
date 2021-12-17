using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Investment_App.Model;
using Microsoft.EntityFrameworkCore;

namespace Investment_App.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<FundDetail> FundDetails { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FundDetail>().HasData(new FundDetail[]
            {
                new FundDetail{ID = 1, FundName ="Nifty Cap Fund", Description = "Nifty type fund"},
                new FundDetail{ID = 2, FundName ="NiftyBank Cap Fund", Description = "NiftyBank type fund"}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
