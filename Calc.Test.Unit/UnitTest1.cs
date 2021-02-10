using System;
using NUnit.Framework;
using Calc = Calculator.Calc;

namespace Calc.Test.Unit
{
    public class CalculatorUnitTest
    {
        private Calculator.Calc _uut;
        private double _pa, _pb, _na, _nb, _zero;

        [SetUp]
        public void Setup()
        {
            _uut = new Calculator.Calc();
            _pa = 5.43;
            _pb = 3.46;
            _na = _pa -1;
            _nb = _pb -1;
            _zero = 0;
        }

        [Test]
        public void Add_SumOfTwoPositiveDoubles()
        {
            Assert.That(_uut.Add(_pa,_pb), Is.EqualTo(_pa+_pb));
        }

        [Test]
        public void Add_SumOfTwoNegativeDoubles()
        {
            Assert.That(_uut.Add(_na, _nb), Is.EqualTo(_na+_nb));
        }

        [Test] 
        public void Divide_SumOfTwoPositiveNumbers()
        {
            Assert.That(_uut.Divide(_pa, _pb), Is.EqualTo(_pa / _pb));
        }

        [Test]
        public void Divide_SumOfTwoNegativeNumbers()
        {
            Assert.That(_uut.Divide(_na, _nb), Is.EqualTo(_na / _nb));
        }

        [Test]
        public void Divide_WithZero()
        {
            Assert.That(_uut.Divide(_zero, _pb), Is.EqualTo(_zero / _pb));

            //Når man tester siger den okay, men det er umuligt at dividere med 0
            //den burde sige fejl
            //Så jeg tænker at lave noget med at den kaster en exception, 
            //Jeg kan bare ike lige lure hvordan man laver det i test.

            //Assert.Throws<DivideByZeroException>(() => _uut = new Calc(_pa, _pb));
        }

    }
}