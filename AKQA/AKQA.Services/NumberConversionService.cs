using AKQA.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKQA.Services.Tests
{
    public class NumberConversionService : INumberConversionService
    {
        public void SplitStringIntoIntegralAndFractionParts(string input, out int integralPart, out int fractionPart)
        {
            try
            {
                var decimalValue = Convert.ToDecimal(input);

                var decimalRoundedValue = decimal.Round(decimalValue, 2, MidpointRounding.AwayFromZero);

                integralPart = (int)decimal.Truncate(decimalRoundedValue);
                fractionPart = (int)Math.Abs(((decimalRoundedValue % 1.0m)*100));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Invalid number string", ex);
            }
        }
    }
}
