using AKQA.Services.Abstract;
using Humanizer;

namespace AKQA.Services
{
    /// <summary>
    /// Provides functionality to "humanize" numbers etc into words
    /// Based on Humanizer library https://github.com/Humanizr/Humanizer#number-to-words
    /// </summary>
    public class HumanizerService : IHumanizerService
    {
        /// <summary>
        /// Generates a word representation of dollars and cents numbers
        /// </summary>
        /// <param name="dollars"></param>
        /// <param name="cents"></param>
        /// <returns></returns>
        public string NumbersToMoneyWords(int dollars, int cents)
        {
            var dollarString = "dollars".ToQuantity(dollars, ShowQuantityAs.Words);
            var centsString = "cents".ToQuantity(cents, ShowQuantityAs.Words);

            return $"{dollarString} AND {centsString}".ToUpper();
        }
    }
}
