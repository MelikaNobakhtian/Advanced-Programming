using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using A13;

namespace EventDelegateThread.Tests
{
    /// <summary>
    /// پیاده سازی کلاس
    /// DirectoryWatcher
    /// مشابه کلاس
    /// SingleFileWatcher
    /// می باشد. با این تفاوت که علاوه بر پایش پوشه بجای فایل
    /// منتظر دو نوع تغییر ایجاد و حذف فایل در پوشه بوده و بعد 
    /// از اطلاع از این تغییر آن را به 
    /// Delegate
    /// هایی که برای آن تغییر 
    /// Register
    /// کرده باشند اطلاع می دهیم. برای پیاده سازی
    /// این کلاس لازم است از 
    /// eventهای 
    /// Created
    /// و 
    /// Deleted
    /// در کلاس 
    /// System.IO.FileSystemWatcher
    /// استفاده کنید.
    /// </summary>
    [TestClass()]
    public class DirectoryWatcherTests
    {
        /// <summary>
        /// برای پاس شدن این تست لازم است که علاوه بر سازنده کلاس
        /// DirectoryWatcher
        /// متد 
        /// Register
        /// بگونه‌ای پیاده‌سازی شود که در صورت ایجاد یک فایل در پوشه
        /// پاس شده به سازنده، 
        /// Deletgate
        /// پاس شده به 
        /// Register
        /// برای نوع تغییر ایجاد فایل صدا زده شود.
        /// برای جزئیات بیشتر تست را مطالعه کنید.
        /// </summary>
        [TestMethod()]
        public void RegisterAddFileTest()
        {
            Random rnd = new Random();
            string dir = Path.Combine(Directory.GetCurrentDirectory(), rnd.Next().ToString());
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var files2Create = Enumerable.Range(1, 5)
                .Select(n => rnd.Next(10000,99999))
                .Select(n => Path.Combine(dir, $"{n}.txt")).ToList();

            List<string> createdFiles = new List<string>();

            files2Create.ForEach(f => { if (File.Exists(f)) File.Delete(f); });
            using (var watcher = new DirectoryWatcher(dir))
            {
                Action<string> notifyMe = (f) => createdFiles.Add(f);
                watcher.Register(notifyMe, ObserverType.Create);

                files2Create.ForEach(f => File.WriteAllText(Path.Combine(dir, f), ";)"));
                Thread.Sleep(500);
                CollectionAssert.AreEqual(files2Create, createdFiles);
            }

            files2Create.ForEach(f => { if (File.Exists(f)) File.Delete(f); });

            Directory.Delete(dir,true);
        }

        /// <summary>
        /// برای پاس شدن این تست لازم است علاوه بر صدا زدن 
        /// Delegate
        /// مربوطه هنگام ایجاد فایل، در صورت حذف فایلی از 
        /// پوشه پاس شده به سازنده،
        /// Delegate
        /// مربوطه را صدا بزنید.
        /// برای جزئیات بیشتر تست را مطالعه کنید.
        /// </summary>
        [TestMethod()]
        public void RegisterDeleteFileTest()
        {
            Random rnd = new Random();
            string dir = Path.Combine(Directory.GetCurrentDirectory(), rnd.Next().ToString());
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var files2Create = Enumerable.Range(1, 5)
                .Select(n => rnd.Next(10000, 99999))
                .Select(n => Path.Combine(dir, $"{n}.txt")).ToList();

            files2Create.ForEach(f => File.WriteAllText(Path.Combine(dir, f), ";)"));

            List<string> deletedFiles = new List<string>();

            using (var watcher = new DirectoryWatcher(dir))
            {
                Action<string> notifyMe = (f) => deletedFiles.Add(f);
                watcher.Register(notifyMe, ObserverType.Delete);
                files2Create.ForEach(f => { if (File.Exists(f)) File.Delete(f); });

                Thread.Sleep(500);
                CollectionAssert.AreEqual(files2Create, deletedFiles);
            }

            Directory.Delete(dir, true);
        }

        /// <summary>
        /// درصورت پیاده‌سازی صحیح متد
        /// UnRegister
        /// این تست پاس خواهد شد.
        /// برای جزئیات بیشتر تست را مطالعه کنید.
        /// </summary>
        [TestMethod()]
        public void UnRegisterTest()
        {
            Random rnd = new Random();
            string dir = Path.Combine(Directory.GetCurrentDirectory(), rnd.Next().ToString());
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var files2Create = Enumerable.Range(1, 5)
                .Select(n => rnd.Next(10000, 99999))
                .Select(n => Path.Combine(dir, $"{n}.txt")).ToList();

            files2Create.ForEach(f => File.WriteAllText(Path.Combine(dir, f), ";)"));

            List<string> deletedFiles = new List<string>();

            using (var watcher = new DirectoryWatcher(dir))
            {
                Action<string> notifyMe = (f) => deletedFiles.Add(f);
                watcher.Register(notifyMe, ObserverType.Delete);
                files2Create.Take(3).ToList().ForEach(f => { if (File.Exists(f)) File.Delete(f); });
                Thread.Sleep(500);
                watcher.Unregister(notifyMe, ObserverType.Delete);
                files2Create.Skip(3).ToList().ForEach(f => { if (File.Exists(f)) File.Delete(f); });
                Thread.Sleep(500);
                CollectionAssert.AreEqual(files2Create.Take(3).ToArray(), deletedFiles);
            }

            Directory.Delete(dir, true);
        }
    }
}