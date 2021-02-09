using System;

namespace Calculator
{
    public class Calc
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b; // subtract betyder minus
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Power(double x, double exp)
        {
            return Math.Pow(x, exp);
        }

        public double Divide(double a, double b)
        { 
            //Dette nedenstående kode er til at prøve med en exception.

            //if (a==0 || b==0)
            //{
            //    throw new DivideByZeroException();
            //}

            return a / b;
        }

        // mikkle tilføjet kommentar
    }
}
