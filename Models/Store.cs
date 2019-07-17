using System.ComponentModel.DataAnnotations;

namespace markoz.Models
{
    public class Store
    {
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }

    }
}