using System;
using System.IO;

namespace A1S3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = @"c:\git\AP97982\A1S3\A1S3\result.txt";
            File.Create(path).Close();
            var filepath = @"c:\git\AP97982\A1S3\A1S3\TwitterData\Tweets\";
            var negpath = @"c:\git\AP97982\A1S3\A1S3\TwitterData\Words\negative.txt";
            var pospath = @"c:\git\AP97982\A1S3\A1S3\TwitterData\Words\positive.txt";
            var posword = Q1_GetWords(pospath);
            var negword = Q1_GetWords(negpath);
            var listfile = Directory.GetFiles(filepath);
            double reactionrate = 0;


            foreach (var dir in listfile)
            {
                var name = Path.GetFileName(dir);
                var lines = Q1_GetWords(dir);
                reactionrate = Q5_GetAvgPopChargeOfTweets(lines, negword, posword);
                File.AppendAllText(path, name + ":" + reactionrate + '\n');
            }
        }

        public static string[] Q1_GetWords(string path)
        {
            return File.ReadAllLines(path);
        }

        public static bool Q2_IsInWords(string[] words, string word)
        {
            foreach (var w in words)
                if (w == word)
                    return true;
            return false;
        }

        public static string[] Q3_GetWordsOfTweet(string tweet)
        {
            var words = tweet.Split(
                new[] { '?', '!', '@', '#', '"', '.', '\'', ' ', '،', '_', '؟', '\n', ':', ')', '(', '.', ',' },
                StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        public static int Q4_GetPopChargeOfTweet(string tweet, string[] posWords, string[] negWords)
        {
            var tweetwords = Q3_GetWordsOfTweet(tweet);
            var point = 0;
            foreach (var word in posWords)
                if (Q2_IsInWords(tweetwords, word))
                    point++;
            foreach (var words in negWords)
                if (Q2_IsInWords(tweetwords, words))
                    point--;

            return point;
        }

        public static double Q5_GetAvgPopChargeOfTweets(string[] tweets, string[] negWords, string[] posWords)
        {
            double charge = 0;
            for (var i = 1; i < tweets.Length; i++)
                charge += Q4_GetPopChargeOfTweet(tweets[i], posWords, negWords);
            double g = tweets.Length - 1;
            var mid = charge / (tweets.Length - 1);

            return mid;
        }
    }
}