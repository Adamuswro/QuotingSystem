using QuotingSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QuotingSystem.ViewModels
{
    public class CreateQuoteViewModel
    {
        public CreateQuoteViewModel()
        {

        }//added comment
        public CreateQuoteViewModel(int? minPN, int? minTemp, List<Product> products, Product prefferedProduct, List<Customer> customers)
        {
            MinPN = minPN ?? 0;
            MinTemp = minTemp ?? 0;
            FilteredProducts = products;
            AvaliableProducts = products.Select(p =>
            new SelectListItem
            {
                Value = p.ProductId.ToString(),
                Text = p.Name
            });
            PrefferedProduct = prefferedProduct;
            AvaliableCustomers = customers.Select(p =>
            new SelectListItem
            {
                Value = p.CustomerId.ToString(),
                Text = p.Name
            });
        }
        public int MinPN { get; set; }
        public int MinTemp { get; set; }
        public int SelectedProductId { get; set; }
        public IEnumerable<SelectListItem> AvaliableProducts { get; set; }
        public IEnumerable<Product> FilteredProducts { get; set; }
        public Product PrefferedProduct { get; set; }
        public int SelectedCustomerId { get; set; }
        public IEnumerable<SelectListItem> AvaliableCustomers { get; set; }
    }
}