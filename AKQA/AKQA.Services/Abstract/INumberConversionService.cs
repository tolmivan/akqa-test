using System;
using System.Collections.Generic;
using System.Text;

namespace AKQA.Services.Abstract
{
    public interface INumberConversionService
    {
        void SplitStringNumberIntoIntegralAndFractionParts(string input, out int integralPart, out int fractionPart);
    }
}
