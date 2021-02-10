using System.Collections;
using System.Linq;
using IntrinsicsGeneric.Extensions;
using IntrinsicsGeneric.Helpers;
using Xunit;

namespace IntrinsicsGeneric.UnitTests.VectorHelperTests
{
    public class AllBitsSets
    {
        [Fact]
        public void AllBitsSet128Test()
        {
            AllBitsSet128<byte>();

            AllBitsSet128<short>();
            AllBitsSet128<ushort>();

            AllBitsSet128<int>();
            AllBitsSet128<uint>();

            AllBitsSet128<long>();
            AllBitsSet128<ulong>();

            AllBitsSet128<float>();
            AllBitsSet128<double>();
        }

        private static void AllBitsSet128<T>()
            where T : unmanaged
        {
            var expected = new BitArray(128);
            expected.SetAll(true);

            var actual = VectorHelper<T>.AllBitsSet128.ToBitArray();

            Assert.True(actual.Cast<bool>().All(b => b));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AllBitsSet256Test()
        {
            AllBitsSet256<byte>();
            AllBitsSet256<short>();
            AllBitsSet256<ushort>();

            AllBitsSet256<int>();
            AllBitsSet256<uint>();

            AllBitsSet256<long>();
            AllBitsSet256<ulong>();

            AllBitsSet256<float>();
            AllBitsSet256<double>();
        }
        
        private static void AllBitsSet256<T>()
            where T : unmanaged
        {
            var expected = new BitArray(256);
            expected.SetAll(true);

            var actual = VectorHelper<T>.AllBitsSet256.ToBitArray();

            Assert.True(actual.Cast<bool>().All(b => b));
            Assert.Equal(expected, actual);
        }
    }
}
