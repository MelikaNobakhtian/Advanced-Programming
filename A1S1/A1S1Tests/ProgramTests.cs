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
         if (File.Exists(tmpDir))
            File.Delete(tmpDir);

        if (!Directory.Exists(tmpDir))
            Directory.CreateDirectory(tmpDir);
        else
            foreach (string file in Directory.GetFiles(tmpDir))
                File.Delete(file);

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
            int expectedresult = 16;
            int functionresult = Program.CaculateLength("Hello my friend!");
            Assert.AreEqual(expectedresult, functionresult);
        }

        [TestMethod()]
        public void LetterCountTest()
        {
            int expectedresult = 5;
            int functionresult = Program.LetterCount("Why me??");
            Assert.AreEqual(expectedresult, functionresult);
        }

        [TestMethod()]
        public void LineCountTest()
        {
            int expectedresult = 4;
            int functionresult = Program.LineCount("stop thinking" +'\n'+
                '\n'+"about what"+
                '\n'+"others thinking"+
                '\n'+ "about you");
            Assert.AreEqual(expectedresult, functionresult);
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
            CollectionAssert.AreEqual(expectedresult, functionresult);
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