using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public class Menu
    {
        public decimal balance;
        Machine machine = new Machine();
        public Menu()
        {
        }
        public void selectSoda()
        {            
            decimal price = 0;
            string soda = "";
            int selection;
            Console.WriteLine("What kind of soda would you like? \n\r1) Orange $0.60 \n\r2) Grape $0.35 \n\r3) Meat-flavored $0.06");
            bool check = int.TryParse(Console.ReadLine(), out selection);
            if (!check) { Console.WriteLine("Invalid Entry."); selectSoda(); }
            switch (selection)
            {
                case (1):
                    price = 0.60m;
                    soda = "orange";
                    insertChange(price, soda);
                    selectSoda();
                    break;
                case (2):
                    price = 0.35m;
                    soda = "grape";
                    insertChange(price, soda);
                    selectSoda();
                    break;
                case (3):
                    price = 0.06m;
                    soda = "meat";
                    insertChange(price, soda);
                    selectSoda();
                    break;
                default:
                    selectSoda();
                    break;
            }
        }
        public decimal insertChange(decimal sodaPrice, string soda)
        {
            Console.WriteLine("Your current balance is {0}. \n\rDo you want to insert more change? (Y/N)?", balance.ToString("C2"));
            string moreChange = Console.ReadLine();
            if (moreChange.Equals("y"))
            {
                int changeType = machine.acceptChange();
                int changeQty = machine.changeQty();
                machine.updateBalance(changeType, changeQty);
                balance = machine.getBalance();
                return insertChange(sodaPrice, soda);
            }
            else if (moreChange.Equals("n"))
            {
                bool checkSoda = checkSodaStock(soda);
                if (checkSoda)
                {
                    decimal newBalance = machine.sellSoda(balance, sodaPrice, soda);
                    if (newBalance.Equals(balance)) { }
                    else{ return balance = finishCheck(newBalance); }
                }
                else { Console.WriteLine("I'm sorry that type of soda is unavailable, please select another."); return balance; }
            }
            else { Console.WriteLine("Invalid Entry"); insertChange(sodaPrice, soda); }
            return balance;
        }
        public bool checkSodaStock(string sodaType)
        {
            bool checkStock = true;
            Type sodaDatatype = typeof(Soda);
            if (sodaType.Equals("orange")) { sodaDatatype = typeof(Orange); }
            else if (sodaType.Equals("grape")) { sodaDatatype = typeof(Grape); }
            else if (sodaType.Equals("meat")) { sodaDatatype = typeof(Meat); }

            foreach (Soda soda in machine.inventory.soda)
            {
                if (soda.GetType() == sodaDatatype)
                {
                    checkStock = true;
                    break;
                }
                else { checkStock = false; }
            }            
            return checkStock;
        }
        public decimal finishCheck(decimal balance)
        {
            Console.WriteLine("Would you like to buy another drink? (Y/N)");
            string anotherDrink = Console.ReadLine();
            anotherDrink = anotherDrink.ToLower();
            if (anotherDrink.Equals("n"))
            {
                Console.WriteLine("Ok, your change of {0} has been dispensed. Press any button to proceed.",balance.ToString("C2"));
                machine.insertedBalance.Clear();
                Console.ReadKey();
                Console.Clear();
                return 0m;
            }
            else Console.WriteLine("Ok I will hold on to your remaining balance of {0} for your next purchase. Press any button to proceed.", balance.ToString("C2"));
            Console.ReadKey();
            Console.Clear();
            return balance;
        }
    }
}
