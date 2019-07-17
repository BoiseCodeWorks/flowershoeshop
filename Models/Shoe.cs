using System.ComponentModel.DataAnnotations;

namespace markoz.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Style { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public decimal Price { get; set; }
    }
}