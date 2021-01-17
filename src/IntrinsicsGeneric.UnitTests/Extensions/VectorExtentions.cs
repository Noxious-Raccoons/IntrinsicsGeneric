using IntrinsicsGeneric.Extensions;
using NUnit.Framework;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace IntrinsicsGeneric.UnitTests.Extensions
{
    public class VectorExtensions
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

        #region Contains128

        [Test]
        public void Contains128_True()
        {
            Assert.IsTrue(Contains128<byte>(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            }, 137));
            Assert.IsTrue(Contains128<sbyte>(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            }, -37));

            Assert.IsTrue(Contains128<ushort>(new ushort[] { 15, 75, 42, 37, 20, 67, 7, 120, 0, 0, 0, 0, 0, 0, 0, 0 }, 20));
            Assert.IsTrue(Contains128<short>(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 0, 0, 0, 0, 0, 0, 0, 0 }, -20));

            Assert.IsTrue(Contains128<uint>(new uint[] { 15, 79, 42, 37, 0, 0, 0, 0 }, 79));
            Assert.IsTrue(Contains128<int>(new int[] { 15, 79, 42, 37, 0, 0, 0, 0 }, 79));

            Assert.IsTrue(Contains128<ulong>(new ulong[] { 42, 7, 0, 0 }, 7));
            Assert.IsTrue(Contains128<long>(new long[] { 42, -7, 0, 0 }, -7));

            Assert.IsTrue(Contains128<float>(new float[] { 15, 75, 67.9f, 37, 0, 0, 0, 0 }, 67.9f));
            Assert.IsTrue(Contains128<double>(new double[] { 42, 37.98, 0, 0 }, 37.98));
        }

        [Test]
        public void Contains128_False()
        {
            Assert.IsFalse(Contains128<byte>(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120
            }, 13));
            Assert.IsFalse(Contains128<sbyte>(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120
            }, -3));

            Assert.IsFalse(Contains128<ushort>(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 20 }, 220));
            Assert.IsFalse(Contains128<short>(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 15, -75, 42, 37, 79, 67, 7, 120 }, -220));

            Assert.IsFalse(Contains128<uint>(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 }, 790));
            Assert.IsFalse(Contains128<int>(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 }, 790));

            Assert.IsFalse(Contains128<ulong>(new ulong[] { 42, 37, 7, 120 }, 795));
            Assert.IsFalse(Contains128<long>(new long[] { 42, -37, 7, 120 }, 0));

            Assert.IsFalse(Contains128<float>(new float[] { 15, 75, 42, 37, 79, 67.9f, 7, 120 }, 67.19f));
            Assert.IsFalse(Contains128<double>(new double[] { 42, 37, 42, 37.98 }, 37.9));
        }

        private bool Contains128<T>(T[] array, T value)
            where T : unmanaged
        {
            return new Vector<T>(array).AsVector128().Contains(value);
        }
        #endregion

        #region Contains256

        [Test]
        public void Contains256_True()
        {
            Assert.IsTrue(Contains256<byte>(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120
            }, 137));
            Assert.IsTrue(Contains256<sbyte>(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120
            }, -37));

            Assert.IsTrue(Contains256<ushort>(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 20 }, 20));
            Assert.IsTrue(Contains256<short>(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 15, -75, 42, 37, 79, 67, 7, 120 }, -20));

            Assert.IsTrue(Contains256<uint>(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 }, 79));
            Assert.IsTrue(Contains256<int>(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 }, 79));

            Assert.IsTrue(Contains256<ulong>(new ulong[] { 42, 37, 7, 120 }, 7));
            Assert.IsTrue(Contains256<long>(new long[] { 42, -37, 7, 120 }, 7));

            Assert.IsTrue(Contains256<float>(new float[] { 15, 75, 42, 37, 79, 67.9f, 7, 120 }, 67.9f));
            Assert.IsTrue(Contains256<double>(new double[] { 42, 37, 42, 37.98 }, 37.98));
        }

        [Test]
        public void Contains256_False()
        {
            Assert.IsFalse(Contains256<byte>(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120
            }, 13));
            Assert.IsFalse(Contains256<sbyte>(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120
            }, -3));

            Assert.IsFalse(Contains256<ushort>(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 20 }, 220));
            Assert.IsFalse(Contains256<short>(new short[] { 15, -75, 42, 37, 79, 67, 7, -20, 15, -75, 42, 37, 79, 67, 7, 120 }, -220));

            Assert.IsFalse(Contains256<uint>(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 }, 790));
            Assert.IsFalse(Contains256<int>(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 }, 790));

            Assert.IsFalse(Contains256<ulong>(new ulong[] { 42, 37, 7, 120 }, 795));
            Assert.IsFalse(Contains256<long>(new long[] { 42, -37, 7, 120 }, 0));

            Assert.IsFalse(Contains256<float>(new float[] { 15, 75, 42, 37, 79, 67.9f, 7, 120 }, 67.19f));
            Assert.IsFalse(Contains256<double>(new double[] { 42, 37, 42, 37.98 }, 37.9));
        }

        private bool Contains256<T>(T[] array, T value)
            where T : unmanaged
        {
            return new Vector<T>(array).AsVector256().Contains(value);
        }

        #endregion
    }
}
