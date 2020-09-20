using QuotingSystem.Models;
using Xunit;

namespace QuotingSystem.Tests.Models
{
    public class MoneyTests
    {
        [Theory]
        [InlineData("100.15EUR", 100.15, Currency.EUR)]
        [InlineData("15PLN", 15, Currency.PLN)]
        public void ToString_ShouldReturnCorrectResult(string expected, decimal price, Currency currency)
        {
            var money = new Money() { CurrencyType = currency, value = price };

            var actual = money.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
