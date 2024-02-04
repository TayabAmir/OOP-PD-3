using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Enemy
    {
        public int x;
        public int y;
        public char symbol;

        public Enemy(int initialX, int initialY, char enemySymbol)
        {
            x = initialX;
            y = initialY;
            symbol = enemySymbol;
        }

        public void printEnemy()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        public void eraseEnemy()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

    }
}
