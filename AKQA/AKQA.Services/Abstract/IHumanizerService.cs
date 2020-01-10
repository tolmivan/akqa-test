using System;
using System.Collections.Generic;
using System.Text;

namespace AKQA.Services.Abstract
{
    public interface IHumanizerService
    {
        string NumbersToMoneyWords(int dollars, int cents);
    }
}
