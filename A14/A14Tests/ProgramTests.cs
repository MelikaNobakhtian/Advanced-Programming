using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace A14.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        /// <summary>
        /// بعد از درست کردن پروژه‌ها و اضافه کردن فایل‌ها این تست بدون هیچ تغییری از طرف شما، پاس می‌شود.
        /// متن این تست و بخصوص متد
        /// RunTest
        /// را با دقت مطالعه کرده و خط به خط اجرا/دیباگ کنید و از تسلط بر نحوه انجام تست اطمینان حاصل کنید. 
        /// به طور خلاص هدف این تست این است که بعد از باز کردن ماشین‌حساب هر چند بار دکمه صفر فشار داده شود
        /// صفحه نمایش عدد صفر را نشان داده و تغییری نمی‌کند.
        /// </summary>
        [TestMethod()]
        public void ZeroTest() => RunTest<StartState>(keys: "000000q", expectedDisplay: "0");

        /// <summary>
        /// برای پیدا کردن شهود نسبت به هدف این تست برنامه 
        /// calc.exe
        /// و یا یک ماشین‌حساب دستی باز کنید. هر چند بار عدد صفر را بزنید، آیا تغییری در صفحه نمایش مشاهده می‌کنید؟
        /// حال، ابتدا دکمه یک را زده و بعد دکمه صفر را به دفعات فشار دهید.
        /// آیا متوجه تفاوت رفتار می‌شوید؟
        /// برای پاس شدن این تست لازم است از دیباگر استفاده کرده و تغییرات لازم را در کد ایجاد کرده تا تست پاس بشود. 
        /// </summary>
        [TestMethod()]
        public void AccumulationTest() => RunTest<AccumulateState>(keys: "10000000q", expectedDisplay: "10000000");

        /// <summary>
        /// هدف این تست مانند بخش قبل است. با این تفاوت که وقتی ماشین‌حساب اجرا می‌شود، هر عددی غیر از صفر باید 
        /// رفتاری متفاوت از عدد صفر داشته باشد. ولی همانطور که در تست قبل مشاهده کردید، این رفتار متفاوت فقط
        /// در ابتدا است. بعد از اینکه عددی غیر از صفر وارد شد، دیگر عدد صفر با دیگر اعداد تفاوتی نمی‌کند.
        /// </summary>
        [TestMethod()]
        public void AccumulateStateTest() => RunTest<AccumulateState>(keys: "123430q", expectedDisplay: "123430");

        /// <summary>
        /// هدف این تست،‌آزمون وارد کردن درست اعداد اعشاری در ماشین حساب می‌باشد. 
        /// </summary>
        [TestMethod()]
        public void PointStateTest() => RunTest<PointState>(keys: ".5q", expectedDisplay: "0.5");

        /// <summary>
        /// برای پاس شدن این تست لازم است از دیباگر استفاده کرده و تست را دیباگ کنید. این تست زمانی پاس می‌شود که 
        /// توی ماشین‌حساب هر چند بار دکمه نقطه فشار داده شود، فقط یک صفر و یک نقطه روی
        /// صفحه نمایش نشان داده شود. برای نمونه و مقایسه می‌توانید از یک ماشین‌حساب دستی یا برنامه
        /// calc.exe
        /// استفاده کنید.
        /// </summary>
        [TestMethod()]
        public void PointsOnlyStateTest() => RunTest<PointState>(keys: ".......q", expectedDisplay: "0.");


        /// <summary>
        /// مجددا برای فهمیدن هدف این تست از یک ماشین‌حساب استفاده کنید. آیا بعد از اینکه مثلا عدد
        ///   یک و یک دهم را وارد کردید فشار دادن دکمه نقطه تغییری در ماشین‌حساب ایجاد می‌کند؟
        ///   این نشان‌دهنده این است که بعد از وارد کردن نقطه، ماشین‌حساب به حالتی وارد می‌شود که وارد کردن نقاط
        ///   بعدی صفحه نمایش را تغییر نمی‌دهد.
        ///   مجددا با کمک گرفتن از دیباگر تغییرات لازم در برنامه را انجام دهید.
        /// </summary>
        [TestMethod()]
        public void ExtraPointTest() => RunTest<PointState>(keys: "55.234.2q", expectedDisplay: "55.2342");

        /// <summary>
        /// حال که اعداد به درستی به ماشین‌حساب وارد می‌شوند، لازم است که بتواینم محاسبات بین اعداد را انجام دهیم.
        /// برای گام اول،این تست زمانی پاس می‌شود که اگر دکمه بعلاوه فشار داده شد، ماشین‌حساب به حالت
        /// ComputeState
        /// تغییر حالت دهد.
        /// </summary>
        [TestMethod()]
        public void StartStateTest() => RunTest<ComputeState>(keys: "12+q", expectedDisplay: "12");

        /// <summary>
        /// بعد از این مقدمات، لازم است که ماشین حساب یک حساب ساده را بتواند انجام دهد. به این معنی که بعد از 
        /// فشار دادن دکمه مساوی، نتیجه محاسبه نمایش داده شود.
        /// </summary>
        [TestMethod()]
        public void SumTest() => RunTest<ComputeState>(keys: "10+10=q", expectedDisplay: "20");

        /// <summary>
        /// چنانچه بعد از نمایش نتیجه یک محاسبه، دکمه مساوی مجددا فشار داده شود، لازم است حالت ماشین‌حساب به
        /// ErrorState
        /// تغییر پیدا کند و صفحه نمایش تغییری نکند.
        /// </summary>
        [TestMethod()]
        public void ErrorStateTest() => RunTest<ErrorState>(keys: "12+5==q", expectedDisplay: "17");


        /// <summary>
        /// حال که عملگر جمع به درستی پیاده‌سازی شد، نوبت عملگر ضرب می‌باشد. تغییرات لازم برای پاس شدن این تست را اعمال کنید.
        /// </summary>
        [TestMethod()]
        public void MultiplyTest() => RunTest<ComputeState>(keys: "10*10=q", expectedDisplay: "100");

        /// <summary>
        /// چنانچه تست‌های قبل به درستی پیاده‌سازی شده باشند، این تست نیز بدون هیچ تغییری باید پاس بشود.
        /// </summary>
        [TestMethod()]
        public void MultipleSumTest() => RunTest<ComputeState>(keys: "10+10+10.3=q", expectedDisplay: "30.3");

        /// <summary>
        /// این تست درستی اجرای عملگر تقسیم را راست‌آزمایی می‌کند.
        /// </summary>
        [TestMethod()]
        public void DivideTest() => RunTest<ComputeState>(keys: "10/2=q", expectedDisplay: "5");

        /// <summary>
        /// چنانچه تست‌های قبل به درستی پیاده‌سازی شده باشند، این تست نیز بدون هیچ تغییری باید پاس بشود.
        /// </summary>
        [TestMethod()]
        public void StartingPointTest() => RunTest<ComputeState>(keys: ".5*2=q", expectedDisplay: "1");

        /// <summary>
        /// حال که چهار عمل اصلی را برای ماشین‌حساب پیاده ‌سازی کردید،‌ نوبت پیاده‌سازی یک عملگر جدید می‌باشد.
        /// تغییرات لازم را برای پاس شدن تست توان اعمال کنید.
        /// </summary>
        [TestMethod()]
        public void PowerTest() => RunTest<ComputeState>(keys: "2^10=q", expectedDisplay: "1024");


        private void RunTest<ExpectedState>(string keys, string expectedDisplay)
        {
            int i = 0;
            Calculator c = Program.RunCalculator(() => keys[i++], () => { });
            Assert.AreEqual(c.Display, expectedDisplay);
            Assert.IsTrue(c.State is ExpectedState);
        }

    }
}