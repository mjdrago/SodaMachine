using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    static class UserInterface
    {
        static public void DisplayUserOption(string word)
        {
            Console.WriteLine(word);
        }
        static public void DisplayUserOption(List<string> words)
        {
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
        static public string GetString()
        {
            return Console.ReadLine();
        }
    }
}
