using System;

namespace A11
{
    public class CheckingAccount : Account
    {
        public double TransActionFee { get; set; }

        public CheckingAccount(int balance, int transactionFee) : base(balance)
        {
            this.TransActionFee = transactionFee;
        }

        public override void Credit(double amount) => base.Credit(amount - TransActionFee);

        public override bool Debit(double amount) => base.Debit(amount + TransActionFee);

    }
}