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
    }
}
