using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.GraphQL.RepositoryFiles
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Item> AddItem(Item item)
        {
            var addedEntity = await applicationDbContext.Items.AddAsync(item);
            return addedEntity.Entity;
        }

        public Task<Item> GetItemByTag(string tag)
        {
            return applicationDbContext.Items.FirstAsync(i => i.Tag.Equals(tag));
        }

        public async Task<IReadOnlyCollection<Item>> GetItems()
        {
            return await applicationDbContext.Items.ToListAsync();
        }
    }
}
