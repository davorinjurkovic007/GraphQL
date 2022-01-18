using MinimalAPI.Models;

namespace MinimalAPI.Queries
{
    public class Query
    {
        public IQueryable<Link> Links => new List<Link>
        {
            new Link
            {
                 Id = 1,
                Url = "https://example.com",
                Title = "Example",
                Description = "This is an example link",
                ImageUrl = "https://example.com/image.png",
                Tags = new List<Tag> { new Tag(){ Name = "Example" } },
                CreatedOn = DateTime.Now
            },
            new Link
            {
                Id = 2,
                Url = "https://dotnetthoughts.net",
                Title = "DotnetThoughts",
                Description = "DotnetThoughts is a blog about .NET",
                ImageUrl = "https://dotnetthoughts.net/image.png",
                Tags = new List<Tag>
                {
                    new Tag(){ Name = "Programming" },
                    new Tag(){ Name = "Blog" },
                    new Tag(){ Name = "dotnet" }
                },
                CreatedOn = DateTime.Now
            },
        }.AsQueryable();
    }
}
