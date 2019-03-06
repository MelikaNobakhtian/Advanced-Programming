using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
    {
    public class Program
        {
        public static void Main(string[] args)
            {
            }
        public int CaculateLength(string str)
            {
            // Write your code here and remove next line
            return str.Length;
            }
        
        public int LetterCount(string str)
            {
            // Write your code here and remove next line
            int num = 0;
            foreach(char letter in str)
            {
                if (Char.IsLetter(letter))
                    num++;

            }
            return num;
            }
        
        public int LineCount(string str)
            {
            // Write your code here and remove next line
            string[] lines = str.Split('\n');
            return lines.Length;
            }
        
        public static int FileLineCount(string filePath)
            {
            
            string[] lines = File.ReadAllLines(filePath);
            return lines.Length;
            }
        
        public static string[] ListFiles(string dirPath)
            {
            // Write your code here and remove next line
            
            return Directory.GetFiles(dirPath);
            }
        
        public static double FileSize(string filePath)
            {
            int charcount = 0;
            string[] lines = File.ReadAllLines(filePath);
            int num = FileLineCount(filePath);
            for (int i = 0; i < num; i++)
                charcount += lines[i].Length;
            return charcount;

            
            }
        }
    }
