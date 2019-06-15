using Microsoft.VisualStudio.TestTools.UnitTesting;
using E2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace E2.Tests
{
    /// <summary>
    /// هدف این بخش سنجش آشنایی ابتدایی با پردازش رشته‌ها، پارامتر‌های خروجی و مدیریت خطا می‌باشد. 
    /// </summary>
    [TestClass()]
    public class BasicsTests
    {
        /// <summary>
        /// متد 
        /// CalculateSum
        /// را بگونه‌ای پیاده‌سازی کنید که یک رشته شامل تعداد عدد و عملگر جمع را به عنوان پارامتر دریافت کرده و 
        /// مقدار معادل عددی را برگرداند.
        /// </summary>
        [TestMethod()]
        public void CalculateSumTest()
        {
			//Assert.Inconclusive();
            int result = Basics.CalculateSum("2+2");
            Assert.AreEqual(4, result);

            result = Basics.CalculateSum("2+4+4+3+4");
            Assert.AreEqual(17, result);

            result = Basics.CalculateSum("17+2+8+8+4+1+11");
            Assert.AreEqual(51, result);
        }

        /// <summary>
        /// در صورتیکه رشته ورودی یک عبارت ریاضی صحیح نباشد
        /// لازم است متد
        /// CalculateTest
        /// یک
        /// Exception
        /// از نوع
        /// InvalidDataException
        /// پرتاب کند.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void CalculateSumTestInvalid()
        {
			//Assert.Inconclusive();
            int result = Basics.CalculateSum("1+");
        }

        /// <summary>
        /// همچنین لازم است در صورتیکه زیررشته موجود در عبارت بین علامت‌های جمع از نوع
        /// عدد صحیح نباشد
        /// Exception
        /// متناظر آن رخ دهد.
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void CalculateSumTestFormatException()
        {
			//Assert.Inconclusive();
            int result = Basics.CalculateSum("a+b");
        }

        /// <summary>
        /// متد
        /// TryCalculate
        /// را به گونه‌ای پیاده‌سازی کنید که در صورت بروز خطا 
        /// false
        /// برگرداند و 
        /// در هیچ شرایطی 
        /// Exception
        /// رخ ندهد. در این متد مقدار عددی محاسبه شده بصورت یک 
        /// پارامتر از نوع 
        /// out
        /// بازگردانده می‌شود.
        /// </summary>
        [TestMethod()]
        public void TryCalculateSumTest()
        {
			//Assert.Inconclusive();
            int result;
            Assert.IsFalse(Basics.TryCalculateSum("a+b", out result));
            Assert.IsFalse(Basics.TryCalculateSum("1+", out result));

            Assert.IsTrue(Basics.TryCalculateSum("2+2+2+2+2+1", out result));
            Assert.AreEqual(11, result);

        }

        /// <summary>
        /// یکی از راه‌های محاسبه عدد پی استفاده از دنباله زیر است.
        /// {\displaystyle 1\,-\,{\frac {1}{3}}\,+\,{\frac {1}{5}}\,-\,{\frac {1}{7}}\,+\,{\frac {1}{9}}\,-\,\cdots \,=\,{\frac {\pi }{4}}.}
        /// سوال این است که برای محاسبه عدد پی تا هفت رقم معنادار این دنباله را تا عبارت چندم باید محاسبه کنیم.
        /// راهنمایی:
        /// Math.PI 
        /// عدد تا دقت بیش از ده رقم اعشار.
        /// Math.Round(x, 10): 
        /// عدد ورودی را به ده رقم معنادار رند می‌کند.
        /// حال متد
        /// PIPrecision
        /// را به گونه‌ای پیاده‌سازی کنید که پاسخ این سوال را پیدا کند.
        /// </summary>
        [TestMethod()]
        public void PIPrecisionTest()
        {
			//Assert.Inconclusive();
            int iterations = Basics.PIPrecision();
            Assert.AreEqual(10372345, iterations);
        }

        /// <summary>
        /// Extension
        /// متد به نام 
        /// Fibonacci
        /// را برای نوع داده‌ای
        /// int
        /// به گونه‌ای پیاده‌سازی کنید که عدد
        /// امn
        /// در دنباله بیبوناچی را برگرداند و این تست پاس شود.
        /// </summary>
        [TestMethod()]
        public void FibonacciTest()
        {
			//Assert.Inconclusive();
            Assert.AreEqual(8, 5.Fibonacci());
            Assert.AreEqual(13, 6.Fibonacci());
        }

        /// <summary>
        /// کلاس
        /// FullName
        /// متد 
        /// RemoveDuplicates
        /// پیاده‌سازی شده‌اند ولی این تست  پاس نمی‌شود.
        /// کلاس 
        /// FullName
        /// را بگونه‌ای تغییر دهید که تست زیر پاس شود.
        /// </summary>
        [TestMethod()]
        public void RemoveDuplicatesDebugTest()
        {
			//Assert.Inconclusive();
            FullName[] celbrities = new FullName[]{
                new FullName("مهناز", "افشار"),
                new FullName("سحر", "قریشی"),
                new FullName("بهنوش", "بختیاری"),
                new FullName("الناز", "شاکردوست"),
                new FullName("رامبد", "جوان"),
                new FullName("ترانه", "علیدوستی"),
                new FullName("بهنوش", "بختیاری"),
                new FullName("رامبد", "جوان"),
                new FullName("الناز", "شاکردوست"),
                new FullName("ترانه", "علیدوستی"),
                new FullName("سحر", "قریشی"),
                new FullName("ترانه", "علیدوستی"),
                new FullName("لیلا", "حاتمی"),
            };

            FullName[] uniqueCelbrities = new FullName[]
            {
                new FullName("مهناز", "افشار"),
                new FullName("سحر", "قریشی"),
                new FullName("بهنوش", "بختیاری"),
                new FullName("الناز", "شاکردوست"),
                new FullName("رامبد", "جوان"),
                new FullName("ترانه", "علیدوستی"),
                new FullName("لیلا", "حاتمی"),
            };

            Basics.RemoveDuplicates(ref celbrities);

            CollectionAssert.AreEqual(uniqueCelbrities, celbrities);
        }
    }
}