using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using A11;

namespace A11Tests
{
    [TestClass]
    public partial class AccountTests
    {
        private const double Tolerance = 0.0001;

        /// <summary>
        /// یک کلاس پایه به نام Account درست کنید که شامل یک عضو دابل به نام Balance باشد که نماینده ی میزان پول موجود در یک حساب است.
        /// این کلاس باید یک constructor داشته باشد که یک مقدار اولیه برای موجودی حساب میگیرد و
        /// با استفاده از آن عضو داده مربطه را مقداردهی میکند. constructor باید چک کند که
        /// مقدار اولیه برای موجودی حساب بزرگتر یا مساوی صفر است و اگر نبود مقدار اولیه موجودی برابر صفر باشد و یک پیغام خطای مناسب (طبق تست) چاپ کند.
        /// </summary>
        [TestMethod]
        public void TestAccountConstructor()
        {
            var account = new Account(balance: 1000);
            Assert.IsNotNull(value: account);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1000) < Tolerance);

            using (var sw = new StringWriter()) {
                Console.SetOut(newOut: sw);

                account = new Account(balance: -100);
                Assert.IsNotNull(value: account);
                Assert.IsTrue(condition: Math.Abs(value: account.Balance - 0) < Tolerance);
                Assert.AreEqual(expected: $"Initial balance is invalid. Setting balance to 0.{Environment.NewLine}",
                    actual: sw.ToString());
            }
        }

        /// <summary>
        /// کلاس Account باید یک متد Credit داشته باشد.
        /// متد Credit باید مقداری را به موجودی اضافه کند.
        /// </summary>
        [TestMethod]
        public void TestAccountCredit()
        {
            var account = new Account(balance: 1000);
            account.Credit(amount: 100);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1100) < Tolerance);
        }

        /// <summary>
        /// اگر مقدار واریزی منفی بود باید پیغام خطای مناسب (طبق تست) چاپ کند و مقدار موجودی را دست نخورده نگه دارد.
        /// </summary>
        [TestMethod]
        [ExpectedException(exceptionType: typeof(ArgumentException),
            noExceptionMessage: "Credit amount must be positive")]
        public void TestAccountCreditNegativeAmount()
        {
            var account = new Account(balance: 1000);
            account.Credit(amount: -100);
        }

        /// <summary>
        /// کلاس Account باید یک متد به نام Debit داشته باشد.
        /// متد Debit باید مقداری را از حساب برداشت کند و همچنین اطمینان حاصل کند که مقدار برداشتی بیشتر از موجودی نشود.
        /// اگر شد باید موجودی دست نخورده باقی بماند و پیغام خطای مناسب (طبق تست) چاپ شود.
        /// </summary>
        [TestMethod]
        public void TestAccountDebit()
        {
            var account = new Account(balance: 1000);
            var success = account.Debit(amount: 100);
            Assert.IsTrue(condition: success);
            Assert.IsTrue(condition: Math.Abs(value: account.Balance - 900) < Tolerance);

            using (var sw = new StringWriter())
            {
                Console.SetOut(newOut: sw);

                account = new Account(balance: 1000);
                success = account.Debit(amount: 1100);
                Assert.IsFalse(condition: success);
                Assert.IsTrue(condition: Math.Abs(value: account.Balance - 1000) < Tolerance);
                Assert.AreEqual(expected: $"Debit amount exceeded account balance.{Environment.NewLine}",
                    actual: sw.ToString());
            }
        }
    }
}