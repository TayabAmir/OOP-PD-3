using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori
{
    internal class Shiritori
    {
        public List<string> shiritori = new List<string>();
        public string word;
        public void addWord()
        {
            shiritori.Add(word);
        }
        public bool gameOver() {

            int n = shiritori.Count - 1;
            if (n == 0)
                return false;
            int n1 = shiritori[n-1].Length-1;
            return shiritori[n][0] != shiritori[n - 1][n1];
        }
        public bool checkWord()
        {
            for(int i=0;i<shiritori.Count-1;i++)
            {
                if (shiritori[i]==word) return true;
            }
            return false;
        }
        public string restartGame()
        {
            shiritori.Clear();
            return "Game Restarted";
        }   

    }
}
