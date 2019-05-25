using System;
using System.IO;
using A11;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A11Tests {
    public partial class AccountTests
    {
        /// <summary>
        /// کلاس SavingsAccount از کلاس Account ارث بری میکند.
        /// این کلاس یک عضو double دارد که نماینده ی نرخ سود است که در constructor خود آن را گرفته و مقداردهی میکند.
        /// </summary>
        [TestMethod]
        public void TestSavingsAccountConstructor()
        {
            var account = new SavingsAccount(balance: 1000, interestRate: 3);
            Assert.IsNotNull(value: account);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1000) < Tolerance);

            using (var sw = new StringWriter())
            {
                Console.SetOut(newOut: sw);

                account = new SavingsAccount(balance: -100, interestRate: 3);
                Assert.IsNotNull(value: account);
                Assert.IsTrue(condition: Math.Abs(value: account.Balance - 0) < Tolerance);
                Assert.AreEqual(expected: $"Initial balance is invalid. Setting balance to 0.{Environment.NewLine}",
                    actual: sw.ToString());
            }
        }

        /// <summary>
        /// ارث برده شده و بدون تغییر باقی میماند
        /// </summary>
        [TestMethod]
        public void TestSavingsAccountCredit()
        {
            var account = new SavingsAccount(balance: 1000, interestRate: 3);
            account.Credit(amount: 100);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1100) < Tolerance);
        }

        /// <summary>
        /// ارث برده شده و بدون تغییر باقی میماند
        /// </summary>
        [TestMethod]
        [ExpectedException(exceptionType: typeof(ArgumentException),
            noExceptionMessage: "Credit amount must be positive")]
        public void TestSavingsAccountCreditNegativeAmount()
        {
            var account = new SavingsAccount(balance: 1000, interestRate: 3);
            account.Credit(amount: -100);
        }

        /// <summary>
        /// ارث برده شده و بدون تغییر باقی میماند
        /// </summary>
        [TestMethod]
        public void TestSavingsAccountDebit()
        {
            var account = new SavingsAccount(balance: 1000, interestRate: 3);
            var success = account.Debit(amount: 100);
            Assert.IsTrue(condition: success);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 900) < Tolerance);

            using (var sw = new StringWriter())
            {
                Console.SetOut(newOut: sw);

                account = new SavingsAccount(balance: 1000, interestRate: 3);
                success = account.Debit(amount: 1100);
                Assert.IsFalse(condition: success);
                Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1000) < Tolerance);
                Assert.AreEqual(expected: $"Debit amount exceeded account balance.{Environment.NewLine}",
                    actual: sw.ToString());
            }
        }

        /// <summary>
        /// کلاس SavingsAccount یک متد public به نام CalculateInterest دارد که مقدار سود را طبق موجودی حساب و نرخ سود آن حساب میکند
        /// </summary>
        [TestMethod]
        public void TestSavingsAccountCalculateInterest()
        {
            var account = new SavingsAccount(balance: 1000, interestRate: 0.03);
            var interest = account.CalculateInterest();
            Assert.IsTrue(condition: Math.Abs(value: interest - 30) < Tolerance);
        }
    }
    }