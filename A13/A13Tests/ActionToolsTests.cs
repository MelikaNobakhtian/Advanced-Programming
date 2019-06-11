using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventDelegateThread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using A13;

namespace EventDelegateThread.Tests
{
    /// <summary>
    /// هدف این بخش از تمرین‌ها آشنایی بیشتر شما با کلاس
    /// System.Threading.Tasks.Task
    /// و پیاده‌سازی متد‌های 
    /// async
    /// و استفاده از کلمه کلیدی
    /// await
    /// می‌باشد. علاوه بر این فهم مساله 
    /// Race Condition
    /// و چگونگی حل آن با استفاده از
    /// lock.
    /// برای این قسمت از تمرین لازم است کلاس استاتیک 
    /// ActionTools
    /// را تعریف کرده و متد‌های متناظر با تست‌ها را پیاده‌سازی کنید.
    /// </summary>
    [TestClass()]
    public class ActionToolsTests
    {
        private const int TestTimingTolerance = 500;

        /// <summary>
        /// در کلاس 
        /// ActionTools
        /// متد 
        /// CallSequential
        /// را به گونه‌ای پیاده‌سازی کنید که تعدادی 
        /// Delegate
        /// از نوع 
        /// params Action[]
        /// به عنوان پارامتر دریافت کند و این 
        /// Delegateها
        /// را یکی پس از دیگری صدا بزن و پس از اتمام همگی، پایان بپذیرد.
        /// لازم است مقدار برگشتی این متد، مدت زمان اجرای آن به میلی‌ثانیه باشد. برای محاسبه زمان اجرای متد می‌توانید از کلاس
        /// Stopwatch
        /// استفاده کنید.
        /// </summary>
        [TestMethod()]
        public void CallSequentialTest()
        {
            bool? t1Called = false; int d1 = 1000;
            bool? t2Called = false; int d2 = 2000;
            bool? t3Called = false; int d3 = 1000;

            Stopwatch sw = Stopwatch.StartNew();
            long duration = ActionTools.CallSequential(
                () => { Task.Delay(d1).Wait(); t1Called = true; },
                () => { Task.Delay(d2).Wait(); t2Called = true; },
                () => { Task.Delay(d3).Wait(); t3Called = true; }
                );

            var elapsed = sw.ElapsedMilliseconds;

            Assert.IsTrue(t1Called.Value);
            Assert.IsTrue(t2Called.Value);
            Assert.IsTrue(t3Called.Value);

            Assert.IsTrue(elapsed - (d1 + d2 + d3) < TestTimingTolerance);
            Assert.IsTrue(Math.Abs(duration - elapsed) < TestTimingTolerance);

        }

        /// <summary>
        /// در کلاس 
        /// ActionTools
        /// متد 
        /// CallParallel
        /// را به گونه‌ای پیاده‌سازی کنید که تعدادی 
        /// Delegate
        /// از نوع 
        /// params Action[]
        /// به عنوان پارامتر دریافت کند و این 
        /// Delegateها
        /// را به صورت همزمان با استفاده از کلاس
        /// Task
        /// صدا زده و پس از اتمام همگی، پایان بپذیرد.
        /// لازم است مقدار برگشتی این متد، مدت زمان اجرای آن به میلی‌ثانیه باشد. برای محاسبه زمان اجرای متد می‌توانید از کلاس
        /// Stopwatch
        /// استفاده کنید.
        /// </summary>
        [TestMethod()]
        public void CallParallelTest()
        {
            bool? t1Called = false; int d1 = 1000;
            bool? t2Called = false; int d2 = 2000;
            bool? t3Called = false; int d3 = 1000;

            Stopwatch sw = Stopwatch.StartNew();
            long duration = ActionTools.CallParallel(
                () => { Task.Delay(d1).Wait(); t1Called = true; },
                () => { Task.Delay(d2).Wait(); t2Called = true; },
                () => { Task.Delay(d3).Wait(); t3Called = true; }
                );

            var elapsed = sw.ElapsedMilliseconds;

            Assert.IsTrue(t1Called.Value);
            Assert.IsTrue(t2Called.Value);
            Assert.IsTrue(t3Called.Value);

            Assert.IsTrue(elapsed - Math.Max(d3, Math.Max(d1, d2)) < TestTimingTolerance);
            Assert.IsTrue(Math.Abs(duration - elapsed) < TestTimingTolerance);
        }

