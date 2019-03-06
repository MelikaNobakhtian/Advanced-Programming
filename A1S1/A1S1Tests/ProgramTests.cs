using Microsoft.VisualStudio.TestTools.UnitTesting;
using A3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A3.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        private static string GetTestFile(out int lineCount, out int charCount)
        {
            charCount = 0;
            string tmpFile = Path.GetTempFileName();
            lineCount = new Random(0).Next(10, 100);
            List<string> lines = new List<string>();
            for (int i = 0; i < lineCount; i++)
            {
                string line = $"Line number {i}";
                charCount += line.Length;
                lines.Add(line);
            }
            File.WriteAllLines(tmpFile, lines);
            return tmpFile;
        }

        private static string[] GetTestDir(out string tmpDir)

        {
        tmpDir = Path.GetTempFileName();
        Directory.CreateDirectory(tmpDir);
         int rndNum = new Random(0).Next(10, 20);
        List<string> files = new List<string>();
        for (int i=0; i<rndNum; i++)
         {
            string fileName = Path.Combine(tmpDir, $"file{i}.txt");
            File.WriteAllText(fileName, $"file{i}.txt content");
            files.Add(fileName);
         }
         return files.ToArray();
 }

[TestMethod()]
        public void MainTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CaculateLengthTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LetterCountTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LineCountTest()
        {
           
        }

        [TestMethod()]
        public void FileLineCountTest()
        {
            int lineCount;
            int charCount;
            string path = GetTestFile(out lineCount, out charCount);
            int functionresult = Program.FileLineCount(path);
            Assert.AreEqual(lineCount, functionresult);


        }

        [TestMethod()]
        public void ListFilesTest()
        {
            string tmpdir;
            string[] expectedresult = GetTestDir(out tmpdir);
            string[] functionresult = Program.ListFiles(tmpdir);
            Assert.AreEqual(expectedresult, functionresult);
        }

        [TestMethod()]
        public void FileSizeTest()
        {
            int lineCount;
            int charCount;
            string path = GetTestFile(out lineCount, out charCount);
            double functionresult = Program.FileSize(path);
            Assert.AreEqual(charCount, functionresult);


        }
    }
}