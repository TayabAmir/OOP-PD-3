using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Player
    {
        public int x;
        public int y;
        public char symbol;

        public Player(int initialX, int initialY, char playerSymbol)
        {
            x = initialX;
            y = initialY;
            symbol = playerSymbol;
        }
        public void movePlayerLeft()
        {
            if (x > 2)
            {
                x = x - 1;
            }
        }
        public void movePlayerRight()
        {
            if (x < 107)
            {
                x = x + 1;
            }
        }
        public void movePlayerUp()
        {
            if (y > 9)
            {
               y = y - 1;
            }
        }
        public void movePlayerDown()
        {
            if (y < 35)
            {
                y = y + 1;
            }
        }
    }
}
