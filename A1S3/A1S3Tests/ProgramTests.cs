using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A1S3.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Q1_GetWordsTest()
        {
            var functionresult = Program.Q1_GetWords(@"..\..\..\Q1.txt");
            string[] expectedresult = {"happiness", "hope", "God", "smile", "friend", "family", "good", "brave"};
            CollectionAssert.AreEqual(functionresult, expectedresult);
        }

        [TestMethod]
        public void Q2_IsInWordsTest()
        {
            string[] array = {"happiness", "hope", "God", "smile", "friend", "family", "good", "brave"};
            var expectedresultresult = true;
            var word = "brave";
            var functionresult = Program.Q2_IsInWords(array, word);
            Assert.AreEqual(functionresult, expectedresultresult);
        }

        [TestMethod]
        public void Q3_GetWordsOfTweetTest()
        {
            var tweet = "hello!How are you?@happy#sad" + '\n' + "she said:wow.";
            var functionresult = Program.Q3_GetWordsOfTweet(tweet);
            string[] expectedresult = {"hello", "How", "are", "you", "happy", "sad", "she", "said", "wow"};
            CollectionAssert.AreEqual(functionresult, expectedresult);
        }

        [TestMethod]
        public void Q4_GetPopChargeOfTweetTest()
        {
            string[] pos = {"happiness", "hope", "God", "smile", "friend", "family", "good", "brave"};
            string[] neg = {"sad", "hopeless", "suicide", "bad", "depressed", "death", "kill"};
            var tweet = "Are you sad?and hopeless?Be brave";
            var expectedresult = -1;
            var functionresult = Program.Q4_GetPopChargeOfTweet(tweet, pos, neg);
            Assert.AreEqual(functionresult, expectedresult);
        }

        [TestMethod]
        public void Q5_GetAvgPopChargeOfTweetsTest()
        {
            var tweet = "Are you sad?and hopeless?Be brave";
            var tweet1 = ":((bad,death,kill?";
            var tweet2 = "you are good!My friend.";
            var tweet3 = "family and friend are the best.give happiness to them.smile on them";
            string[] pos = {"happiness", "hope", "God", "smile", "friend", "family", "good", "brave"};
            string[] neg = {"sad", "hopeless", "suicide", "bad", "depressed", "death", "kill"};

            string[] tweets = {tweet, tweet1, tweet2, tweet3};
            double expectedresult = 1;
            var functionresult = Program.Q5_GetAvgPopChargeOfTweets(tweets, neg, pos);
            Assert.AreEqual(functionresult, expectedresult);
        }
    }
}