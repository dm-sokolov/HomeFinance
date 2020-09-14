using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HF.Web.Models;

namespace HF.Web.Data
{
    public class HFWebContext : DbContext
    {
        public HFWebContext (DbContextOptions<HFWebContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<HF.Web.Models.Currency> Currency { get; set; }
    }
}
