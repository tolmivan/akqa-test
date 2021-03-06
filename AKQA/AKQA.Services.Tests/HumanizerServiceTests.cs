using System;
using Xunit;

namespace AKQA.Services.Tests
{
    public class HumanizerServiceTests
    {
        private HumanizerService _sut;

        public HumanizerServiceTests()
        {
            _sut = new HumanizerService();
        }

        [Fact]
        public void NumbersToMoneyWords_GivenNumbersAsPerExample_ReturnsStringAsPerExample()
        {
            var actual = _sut.NumbersToMoneyWords(123, 45);

            Assert.Equal("ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS", actual);
        }

        [Fact]
        public void NumbersToMoneyWords_GivenOneDollarAndOneCent_ReturnsStringContainingDOLLARandCENT()
        {
            var actual = _sut.NumbersToMoneyWords(1, 1);

            Assert.Equal("ONE DOLLAR AND ONE CENT", actual);
        }

        [Fact]
        public void NumbersToMoneyWords_GivenZeroValues_ReturnsStringContainingZERO()
        {
            var actual = _sut.NumbersToMoneyWords(0, 0);

            Assert.Equal("ZERO DOLLARS AND ZERO CENTS", actual);
        }

        [Fact]
        public void NumbersToMoneyWords_GivenNegativeNumbers_ReturnsStringContainingMINUS()
        {
            var actual = _sut.NumbersToMoneyWords(-1, -1);

            Assert.Equal("MINUS ONE DOLLARS AND MINUS ONE CENTS", actual);
        }

        [Theory]
        [InlineData(-1, -1, "MINUS ONE DOLLARS AND MINUS ONE CENTS")]
        [InlineData(123, 45, "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS")]
        public void NumbersToMoneyWords_GivenSomeRandomNUmbers_ReturnsExpectedStrings(int dollars, int cents, string expected)
        {
            var actual = _sut.NumbersToMoneyWords(dollars, cents);

            Assert.Equal(expected, actual);
        }


    }
}
