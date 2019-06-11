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
    /// تا اینجا با استفاده از یک 
    /// event
    /// که توسط کلاس
    /// FileSystemWatcher
    /// پیاده‌سازی شده بود آشنا شدید. حال نوبت آن است که شما یک 
    /// event
    /// پیاده‌سازی کنید. برای این کار یک واسط به نام
    /// ISingleReminder
    /// در نظر گرفته‌ایم که شما آن را به سه روش پیاده‌سازی می‌کنید.
    /// ابتدا با استفاده از یک 
    /// Thread
    /// ساده.
    /// سپس با استفاده از
    /// ThreadPool
    /// و نهایتا با استفاده از
    /// Task.
    /// همه پیاده‌سازی‌ها یک کار را انجام می‌دهند ولی به روش‌های متفاوت.
    /// هدف نهایی این است که سازنده هر کدام از این کلاس‌های یک پیام و مدت زمان در سازنده دریافت کنند.
    /// سپس با ارائه یک 
    /// event
    /// به نام 
    /// Reminder
    /// امکان 
    /// Register
    /// کردن را فراهم کنند.
    /// بعد از صدا زدن متد 
    /// Start
    /// تمام کسانی که با 
    /// event
    /// این کلاس
    /// Register
    /// کرده‌اند،‌ بعد از زمان مشخص شده، پیام معین را دریافت می‌کنند.
    /// </summary>
    [TestClass()]
    public class SingleReminderTests
    {
        /// <summary>
        /// برای پاس شدن این تست لازم است که کلاس
        /// SingleReminderThread
        /// را طبق توضیح بالا پیاده‌سازی کنید.
        /// در این قسمت لازم است هنگام پیاده سازی از کلاس
        /// System.Threading.Thread
        /// استفاده کنید. در صورت عدم استفاده مناسب از این کلاس
        /// نمره این تمرین صفر لحاظ خواهد شد.
        /// </summary>
        [TestMethod()]
        public void SingleReminderThreadTest()
        {
            string msg = $"Call Me {new Random().Next(10, 99)}";
            int delay = 1000;
            ISingleReminder r = new SingleReminderThread(msg, delay);
            TestISingleReimder(msg, delay, r);
        }

        /// <summary>
        /// برای پاس شدن این تست لازم است که کلاس
        /// SingleReminderThreadPool
        /// را طبق توضیح بالا پیاده‌سازی کنید.
        /// در این قسمت لازم است هنگام پیاده سازی از کلاس
        /// System.Threading.ThreadPool
        /// استفاده کنید. در صورت عدم استفاده مناسب از این کلاس
        /// نمره این تمرین صفر لحاظ خواهد شد.
        /// </summary>
        [TestMethod()]
        public void SingleReminderThreadPoolTest()
        {
            string msg = $"Call Me {new Random().Next(10, 99)}";
            int delay = 1000;
            ISingleReminder r = new SingleReminderThreadPool(msg, delay);
            TestISingleReimder(msg, delay, r);
        }

        /// <summary>
        /// برای پاس شدن این تست لازم است که کلاس
        /// SingleReminderTask
        /// را طبق توضیح بالا پیاده‌سازی کنید.
        /// در این قسمت لازم است هنگام پیاده سازی از کلاس
        /// System.Threading.Tasks.Task
        /// استفاده کنید. در صورت عدم استفاده مناسب از این کلاس
        /// نمره این تمرین صفر لحاظ خواهد شد.
        /// </summary>
        [TestMethod()]
        public void SingleReminderTaskTest()
        {
            string msg = $"Call Me {new Random().Next(10, 99)}";
            int delay = 1000;
            ISingleReminder r = new SingleReminderTask(msg, delay);
            TestISingleReimder(msg, delay, r);
        }

        private static void TestISingleReimder(string msg, int delay, ISingleReminder r)
        {
            bool? callback = false;
            r.Reminder += m =>
            {
                Assert.AreEqual(msg, m);
                callback = true;
            };

            Stopwatch s = Stopwatch.StartNew();
            r.Start();
            Thread.Sleep(delay + 100);
            Assert.IsTrue(callback.Value);
        }
    }
}