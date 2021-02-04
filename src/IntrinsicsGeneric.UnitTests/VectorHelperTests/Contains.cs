using IntrinsicsGeneric.Helpers;
using Xunit;

namespace IntrinsicsGeneric.UnitTests.VectorHelperTests
{
    public class Contains
    {
        [Fact]
        public void ShouldContainValueOfVector()
        {
            Assert.True(VectorHelper<byte>.Contains(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 1, 37, 79, 67, 7, 120, 15, 75, 42, 1, 79, 67, 7, 120
            }, 37));
            
            
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
        public void ShouldNotContainValueOfVector()
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
    }
}