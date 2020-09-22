using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuotingSystem.Models
{
    public class Quote : ITrackable
    {
        //Alternative: [Key] property, suffix Id means key for EF naming convention
        [ScaffoldColumn(false)]
        public int QuoteId { get; set; }

        //Alternative: 
        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name ="Creation")]
        public DateTime CreationDate { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Last changed")]
        public DateTime LastChangedDate { get; set; }

        [Required(ErrorMessage = "Customer is reqiured!")]
        [Display(Name = "Customer")]
        public virtual Customer SelectedCustomer { get; set; }

        [Required(ErrorMessage = "Product selection is reqiured!")]
        [Display(Name = "Product")]
        public virtual Product SelectedProduct { get; set; }
    }
}