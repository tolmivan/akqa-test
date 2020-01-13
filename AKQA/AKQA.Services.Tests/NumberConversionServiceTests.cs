using System;
using Xunit;

namespace AKQA.Services.Tests
{
    public class NumberConversionServiceTests
    {
        private NumberConversionService _sut;

        public NumberConversionServiceTests()
        {
            _sut = new NumberConversionService();
        }

        [Fact]
        public void SplitStringIntoIntegralAndFractionParts_GivenStringAsPerExample_ReturnsNumbersAsPerExample()
        {
            int dollars;
            int cents;

            _sut.SplitStringNumberIntoIntegralAndFractionParts("123.45", out dollars, out cents);

            Assert.Equal(123, dollars);
            Assert.Equal(45, cents);
        }

        [Theory]
        [InlineData("123.45", 123, 45)]
        [InlineData("-123.45", -123, 45)]
        [InlineData("0.0", 0, 0)]
        [InlineData("-0.0", 0, 0)]
        [InlineData("0.1", 0, 10)]
        [InlineData("0.123", 0, 12)]
        [InlineData("0.129", 0, 13)]
        public void SplitStringIntoIntegralAndFractionParts_GivenRandomValidStrings_ReturnsExpectedNumbers(string input, int expectedDollars, int expectedCents)
        {
            int dollars;
            int cents;

            _sut.SplitStringNumberIntoIntegralAndFractionParts(input, out dollars, out cents);

            Assert.Equal(expectedDollars, dollars);
            Assert.Equal(expectedCents, cents);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("123a")]
        [InlineData("-123a")]
        [InlineData("-+123")]
        [InlineData("1.1.1")]
        public void SplitStringIntoIntegralAndFractionParts_GivenRandomInValidStrings_ThrowsArgumentException(string input)
        {
            int dollars;
            int cents;

            Exception result = Assert.Throws<ArgumentException>(() => _sut.SplitStringNumberIntoIntegralAndFractionParts(input, out dollars, out cents));

            Assert.Equal("Invalid number string", result.Message);
        }

    }
}
