using KOPA.LoanManagement.Domain.Common;
using KOPA.LoanManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOPA.LoanManagement.Persistence
{
    public  class LoanManagementDbContext : DbContext
    {
        public LoanManagementDbContext(DbContextOptions<LoanManagementDbContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoanManagementDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerLoan> CustomerLoans { get; set; }

    }
}
