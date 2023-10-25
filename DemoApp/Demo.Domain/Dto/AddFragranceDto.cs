using Demo.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Demo.Domain.Dto
{
    public class AddFragranceDto
    {

        [Required]
        public FragranceType Type { get; set; }
        [Required]
        public Intensity Intensity { get; set; }
        [Required]
        public Preference Preference { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
