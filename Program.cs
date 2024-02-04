using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opt;
            bool flag = false;
            Cal calculator = new Cal();

            do
            {

                Console.WriteLine("1.Create the a Single Object of Calculator");
                Console.WriteLine("2.Change Values of Attributes");
                Console.WriteLine("3.Add");
                Console.WriteLine("4.Subtract");
                Console.WriteLine("5.Multiply");
                Console.WriteLine("6.Divide");
                Console.WriteLine("7.Modulo");
                Console.WriteLine("0.Exit");
                Console.Write("Choose the option...");
                opt = int.Parse(Console.ReadLine());

                if(opt==1)
                {
                    calculator.num1 = 10;
                    calculator.num2 = 10;
                    flag = true;
                }
                else if(opt==2 && flag==true)
                {
                    Console.Write("Enter num1: ");
                    calculator.num1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter num2: ");
                    calculator.num2 = int.Parse(Console.ReadLine());
                }

                else if (opt == 3 && flag == true)
                {
                    Console.WriteLine(calculator.addition());
                }
                else if (opt == 4 && flag == true)
                {
                    Console.WriteLine(calculator.subtraction());
                }
                else if (opt == 5 && flag == true)
                {
                    Console.WriteLine(calculator.multiplication());
                }
                else if (opt == 6 && flag == true)
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
                else if (opt == 7 && flag == true)
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
                else if(!flag)
                {
                    Console.WriteLine("Select option 1 first to create object");
                }
                Console.ReadKey();
            }
            while (opt!=0);
            Console.WriteLine("Thank You");
        }
    }
}
