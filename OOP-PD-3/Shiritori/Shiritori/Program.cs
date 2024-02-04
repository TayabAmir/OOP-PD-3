using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shiritori shiritori = new Shiritori();
            int opt;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Play Game");
                Console.WriteLine("2. Restart Game");
                Console.WriteLine("3. ExiT");
                Console.Write("Choose a option...");
                opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    while (true)
                    {
                        Console.Write("Enter the word: ");
                        shiritori.word = Console.ReadLine();
                        shiritori.addWord();
                        if(shiritori.gameOver() || shiritori.checkWord())
                        {
                            Console.WriteLine("Game Over");
                            break;
                        }
                    }
                }
                else if(opt==2)
                {
                    Console.Clear();
                    Console.WriteLine(shiritori.restartGame());
                }
                Console.ReadKey();
            } while (opt != 3);

            Console.WriteLine("Thanks for playing");
        }
    }
}