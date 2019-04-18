using System.IO;

namespace A3
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public static int CaculateLength(string str)
        {
            return str.Length;
        }

        public static int LetterCount(string str)
        {
            var num = 0;
            foreach (var letter in str)
                if (char.IsLetter(letter))
                    num++;
            return num;
        }

        public static int LineCount(string str)
        {
            var lines = str.Split('\n');
            return lines.Length;
        }

        public static int FileLineCount(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            return lines.Length;
        }

        public static string[] ListFiles(string dirPath)
        {
            var files = Directory.GetFiles(dirPath);
            return files;
        }


        public static double FileSize(string filePath)
        {
            var charCount = 0;
            var lines = File.ReadAllLines(filePath);
            var num = FileLineCount(filePath);
            for (var i = 0; i < num; i++)
                charCount += lines[i].Length;
            return charCount;
        }
    }
}