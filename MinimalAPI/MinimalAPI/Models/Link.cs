namespace MinimalAPI.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
