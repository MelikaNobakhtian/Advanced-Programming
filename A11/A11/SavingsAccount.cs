using System;

namespace A11
{
    public class SavingsAccount : Account
    {
        public double interestRate { get; set; }

        public SavingsAccount(double balance, double interestRate) : base(balance)
        {
            this.interestRate = interestRate;
        }

        public double CalculateInterest() => (Balance * interestRate);

    }
}