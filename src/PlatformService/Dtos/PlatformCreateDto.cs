using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    public class PlatformCreateDto
    {
        [Required]        
        public string Name { get; set; }


        public string Publisher { get; set; }
        

        public string Cost { get; set; }
    }
}