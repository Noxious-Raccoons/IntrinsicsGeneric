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
        [InlineData((short) 1, (short) 8)]
        [InlineData((ushort) 1, (ushort) 8)]
        [InlineData((byte) 1, (byte) 16)]
        [InlineData((sbyte) 1, (sbyte) 16)]
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
        [InlineData((short) 1, (short) 16)]
        [InlineData((ushort) 1, (ushort) 16)]
        [InlineData((byte) 1, (byte) 32)]
        [InlineData((sbyte) 1, (sbyte) 32)]
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
            /*Assert.True(VectorHelper<byte>.Contains(
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120
            ), 137);
            */
            
            Assert.True(VectorHelper<sbyte>.Contains(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120
            }, -37));

            Assert.True(VectorHelper<ushort>.Contains(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 20 }, 20));
            Assert.True(VectorHelper<short>.Contains(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 15, -75, 42, 37, 79, 67, 7, 120 }, -20));

            Assert.True(VectorHelper<uint>.Contains(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 }, 79));
            Assert.True(VectorHelper<int>.Contains(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 }, 79));

            Assert.True(VectorHelper<ulong>.Contains(new ulong[] { 42, 37, 7, 120 }, 7));
            Assert.True(VectorHelper<long>.Contains(new long[] { 42, -37, 7, 120 }, 7));

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
