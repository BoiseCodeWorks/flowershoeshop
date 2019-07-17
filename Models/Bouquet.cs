using System.ComponentModel.DataAnnotations;

namespace markoz.Models
{
    public class Bouquet
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int StoreId { get; set; }
    }

    public class FlowerBouquet
    {
        [Required]
        public int FlowerId { get; set; }
        public int BouquetId { get; set; }
    }
}
