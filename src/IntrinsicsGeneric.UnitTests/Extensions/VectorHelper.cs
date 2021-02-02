using IntrinsicsGeneric.Extensions;
using System.Collections;
using System.Linq;
using System.Runtime.Intrinsics;
using Xunit;

namespace IntrinsicsGeneric.UnitTests.Extensions
{
    public class VectorHelper
    {
        [Theory]
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

        [Theory]
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
        
                #region Contains

        [Fact]
        public void Contains256_True()
        {
            var vByte = VectorHelper<byte>.CreateVector256(
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120);
            
            var vSbyte = VectorHelper<sbyte>.CreateVector256(
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120);
            
            var vUshort = VectorHelper<ushort>.CreateVector256(
                15, 20, 42, 37, 79, 67, 7, 120, 15, 13, 42, 37, 79, 67, 7, 120);
            
            var vShort = VectorHelper<short>.CreateVector256(
                15, 20, 42, 37, 79, 67, 7, 120, -15, 13, 42, 37, 79, 67, 7, 120);
            
            var vInt = VectorHelper<int>.CreateVector256(-15, 20, 42, 37, 79, 67, 7, 120);
            var vUInt = VectorHelper<uint>.CreateVector256(15, 20, 42, 37, 79, 67, 7, 120);
            var vFloat = VectorHelper<float>.CreateVector256(15, 20, 42, 37, 79, 67.9f, 7, 120);
            var vDouble = VectorHelper<double>.CreateVector256(15, 12.9d, 42, 37);
            var vLong = VectorHelper<long>.CreateVector256(-15, 20, 42, 37);
            var vULong = VectorHelper<ulong>.CreateVector256(15, 20, 42, 37);
            
            Assert.True(vByte.Contains<byte>(120));
            Assert.True(vSbyte.Contains<sbyte>(-75));
            Assert.True(vUshort.Contains<ushort>(7));
            Assert.True(vShort.Contains<short>(-15));
            Assert.True(vUInt.Contains<uint>(7));
            Assert.True(vULong.Contains<ulong>(20));
            Assert.True(vLong.Contains(42));
            Assert.True(vInt.Contains(-15));
            Assert.True(vFloat.Contains(67.9f));
            Assert.True(vDouble.Contains(12.9d));
        }
        
        [Fact]
        public void Contains256_False()
        {
            var vByte = VectorHelper<byte>.CreateVector256(
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120);
            
            var vSbyte = VectorHelper<sbyte>.CreateVector256(
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120);
            
            var vUshort = VectorHelper<ushort>.CreateVector256(
                15, 20, 42, 37, 79, 67, 7, 120, 15, 13, 42, 37, 79, 67, 7, 120);
            
            var vShort = VectorHelper<short>.CreateVector256(
                15, 20, 42, 37, 79, 67, 7, 120, -15, 13, 42, 37, 79, 67, 7, 120);
            
            var vInt = VectorHelper<int>.CreateVector256(-15, 20, 42, 37, 79, 67, 7, 120);
            var vUInt = VectorHelper<uint>.CreateVector256(15, 20, 42, 37, 79, 67, 7, 120);
            var vFloat = VectorHelper<float>.CreateVector256(15, 20, 42, 37, 79, 67.9f, 7, 120);
            var vDouble = VectorHelper<double>.CreateVector256(15, 12.9d, 42, 37);
            var vLong = VectorHelper<long>.CreateVector256(-15, 20, 42, 37);
            var vULong = VectorHelper<ulong>.CreateVector256(15, 20, 42, 37);
            
            Assert.False(vByte.Contains<byte>(74));
            Assert.False(vSbyte.Contains<sbyte>(-74));
            Assert.False(vUshort.Contains<ushort>(6));
            Assert.False(vShort.Contains<short>(9));
            Assert.False(vUInt.Contains<uint>(11));
            Assert.False(vULong.Contains<ulong>(12));
            Assert.False(vLong.Contains(44));
            Assert.False(vInt.Contains(-44));
            Assert.False(vFloat.Contains(68.9f));
            Assert.False(vDouble.Contains(1.4d));
        }
        
        [Fact]
        public void Contains_True()
        {
            Assert.True(VectorHelper<byte>.Contains(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120
            }, 15));
            Assert.True(VectorHelper<sbyte>.Contains(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120
            }, -75));

            Assert.True(VectorHelper<ushort>.Contains(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 20 }, 120));
            Assert.True(VectorHelper<short>.Contains(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 15, -75, 42, 37, 79, 67, 7, 120 }, 7));

            Assert.True(VectorHelper<uint>.Contains(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 }, 67));
            Assert.True(VectorHelper<int>.Contains(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 }, 79));

            Assert.True(VectorHelper<ulong>.Contains(new ulong[] { 42, 37, 7, 120 }, 42));
            Assert.True(VectorHelper<long>.Contains(new long[] { 42, -37, 7, 120 }, -37));

            Assert.True(VectorHelper<float>.Contains(new float[] { 15, 75, 42, 37, 79, 67.9f, 7, 120 }, 67.9f));
            Assert.True(VectorHelper<double>.Contains(new double[] { 42, 37, 42, 37.98 }, 37.98));
        }
        
        [Fact]
        public void Contains_False()
        {
            Assert.False(VectorHelper<byte>.Contains(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120
            }, 13));
            Assert.False(VectorHelper<sbyte>.Contains(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120
            }, -3));

            Assert.False(VectorHelper<ushort>.Contains(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 20 }, 220));
            Assert.False(VectorHelper<short>.Contains(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 15, -75, 42, 37, 79, 67, 7, 120 }, -220));

            Assert.False(VectorHelper<uint>.Contains(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 }, 790));
            Assert.False(VectorHelper<int>.Contains(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 }, 790));

            Assert.False(VectorHelper<ulong>.Contains(new ulong[] { 42, 37, 7, 120 }, 795));
            Assert.False(VectorHelper<long>.Contains(new long[] { 42, -37, 7, 120 }, 0));

            Assert.False(VectorHelper<float>.Contains(new float[] { 15, 75, 42, 37, 79, 67.9f, 7, 120 }, 67.19f));
            Assert.False(VectorHelper<double>.Contains(new double[] { 42, 37, 42, 37.98 }, 37.9));
        }
        
        #endregion
    }
}
