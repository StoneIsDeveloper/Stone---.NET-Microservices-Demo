using System.ComponentModel.DataAnnotations;

namespace CommandsService.Models
{
    public class Platform
    {
        private ICollection<Command> commands = new List<Command>();

        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int ExternalId { get; set; } 
        
        [Required]
        public string Name { get; set; }

        public ICollection<Command> Commands { get => commands; set => commands = value; }
    }
}