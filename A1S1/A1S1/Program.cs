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
        public static int CaculateLength(string str)
            {
           
            return str.Length;
            }
        
        public static int LetterCount(string str)
            {
            
            int num = 0;
            foreach(char letter in str)
            {
                if (Char.IsLetter(letter))
                    num++;

            }
            return num;
            }
        
        public static int LineCount(string str)
            {
            
            string[] lines = str.Split('\n');
            return lines.Length-1;
            }
        
        public static int FileLineCount(string filePath)
            {
            
            string[] lines = File.ReadAllLines(filePath);
            return lines.Length;
            }
        
        public static string[] ListFiles(string dirPath)
            {
            string[] files= Directory.GetFiles(dirPath);
            int length = files.Length;
            string[] sortfile = new string[length];
            for(int i=0;i<length; i++)
            {
                for(int j = 0; j < length; j++)
                {
                    if (files[j].Contains($"file{i}.txt"))
                    {
                        sortfile[i] = files[j];
                        break;
                    }
                }
            }

            return sortfile;
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
