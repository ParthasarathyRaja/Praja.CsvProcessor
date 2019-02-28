using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;

namespace Praja.CsvProcessor.Models
{
    public class CsvContext : DbContext
    {
        public DbSet<IRESSSuperTransaction> IRESSSuperTransactions { get; set; }
        public DbSet<AustralianSuperTransaction> AustralianSuperTransactions { get; set; }
        public DbSet<ClassSuperTransaction> ClassSuperTransactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
