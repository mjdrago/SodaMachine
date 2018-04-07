using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Bank
    {
        List<Coin> quarters;
        List<Coin> dimes;
        List<Coin> nickels;
        List<Coin> pennies;

        public Bank(int startQuarters,int startDimes,int startNickels, int startPennies)
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
                dimes.Add(new Dime());
            }
            for (int i = 0; i < startNickels; i++)
            {
                nickels.Add(new Nickel());
            }
            for (int i = 0; i < startPennies; i++)
            {
                pennies.Add(new Penny());
            }
        }

        public List<Coin> ReturnChange(double changeNeeded)
        {
            double changeRemaining = changeNeeded;
            List<Coin> change = new List<Coin>();
            while (quarters.Count > 0 && changeRemaining >= quarters[0].Value)
            {
                change.Add(new Quarter());
                changeRemaining -= quarters[0].Value;
                quarters.RemoveAt(0);
            }
            while (dimes.Count > 0 && changeRemaining >= dimes[0].Value)
            {
                change.Add(new Dime());
                changeRemaining -= dimes[0].Value;
                dimes.RemoveAt(0);
            }
            while (nickels.Count > 0 && changeRemaining >= nickels[0].Value)
            {
                change.Add(new Nickel());
                changeRemaining -= nickels[0].Value;
                nickels.RemoveAt(0);
            }
            while (pennies.Count > 0 && changeRemaining >= pennies[0].Value)
            {
                change.Add(new Penny());
                changeRemaining -= pennies[0].Value;
                pennies.RemoveAt(0);
            }
            if (CoinTotal(change) == changeNeeded)
            {
                return change;
            }
            else
            {
                DepositCoin(change);
                return new List<Coin>();
            }
        }

        public void DepositCoin(List<Coin> change)
        {
            foreach (Coin coin in change)
            {
                if (coin.Value == .25)
                {
                    quarters.Add(new Quarter());
                }
                else if (coin.Value == .10)
                {
                    dimes.Add(new Dime());
                }
                else if (coin.Value == .05)
                {
                    nickels.Add(new Nickel());
                }
                else if (coin.Value == .01)
                {
                    pennies.Add(new Penny());
                }
            }
        }

        public double CoinTotal(List<Coin> coinsInserted)
        {
            double coinTotal = 0;
            foreach (Coin coin in coinsInserted)
            {
                coinTotal += coin.Value;
            }
            return coinTotal;
        }
    }
}
