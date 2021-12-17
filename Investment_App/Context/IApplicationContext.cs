using Investment_App.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investment_App.Context
{
    public interface IApplicationContext
    {
        DbSet<FundDetail> FundDetails { get; set; }

        Task<int> SaveChanges();
    }
}
