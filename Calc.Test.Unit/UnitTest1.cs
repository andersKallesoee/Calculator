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
            _na = -_pa;
            _nb = -_pb;
            _zero = 0;
        }

        [Test]
        public void Accumulator_StoreNumber_iscorrect()
        {
            double test = _uut.Add(_pa, _pb);
            Assert.That(_uut.Accumulator, Is.EqualTo(test));
        }

        [Test]
        public void Accumulator_StoreNumberTwoTimes_iscorrect()
        {
            double test = _uut.Add(_pa, _pb);
            double test2 = _uut.Multiply(_pa, 2);
            Assert.That(_uut.Accumulator, Is.EqualTo(test2));
        }

        [Test]
        public void Accumulator_ClearNumber_is0()
        {
            double test = _uut.Add(_pa, _pb);
            _uut.Clear();
            Assert.That(_uut.Accumulator, Is.EqualTo(0));
        }

        [Test]
        public void Add_SumOfTwoPositiveDoubles_Is8_89()
        {
            Assert.That(_uut.Add(_pa,_pb), Is.EqualTo(8.89));
        }

        [Test]
        public void Add_SumOfTwoNegativeDoubles_IsNegative8_89()
        {
            Assert.That(_uut.Add(_na, _nb), Is.EqualTo(-8.89));
        }

        [Test]
        public void Add_SumOfTwoNegativPlusPositive_Is0()
        {
            Assert.That(_uut.Add(_na, _pa), Is.EqualTo(0));
        }

        [Test]
        public void Add_OverloadTwoPositiveDoubles_Is8_89()
        {
            _uut.Add(_pa, 0);
            Assert.That(_uut.Add(_pb), Is.EqualTo(8.89));
        }

        [Test]
        public void Add_OverloadTwoNegativeDoubles_IsNegative8_89()
        {
            _uut.Add(_na, 0);
            Assert.That(_uut.Add(_nb), Is.EqualTo(-8.89));
        }

        [Test]
        public void Add_OverloadNegativPlusPositive_Is0()
        {
            _uut.Add(_pa, 0);
            Assert.That(_uut.Add(_na), Is.EqualTo(0));
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

        // test af jenkins

    }
}