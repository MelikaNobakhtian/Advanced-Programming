using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventDelegateThread;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using A13;

namespace EventDelegateThread.Tests
{
    /// <summary>
    /// هدف این تمرین آشنایی با 
    /// Delegate
    /// و 
    /// Event
    /// و طرز استفاده از آنها می‌باشد. در این کلاس لازم است از
    /// event
    /// به نام 
    /// Changed
    /// در کلاس
    /// System.IO.FileSystemWatcher
    /// استفاده کنید. 
    /// </summary>
    [TestClass()]
    public class SingleFileWatcherTests
    {
        /// <summary>
        /// برای پاس شدن این تست لازم است که کلاس 
        /// SingleFileWatcher
        /// را به گونه‌ای پیاده سازی کنید که علاوه بر پیاده سازی واسط
        /// IDisposable
        /// سازنده و متد
        /// Register
        /// را به گونه‌ای پیاده سازی‌کنید که هنگام تغییر فایلی که به سازنده پاس می‌شود 
        /// Delegate
        /// داده‌شده به متد 
        /// Register
        /// صدا زده شود.
        /// علت پیاده‌سازی واسط
        /// Disposable
        /// در این کلاس عضویت شئی از نوع
        /// FileSystemWatcher
        /// است که خود این واسط را پیاده‌سازی می‌کند.
        /// لذا لازم است که استفاده کننده از این شئ بداند که وقتی کارش با این شئ تمام شد 
        /// باید متد 
        /// Dispose
        /// را صدا بزند.
        /// برای جزئیات بیشتر در رابطه با نیازمندی‌های پیاده‌سازی
        /// متد تست را مطالعه کنید.
        /// </summary>
        [TestMethod()]
        public void RegisterTest()
        {
            bool? bChanged = false;
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), "test1.txt");
            string fileName0 = Path.Combine(Directory.GetCurrentDirectory(), "test2.txt");
            using (var watcher = new SingleFileWatcher(fileName))
            {
                Assert.AreEqual(false, bChanged);

                Action notify = () => bChanged = true;

                File.WriteAllText(fileName, "کپ‌ها رو میگیره");
                watcher.Register(notify);
                File.WriteAllText(fileName, "کپ‌ها رو میگیرن");
                Thread.Sleep(10);
                Assert.AreEqual(true, bChanged);

                bChanged = false;
                File.WriteAllText(fileName0, "do not get notified");
                Thread.Sleep(10);
                Assert.AreEqual(false, bChanged);
            }

            File.Delete(fileName);
            File.Delete(fileName0);
        }

        /// <summary>
        /// برای پاس شدن این تست لازم است متد
        /// Unregister
        /// را بدرستی پیاده‌سازی کنید.
        /// بطوریکه بعد از صدا زدن این متد برای یک
        /// Delegate
        /// هنگام تغییر فایل دیگر صدا زده نشود.
        /// برای جزئیات بیشتر پیاده‌سازی متد تست را مطالعه کنید.
        /// </summary>
        [TestMethod()]
        public void UnregisterTest()
        {

            bool? bChanged = false;
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), "test3.txt");
            string fileName0 = Path.Combine(Directory.GetCurrentDirectory(), "test4.txt");
            using (var watcher = new SingleFileWatcher(fileName))
            {
                Assert.AreEqual(false, bChanged);

                Action notify = () => bChanged = true;

                File.WriteAllText(fileName, "کپ‌ها رو میگیره");
                watcher.Register(notify);
                watcher.Unregister(notify);
                File.WriteAllText(fileName, "کپ‌ها رو میگیرن");
                Thread.Sleep(10);
                Assert.AreEqual(false, bChanged);
            }
            File.Delete(fileName);
            File.Delete(fileName0);
        }

        /// <summary>
        /// پیاده‌سازی شما از سازنده و متد‌های
        /// Register
        /// و
        /// Unregister
        /// باید بگونه‌ای باشد که بیش از یک 
        /// Delegate
        /// بتوانند در آن واحد 
        /// Register
        /// شده و در صورت نیاز بعدا 
        /// Unregister
        /// شوند. مطالعه این تست و اطمینان از پاس شدن آن به درک مفهوم
        /// Multicast Delegate
        /// کمک می‌کند.
        /// </summary>
        [TestMethod()]
        public void MultiRegisterUnregister()
        {
            bool? bChange1 = false;
            bool? bChange2 = false;
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), "test3.txt");
            string fileName0 = Path.Combine(Directory.GetCurrentDirectory(), "test4.txt");
            using (var watcher = new SingleFileWatcher(fileName))
            {
                Assert.AreEqual(false, bChange1);
                Assert.AreEqual(false, bChange2);

                Action notify1 = () => bChange1 = true;
                Action notify2 = () => bChange2 = true;

                File.WriteAllText(fileName, "کپ‌ها رو میگیره");
                watcher.Register(notify1);
                watcher.Register(notify2);
                File.WriteAllText(fileName, "کپ‌ها رو میگیرن");
                Thread.Sleep(10);

                Assert.AreEqual(true, bChange1);
                Assert.AreEqual(true, bChange2);

                bChange1 = false;
                bChange2 = false;
                watcher.Unregister(notify1);

                File.WriteAllText(fileName, ":)))");
                Thread.Sleep(10);

               Assert.AreEqual(false, bChange1);
                Assert.AreEqual(true, bChange2);

            }
            File.Delete(fileName);
            File.Delete(fileName0);
        }

        /// <summary>
        /// این تست برای اطمینان از پیاده‌سازی واسط
        /// IDisposable 
        /// طراحی شده. در صورت پیاده‌سازی این واسط
        /// این تست کامپایل شده و پاس می‌شود.
        /// </summary>
        [TestMethod()]
        public void DisposeTest()
        {
            IDisposable sfw = new SingleFileWatcher(Directory.GetCurrentDirectory());
            sfw.Dispose();
        }
    }
}