using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    abstract class Soda
    {
        string flavor;
        double price;

        public string Flavor
        {
            get
            {
                return flavor;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
        }
    }
}
