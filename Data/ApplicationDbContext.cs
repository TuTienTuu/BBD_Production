using BBD_Production_New.Models;
using Microsoft.EntityFrameworkCore;

namespace BBD_Production_New.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ProductionPlan> ProductionPlans { get; set; }
    }
}
