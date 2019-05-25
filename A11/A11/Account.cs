using System;

namespace A11
{
    public class Account
    {
        public double Balance { get; set; }

        public Account(double balance)
        {
            if (balance >= 0)
                Balance = balance;
            else
            {
                balance = 0;
                Console.WriteLine($"Initial balance is invalid. Setting balance to 0.");
            }
        }

        public virtual void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Credit amount must be positive");
            this.Balance += amount;
        }

        public virtual bool Debit(double amount)
        {
            if (amount <= this.Balance)
            {
                this.Balance -= amount;
                return true;
            }

            else
            {
                Console.WriteLine("Debit amount exceeded account balance.");
                return false;
            }


        }
    }
}