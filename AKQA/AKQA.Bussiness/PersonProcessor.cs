using AKQA.Bussiness.Abstract;
using AKQA.Model;
using AKQA.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AKQA.Bussiness
{
    public class PersonProcessor : IPersonProcessor
    {
        private readonly INumberConversionService _numberConversionService;
        private readonly IHumanizerService _humanizerService;

        public PersonProcessor(INumberConversionService numberConversionService, IHumanizerService humanizerService)
        {
            _numberConversionService = numberConversionService;
            _humanizerService = humanizerService;
        }

        public Person ProcessPerson(Person person)
        {
            _numberConversionService.SplitStringIntoIntegralAndFractionParts(person.Number, out int integralPart, out int fractionPart);

            person.HumanizedNumber = _humanizerService.NumbersToMoneyWords(integralPart, fractionPart);

            return person;
        }
    }
}
