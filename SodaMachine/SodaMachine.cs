using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        CoinStorage bank;
        public SodaMachine()
        {
            bank = new CoinStorage(20, 10, 20, 50);
        }
    }
}
