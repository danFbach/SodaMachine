using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    public class Machine
    {
        Inventory inventory = new Inventory();
        Register register = new Register();
        public List<Coins> insertedBalance = new List<Coins>();
        public Machine()
        {
            populateInventory();
            populateRegister();
        }
        public int acceptChange()
        {
            int changeType;
            Console.WriteLine("Identify the type of coin you would like to insert. \n\r1) Quarter \n\r2) Dime \n\r3) Nickel \n\r4) Penny");
            bool check = int.TryParse(Console.ReadLine(),out changeType);
            if (!check) { return acceptChange(); }
            return changeType;
        }
        public int changeQty()
        {
            int quantity;
            Console.WriteLine("How many would you like to insert?");
            bool check = int.TryParse(Console.ReadLine(), out quantity);
            if (!check) { return changeQty(); }
            return quantity;
        }
        public void updateBalance(int coinType, int coinQty)
        {
            Coins coin = new Coins();
            if (coinType.Equals(1)) { coin = new Quarter(); }
            else if (coinType.Equals(2)) { coin = new Dime(); }
            else if (coinType.Equals(3)) { coin = new Nickel(); }
            else if (coinType.Equals(4)) { coin = new Penny(); }
            for(int i = 0; i < coinQty; i++)
            {
                insertedBalance.Add(coin);
            }
        }
        public void populateRegister()
        {
            for (int penny = 0; penny < 50; penny++) { register.coins.Add(new Penny()); }
            for (int nickel = 0; nickel < 20; nickel++) { register.coins.Add(new Nickel()); }
            for (int dime = 0; dime < 10; dime++) { register.coins.Add(new Dime()); }
            for (int quarter = 0; quarter < 20; quarter++) { register.coins.Add(new Quarter()); }
        }
        public void populateInventory()
        {
            for (int sodaPop = 0; sodaPop < 5; sodaPop++)
            {
                inventory.soda.Add(new Grape());
                inventory.soda.Add(new Orange());
                inventory.soda.Add(new Meat());
            }
        }
        public double getBalance(double balance)
        {
            foreach (Coins coin in insertedBalance)
            {
                balance += coin.value;
            }
            return balance;
        }
        public double sellSoda(double balance, double sodaPrice, string soda)
        {
            if (balance < sodaPrice) { Console.WriteLine("You have not inserted enough change. I cannot complete the sale."); return balance; }
            else if (balance == sodaPrice) { Console.WriteLine("You have entered exact change. Here's your soda."); updateInventory(soda);return 0; }
            else if(balance > sodaPrice) { balance -= sodaPrice; Console.WriteLine("You have entered more change than is needed, your change is {0}.", balance); return balance; }
            return 0;
        }
        public void updateInventory(string soda)
        {
            
            foreach (Soda pop in inventory.soda)
            {
                if (soda.Equals("orange"))
                {
                    if (pop is Orange)
                    {                        
                        inventory.soda.Remove(pop);
                        break;                    
                    }

                }
                if (soda.Equals("grape"))
                {
                    if (pop is Grape)
                    {
                        inventory.soda.Remove(pop);
                        break;
                    }
                }
                if (soda.Equals("meat"))
                {
                    if (pop is Meat)
                    {
                        inventory.soda.Remove(pop);
                        break;
                    }
                }
            }
            register.coins.AddRange(insertedBalance);
            insertedBalance.Clear();
        }
    }
}
