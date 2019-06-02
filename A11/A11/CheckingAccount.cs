using System;

namespace A11
{
    public class CheckingAccount : Account
    {
        public double TransactionFee { get; set; }

        public CheckingAccount(int balance, int transactionFee) : base(balance)
        {
            this.TransactionFee = transactionFee;
        }

        public override void Credit(double amount) => base.Credit(amount - TransactionFee);

        public override bool Debit(double amount) => base.Debit(amount + TransactionFee);

    }
}