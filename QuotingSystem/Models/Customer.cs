using System.ComponentModel.DataAnnotations;

namespace QuotingSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        
        [Display(Name="Customer name")]
        public string Name { get; set; }
    }
}