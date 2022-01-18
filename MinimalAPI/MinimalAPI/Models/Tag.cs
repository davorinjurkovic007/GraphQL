namespace MinimalAPI.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LinkId { get; set; }
        public Link Link { get; set; }
    }
}
