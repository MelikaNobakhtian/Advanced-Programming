using Microsoft.VisualStudio.TestTools.UnitTesting;
using E2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace E2.Tests
{
    /// <summary>
    /// تست‌های این بخش مربوط به 
    /// IEnumerable/foreach/yield
    /// و
    /// Event
    /// و
    /// Thread
    /// هستند
    /// </summary>
    [TestClass()]
    public class ThreadsAndEvents
    {
        /// <summary>
        /// لازم است متد
        /// GetElapsedTimes
        /// به گونه‌ای پیاده‌سازی شود که فاصله دسترسی به مقداری این مجموعه را برگرداند.
        /// به این شکل که مقدار اولی که بر میگرداند همیشه صفر است و مقادیر بعدی
        /// برابر با تعداد میلی ثانیه‌ای است که از زمان دسترسی به مقدار قبلی گذشته است.
        /// پارامتر ورودی این متد حداکثر طول این رشته است.
        /// در این متد می‌توانید از کلاس
        /// Stopwatch
        /// برای اندازه‌گیری زمان استفاده کنید.
        /// برای شیوه استفاده از آن به  
        /// MSDN
        /// یا تست‌های پیاده‌سازی شده از که این کلاس استفاده می‌کنند مراجعه کنید.
        /// </summary>
        [TestMethod()]
        public void GetElapsedTimesTest()
        {
			//Assert.Inconclusive();
            Assert.IsTrue(DotNetInterfaces.GetElapsedTimes(5).ToList().All(l => l < 100));

            TestElapsedTimes(10, 1000, 300);
            TestElapsedTimes(5, 2000, 500);
            TestElapsedTimes(20, 500, 250);
        }

        private static void TestElapsedTimes(int count, int delay, int tolerance)
        {
			//Assert.Inconclusive();
            var result = DotNetInterfaces.GetElapsedTimes(count);
            int idx = 0;
            foreach (var elapsed in result)
            {
                Assert.IsTrue(ApproxEqual(elapsed, idx++ == 0 ? 0 : delay, tolerance));
                Task.Delay(delay).Wait();
            }

            Assert.AreEqual(count + 1, idx);
        }

        private static bool ApproxEqual(long l1, long l2, long tolerance)
        {
			//Assert.Inconclusive();
            return Math.Abs(l1 - l2) < tolerance;
        }

        /// <summary>
        /// کلاس
        /// DuplicateNumberDetector
        /// را به گونه‌ای پیاده‌سازی کنید که یک متد
        /// AddNumber
        /// داشته باشد که یک عدد صحیح به عنوان ورودی دریافت می کند.
        /// چنانچه این متد با یک عدد تکراری صدا زده شود لازم است 
        /// Event
        /// به نام
        /// DuplicateNumberAdded
        /// اتفاق بیافتد که به عنوان پارامتر
        /// تعداد کل دفعاتی که عدد تکراری اضافه شده را برگرداند.
        /// </summary>
        [TestMethod()]
        public void DuplicateNumberAddedTest()
        {
			//Assert.Inconclusive();
            DuplicateNumberDetector detector = new DuplicateNumberDetector();
            List<int> dups = new List<int>();
            detector.DuplicateNumberAdded += (n) => dups.Add(n);

            int dupCount = 0;
            detector.DuplicateNumberAdded += (n) => dupCount++;

            detector.AddNumber(5);
            detector.AddNumber(4);
            detector.AddNumber(3);
            detector.AddNumber(2);
            detector.AddNumber(4);
            detector.AddNumber(3);
            detector.AddNumber(3);

            Assert.AreEqual(3, dups.Count);
            Assert.AreEqual(3, dupCount);
        }

        /// <summary>
        /// متد 
        /// MakeItFasterTest
        /// را به گونه‌ای پیاده‌سازی کنید که تعدادی
        /// Action
        /// از ورودی دریافت کرده و آنها را همزمان اجرا کند.
        /// این متد تنها زمانی باید برگردد که تمام 
        /// delegate
        /// ها اجرا شده باشند.
        /// </summary>
        [TestMethod()]
        public void MakeItFasterTest()
        {
			//Assert.Inconclusive();
            int[] delays = new int[] { 5_000, 10_000, 1_000, 2_000, 4_000, 6_000 };
            bool[] run = Enumerable.Repeat(false, 6).ToArray();
            Stopwatch sw = Stopwatch.StartNew();
            Threading.MakeItFaster(
                    () => { Task.Delay(delays[0]).Wait(); run[0] = true; },
                    () => { Task.Delay(delays[1]).Wait(); run[1] = true; },
                    () => { Task.Delay(delays[2]).Wait(); run[2] = true; },
                    () => { Task.Delay(delays[3]).Wait(); run[3] = true; },
                    () => { Task.Delay(delays[4]).Wait(); run[4] = true; },
                    () => { Task.Delay(delays[5]).Wait(); run[5] = true; }
                );
            long elapsed = sw.ElapsedMilliseconds;

            Assert.IsTrue(run.All(b => b));
            Assert.IsTrue(Math.Abs(elapsed - 10_000) < 2000);
        }
    }
}