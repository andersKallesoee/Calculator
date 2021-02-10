using System;

namespace Calculator
{
    public class Calc
    {
        public double Accumulator { get; private set; }

        public double Add(double a, double b)
        {
            Accumulator = a + b;
            return a + b;

        }

        public double Add(double adder) // Add overloaded
        {
            double resultat = adder + Accumulator;
            Accumulator = resultat;
            return resultat;
        }

        public double Subtract(double a, double b)
        {
            Accumulator = a - b;
            return a - b;
        }

        public double Subtract(double subtractor) //subtract overload
        {
            double resultat = Accumulator - subtractor;
            Accumulator = resultat;
            return resultat;
        }

        public double Multiply(double a, double b)
        {
            Accumulator = a * b;
            return a * b;
        }
        public double Multiply(double multiplyer) //multiply overload
        {
            double resultat = Accumulator * multiplyer;
            Accumulator = resultat;
            return resultat;
        }

        public double Power(double x, double exp)
        {
            var tmp = Accumulator = Math.Pow(x, exp);    // checks for overflow and underflow
            if (double.IsInfinity(tmp) || double.IsNaN(tmp))
            {
                throw new NotFiniteNumberException();
            }
            return Math.Pow(x, exp);
        }

        public double Power(double exponent) // power overload
        {
            double resultat = Math.Pow(Accumulator, exponent);
            Accumulator = resultat;
            return resultat;
        }

        public double Divide(double divided, double divisor) //divide vil ikke dividere med 0
        {
            if (divisor != 0)
            {
                Accumulator = divided / divisor;
                return divided / divisor;
            }

            return 0;
        }

        public double Divide(double divisor) // didide overload
        {
            if (divisor != 0)
            {
                double resultat = Accumulator / divisor;
                Accumulator = resultat;
                return resultat;
            }

            return 0;
        }

        

    }
}
