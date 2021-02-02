using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using BenchmarkDotNet.Attributes;
using IntrinsicsGeneric.Extensions;

namespace ConsoleApp2
{
    public class BenchAdd
    {
        private int[] array;
        private int[] array2;

        [GlobalSetup]
        public void Setup()
        {
            array = new int[32];
            array2 = new int[32];
        }

        public Vector256<int> TestAdd()
        {
            var x = VectorHelper<int>.CreateVector256(
                15, 75, 42, 37, 79, 40, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120).AsByte();

            return Avx2.Add(x, x).AsInt32();
        }
    }
}