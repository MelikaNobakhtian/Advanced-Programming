using System;
using System.Runtime.InteropServices;

namespace A6
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TypeOfSize5
    {
        public int Size4;
        public byte Size1;
    }

    public struct TypeOfSize22
    {
        public TypeOfSize5 Obj1;
        public TypeOfSize5 Obj2;
        public TypeOfSize5 Obj3;
        public TypeOfSize5 Obj4;
        public byte Size1;
        public byte Size12;
    }

    public struct TypeOfSize125
    {
        public TypeOfSize22 Obj1Size;
        public TypeOfSize22 Obj2Size;
        public TypeOfSize22 Obj3Size;
        public TypeOfSize22 Obj4Size;
        public TypeOfSize22 Obj5Size;
        public TypeOfSize5 Obj6Size;
        public TypeOfSize5 Obj7Size;
        public TypeOfSize5 Obj8Size;
    }

    public struct TypeOfSize1024
    {
        public TypeOfSize125 OfSize1251;
        public TypeOfSize125 OfSize1252;
        public TypeOfSize125 OfSize1253;
        public TypeOfSize125 OfSize1254;
        public TypeOfSize125 OfSize1255;
        public TypeOfSize125 OfSize1256;
        public TypeOfSize125 OfSize1257;
        public TypeOfSize125 OfSize1258;
        public TypeOfSize22 OfSize22;
        public byte OfSize11;
        public byte OfSize12;
    }

    public struct TypeOfSize4096
    {
        public TypeOfSize1024 OfSize1024;
        public TypeOfSize1024 OfSize10242;
        public TypeOfSize1024 OfSize10243;
        public TypeOfSize1024 OfSize10244;
    }

    public struct TypeOfSize32768
    {
       public TypeOfSize4096 OfSize4096;
       public TypeOfSize4096 OfSize40962;
       public TypeOfSize4096 OfSize40963;
       public TypeOfSize4096 OfSize40964;
       public TypeOfSize4096 OfSize40965;
       public TypeOfSize4096 OfSize40966;
       public TypeOfSize4096 OfSize40967;
       public TypeOfSize4096 OfSize40968;
    }

    public struct StructOrClass1
    {
        public int X;
    }

    public class StructOrClass2
    {
        public int X;
    }

    public class StructOrClass3
    {
        public StructOrClass2 X;
    }

    public struct TypeForMaxStackOfDepth10
    {
        public TypeOfSize32768 OfSize32768;
        public TypeOfSize1024 OfSize1024;
        public TypeOfSize1024 OfSize10242;
        public TypeOfSize1024 OfSize10243;
        public TypeOfSize1024 OfSize10244;
        public TypeOfSize1024 OfSize10245;
        public TypeOfSize1024 OfSize10246;
        public TypeOfSize1024 OfSize10247;
        public TypeOfSize1024 OfSize10248;
    }

    public struct TypeForMaxStackOfDepth100
    {
        public TypeOfSize1024 OfSize1024;
        public TypeOfSize1024 OfSize10242;
        public TypeOfSize1024 OfSize10243;
        public TypeOfSize1024 OfSize10244;
        public TypeOfSize1024 OfSize10245;
    }

    public struct TypeForMaxStackOfDepth1000
    {
        public TypeOfSize125 OfSize125;
        public TypeOfSize125 OfSize1252;
        public TypeOfSize125 OfSize1253;
        public TypeOfSize125 OfSize1254;
    }

    public struct TypeForMaxStackOfDepth3000
    {
        public TypeOfSize22 OfSize22;
        public TypeOfSize22 OfSize222;
        public TypeOfSize22 OfSize223;
        public TypeOfSize22 OfSize224;
        public TypeOfSize22 OfSize225;
        public TypeOfSize22 OfSize226;
    }

    public class TypeWithMemoryOnHeap
    {
        public string[] HeapString;

        public void Allocate()
        {
            HeapString = new string[1000000];
        }

        public void DeAllocate()
        {
            HeapString = null;
        }
    }

    public class Program
    {
        public static int GetObjectType(object obj)
        {
            if (obj is string)
                return 0;
            if (obj is int[])
                return 1;
            return 2;
        }

        public enum FutureHusbandType
        {
            None = 2,
            HasBigNose = 4,
            IsBald = 8,
            IsShort = 16
        }

        public static bool IdealHusband(FutureHusbandType fht)
        {
            var result = 0;
            if ((fht & FutureHusbandType.HasBigNose) == FutureHusbandType.HasBigNose)
                result += 4;
            if ((fht & FutureHusbandType.IsBald) == FutureHusbandType.IsBald)
                result += 8;
            if ((fht & FutureHusbandType.IsShort) == FutureHusbandType.IsShort)
                result += 16;
            if (result == 24 || result == 12 || result == 20)
                return true;
            return false;
        }

        public static void Main(string[] args)
        {
        }
    }
}