using IntrinsicsGeneric.Extensions;
using IntrinsicsGeneric.Helpers;
using Xunit;

namespace IntrinsicsGeneric.UnitTests.VectorExtensionsTests
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
    }
}
