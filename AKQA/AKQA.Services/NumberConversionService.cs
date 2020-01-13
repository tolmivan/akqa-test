using AKQA.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKQA.Services

{
    public class NumberConversionService : INumberConversionService
    {
        /// <summary>
        /// Given a string containg a number returns an integral and fraction parts of it
        /// Throws an argument exception if fails to convert the string to a number
        /// </summary>
        /// <param name="input">a string containg a number</param>
        /// <param name="integralPart">integral part</param>
        /// <param name="fractionPart">fraction part</param>
        public void SplitStringNumberIntoIntegralAndFractionParts(string input, out int integralPart, out int fractionPart)
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
