using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A3.Tests
{
    [TestClass]
    public class ProgramTests
    {
        private static string GetTestFile(out int lineCount, out int charCount)
        {
            charCount = 0;
            var tmpFile = Path.GetTempFileName();
            lineCount = new Random(0).Next(10, 100);
            var lines = new List<string>();
            for (var i = 0; i < lineCount; i++)
            {
                var line = $"Line number {i}";
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
                foreach (var file in Directory.GetFiles(tmpDir))
                    File.Delete(file);

            var rndNum = new Random(0).Next(10, 20);
            var files = new List<string>();
            for (var i = 0; i < rndNum; i++)
            {
                var fileName = Path.Combine(tmpDir, $"file{i}.txt");
                File.WriteAllText(fileName, $"file{i}.txt content");
                files.Add(fileName);
            }

            return files.ToArray();
        }


        [TestMethod]
        public void CaculateLengthTest()
        {
            var expectedresult = 16;
            var expectedresult1 = 24;
            var functionresult1 = Program.CaculateLength("end!!" + '\n' + "به کجا چنین شتابان");
            var functionresult = Program.CaculateLength("Hello my friend!");
            Assert.AreEqual(expectedresult, functionresult);
            Assert.AreEqual(expectedresult1, functionresult1);
        }

        [TestMethod]
        public void LetterCountTest()
        {
            var expectedresult = 5;
            var functionresult = Program.LetterCount("Why me??");
            var expectedresult1 = 20;
            var functionresult1 = Program.LetterCount("beautiful: زیبا " + '\n' + " ugly : زشت");
            Assert.AreEqual(expectedresult, functionresult);
            Assert.AreEqual(expectedresult1, functionresult1);
        }

        [TestMethod]
        public void LineCountTest()
        {
            var expectedresult = 4;
            var functionresult = Program.LineCount("stop thinking" +
                                                   '\n' + "about what" +
                                                   '\n' + "others thinking" +
                                                   '\n' + "about you");
            var expectedresult1 = 3;
            var functionrsult1 = Program.LineCount("حد تصور" + '\n' + "مهربان تر از" + '\n' + "وخدایی هست");
            Assert.AreEqual(expectedresult, functionresult);
            Assert.AreEqual(expectedresult1, functionrsult1);
        }

        [TestMethod]
        public void FileLineCountTest()
        {
            int lineCount;
            int charCount;
            var path = GetTestFile(out lineCount, out charCount);
            var functionresult = Program.FileLineCount(path);
            Assert.AreEqual(lineCount, functionresult);
        }

        [TestMethod]
        public void ListFilesTest()
        {
            string tmpdir;
            var expectedresult = GetTestDir(out tmpdir);
            var functionresult = Program.ListFiles(tmpdir);
            CollectionAssert.AreEqual(expectedresult, functionresult);
        }

        [TestMethod]
        public void FileSizeTest()
        {
            int lineCount;
            int charCount;
            var path = GetTestFile(out lineCount, out charCount);
            var functionresult = Program.FileSize(path);
            Assert.AreEqual(charCount, functionresult);
        }
    }
}