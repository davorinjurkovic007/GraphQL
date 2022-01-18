using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.GraphQL.RepositoryFiles
{
    public interface IRepository
    {
        Task<IReadOnlyCollection<Item>> GetItems();
        Task<Item> GetItemByTag(string tag);
        Task<Item> AddItem(Item item);
    }
}
