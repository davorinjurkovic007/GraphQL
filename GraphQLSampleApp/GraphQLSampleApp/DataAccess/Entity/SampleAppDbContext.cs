using Microsoft.EntityFrameworkCore;

namespace GraphQLSampleApp.DataAccess.Entity
{
    public class SampleAppDbContext : DbContext
    {
        public SampleAppDbContext(DbContextOptions<SampleAppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; } = default!;

        public DbSet<Department> Department { get; set; } = default!;
    }
}
