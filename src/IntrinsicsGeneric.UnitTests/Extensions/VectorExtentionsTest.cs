using IntrinsicsGeneric.Extensions;
using NUnit.Framework;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using IntrinsicsGeneric.Simd;

namespace IntrinsicsGeneric.UnitTests.Extensions
{
    public class VectorExtensionsTest
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
            var v = VectorHelper<T>.CreateVector128(value);

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
            var v = VectorHelper<T>.CreateVector256(value);

            var result = v.Sum();

            Assert.AreEqual(expected, result);
        }
        
        #region Contains

        [Test]
        public void Contains_True()
        {
            TestContext.Write(Avx2.IsSupported);
            TestContext.Write(Avx.IsSupported);
            TestContext.Write(Sse41.IsSupported);
            TestContext.Write(Ssse3.IsSupported);
            TestContext.Write(Sse3.IsSupported);
            TestContext.Write(Sse2.IsSupported);
            TestContext.Write(Sse.IsSupported);
            Assert.IsTrue(VectorExtensions.Contains<byte>(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120
            }, 137));
            
            Assert.IsTrue(VectorExtensions.Contains<sbyte>(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120
            }, -37));

            Assert.IsTrue(VectorExtensions.Contains<ushort>(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 20 }, 20));
            Assert.IsTrue(VectorExtensions.Contains<short>(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 15, -75, 42, 37, 79, 67, 7, 120 }, -20));

            Assert.IsTrue(VectorExtensions.Contains<uint>(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 }, 79));
            Assert.IsTrue(VectorExtensions.Contains<int>(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 }, 79));

            Assert.IsTrue(VectorExtensions.Contains<ulong>(new ulong[] { 42, 37, 7, 120 }, 7));
            Assert.IsTrue(VectorExtensions.Contains<long>(new long[] { 42, -37, 7, 120 }, 7));

            Assert.IsTrue(VectorExtensions.Contains<float>(new float[] { 15, 75, 42, 37, 79, 67.9f, 7, 120 }, 67.9f));
            Assert.IsTrue(VectorExtensions.Contains<double>(new double[] { 42, 37, 42, 37.98 }, 37.98));
        }
        
        [Test]
        public void Contains_False()
        {
            Assert.IsFalse(VectorExtensions.Contains<byte>(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120
            }, 13));
            Assert.IsFalse(VectorExtensions.Contains<sbyte>(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120
            }, -3));

            Assert.IsFalse(VectorExtensions.Contains<ushort>(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 20 }, 220));
            Assert.IsFalse(VectorExtensions.Contains<short>(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 15, -75, 42, 37, 79, 67, 7, 120 }, -220));

            Assert.IsFalse(VectorExtensions.Contains<uint>(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 }, 790));
            Assert.IsFalse(VectorExtensions.Contains<int>(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 }, 790));

            Assert.IsFalse(VectorExtensions.Contains<ulong>(new ulong[] { 42, 37, 7, 120 }, 795));
            Assert.IsFalse(VectorExtensions.Contains<long>(new long[] { 42, -37, 7, 120 }, 0));

            Assert.IsFalse(VectorExtensions.Contains<float>(new float[] { 15, 75, 42, 37, 79, 67.9f, 7, 120 }, 67.19f));
            Assert.IsFalse(VectorExtensions.Contains<double>(new double[] { 42, 37, 42, 37.98 }, 37.9));
        }
        
        #endregion
    }
}
