using CashFlowMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CashFlowMvc.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole <Guid>,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<FinancialEntry> FinancialEntries { get; set; }
        public DbSet<FinancialExpense> FinancialExpenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
