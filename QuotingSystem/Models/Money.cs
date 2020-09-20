using System.Globalization;

namespace QuotingSystem.Models
{
    public struct Money
    {
        public decimal value { get; set; }
        public Currency CurrencyType { get; set; }

        public override string ToString()
        {
            return $"{value.ToString(new CultureInfo("en-US"))}{CurrencyType}";
        }
    }

    public enum Currency
    {
        EUR,
        USD,
        PLN
    }
}