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
        public void Subtract_SumOfTwoPositiveDoubles_Is1_97()
        {
            Assert.That(_uut.Subtract(_pa, _pb), Is.EqualTo(_pa-_pb));
        }

        [Test]
        public void Subtract_SumOfTwoNegativeDoubles_IsNegative1_97()
        {
            Assert.That(_uut.Subtract(_na, _nb), Is.EqualTo(_na-_nb));
        }

        [Test]
        public void Subtract_SumOfNegativeAndPositive_IsNegative8_89()
        {
            Assert.That(_uut.Subtract(_na, _pb), Is.EqualTo(_na-_pb));
        }

        [Test]
        public void Subtract_OverloadOfTwoPositiveDoubles_Is1_97()
        {
            _uut.Subtract(_pa, 0);
            Assert.That(_uut.Subtract( _pb), Is.EqualTo(_pa-_pb));
        }

        [Test]
        public void Subtract_OverloadOfTwoNegativeDoubles_IsNegative1_97()
        {
            _uut.Subtract(_na, 0);
            Assert.That(_uut.Subtract(_nb), Is.EqualTo(_na-_nb));
        }

        [Test]
        public void Subtract_OverloadOfNegativeAndPositive_IsNegative8_89()
        {
            _uut.Subtract(_na, 0);
            Assert.That(_uut.Subtract(_pb), Is.EqualTo(_na-_pb));
        }

        [Test]
        public void Multiply_SumOfTwoPositiveDoubles_Is18_78()
        {
            Assert.That(_uut.Multiply(_pa, _pb), Is.EqualTo(_pa*_pb));
        }

        [Test]
        public void Multiply_SumOfTwoNegativeDoubles_Is18_78()
        {
            Assert.That(_uut.Multiply(_na, _nb), Is.EqualTo(_na * _nb));
        }

        [Test]
        public void Multiply_SumOfNegativeAndPositive_IsNegative18_78()
        {
            Assert.That(_uut.Multiply(_na, _pb), Is.EqualTo(_na * _pb));
        }

        [Test]
        public void Multiply_OverloadOfTwoPositiveDoubles_Is102()
        {
            _uut.Multiply(_pa, _pa);
            Assert.That(_uut.Multiply(_pb), Is.EqualTo((_pa*_pa)*_pb));
        }

        [Test]
        public void Multiply_OverloadOfTwoNegativeDoubles_Is102()
        {
            _uut.Multiply(_na, _pa);
            Assert.That(_uut.Multiply(_nb), Is.EqualTo((_na * _pa) * _nb));
        }

        [Test]
        public void Multiply_OverloadOfNegativeAndPositive_IsNegative102()
        {
            _uut.Multiply(_pa, _na);
            Assert.That(_uut.Multiply(_pb), Is.EqualTo((_pa * _na) * _pb));
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
            Assert.That(() => _uut.Divide(_pa, _zero), Throws.TypeOf<DivideByZeroException>());
        }


    }
}