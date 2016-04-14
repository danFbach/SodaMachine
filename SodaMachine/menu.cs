using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public class Menu
    {
        Machine machine = new Machine();
        public Menu()
        {

        }
        public void selectSoda()
        {
            double price = 0;
            string soda = "";
            int selection;
            Console.WriteLine("What kind of soda would you like? \n\r1) Orange $0.60 \n\r2) Grape $0.35 \n\r3) Meat-flavored $0.06");
            bool check = int.TryParse(Console.ReadLine(), out selection);
            if (!check) { Console.WriteLine("Invalid Entry."); selectSoda(); }

            switch (selection)
            {
                case (1):
                    price = .60;
                    soda = "orange";
                    insertChange(price, soda);
                    selectSoda();
                    break;
                case (2):
                    price = .35;
                    soda = "grape";
                    insertChange(price, soda);
                    selectSoda();
                    break;
                case (3):
                    price = .06;
                    soda = "meat";
                    insertChange(price, soda);
                    selectSoda();
                    break;
                default:
                    selectSoda();
                    break;
            }

        }
        public void insertChange(double sodaPrice, string soda)
        {
            double balance = 0;
            int changeType = machine.acceptChange();
            int changeQty = machine.changeQty();
            machine.updateBalance(changeType, changeQty);
            balance = machine.getBalance(balance);
            Console.WriteLine("Do you want to insert more change? (Y/N)? \n\rYour current balance is {0}.", balance.ToString("C2"));
            string moreChange = Console.ReadLine();
            if (moreChange.Equals("y")) { insertChange(sodaPrice, soda); }
            else if (moreChange.Equals("n"))
            {
                machine.sellSoda(balance, sodaPrice, soda);
                Console.Clear();
            }
            else { Console.WriteLine("Invalid Entry"); insertChange(sodaPrice, soda); }
        }
        
    }
}
