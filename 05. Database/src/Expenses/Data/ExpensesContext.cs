using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Expenses.Data
{
    public class ExpensesContext : DbContext
    {
        public ExpensesContext(DbContextOptions<ExpensesContext> options)
            : base(options)
        {
        }

        public DbSet<ExpenseEntity> Expenses { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>(builder =>
            {
                builder.ToTable("category");
            });
            modelBuilder.Entity<ExpenseEntity>(builder =>
            {
                builder.ToTable("expense");
                builder.HasOne(x => x.Category).WithMany(x => x.Expenses).HasForeignKey(x => x.CategoryId);
            });
            base.OnModelCreating(modelBuilder);
        }
    }

    public class CategoryEntity
    {
        public string Id { get; set; }

        public ICollection<ExpenseEntity> Expenses { get; set; }
    }

    public class ExpenseEntity
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string CategoryId { get; set; }

        public CategoryEntity Category { get; set; }
    }
}
