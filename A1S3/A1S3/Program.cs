using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S3
{
    public class Program
    {
       public static void Main(string[] args)
        {
            /*string path = @"c:\git\AP97982\A1S3\A1S3\result.txt";
            File.Create(path).Close();
            string filepath = @"c:\git\AP97982\A1S3\A1S3\TwitterData\Tweets\";            string negpath = @"c:\git\AP97982\A1S3\A1S3\TwitterData\Words\negative.txt";            string pospath= @"c:\git\AP97982\A1S3\A1S3\TwitterData\Words\positive.txt";            string[] posword = Q1_GetWords(pospath);            string[] negword = Q1_GetWords(negpath);            string[] listfile = Directory.GetFiles(filepath);            double reactionrate = 0;
                        foreach (string dir in listfile)
            {

                
                string name = Path.GetFileName(dir);
                string[] lines = Q1_GetWords(dir);
                reactionrate = Q5_GetAvgPopChargeOfTweets(lines, negword, posword);
                File.AppendAllText(path, name +":"+reactionrate+ '\n');

            }*/
            string tweet = " ";
            string tweet1 = ":((bad,death,kill?";
            string tweet2 = "you are good!My friend.";
            string tweet3 = "family and friend are the best.give happiness to them.smile on them,be good";
            string[] pos = { "happiness", "hope", "God", "smile", "friend", "family", "good", "brave" };
            string[] neg = { "sad", "hopeless", "suicide", "bad", "depressed", "death", "kill" };            string[] tweets = { tweet, tweet1, tweet2, tweet3 };            double functionresult = Q5_GetAvgPopChargeOfTweets(tweets, neg, pos);
        }

        public static string[] Q1_GetWords(string path)
        {
            return File.ReadAllLines(path);
        }

        public static bool Q2_IsInWords(string[] words, string word)
        {
            foreach (string w in words)
                if (w==word)
                {
                    return true;
                }
            return false;
        }

         public static string[] Q3_GetWordsOfTweet(string tweet)
        {
            string[] words = tweet.Split(new Char[] { '?', '!', '@', '#', '"', '.', '\'', ' ', '،','_' ,'؟','\n',':',')','(','.',','},
                                 StringSplitOptions.RemoveEmptyEntries);

            return words;
        }

        public static int Q4_GetPopChargeOfTweet(string tweet ,string[] posWords, string[]negWords)
        {
            string[] tweetwords = Q3_GetWordsOfTweet(tweet);
            int point = 0;
            foreach (string word in posWords)
                if (Q2_IsInWords(tweetwords, word))
                    point++;
            foreach(string words in negWords)
                if (Q2_IsInWords(tweetwords, words))
                    point--;

            return point;
        }

        public static double Q5_GetAvgPopChargeOfTweets(string[] tweets, string[] negWords, string[] posWords)
        {

            double charge = 0;
            for (int i=1;i<tweets.Length;i++)
                charge += Q4_GetPopChargeOfTweet(tweets[i], posWords, negWords);
            double g = tweets.Length - 1;
            double mid = charge / (tweets.Length-1);

            return mid;

        }




        }



    }


