using AKQA.Bussiness.Abstract;
using AKQA.Model;
using AKQA.Services.Abstract;

namespace AKQA.Bussiness
{
    /// <summary>
    /// Encapsulate processing logic for Person object
    /// </summary>
    public class PersonProcessor : IPersonProcessor
    {
        private readonly INumberConversionService _numberConversionService;
        private readonly IHumanizerService _humanizerService;

        public PersonProcessor(INumberConversionService numberConversionService, IHumanizerService humanizerService)
        {
            _numberConversionService = numberConversionService;
            _humanizerService = humanizerService;
        }

        /// <summary>
        /// Generates a word representation of Number field and updated HumanizedNumber field with that
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Person ProcessNumberIntoWords(Person person)
        {
            if (!string.IsNullOrEmpty(person?.Number))
            {
                // call conversion service to get dollars and cents values
                _numberConversionService.SplitStringNumberIntoIntegralAndFractionParts(person.Number, out int dollars, out int cents);

                // call humanizer service to convert numbers into words
                person.HumanizedNumber = _humanizerService.NumbersToMoneyWords(dollars, cents);
            }

            return person;
        }
    }
}
