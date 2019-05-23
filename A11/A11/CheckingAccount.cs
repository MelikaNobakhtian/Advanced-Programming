using System;

namespace A11
{
    public class CheckingAccount : Account
    {
        public double transactionFee { get; set; }

        public CheckingAccount(int balance, int transactionFee) : base(balance)
        {
            this.transactionFee = transactionFee;
        }

        public override void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentException("Credit amount must be positive");
            this.Balance += (amount - transactionFee);
        }

        public override bool Debit(double amount)
        {
            if (amount <= this.Balance)
            {
                this.Balance -= (amount + transactionFee);
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