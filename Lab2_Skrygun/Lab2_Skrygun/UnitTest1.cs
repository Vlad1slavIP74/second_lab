using System;
using Xunit;
using System.IO;

namespace Lab2_Skrygun
{
    public class UnitTest1
    {
        static readonly string workingDirectory = Environment.CurrentDirectory;
        private readonly string testsDirFullPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "\\test";

        [Fact]
        public void TestGetFileName()
        {
            string fileNameExpected = "write.txt";
            string fileFullPath = testsDirFullPath + "\\" + fileNameExpected;
            string fileNameReal = IIG.FileWorker.BaseFileWorker.GetFileName(fileFullPath);

            Assert.Equal(fileNameExpected, fileNameExpected);
        }

        [Fact]
        public void TestWrite()
        {
            string fileWrittenFullPath = testsDirFullPath + "\\write.txt";
            string data = "some data here";
            bool written = IIG.FileWorker.BaseFileWorker.Write(data, fileWrittenFullPath);
            Assert.True(written);
        }

        [Fact]
        public void TestWriteInNotExist()
        {
            string fileWrittenFullPath = testsDirFullPath + "\\write3.txt";
            string data = "some data here";
            bool written = IIG.FileWorker.BaseFileWorker.Write(data, fileWrittenFullPath);
            Assert.True(written);
        }


        [Fact]
        public void TestTryCopyRewriteNotAllow()
        {
            string fileFromFullPath = testsDirFullPath + "\\fileForCopy.txt";
            string fileToFullPath = testsDirFullPath + "\\ALREADY_EXIST.txt";
            try
            {
                bool copied = IIG.FileWorker.BaseFileWorker.TryCopy(fileFromFullPath, fileToFullPath, false);
            }
            catch (IOException e)
            {
                bool alreadyExist = e.Message.Contains("already exists");
                Assert.True(alreadyExist);
            }
        }

         [Fact]
        public void TestReadLines()
        {
            string fileFullPath = testsDirFullPath+ "\\TestFile.txt";
            string[] linesExpected = { "1", "2" };
            string[] lines = IIG.FileWorker.BaseFileWorker.ReadLines(fileFullPath);
            Assert.Equal(linesExpected, lines);
        }

        [Fact]
        public void TryCopyRewriteNotAllow()
        {
            string fileFromFullPath = testsDirFullPath + "\\fileForCopy.txt";
            string fileToFullPath = testsDirFullPath + "\\ALREADY_EXIST.txt";
            bool copied = IIG.FileWorker.BaseFileWorker.TryCopy(fileFromFullPath, fileToFullPath, false);
            Assert.False(copied);
        }
    }
}

