using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Inventory
    {
        Dictionary<string, int> sodaInvetory;
        Dictionary<string, Soda> typesOfSodaInMachine;

        public Inventory()
        {
            sodaInvetory = new Dictionary<string, int>();
            typesOfSodaInMachine = new Dictionary<string, Soda>();
        }

        public void AddSodas(Soda typeOfSoda,int numberOfSoda)
        {
            typesOfSodaInMachine.Add(typeOfSoda.Flavor, typeOfSoda);
            sodaInvetory.Add(typeOfSoda.Flavor, numberOfSoda);
        }

        public List<string> SodasInMachine
        {
            get{
                List<string> sodaTypes = new List<string>();
                foreach (var soda in typesOfSodaInMachine)
                {
                    sodaTypes.Add(soda.Key);
                }
                return sodaTypes;
            }
            
        }

        public int GetNumberOfSodaInStock(string sodaWanted)
        {
            return sodaInvetory[sodaWanted];
        }

        public double GetSodaCost(string sodaWanted)
        {
            return typesOfSodaInMachine[sodaWanted].Price;
        }

        internal void RemoveSoda(string sodaToDispense)
        {
            sodaInvetory[sodaToDispense] -= 1;
        }
    }
}
