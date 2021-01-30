using IntrinsicsGeneric.Extensions;
using Xunit;

namespace IntrinsicsGeneric.UnitTests.Extensions
{
    public class VectorExtensionsTest
    {
        [Theory]
        [InlineData(1, 4)]
        [InlineData(1U, 4U)]
        [InlineData(1F, 4F)]
        [InlineData(1L, 2L)]
        [InlineData(1UL, 2UL)]
        [InlineData(1D, 2D)]
        [InlineData((short)1, (short)8)]
        [InlineData((ushort)1, (ushort)8)]
        [InlineData((byte)1, (byte)16)]
        [InlineData((sbyte)1, (sbyte)16)]
        public void Vector128Sum<T>(T value, T expected)
            where T : unmanaged
        {
            var v = VectorHelper<T>.CreateVector128(value);

            var result = v.Sum();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 8)]
        [InlineData(1U, 8U)]
        [InlineData(1F, 8F)]
        [InlineData(1L, 4L)]
        [InlineData(1UL, 4UL)]
        [InlineData(1D, 4D)]
        [InlineData((short)1, (short)16)]
        [InlineData((ushort)1, (ushort)16)]
        [InlineData((byte)1, (byte)32)]
        [InlineData((sbyte)1, (sbyte)32)]
        public void Vector256Sum<T>(T value, T expected)
            where T : unmanaged
        {
            var v = VectorHelper<T>.CreateVector256(value);

            var result = v.Sum();

            Assert.Equal(expected, result);
        }
        
        #region Contains

        [Fact]
        public void Contains_True()
        {
            Assert.True(VectorExtensions.Contains<byte>(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120
            }, 137));
            
            Assert.True(VectorExtensions.Contains<sbyte>(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120
            }, -37));

            Assert.True(VectorExtensions.Contains<ushort>(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 20 }, 20));
            Assert.True(VectorExtensions.Contains<short>(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 15, -75, 42, 37, 79, 67, 7, 120 }, -20));

            Assert.True(VectorExtensions.Contains<uint>(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 }, 79));
            Assert.True(VectorExtensions.Contains<int>(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 }, 79));

            Assert.True(VectorExtensions.Contains<ulong>(new ulong[] { 42, 37, 7, 120 }, 7));
            Assert.True(VectorExtensions.Contains<long>(new long[] { 42, -37, 7, 120 }, 7));

            Assert.True(VectorExtensions.Contains<float>(new float[] { 15, 75, 42, 37, 79, 67.9f, 7, 120 }, 67.9f));
            Assert.True(VectorExtensions.Contains<double>(new double[] { 42, 37, 42, 37.98 }, 37.98));
        }
        
        [Fact]
        public void Contains_False()
        {
            Assert.False(VectorExtensions.Contains<byte>(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120
            }, 13));
            Assert.False(VectorExtensions.Contains<sbyte>(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120
            }, -3));

            Assert.False(VectorExtensions.Contains<ushort>(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 20 }, 220));
            Assert.False(VectorExtensions.Contains<short>(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 15, -75, 42, 37, 79, 67, 7, 120 }, -220));

            Assert.False(VectorExtensions.Contains<uint>(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 }, 790));
            Assert.False(VectorExtensions.Contains<int>(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 }, 790));

            Assert.False(VectorExtensions.Contains<ulong>(new ulong[] { 42, 37, 7, 120 }, 795));
            Assert.False(VectorExtensions.Contains<long>(new long[] { 42, -37, 7, 120 }, 0));

            Assert.False(VectorExtensions.Contains<float>(new float[] { 15, 75, 42, 37, 79, 67.9f, 7, 120 }, 67.19f));
            Assert.False(VectorExtensions.Contains<double>(new double[] { 42, 37, 42, 37.98 }, 37.9));
        }
        
        #endregion
    }
}
