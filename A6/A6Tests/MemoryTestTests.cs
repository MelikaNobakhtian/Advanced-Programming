using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Runtime.InteropServices;
using A6;

namespace A6.Tests
{
    [TestClass]
    public class MemoryTestTests
    {
        [TestMethod]
        public void VariableSizeTest()
        {
            TypeOfSize5 tos5 = new TypeOfSize5();
            VerifySize(tos5, 5);
            TypeOfSize22 tos22 = new TypeOfSize22();
            VerifySize(tos22, 22);
            TypeOfSize125 tos125 = new TypeOfSize125();
            VerifySize(tos125, 125);
            TypeOfSize1024 tos1024 = new TypeOfSize1024();
            VerifySize(tos1024, 1024);
            TypeOfSize32768 tos32768 = new TypeOfSize32768();
            VerifySize(tos32768, 32768);
        }

        
        [TestMethod]
        public void StackDepth10Test()
        {
            TypeForMaxStackOfDepth10 a = new TypeForMaxStackOfDepth10();
            int recursionDepth = GetMaxRecursion(0, a);
            VerifyApproximateMatch(recursionDepth, 10);
        }
        
        [TestMethod]
        public void StackDepth100Test()
        {
            TypeForMaxStackOfDepth100 a = new TypeForMaxStackOfDepth100();
            int recursionDepth = GetMaxRecursion(0, a);
            VerifyApproximateMatch(recursionDepth, 100);
        }
        
        [TestMethod]
        public void StackDepth1000Test()
        {
            TypeForMaxStackOfDepth1000 a = new TypeForMaxStackOfDepth1000();
            int recursionDepth = GetMaxRecursion(0, a);
            VerifyApproximateMatch(recursionDepth, 1000);
        }
        
        [TestMethod]
        public void StackDepth3000Test()
        {
            TypeForMaxStackOfDepth3000 a = new TypeForMaxStackOfDepth3000();
            int recursionDepth = GetMaxRecursion(0, a);
            VerifyApproximateMatch(recursionDepth, 3000);
        }
        
        private static void VerifyApproximateMatch(int actual, int expected)
        {

            Assert.IsTrue(Math.Abs(actual - expected) <= (0.1 * expected), $"Actual:{actual} != Expected:{expected}");
        }
        
        [TestMethod]
        public void HeapMemoryTest()
        {
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            var memSize = GC.GetTotalMemory(true);
            TypeWithMemoryOnHeap r = new TypeWithMemoryOnHeap();
            r.Allocate();

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            var memDiff1 = GC.GetTotalMemory(true) - memSize;
            r.DeAllocate();

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            var memDiff2 = GC.GetTotalMemory(true) - memSize;

            Assert.IsTrue(memDiff1 < 4_100_000 && memDiff1 > 3_900_000);
            Assert.IsTrue(memDiff2 < 100_000 && memDiff2 > -100_000);
        }
        
        [TestMethod]
        public void RefValueTypeCopyTest1()
        {
            StructOrClass1 soc1a = new StructOrClass1();
            soc1a.X = 1;
            var soc1b = soc1a;
            soc1a.X = 2; ;
            Assert.AreNotEqual(soc1a.X, soc1b.X);
        }

        [TestMethod]
        public void RefValueTypeCopyTest2()
        {
            StructOrClass2 soc1a = new StructOrClass2();
            soc1a.X = 1;
            var soc1b = soc1a;
            soc1a.X = 2; ;
            Assert.AreEqual(soc1a.X, soc1b.X);
        }
    
        [TestMethod]
        public void RefValueTypeCopyTest3()
        {
            StructOrClass3 soc1a = new StructOrClass3();
            var soc2 = new StructOrClass2();
            soc2.X = 5;
            soc1a.X = soc2;
            var soc1b = soc1a;
            soc1a.X.X = 6; ;
            Assert.AreEqual(soc1a.X.X, soc1b.X.X);
            Assert.AreEqual(soc2.X, soc1b.X.X);

        }

        [TestMethod]
        public void BoxingTest()
        {
            StructOrClass1 soc = new StructOrClass1();
            soc.X = 5;
            object o = soc;
            soc.X = 6;
            StructOrClass1 soc2 = (StructOrClass1) o;
            Assert.AreEqual(5, soc2.X);
        }
        
        [TestMethod]
        public void TypeTest()
        {
            string str = "ThinkBig";
            int value = Program.GetObjectType(str);
            Assert.AreEqual(0, value);
            value = Program.GetObjectType(new int[] { 2 });
            Assert.AreEqual(1, value);
            value = Program.GetObjectType(24434);
            Assert.AreEqual(2, value);
        }
        
        [TestMethod]
        public void IdealHusbandTest()
        {
            Program.FutureHusbandType fht = Program.FutureHusbandType.HasBigNose;
            Assert.AreEqual(false, Program.IdealHusband(fht));

            fht = Program.FutureHusbandType.IsBald;
            Assert.AreEqual(false, Program.IdealHusband(fht));

            fht = Program.FutureHusbandType.IsShort;
            Assert.AreEqual(false, Program.IdealHusband(fht));

            fht = Program.FutureHusbandType.IsBald | Program.FutureHusbandType.IsShort;
            Assert.AreEqual(true, Program.IdealHusband(fht));

            fht = Program.FutureHusbandType.IsBald | Program.FutureHusbandType.HasBigNose;
            Assert.AreEqual(true, Program.IdealHusband(fht));

            fht = Program.FutureHusbandType.IsShort | Program.FutureHusbandType.HasBigNose;
            Assert.AreEqual(true, Program.IdealHusband(fht));

            fht = Program.FutureHusbandType.IsShort | Program.FutureHusbandType.HasBigNose | Program.FutureHusbandType.IsBald;
            Assert.AreEqual(false, Program.IdealHusband(fht));


        }
        
        #region Helper Methods
        private void VerifySize<_Type>(_Type tos, int expectedSize)
        {
            int actualSize = Marshal.SizeOf(tos);
            Assert.AreEqual(expectedSize, actualSize);
        }

        private int GetMaxRecursion<_Type>(int currentDepth, _Type bvt)
        {
            try
            {
                EnsureSufficientExecutionStack();
                return GetMaxRecursion(currentDepth + 1, bvt);
            }
            catch (InsufficientExecutionStackException) {}
            return currentDepth;
        }
        #endregion
    }
}