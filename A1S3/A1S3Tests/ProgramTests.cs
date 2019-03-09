using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S3.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Q1_GetWordsTest()
        {
           string[] functionresult=Program.Q1_GetWords(@"..\..\..\Q1.txt");
            string[] expectedresult = { "happiness", "hope", "God", "smile","friend", "family", "good", "brave" };
            CollectionAssert.AreEqual(functionresult, expectedresult);


        }

        [TestMethod()]
        public void Q2_IsInWordsTest()
        {
            string[] array = { "happiness", "hope", "God", "smile", "friend", "family", "good", "brave" };
            bool expectedresultresult = true;
            string word = "brave";
            bool functionresult = Program.Q2_IsInWords(array, word);
            Assert.AreEqual(functionresult, expectedresultresult);


        }

        [TestMethod()]
        public void Q3_GetWordsOfTweetTest()
        {
            string tweet = "hello!How are you?@happy#sad" + '\n' + "she said:wow.";
            string[] functionresult = Program.Q3_GetWordsOfTweet(tweet);
            string[] expectedresult = { "hello", "How", "are", "you", "happy", "sad", "she", "said", "wow" };
            CollectionAssert.AreEqual(functionresult, expectedresult);
               
        }

        [TestMethod()]
        public void Q4_GetPopChargeOfTweetTest()
        {
            string[] pos = { "happiness", "hope", "God", "smile", "friend", "family", "good", "brave" };
            string[] neg = { "sad", "hopeless", "suicide", "bad", "depressed", "death", "kill" };
            string tweet = "Are you sad?and hopeless?Be brave";
            int expectedresult = -1;
            int functionresult = Program.Q4_GetPopChargeOfTweet(tweet, pos, neg);
            Assert.AreEqual(functionresult, expectedresult);

        }

        [TestMethod()]
        public void Q5_GetAvgPopChargeOfTweetsTest()
        {
            string tweet = "Are you sad?and hopeless?Be brave";
            string tweet1 = ":((bad,death,kill?";
            string tweet2 = "you are good!My friend.";
            string tweet3 = "family and friend are the best.give happiness to them.smile on them";
            string[] pos = { "happiness", "hope", "God", "smile", "friend", "family", "good", "brave" };
            string[] neg = { "sad", "hopeless", "suicide", "bad", "depressed", "death", "kill" };

            string[] tweets = { tweet, tweet1, tweet2 ,tweet3};
            double expectedresult =1;
            double functionresult = Program.Q5_GetAvgPopChargeOfTweets(tweets, neg, pos);
            Assert.AreEqual(functionresult, expectedresult);
        }
    }
}