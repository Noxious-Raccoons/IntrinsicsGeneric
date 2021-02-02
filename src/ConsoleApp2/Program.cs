using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using IntrinsicsGeneric.Extensions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine(Vector256.Create(259, long.MaxValue, 100, 100, 100, 100, 100, 100).AsInt64());
           var vByte = VectorHelper<int>.CreateVector256(
               15, 75, 42, 37, 79, 67, 255, 120, 15, 75, 42, 37, 79, 67, 7, 120,
               15, 75, 42, 37, 79, 67, 255, 120, 15, 75, 42, 137, 79, 67, 7, 120);
            
           var vSbyte = VectorHelper<sbyte>.CreateVector256(
               15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
               15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120);
            
           var vUshort = VectorHelper<ushort>.CreateVector256(
               15, 20, 42, 37, 79, 67, 7, 120, 15, 13, 42, 37, 79, 67, 7, 120);
            
           var vShort = VectorHelper<short>.CreateVector256(
               15, 20, 42, 37, 79, 67, 7, 120, -15, 13, 42, 37, 79, 67, 7, 120);
            
           var vInt = VectorHelper<int>.CreateVector256(-15, 20, 42, 37, 79, 67, 7, 120, -15, 20, 42, 37, 79, 67, 7, 120);
           Console.WriteLine(Avx2.Add(vByte, vByte).AsByte());
        }
    }
}