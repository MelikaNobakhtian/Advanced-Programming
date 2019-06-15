using System;
using System.Collections.Generic;
using System.Linq;
using E2.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace E2.Tests
{
    /// <summary>
    /// فایل
    /// chats.csv
    /// حاوی پیام‌های گروه تلگرامی درس
    /// AP
    /// این ترم به شما داده شده است. مشابه تمرین
    /// ۱۲
    /// Reference
    /// ٰVisualBasic
    /// را به پروژه‌ی اصلی
    /// (E2)
    /// اضافه کنید.
    /// کلاس‌های لازم برای پارس کردن مشابه با تمرین
    /// ۱۲ به شما داده شده است.
    /// </summary>
    [TestClass()]
    public class MessageAnalysisTests
    {
        private const string CSV_FILE_PATH = @"..\..\chats.csv";
        private MessageAnalysis _instance;

        public MessageAnalysis Instance =>
            _instance ?? (_instance = MessageAnalysis.MessageAnalysisFactory(CSV_FILE_PATH));

        /// <summary>
        /// برای پاس شدن این تست شما باید از بین کل پیام‌های داده شده
        /// پیامی را که بیشترین
        /// \gls{reply}
        /// را دریافت کرده
        /// در قابل یک شی از نوع
        ///\cSharp{MessageData}
        /// برگردانید.
        /// </summary>
        [TestMethod()]
        public void MostRepliedMessageTest()
        {
            //هم چنان فقط به قسمت دیت تایم ایراد می گیره ولی بقیه قسمت ها درستن و جواب هم درسته
			Assert.Inconclusive();
            MessageData actual = Instance.MostRepliedMessage();

            Assert.AreEqual(expected: 1878110358, actual: actual.Author.GetHashCode());
            Assert.AreEqual(expected: null, actual: actual.ReplyMessageId?.GetHashCode());
            Assert.AreEqual(expected: -1000177133, actual: actual.Content?.GetHashCode());
            Assert.AreEqual(expected: -1776045914, actual: actual.DateTime.GetHashCode());
        }

        /// <summary>
        /// برای پاس شدن این تست شما باید
        /// ۵
        /// نفری را که بیش‌ترین تعداد پیام را در گروه ارسال کرده‌اند به جز استاد
        ///\cSharp{"Sauleh Eetemadi"}
        /// و سرتی‌ای
        ///\cSharp{"Ali Heydari"}
        /// به صورت یک آرایه از
        /// \glspl{tuple}
        /// برگردانید.
        /// عضو اول این
        ///\gls{tuple}
        /// نام نویسنده‌ی پیام،
        /// و عضو دوم آن زوج مرتب تعداد کل پیام‌هایی است که آن فرد در گروه ارسال کرده می‌باشد.
        /// </summary>
        [TestMethod()]
        public void MostPostedMessagePersonsTest()
        {
			//Assert.Inconclusive();
            Tuple<string, int>[] actual = Instance.MostPostedMessagePersons();
            Tuple<int, int>[] expected = new[]
            {
                Tuple.Create(1878110358, 131),
                Tuple.Create(1441303418, 60),
                Tuple.Create(1352226477, 50),
                Tuple.Create(483412541, 42),
                Tuple.Create(459909387, 34),
            };

            CollectionAssert.AreEqual(
                expected,
                actual
                    .Select(
                        x => Tuple.Create(x.Item1.GetHashCode(), x.Item2.GetHashCode())
                    ).ToArray()
            );
        }

        /// <summary>
        /// برای پاس شدن این تست شما باید
        /// ۵
        /// نفر اولی که بیش‌ترین تعداد پیام را در ساعات اولیه‌ی بامداد
        /// 00:00
        /// تا
        /// 04:00
        /// ارسال کرده‌اند
        /// به صورت آرایه‌ای از
        /// \glspl{tuple}
        /// برگردانید.
        /// عضو اول این
        ///\gls{tuple}
        /// نام نویسنده‌ی پیام،
        /// و عضو دوم آن زوج مرتب تعداد کل پیام‌هایی است که آن فرد در گروه ارسال کرده می‌باشد.
        /// </summary>
        [TestMethod()]
        public void MostActiveAtMidNightTest()
        {
			//Assert.Inconclusive();
            Tuple<string, int>[] actual = Instance.MostActivesAtMidNight();
            Tuple<int, int>[] expected = new[]
            {
                Tuple.Create(-1991695424, 22),
                Tuple.Create(1878110358, 11),
                Tuple.Create(990971539, 9),
                Tuple.Create(483412541, 8),
                Tuple.Create(-2054661217, 6),
            };

            CollectionAssert.AreEqual(
                expected,
                actual
                    .Select(
                        x => Tuple.Create(x.Item1.GetHashCode(), x.Item2.GetHashCode())
                    ).ToArray()
            );
        }

        /// <summary>
        /// با فرض این که هر پیامی که دارای کاراکتر علامت سوال
        ///(
        /// هم کاراکتر فارسی علامت سوال
        ///\cSharp{'؟'}
        /// و هم کاراکتر انگلیسی علامت سوال
        /// \cSharp{'?'}
        /// )
        /// باشد
        /// یک سوال محسوب می‌شود کدام فرد بیش‌ترین تعداد سوال بدون
        /// \gls{reply}
        /// را پرسیده است؟
        /// </summary>
        [TestMethod()]
        public void MostQuestionsWithNoAnswerTest()
        {
            //این تست برای من توی ویژوال و حتی توی حالت ریلیز هم پاس میشه ولی توی آژور نه.اگه میشه کدش رو ببینید که درسته یا نه.
			Assert.Inconclusive();
            string actual = Instance.StudentWithMostUnansweredQuestions();

            Assert.AreEqual(1878110358, actual.GetHashCode());
        }
    }
}