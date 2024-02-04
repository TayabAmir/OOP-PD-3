using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificCal
{
    internal class sCal
    {
        public int num;
        public int num1;
        public int num2;

        public int addition()
        {
            return num1 + num2;
        }
        public int subtraction()
        {
            return num1 - num2;
        }
        public int multiplication()
        {
            return num1 * num2;
        }
        public int division()
        {
            if (num2 != 0)
            {
                return num1 / num2;
            }
            return -1;
        }
        public int modulus()
        {
            if (num2 != 0)
            {
                return num1 % num2;
            }
            return -1;
        }
        public double squareRoot()
        {
            return Math.Sqrt(num);
        }
        public double exponential()
        {
            return Math.Exp(num);
        }
        public double logarithm()
        {
            return Math.Log(num);
        }
        public double sine()
        {
            return Math.Sin(num * (180 / 3.1415F));
        }
        public double cosine()
        {
            return Math.Cos(num * (180 / 3.1415F));
        }
        public double tangent()
        {
            return Math.Tan(num * (180 / 3.1415F));
        }
    }
}
