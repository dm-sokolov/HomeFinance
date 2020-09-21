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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionCategory>()
                .HasKey(t => new { t.TransactionId, t.CategoryId });

            modelBuilder.Entity<TransactionCategory>()
                .HasOne(sc => sc.Transaction)
                .WithMany(s => s.TransactionCategories)
                .HasForeignKey(sc => sc.TransactionId);

            modelBuilder.Entity<TransactionCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.TransactionCategories)
                .HasForeignKey(sc => sc.CategoryId);
        }

        public DbSet<HF.Web.Models.Currency> Currency { get; set; }

        public DbSet<HF.Web.Models.Category> Category { get; set; }

        public DbSet<HF.Web.Models.Operation> Operation { get; set; }

        public DbSet<HF.Web.Models.Unit> Unit { get; set; }

        public DbSet<HF.Web.Models.Transaction> Transaction { get; set; }

        public DbSet<HF.Web.Models.Contractor> Contractor { get; set; }

        public DbSet<HF.Web.Models.Recipient> Recipient { get; set; }
        
        public DbSet<HF.Web.Models.TransactionCategory> TransactionCategory { get; set; }
    }
}
