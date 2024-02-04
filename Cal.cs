using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Cal
    {
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
    }
}
