using GraphQLDemo.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Database
{
    public class GraphQLDemoDbContext : DbContext
    {
        public GraphQLDemoDbContext(DbContextOptions<GraphQLDemoDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
