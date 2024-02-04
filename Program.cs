using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificCal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opt;
            bool flag = false, flag1 = false;
            sCal calculator = new sCal();

            do
            {
                Console.Clear();
                Console.WriteLine("1.Create the a Single Object of Calculator");
                Console.WriteLine("2.Change Values of Attributes");
                Console.WriteLine("3.Add");
                Console.WriteLine("4.Subtract");
                Console.WriteLine("5.Multiply");
                Console.WriteLine("6.Divide");
                Console.WriteLine("7.Modulo");
                Console.WriteLine("8.Enter the value for below functions");
                Console.WriteLine("9.Square Root");
                Console.WriteLine("10.exponential");
                Console.WriteLine("11.logarithm");
                Console.WriteLine("12.Trignometric Function");
                Console.WriteLine("0.Exit");
                Console.Write("Choose the option...");
                opt = int.Parse(Console.ReadLine());

                if (opt == 1)
                {
                    calculator.num1 = 10;
                    calculator.num2 = 10;
                    flag = true;
                }
                else if (opt == 2 && flag)
                {
                    Console.Write("Enter num1: ");
                    calculator.num1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter num2: ");
                    calculator.num2 = int.Parse(Console.ReadLine());
                }

                else if (opt == 3 && flag)
                {
                    Console.WriteLine(calculator.addition());
                }
                else if (opt == 4 && flag)
                {
                    Console.WriteLine(calculator.subtraction());
                }
                else if (opt == 5 && flag)
                {
                    Console.WriteLine(calculator.multiplication());
                }
                else if (opt == 6 && flag)
                {
                    if (calculator.division() != -1)
                    {
                        Console.WriteLine(calculator.division());
                    }
                    else
                    {
                        Console.WriteLine("Second number must not equal to zero");
                    }
                }
                else if (opt == 7 && flag)
                {
                    if (calculator.modulus() != -1)
                    {
                        Console.WriteLine(calculator.modulus());
                    }
                    else
                    {
                        Console.WriteLine("Second number must not equal to zero");
                    }
                }
                else if (opt == 8 && flag)
                {
                    Console.Write("Enter the number: ");
                    calculator.num = int.Parse(Console.ReadLine());
                    flag1 = true;
                }
                else if (opt == 9)
                {
                    if (flag1)
                       Console.WriteLine(calculator.squareRoot());
                    else
                        Console.Write("First go to option 8");
                    Console.ReadKey();

                    continue;
                }
                else if (opt == 10)
                {
                    if (flag1)
                        Console.WriteLine(calculator.exponential());
                    else
                        Console.Write("First go to option 8");
                    Console.ReadKey();
                    continue;
                }
                else if (opt == 11)
                {
                    if (flag1)
                        Console.WriteLine(calculator.logarithm());
                    else
                        Console.Write("First go to option 8");
                    Console.ReadKey();

                    continue;

                }
                else if (opt == 12)
                {
                    if (flag1)
                    {
                        Console.WriteLine("SIN of number is: " + calculator.sine());
                        Console.WriteLine("COS of number is: " + calculator.cosine());
                        Console.WriteLine("TAN of number is: " + calculator.tangent());
                    }
                    else
                        Console.Write("First go to option 8");
                    Console.ReadKey();

                    continue;

                }
                if (!flag)
                    Console.WriteLine("First go to option 1 to create object");
                Console.ReadKey();
            }while (opt != 0);
            Console.WriteLine("Thank You");

        }
    }
}
