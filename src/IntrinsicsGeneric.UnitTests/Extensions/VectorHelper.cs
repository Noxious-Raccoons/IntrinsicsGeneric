using IntrinsicsGeneric.Extensions;
using System.Collections;
using System.Linq;
using System.Runtime.Intrinsics;
using Xunit;

namespace IntrinsicsGeneric.UnitTests.Extensions
{
    public class VectorHelper
    {
        [InlineData(115.3)]
        [InlineData(-5)]
        [InlineData(300)]
        public void CreateVector128(double value)
        {
            Assert.Equal(Vector128.Create((sbyte)value), VectorHelper<sbyte>.CreateVector128((sbyte)value));
            Assert.Equal(Vector128.Create((byte)value), VectorHelper<byte>.CreateVector128((byte)value));

            Assert.Equal(Vector128.Create((short)value), VectorHelper<short>.CreateVector128((short)value));
            Assert.Equal(Vector128.Create((ushort)value), VectorHelper<ushort>.CreateVector128((ushort)value));

            Assert.Equal(Vector128.Create((int)value), VectorHelper<int>.CreateVector128((int)value));
            Assert.Equal(Vector128.Create((uint)value), VectorHelper<uint>.CreateVector128((uint)value));

            Assert.Equal(Vector128.Create((long)value), VectorHelper<long>.CreateVector128((long)value));
            Assert.Equal(Vector128.Create((ulong)value), VectorHelper<ulong>.CreateVector128((ulong)value));

            Assert.Equal(Vector128.Create((float)value), VectorHelper<float>.CreateVector128((float)value));
            Assert.Equal(Vector128.Create(value), VectorHelper<double>.CreateVector128(value));
        }

        [InlineData(115.3)]
        [InlineData(-5)]
        [InlineData(300)]
        public void CreateVector256(double value)
        {
            Assert.Equal(Vector256.Create((sbyte)value), VectorHelper<sbyte>.CreateVector256((sbyte)value));
            Assert.Equal(Vector256.Create((byte)value), VectorHelper<byte>.CreateVector256((byte)value));

            Assert.Equal(Vector256.Create((short)value), VectorHelper<short>.CreateVector256((short)value));
            Assert.Equal(Vector256.Create((ushort)value), VectorHelper<ushort>.CreateVector256((ushort)value));

            Assert.Equal(Vector256.Create((int)value), VectorHelper<int>.CreateVector256((int)value));
            Assert.Equal(Vector256.Create((uint)value), VectorHelper<uint>.CreateVector256((uint)value));

            Assert.Equal(Vector256.Create((long)value), VectorHelper<long>.CreateVector256((long)value));
            Assert.Equal(Vector256.Create((ulong)value), VectorHelper<ulong>.CreateVector256((ulong)value));

            Assert.Equal(Vector256.Create((float)value), VectorHelper<float>.CreateVector256((float)value));
            Assert.Equal(Vector256.Create(value), VectorHelper<double>.CreateVector256(value));
        }

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
