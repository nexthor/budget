using Budget.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Budget.Api
{
    public class BudgetDbContext : IdentityDbContext<User>
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options) { }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
    }
}
