using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuotingSystem.Models
{
    public class Quote
    {
        //Alternative: [Key] property, suffix Id means key for EF naming convention
        public int QuoteId { get; set; }
        [Required(ErrorMessage ="Quote name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "PN is required")]
        public int PN { get; set; }
        public int Temp { get; set; }
        public Money Price { get; set; }

    }
}