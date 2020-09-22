using System.ComponentModel.DataAnnotations;

namespace QuotingSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Display(Name = "Poduct name")]
        public string Name { get; set; }

        [Display(Name = "Minimum PN [?]")]
        public int PN { get; set; }

        [Display(Name = "Minimum temperature [°C]")]
        public int Temp { get; set; }

        [Display(Name = "Price [EUR]")]
        public decimal Price { get; set; }
    }
}