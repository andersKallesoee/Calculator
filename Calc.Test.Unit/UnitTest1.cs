using NUnit.Framework;

namespace Calc.Test.Unit
{
    public class CalculatorUnitTest
    {
        private Calculator.Calc _uut;
        private double _pa, _pb, _na, _nb;

        [SetUp]
        public void Setup()
        {
            _uut = new Calculator.Calc();
            _pa = 5.43;
            _pb = 3.46;
            _na = _pa -1;
            _nb = _pb - 1;

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


    }
}