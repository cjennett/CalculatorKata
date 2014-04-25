using System;
using FluentAssertions;
using NUnit.Framework;

namespace CalculatorKata.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        Calculator calculator = new Calculator();

        [Test]
        public void Add_EmptyString_ReturnZero()
        {
            var result = calculator.Add("");
            result.Should().Be(0);
        }
        [Test]
        public void Add_NullString_ReturnZero()
        {
            var result = calculator.Add(null);
            result.Should().Be(0);
        }
        [Test]
        public void Add_SingleNumber_ReturnTheNumber()
        {
            var result = calculator.Add("1");
            result.Should().Be(1);
        }
        [Test]
        public void Add_TwoNumbers_ReturnTheSum()
        {
            var result = calculator.Add("1,2");
            result.Should().Be(3);
        }
        [Test]
        public void Add_TwoNumbersWithNewLine_ReturnTheSum()
        {
            var result = calculator.Add("1\n2");
            result.Should().Be(3);
        }
        [Test]
        public void Add_ThreeNumbersCombinedCommasAndNewLine_ReturnTheSum()
        {
            var result = calculator.Add("1\n2,3");
            result.Should().Be(6);
        }
        [Test]
        public void Add_CustomDelimiters_ReturnTheSum()
        {
            var result = calculator.Add("//;\n1;2");
            result.Should().Be(3);
        }
        [Test]
        public void Add_SingleNegativeNumber_ThrowsAnException()
        {
            Action act = () => calculator.Add("-1");

            act.ShouldThrow<Exception>().WithMessage("-1");
        }
        [Test]
        public void Add_SingleNegativeNumberSinglePositiveNumber_ThrowsAnException()
        {
            Action act = () => calculator.Add("-1,2");

            act.ShouldThrow<Exception>().WithMessage("-1");
        }
        [Test]
        public void Add_TwoNegativeNumber_ThrowsAnException()
        {
            Action act = () => calculator.Add("-1,-2");

            act.ShouldThrow<Exception>().WithMessage("-1 -2");
        }
        [Test]
        public void Add_BadParameter_ThrowsAnException()
        {
            Action act = () => calculator.Add("1-");

            act.ShouldThrow<InvalidOperationException>().WithMessage("1-");
        }

    }
}
