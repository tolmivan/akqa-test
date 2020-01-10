using Humanizer;

namespace AKQA.Services
{
    public static class HumanizerService
    {
        public static string NumbersToMoneyWords(int dollars, int cents)
        {
            var dollarString = "dollars".ToQuantity(dollars, ShowQuantityAs.Words);
            var centsString = "cents".ToQuantity(cents, ShowQuantityAs.Words);

            return $"{dollarString} AND {centsString}".ToUpper();
        }
    }
}
