using GraphQL.Data;
using GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL
{
    public class Query
    {
        /// <summary>
        /// By annotating UseApplicationDbContext we are essentially applying a Middleware to the field resolver pipeline. 
        /// Important: Note, that we no longer are returning the IQueryable but are executing the IQueryable by using ToListAsync.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) => context.Speakers.ToListAsync();


    }
}
