using System;
using System.Collections.Generic;
using System.Text;

namespace AKQA.Services.Abstract
{
    public interface INumberConversionService
    {
        void SplitStringIntoIntegralAndFractionParts(string input, out int integralPart, out int fractionPart);
    }
}
