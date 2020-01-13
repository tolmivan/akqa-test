using AKQA.Bussiness;
using AKQA.Model;
using AKQA.Services.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AKQA.Services.Tests
{
    public class PersonProcessorTests
    {
        private PersonProcessor _sut;
        private Mock<INumberConversionService> _conversionSvcMock;
        private Mock<IHumanizerService> _humanizerSvcMock;
        private int _iPart, _fPart;

        public PersonProcessorTests()
        {
            _conversionSvcMock = new Mock<INumberConversionService>();
            _humanizerSvcMock = new Mock<IHumanizerService>();

            _sut = new PersonProcessor(_conversionSvcMock.Object, _humanizerSvcMock.Object);

            _conversionSvcMock
                .Setup(s => s.SplitStringNumberIntoIntegralAndFractionParts(It.IsAny<string>(), out _iPart, out _fPart))
                .Verifiable();

            _humanizerSvcMock
                .Setup(s => s.NumbersToMoneyWords(It.IsAny<int>(), It.IsAny<int>()))
                .Verifiable();
        }

        [Fact]
        public void ProcessNumberIntoWords_GivenNullPerson_DoesntCallServicesReturnsNull()
        {
            var actual = _sut.ProcessNumberIntoWords(null);

            _conversionSvcMock
                .Verify(s => s.SplitStringNumberIntoIntegralAndFractionParts(It.IsAny<string>(), out _iPart, out _fPart), Times.Never);

            _humanizerSvcMock
                .Verify(s => s.NumbersToMoneyWords(It.IsAny<int>(), It.IsAny<int>()), Times.Never);

            Assert.Null(actual);
        }

        [Fact]
        public void ProcessNumberIntoWords_GivenNullNumberString_DoesntCallServicesReturnsNullHumanizedNumber()
        {
            var person = new Person { Number = null };

            var actual = _sut.ProcessNumberIntoWords(person);

            _conversionSvcMock
                .Verify(s => s.SplitStringNumberIntoIntegralAndFractionParts(It.IsAny<string>(), out _iPart, out _fPart), Times.Never);

            _humanizerSvcMock
                .Verify(s => s.NumbersToMoneyWords(It.IsAny<int>(), It.IsAny<int>()), Times.Never);

            Assert.Null(actual.HumanizedNumber);
        }

        [Fact]
        public void ProcessNumberIntoWords_GivenEmptyNumberString_DoesntCallServicesReturnsPersonWithNullHumanizedNumber()
        {
            var person = new Person { Number = "" };

            var actual = _sut.ProcessNumberIntoWords(person);

            _conversionSvcMock
                .Verify(s => s.SplitStringNumberIntoIntegralAndFractionParts(It.IsAny<string>(), out _iPart, out _fPart), Times.Never);

            _humanizerSvcMock
                .Verify(s => s.NumbersToMoneyWords(It.IsAny<int>(), It.IsAny<int>()), Times.Never);

            Assert.Null(actual.HumanizedNumber);
        }

        [Fact]
        public void ProcessNumberIntoWords_GivenNotEmptyNumberString_CallsBothServicesOnceAndUpdatesHumanizedNumber()
        {
            var person = new Person { Number = "123" };

            _humanizerSvcMock
                .Setup(s => s.NumbersToMoneyWords(It.IsAny<int>(), It.IsAny<int>()))
                .Returns("HUMANIZED");

            var actual = _sut.ProcessNumberIntoWords(person);

            _conversionSvcMock
                .Verify(s => s.SplitStringNumberIntoIntegralAndFractionParts(It.IsAny<string>(), out _iPart, out _fPart), Times.Once);

            _humanizerSvcMock
                .Verify(s => s.NumbersToMoneyWords(It.IsAny<int>(), It.IsAny<int>()), Times.Once);

            Assert.Equal("HUMANIZED", actual.HumanizedNumber);
        }

    }
}
