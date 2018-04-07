using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class SodaMachine
    {
        Bank bank;
        Inventory sodaInMachine;
        public SodaMachine()
        {
            bank = new Bank(20, 10, 20, 50);
            sodaInMachine = new Inventory();
            sodaInMachine.AddSodas(new GrapeSoda(), 15);
            sodaInMachine.AddSodas(new OrangeSoda(), 5);
            sodaInMachine.AddSodas(new LemonSoda(), 10);
        }
        public void Run()
        {
            List<Coin> coinsInserted = InsertChange();
            string sodaSelected = SelectSoda();
            bool isDispensed = DispenseSoda(sodaSelected,coinsInserted);
            RunAgain(isDispensed);
        }

        private void RunAgain(bool isDispensed)
        {
            if (isDispensed == false)
            {
                UserInterface.DisplayUserOption("Would you like to try buying a soda again? Please enter 'yes' or 'no'");
                string input = UserInterface.GetString();
                if (input.ToLower() == "yes" || input.ToLower() == "y")
                {
                    Run();
                }
                else if (input.ToLower() == "no" || input.ToLower() == "n")
                {
                }
                else
                {
                    UserInterface.DisplayUserOption("Not a valid option. Try again.");
                    RunAgain(isDispensed);
                }
            }
        }

        public List<Coin> InsertChange()
        {
            List<Coin> changeInserted = new List<Coin>();
            bool isDone = false;
            while (isDone == false)
            {
                Console.Clear();
                List<string> displayOption = new List<string>() { $"Please insert coins.","(To enter a coin please type the number or enter the coin type. Press 5 or Done when finished.)"
                            ,"1 - Quarter","2 - Dime","3 - Nickel","4 - Penny","5 - Done" };
                UserInterface.DisplayUserOption(displayOption);
                string input = UserInterface.GetString();
                if (input == "1"||input.ToLower() == "quarter")
                {
                    changeInserted.Add(new Quarter());
                }
                else if (input == "2" || input.ToLower() == "dime")
                {
                    changeInserted.Add(new Dime());
                }
                else if (input == "3" || input.ToLower() == "nickel")
                {
                    changeInserted.Add(new Nickel());
                }
                else if (input == "4" || input.ToLower() == "penny")
                {
                    changeInserted.Add(new Penny());
                }
                else if (input == "5"|| input.ToLower() == "done")
                {
                    isDone = true;
                }
                else
                {
                    UserInterface.DisplayUserOption("This was an invalid option. Please enter another coin.");
                }
            }

            return changeInserted;
        }

        private string SelectSoda()
        {
            List<string> typesOfSoda = sodaInMachine.SodasInMachine;
            List<string> display = new List<string>();
            int counter = 1;
            foreach (string sodaType in typesOfSoda)
            {
                display.Add($"{counter} - {sodaType}");
                counter++;
            }
            UserInterface.DisplayUserOption("What flavor of soda would you like?");
            UserInterface.DisplayUserOption(display);
            string input = UserInterface.GetString();
            string sodaSelected;
            try
            {
                if (typesOfSoda.Contains(input.ToLower()))
                {
                    sodaSelected = input;
                }
                else if (int.Parse(input) <= counter)
                {
                    sodaSelected = typesOfSoda[int.Parse(input) - 1];
                }
                else
                {
                    UserInterface.DisplayUserOption("Not a valid option. Please try again.");
                    sodaSelected = SelectSoda();
                }
                return sodaSelected;
            }
            catch
            {
                UserInterface.DisplayUserOption("Not a valid option. Please try again.");
                sodaSelected = SelectSoda();
                return sodaSelected;
            }
            
        }

        private bool DispenseSoda(string sodaSelected, List<Coin> coinsInserted)
        {
            int numberAvailable = sodaInMachine.GetNumberOfSodaInStock(sodaSelected);
            double coinsInsertedTotal = bank.CoinTotal(coinsInserted);
            double sodaCost = sodaInMachine.GetSodaCost(sodaSelected);
            if (coinsInsertedTotal < sodaCost)
            {
                ReturnCoins($"The soda costs {sodaCost}. Not enough change was inserted. Here are your coins back.",coinsInserted);
                return false;
            }
            else if (numberAvailable == 0)
            {
                ReturnCoins("Out of Stock. Here are your coins back", coinsInserted);
                return false;
            }
            else if (coinsInsertedTotal == sodaCost)
            {
                GiveSoda(sodaSelected);
                bank.DepositCoin(coinsInserted);
                return true;
            }
            else
            {
                List<Coin> change = bank.ReturnChange(coinsInsertedTotal - sodaCost);
                if (change.Count == 0)
                {
                    ReturnCoins("Not enough change. Here are your coins back.", coinsInserted);
                    return false;
                }
                else
                {
                    GiveSoda(sodaSelected);
                    ReturnCoins("Here is your change.",change);
                    return true;
                }
            }
        }

        private void GiveSoda(string sodaToDispense)
        {
            sodaInMachine.RemoveSoda(sodaToDispense);
            UserInterface.DisplayUserOption($"Here is your {sodaToDispense}!");
        }

        private void ReturnCoins(string message, List<Coin> coinsToReturn)
        {
            UserInterface.DisplayUserOption(message);
            foreach (Coin coin in coinsToReturn)
            {
                UserInterface.DisplayUserOption(coin.Name);
            }
        }
    }
}
