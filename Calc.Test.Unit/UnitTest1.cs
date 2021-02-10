using System;
using NUnit.Framework;
using Calc = Calculator.Calc;

namespace Calc.Test.Unit
{
    public class CalculatorUnitTest
    {
        private Calculator.Calc _uut;
        private double _pa, _pb, _pc, _na, _nb, _nc, _zero;

        [SetUp]
        public void Setup()
        {
            _uut = new Calculator.Calc();
            _pa = 5.43;
            _pb = 3.46;
            _pc = 5;
            _na = _pa -1;
            _nb = _pb -1;
            _nc = -3.46;
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

            //N�r man tester siger den okay, men det er umuligt at dividere med 0
            //den burde sige fejl
            //S� jeg t�nker at lave noget med at den kaster en exception, 
            //Jeg kan bare ike lige lure hvordan man laver det i test.

            //Assert.Throws<DivideByZeroException>(() => _uut = new Calc(_pa, _pb));
        }

        [Test]
        public void Power_TwoPositiveDoubles_resultCorrect()
        {
            Assert.That(_uut.Power(_pa, _pb), Is.EqualTo(Math.Pow(_pa, _pb)));
        }

        [Test]
        public void Power_NegativeDoublePositiveInt_ResultCorrect()
        {
            Assert.That(_uut.Power(_nc,_pc), Is.EqualTo(Math.Pow(_nc, _pc)));
        }

        [Test]
        public void Power_NegativeDoublePositiveDouble_ExceptionThrown()
        {
            Assert.That(() => _uut.Power(_nc, _pb), Throws.TypeOf<NotFiniteNumberException>());
        }

        [Test]
        public void Power_AccumulatorNegativeDoublePositiveInt_ResultCorrect()
        {
            _uut.Power(_pa, _pb);
            Assert.That(_uut.Power(_pc), Is.EqualTo(Math.Pow(Math.Pow(_pa, _pb), _pc)));
        }

        [Test]
        public void Power_AccumulatorNegativeDoublePositiveDouble_ExceptionThrown()
        {
            _uut.Power(_pa, _pb);
            _uut.Multiply(-1);
            Assert.That(() => _uut.Power(_pb), Throws.TypeOf<NotFiniteNumberException>());
        }
    }
}