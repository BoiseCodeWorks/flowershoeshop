using System.ComponentModel.DataAnnotations;

namespace markoz.Models
{
    public class Flower
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(.1, 100000)]
        public decimal Price { get; set; }
    }
}