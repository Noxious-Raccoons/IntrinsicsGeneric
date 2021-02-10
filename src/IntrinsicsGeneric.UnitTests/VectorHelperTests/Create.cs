using System.Runtime.Intrinsics;
using IntrinsicsGeneric.Helpers;
using Xunit;

namespace IntrinsicsGeneric.UnitTests.VectorHelperTests
{
    public class Create
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
    }
}
