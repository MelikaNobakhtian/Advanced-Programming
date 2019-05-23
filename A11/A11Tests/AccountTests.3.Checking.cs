using System;
using System.IO;
using A11;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A11Tests {
    public partial class AccountTests
    {
        /// <summary>
        /// کلاس CheckingAccount از کلاس Account ارث بری میکند.
        /// این کلاس یک عصو double به نام TransactionFee دارد که نشانگر مقدار کارمزد به ازای هر تراکنش است و مقدار آن را در constructor خود دریافت میکند.
        /// </summary>
        [TestMethod]
        public void TestCheckingAccountConstructor()
        {
            var account = new CheckingAccount(balance: 1000, transactionFee: 3);
            Assert.IsNotNull(value: account);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1000) < Tolerance);

            using (var sw = new StringWriter())
            {
                Console.SetOut(newOut: sw);

                account = new CheckingAccount(balance: -100, transactionFee: 3);
                Assert.IsNotNull(value: account);
                Assert.IsTrue(condition: Math.Abs(value: account.Balance - 0) < Tolerance);
                Assert.AreEqual(expected: $"Initial balance is invalid. Setting balance to 0.{Environment.NewLine}",
                    actual: sw.ToString());
            }
        }

        /// <summary>
        /// باید متد Credit را به گونه ای تغییر دهید که مقدار کارمزد به ازای هر واریز کسر شود.
        /// </summary>
        [TestMethod]
        public void TestCheckingAccountCredit()
        {
            var account = new CheckingAccount(balance: 1000, transactionFee: 3);
            account.Credit(amount: 100);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1097) < Tolerance);
        }

        /// <summary>
        /// اگر تراکنش موفق نبود نباید کارمزدی کم شود
        /// </summary>
        [TestMethod]
        [ExpectedException(exceptionType: typeof(ArgumentException),
            noExceptionMessage: "Credit amount must be positive")]
        public void TestCheckingAccountCreditNegativeAmount()
        {
            var account = new CheckingAccount(balance: 1000, transactionFee: 3);
            account.Credit(amount: -100);
        }

        /// <summary>
        /// متد Debit را به گونه ای تغییر دهید که مقدار کارمزد به ازای هر برداشت کسر شود.
        /// اگر تراکنش موفق نبود نباید کارمزدی کم شود
        /// </summary>
        [TestMethod]
        public void TestCheckingAccountDebit()
        {
            var account = new CheckingAccount(balance: 1000, transactionFee: 3);
            var success = account.Debit(amount: 100);
            Assert.IsTrue(condition: success);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 897) < Tolerance);

            using (var sw = new StringWriter())
            {
                Console.SetOut(newOut: sw);

                account = new CheckingAccount(balance: 1000, transactionFee: 3);
                success = account.Debit(amount: 1100);
                Assert.IsFalse(condition: success);
                Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1000) < Tolerance);
                Assert.AreEqual(expected: $"Debit amount exceeded account balance.{Environment.NewLine}",
                    actual: sw.ToString());
            }
        }
    }
    }