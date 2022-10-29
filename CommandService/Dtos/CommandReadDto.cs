
using System.ComponentModel.DataAnnotations;

namespace commandService.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }
    }
}