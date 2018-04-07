using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class CoinStorage
    {
        List<Coin> quarters;
        List<Coin> dimes;
        List<Coin> nickels;
        List<Coin> pennies;

        public CoinStorage(int startQuarters,int startDimes,int startNickels, int startPennies)
        {
            quarters = new List<Coin>();
            dimes = new List<Coin>();
            nickels = new List<Coin>();
            pennies = new List<Coin>();
            for (int i = 0; i < startQuarters; i++)
            {
                quarters.Add(new Quarter());
            }
            for (int i = 0; i < startDimes; i++)
            {
                quarters.Add(new Dime());
            }
            for (int i = 0; i < startNickels; i++)
            {
                quarters.Add(new Nickel());
            }
            for (int i = 0; i < startPennies; i++)
            {
                quarters.Add(new Penny());
            }
        }

    }
}
