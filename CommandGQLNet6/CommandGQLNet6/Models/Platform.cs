using System.ComponentModel.DataAnnotations;

namespace CommandGQLNet6.Models
{
    //[GraphQLDescription("This is Description of this table")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        //[GraphQLDescription("This is purchased, valid license key of the Software")]
        public string? LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
