using Microsoft.VisualStudio.TestTools.UnitTesting;
using E2;


namespace E2.Tests
{
    /// <summary>
    /// کلاس 
    /// MyString
    /// باید بگونه‌ای پیاده‌سازی شده و 
    /// اپراتورهای لازم برای آن
    /// overload
    /// شده یا متد‌های لازم
    /// override
    /// شوند که تست‌های این مجموعه پاس بشوند.
    /// </summary>
    [TestClass()]
    public class CustomStringOperatorTests
    {
        /// <summary>
        /// اپراتور تبدیل نوع داده‌ای از
        /// System.String
        /// به 
        /// MyString
        /// را پیاده‌سازی کرده
        /// و متدها و اپراتورهای لازم برای مقایسیه این دو نوع
        /// را به گونه‌ای پیاده سازی کنید که این تست پاس شود.
        /// </summary>
        [TestMethod()]
        public void StringExplicitOperatorTest()
        {
           


            MyString s1 = (MyString)"I love you";
            Assert.AreEqual(s1, "I love you");
            Assert.IsTrue(s1 == "I love you");

            MyString s2 = (MyString)"You love me";
            Assert.AreEqual(s2, "You love me");
            Assert.IsTrue(s2 == "You love me");


            Assert.AreNotEqual(s1, s2);

            Assert.IsFalse(s1 == s2);

        }

        /// <summary>
        /// اپراتور تبدیل نوع داده‌ای از
        /// MyString
        /// به 
        /// System.String
        /// را پیاده‌سازی کرده
        /// و متدها و اپراتورهای لازم برای مقایسیه این دو نوع
        /// را به گونه‌ای پیاده سازی کنید که این تست پاس شود.
        /// </summary>
        [TestMethod()]
        public void StringReverseExplicitOperatorTest()
        {
            //Assert.Inconclusive();
            

            MyString s1 = new MyString("I love you");
            string ss1 = (string)s1;
            Assert.AreEqual(ss1, "I love you");
            Assert.IsTrue(ss1 == "I love you");

            MyString s2 = new MyString("You love me");
            string ss2 = (string)s2;
            Assert.AreEqual(ss2, "You love me");
            Assert.IsTrue(ss2 == "You love me");


            Assert.AreNotEqual(ss1, ss2);
            Assert.IsFalse(ss1 == ss2);
            
        }

        /// <summary>
        /// اپراتور 
        /// ++
        /// را برای کلاس 
        /// MyString
        /// به گونه‌ای پیاده‌سازی کنید که رشته حرفی را به حروف بزرگ تبدیل کند.
        /// </summary>
        [TestMethod]
        public void StringPlusPlusOperatorTest()
        {
            
          

            MyString s = (MyString)"I love you";
            Assert.AreEqual(++s, "I LOVE YOU");
            
        }

        /// <summary>
        /// اپراتور 
        /// ++
        /// را برای کلاس 
        /// MyString
        /// به گونه‌ای پیاده‌سازی کنید که رشته حرفی را به حروف کوچک تبدیل کند.
        /// </summary>
        [TestMethod]
        public void StringMinusMinusOperatorTest()
        {
            //Assert.Inconclusive();
           

            MyString s = (MyString)"YOU LOVE ME";
            Assert.AreEqual(--s, "you love me");
            
        }

    }
}