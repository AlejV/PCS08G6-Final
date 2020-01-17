using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_6_application
{
    public class Groceries
    {
        List<string> debtusers;
        private decimal amount;
        private static int idseeder = 0;
        private int orderId { get; }
        public string buyerName { get; private set; }

        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }
        public Groceries(decimal amount, string buyerName)
        {
            this.amount = amount;
            this.buyerName = buyerName;
            this.debtusers = new List<string>();
            this.orderId = idseeder;
            ++idseeder;
        }

        public int GetItemId()
        {
            return this.orderId;
        }

        public List<string> BoughtItems()
        {
            return debtusers;
        }


        public void addusers(string user)
        {
            debtusers.Add(user);
        }

        public void removeuser(string user)
        {
            for (int i = 0; i < debtusers.Count(); ++i)
            {
                if (user == debtusers[i].ToString())
                {
                    debtusers.Remove(debtusers[i]);
                }
            }
        }

        public List<string> userlist()
        {
            return debtusers;
        }

        public decimal Balance()
        {
            return this.amount;
        }

        public string Show()// for Housing displaying buyer,item,price
        {
            return orderId + "-" + buyerName + ": " + amount + "€";
        }
    }
}