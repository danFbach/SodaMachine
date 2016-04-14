using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.selectSoda();
        }
    }
}
//Using proper code design, write a SodaMachine class that accepts coins as payment, returns coins from its limited register as change, and dispenses soda cans from its limited inventory.
//Make a class for each coin(penny, nickel, dime, quarter) that sets its value in its constructor.Allow payment via passing a List of coins into a public function on the SodaMachine class.
//If not enough money is passed in, don't complete transaction: give the money back
//If exact change is passed in, accept payment and dispense a soda from the limited inventory.
//If too much money is passed in, accept the payment, return change as a list of coins from internal, limited register, and return a soda instance from internal, limited inventory.
//If too much money is passed in but there isn't sufficient change in the machine's internal register, don't complete transaction: give the money back
//If exact or too much money is passed in but there isn't sufficient inventory for that soda, don't complete the transaction: give the money back

//The machine should start with:
//Coins: 20 quarters, 10 dimes, 20 nickels, 50 pennies
//Cans: Grape-flavored(60¢ per), Orange-flavored(35¢ per), Meat-flavored(6¢ per)