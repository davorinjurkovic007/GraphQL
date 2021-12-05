using CarvedRock.Api.Data;
using CarvedRock.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Api.Repositories
{
    public class ProductRepository
    {
        private readonly CarvedRockDbContext dbContext;

        public ProductRepository(CarvedRockDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Product>?> GetAll()
        {
            if(dbContext.Products == null)
            {
                return null;
            }

            return await dbContext.Products.ToListAsync();
        }
    }
}