        /// <summary>
        /// در کلاس 
        /// ActionTools
        /// متد 
        /// CallParallelThreadSafe
        /// را به گونه‌ای پیاده‌سازی کنید که تعدادی 
        /// Delegate
        /// از نوع 
        /// params Action[]
        /// و یک عدد تکرار
        /// به عنوان پارامتر دریافت کند و این 
        /// Delegateها
        /// را به صورت همزمان و به تعداد تکرار با استفاده از کلاس
        /// Task
        /// صدا ده و پس از اتمام همگی پایان بپذیرد. 
        /// در این پیاده‌سازی با استفاده از
        /// lock
        /// لازم است اطمینان حاصل کنید که با شروع همه
        /// Delegate
        /// ها بصورت همزمان و اجرا به تعداد تکرار مشخص شده، ولی هیچکدام از
        /// Delegate
        /// ها بصورت همزمان اجرا نشوند.
        /// مثلا 
        /// delegate
        /// اول برای بار سوم اجرا شود بعد 
        /// delegate
        /// دوم برای بار پنجم
        /// و به همین ترتیب. ولی هر دو 
        /// delegate
        /// در آن واحد در حال اجرا نباشند.
        /// لازم است مقدار برگشتی این متد، مدت زمان اجرای آن به میلی‌ثانیه باشد. برای محاسبه زمان اجرای متد می‌توانید از کلاس
        /// Stopwatch
        /// استفاده کنید.
        /// </summary>
        [TestMethod()]
        public void CallParallelThreadSafeTest()
        {
            int? sum = 0;
            Stopwatch sw = Stopwatch.StartNew();
            long duration = ActionTools.CallParallelThreadSafe(100,
                () => { sum+=2; Task.Delay(10).Wait(); },
                () => { sum-=1; Task.Delay(10).Wait(); }
                );

            var elapsed = sw.ElapsedMilliseconds;
            Assert.AreEqual(100, sum);
            Assert.IsTrue(Math.Abs(duration - elapsed) < TestTimingTolerance);
        }


        /// <summary>
        /// در کلاس 
        /// ActionTools
        /// متد 
        /// CallSequentialAsync
        /// را شبیه متد
        /// CallSequential
        /// پیاده‌سازی کنید، با این تفاوت که لازم است این متد بصورت 
        /// async
        /// پیاده‌سازی شود که بلافاصله مقداری از نوع
        /// Task long
        /// برگرداند و اتمام پذیرد.
        /// در پیاده‌سازی این متد لازم است از کلمه کلیدی 
        /// await
        /// استفاده کنید.
        /// لازم است مقدار برگشتی این متد، مدت زمان اجرای آن به میلی‌ثانیه باشد. برای محاسبه زمان اجرای متد می‌توانید از کلاس
        /// Stopwatch
        /// استفاده کنید.
        /// برای جزئیات بیشتر متد تست را مطالعه کنید.
        /// </summary>
        [TestMethod()]
        public void CallSequentialAsyncTest()
        {
            bool? t1Called = false; int d1 = 1000;
            bool? t2Called = false; int d2 = 2000;
            bool? t3Called = false; int d3 = 1000;

            Stopwatch sw = Stopwatch.StartNew();
            var result = ActionTools.CallSequentialAsync(
                () => { Task.Delay(d1).Wait(); t1Called = true; },
                () => { Task.Delay(d2).Wait(); t2Called = true; },
                () => { Task.Delay(d3).Wait(); t3Called = true; }
                );
            Assert.IsTrue(sw.ElapsedMilliseconds < TestTimingTolerance);
            Thread.Sleep(d1 + d2 + d3 + TestTimingTolerance);

            Assert.IsTrue(result.IsCompleted);
            Assert.IsTrue(t1Called.Value);
            Assert.IsTrue(t2Called.Value);
            Assert.IsTrue(t3Called.Value);

            var elapsed = sw.ElapsedMilliseconds;
            Assert.IsTrue(Math.Abs(result.Result - elapsed) < 2*TestTimingTolerance);
        }

