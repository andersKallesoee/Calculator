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
            _na = -_pa;
            _nb = -_pb;
            _pc = 5;
            _nc = -3.46;
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
        public void Divide_SumOfTwoPositiveNumbers_Is1_56()
        {
            Assert.That(_uut.Divide(_pa, _pb), Is.EqualTo(_pa / _pb));
        }

        [Test]
        public void Divide_SumOfTwoNegativeNumbers_Is1_56()
        {
            Assert.That(_uut.Divide(_na, _nb), Is.EqualTo(_na / _nb));
        }

        [Test]
        public void Divide_WithZero_throwsExecption()
        {
            Assert.That(() =>_uut.Divide(_pb, _zero), Throws.TypeOf<DivideByZeroException>());

        }

        [Test]
        public void Divide_OverloadPositiveNumbers_Is2_715()
        {
            double test = _uut.Add(_pa, 0);
            Assert.That(_uut.Divide(2), Is.EqualTo(_pa/2));
        
        }

        [Test]
        public void Divide_OverloadWithZero_throwsExecption()
        {
            double test = _uut.Add(2, 5);
            Assert.That(() => _uut.Divide(_zero), Throws.TypeOf<DivideByZeroException>());
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