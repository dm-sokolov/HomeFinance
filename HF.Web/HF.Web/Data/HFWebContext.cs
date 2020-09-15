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
            //Database.EnsureCreated();
        }

        public DbSet<HF.Web.Models.Currency> Currency { get; set; }

        public DbSet<HF.Web.Models.Category> Category { get; set; }

        public DbSet<HF.Web.Models.Operation> Operation { get; set; }

        public DbSet<HF.Web.Models.Unit> Unit { get; set; }

        public DbSet<HF.Web.Models.Transaction> Transaction { get; set; }

        public DbSet<HF.Web.Models.Contractor> Contractor { get; set; }

        public DbSet<HF.Web.Models.Recipient> Recipient { get; set; }
    }
}
