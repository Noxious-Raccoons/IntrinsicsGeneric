using IntrinsicsGeneric.Extensions;
using IntrinsicsGeneric.Simd;
using NUnit.Framework;

namespace IntrinsicsGeneric.UnitTests.Extensions
{
    public class Tests
    {
        [TestCase(1, 4)]
        [TestCase(1U, 4U)]
        [TestCase(1F, 4F)]
        [TestCase(1L, 2L)]
        [TestCase(1UL, 2UL)]
        [TestCase(1D, 2D)]
        [TestCase((short)1, (short)8)]
        [TestCase((ushort)1, (ushort)8)]
        [TestCase((byte)1, (byte)16)]
        [TestCase((sbyte)1, (sbyte)16)]
        public void Vector128Sum<T>(T value, T expected)
            where T : unmanaged
        {
            var v = Simd<T>.CreateVector128(value);

            var result = v.Sum();

            Assert.AreEqual(expected, result);
        }

        [TestCase(1, 8)]
        [TestCase(1U, 8U)]
        [TestCase(1F, 8F)]
        [TestCase(1L, 4L)]
        [TestCase(1UL, 4UL)]
        [TestCase(1D, 4D)]
        [TestCase((short)1, (short)16)]
        [TestCase((ushort)1, (ushort)16)]
        [TestCase((byte)1, (byte)32)]
        [TestCase((sbyte)1, (sbyte)32)]
        public void Vector256Sum<T>(T value, T expected)
            where T : unmanaged
        {
            var v = Simd<T>.CreateVector256(value);

            var result = v.Sum();

            Assert.AreEqual(expected, result);
        }
    }
}