        /// <summary>
        /// در کلاس 
        /// ActionTools
        /// متد 
        /// CallParallelAsync
        /// را شبیه متد
        /// CallParallel
        /// پیاده‌سازی کنید، با این تفاوت که لازم است این متد بصورت 
        /// async
        /// پیاده‌سازی شود که بلافاصله مقداری از نوع
        /// Task long
        /// برگرداند و اتمام پذیرد.
        /// در پیاده‌سازی این متد لازم است از کلمه کلیدی 
        /// await
        /// استفاده کنید.
        /// لازم است مقدار برگشتی این متد، مدت زمان اجرای آن به میلی‌ثانیه باشد. برای محاسبه زمان اجرای متد می‌توانید از کلاس
        /// Stopwatch
        /// استفاده کنید.
        /// برای جزئیات بیشتر متد تست را مطالعه کنید.
        /// </summary>
        [TestMethod()]
        public void CallParallelAsyncTest()
        {
            bool? t1Called = false; int d1 = 1000;
            bool? t2Called = false; int d2 = 2000;
            bool? t3Called = false; int d3 = 1000;

            Stopwatch sw = Stopwatch.StartNew();
            var result = ActionTools.CallParallelAsync(
                () => { Task.Delay(d1).Wait(); t1Called = true; },
                () => { Task.Delay(d2).Wait(); t2Called = true; },
                () => { Task.Delay(d3).Wait(); t3Called = true; }
                );
            Assert.IsTrue(sw.ElapsedMilliseconds < TestTimingTolerance);

            Thread.Sleep(Math.Max(d3, Math.Max(d1, d2)) + TestTimingTolerance);

            Assert.IsTrue(result.IsCompleted);
            Assert.IsTrue(t1Called.Value);
            Assert.IsTrue(t2Called.Value);
            Assert.IsTrue(t3Called.Value);
            Assert.IsTrue(Math.Abs(result.Result - sw.ElapsedMilliseconds) < 2 * TestTimingTolerance);
        }


        /// <summary>
        /// در کلاس 
        /// ActionTools
        /// متد 
        /// CallParallelThreadSafeAsync
        /// را شبیه متد
        /// CallParallelThreadSafe
        /// پیاده‌سازی کنید، با این تفاوت که لازم است این متد بصورت 
        /// async
        /// پیاده‌سازی شود که بلافاصله مقداری از نوع
        /// Task long
        /// برگرداند و اتمام پذیرد.
        /// در پیاده‌سازی این متد لازم است از کلمه کلیدی 
        /// await
        /// استفاده کنید.
        /// لازم است مقدار برگشتی این متد، مدت زمان اجرای آن به میلی‌ثانیه باشد. برای محاسبه زمان اجرای متد می‌توانید از کلاس
        /// Stopwatch
        /// استفاده کنید.
        /// برای جزئیات بیشتر متد تست را مطالعه کنید.
        /// </summary>
        [TestMethod()]
        public void CallParallelThreadSafeAsyncTest()
        {
            int? sum = 0;
            Stopwatch sw = Stopwatch.StartNew();
            var result = ActionTools.CallParallelThreadSafeAsync(100,
                () => { sum += 2; Task.Delay(10).Wait(); },
                () => { sum -= 1; Task.Delay(10).Wait(); }
                );
            Assert.IsTrue(sw.ElapsedMilliseconds < TestTimingTolerance);

            result.Wait();
            var elapsed = sw.ElapsedMilliseconds;
            Assert.IsTrue(Math.Abs(result.Result - elapsed) < TestTimingTolerance);
            Assert.AreEqual(100, sum);
        }

    }
}