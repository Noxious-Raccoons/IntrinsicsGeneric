﻿using IntrinsicsGeneric.Extensions;
using IntrinsicsGeneric.Simd;
using NUnit.Framework;
using System.Runtime.Intrinsics;

namespace IntrinsicsGeneric.UnitTests.Simd
{
    [TestFixture]
    public class Sse2
    {
        public Sse2()
        {
            if (!System.Runtime.Intrinsics.X86.Sse2.IsSupported)
            {
                Assert.Inconclusive("Sse2 is not supported");
            }
        }

        #region Add

        [TestCase(1, 2)]
        [TestCase(1U, 2U)]
        [TestCase(1F, 2F)]
        [TestCase(1L, 2L)]
        [TestCase(1UL, 2UL)]
        [TestCase(1D, 2D)]
        [TestCase((short)1, (short)2)]
        [TestCase((ushort)1, (ushort)2)]
        [TestCase((byte)1, (byte)2)]
        [TestCase((sbyte)1, (sbyte)2)]
        public void Add<T>(T value, T expected)
            where T : unmanaged
        {
            var vector = VectorHelper<T>.CreateVector128(value);
            var expectedVector = VectorHelper<T>.CreateVector128(expected);

            var result = Sse2<T>.Add(vector, vector);

            Assert.AreEqual(expectedVector, result);
        }

        [TestCase(1, 2, 3)]
        [TestCase(1U, 2U, 3U)]
        [TestCase(1F, 2F, 3F)]
        [TestCase(1L, 2L, 3L)]
        [TestCase(1UL, 2UL, 3UL)]
        [TestCase(1D, 2D, 3D)]
        [TestCase((short)1, (short)2, (short)3)]
        [TestCase((ushort)1, (ushort)2, (ushort)3)]
        [TestCase((byte)1, (byte)2, (byte)3)]
        [TestCase((sbyte)1, (sbyte)2, (sbyte)3)]
        public void Add<T>(T a, T b, T expected)
            where T : unmanaged
        {
            var vectorA = VectorHelper<T>.CreateVector128(a);
            var vectorB = VectorHelper<T>.CreateVector128(b);
            var expectedVector = VectorHelper<T>.CreateVector128(expected);

            var result = Sse2<T>.Add(vectorA, vectorB);

            Assert.AreEqual(expectedVector, result);
        }

        #endregion

        #region And

        [TestCase((sbyte)1, (sbyte)0, (sbyte)0)]
        [TestCase((sbyte)1, (sbyte)1, (sbyte)1)]
        [TestCase((sbyte)0b1010, (sbyte)0b1010, (sbyte)0b1010)]
        [TestCase((sbyte)0b1010, (sbyte)0b0101, (sbyte)0)]
        [TestCase((sbyte)0b00101010, (sbyte)0b00101010, (sbyte)0b00101010)]
        [TestCase((sbyte)0b00101010, (sbyte)0b00111000, (sbyte)0b00101000)]
        [TestCase((byte)1, (byte)0, (byte)0)]
        [TestCase((byte)1, (byte)1, (byte)1)]
        [TestCase((byte)0b1010, (byte)0b1010, (byte)0b1010)]
        [TestCase((byte)0b1010, (byte)0b0101, (byte)0)]
        [TestCase((byte)0b10101010, (byte)0b10101010, (byte)0b10101010)]
        [TestCase((byte)0b10101010, (byte)0b00111010, (byte)0b00101010)]
        [TestCase((short)1, (short)0, (short)0)]
        [TestCase((short)1, (short)1, (short)1)]
        [TestCase((short)0b1010, (short)0b1010, (short)0b1010)]
        [TestCase((short)0b1010, (short)0b0101, (short)0)]
        [TestCase((short)0b10101010, (short)0b10101010, (short)0b10101010)]
        [TestCase((short)0b10101010, (short)0b00111010, (short)0b00101010)]
        [TestCase((ushort)1, (ushort)0, (ushort)0)]
        [TestCase((ushort)1, (ushort)1, (ushort)1)]
        [TestCase((ushort)0b1010, (ushort)0b1010, (ushort)0b1010)]
        [TestCase((ushort)0b1010, (ushort)0b0101, (ushort)0)]
        [TestCase((ushort)0b10101010, (ushort)0b10101010, (ushort)0b10101010)]
        [TestCase((ushort)0b10101010, (ushort)0b00111010, (ushort)0b00101010)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 1)]
        [TestCase(0b1010, 0b1010, 0b1010)]
        [TestCase(0b1010, 0b0101, 0)]
        [TestCase(0b10101010, 0b10101010, 0b10101010)]
        [TestCase(0b10101010, 0b00111010, 0b00101010)]
        [TestCase((uint)1, (uint)0, (uint)0)]
        [TestCase((uint)1, (uint)1, (uint)1)]
        [TestCase((uint)0b1010, (uint)0b1010, (uint)0b1010)]
        [TestCase((uint)0b1010, (uint)0b0101, (uint)0)]
        [TestCase((uint)0b10101010, (uint)0b10101010, (uint)0b10101010)]
        [TestCase((uint)0b10101010, (uint)0b00111010, (uint)0b00101010)]
        [TestCase((float)1, (float)0, (float)0)]
        [TestCase((float)1, (float)1, (float)1)]
        [TestCase((float)0b1010, (float)0b1010, (float)0b1010)]
        [TestCase((float)0b10101010, (float)0b10101010, (float)0b10101010)]
        [TestCase((float)0b10101010, (float)0b00111010, (float)0b00101010)]
        [TestCase((double)1, (double)0, (double)0)]
        [TestCase((double)1, (double)1, (double)1)]
        [TestCase((double)0b1010, (double)0b1010, (double)0b1010)]
        [TestCase((double)0b10101010, (double)0b10101010, (double)0b10101010)]
        [TestCase((double)0b10101010, (double)0b00111010, (double)0b00101010)]
        [TestCase((long)1, (long)0, (long)0)]
        [TestCase((long)1, (long)1, (long)1)]
        [TestCase((long)0b1010, (long)0b1010, (long)0b1010)]
        [TestCase((long)0b1010, (long)0b0101, (long)0)]
        [TestCase((long)0b10101010, (long)0b10101010, (long)0b10101010)]
        [TestCase((long)0b10101010, (long)0b00111010, (long)0b00101010)]
        [TestCase((ulong)1, (ulong)0, (ulong)0)]
        [TestCase((ulong)1, (ulong)1, (ulong)1)]
        [TestCase((ulong)0b1010, (ulong)0b1010, (ulong)0b1010)]
        [TestCase((ulong)0b1010, (ulong)0b0101, (ulong)0)]
        [TestCase((ulong)0b10101010, (ulong)0b10101010, (ulong)0b10101010)]
        [TestCase((ulong)0b10101010, (ulong)0b00111010, (ulong)0b00101010)]
        public void And<T>(T a, T b, T expected)
            where T : unmanaged
        {
            var vectorA = VectorHelper<T>.CreateVector128(a);
            var vectorB = VectorHelper<T>.CreateVector128(b);

            var expectedVector = VectorHelper<T>.CreateVector128(expected);

            var result = Sse2<T>.And(vectorA, vectorB);

            Assert.AreEqual(expectedVector, result);
        }

        [Test]
        public void AndFloat_Additional()
        {
            var vectorA = Vector128.Create(5F);
            var vectorB = Vector128.Create(10F);

            var expectedVector = System.Runtime.Intrinsics.X86.Sse.And(vectorA, vectorB);
            var result = Sse2<float>.And(vectorA, vectorB);

            Assert.AreEqual(expectedVector, result);
        }

        [Test]
        public void AndDouble_Additional()
        {
            var vectorA = Vector128.Create(5D);
            var vectorB = Vector128.Create(10D);

            var expectedVector = System.Runtime.Intrinsics.X86.Sse2.And(vectorA, vectorB);
            var result = Sse2<double>.And(vectorA, vectorB);

            Assert.AreEqual(expectedVector, result);
        }

        #endregion

        #region LoadVector128

        [Test]
        public void LoadVector128()
        {
            LoadVector128(new byte[] { 15, 75, 42, 37, 15, 75, 42, 37, 15, 75, 42, 37, 15, 75, 42, 37 });
            LoadVector128(new sbyte[] { 15, -75, 42, 37, 15, -75, 42, 37, 15, -75, 42, 37, 15, -75, 42, 37 });

            LoadVector128(new ushort[] { 15, 75, 42, 37, 15, 75, 42, 37 });
            LoadVector128(new short[] { 15, -75, 42, 37, 15, -75, 42, 37 });

            LoadVector128(new uint[] { 15, 75, 42, 37 });
            LoadVector128(new int[] { 15, -75, 42, 37 });

            LoadVector128(new ulong[] { 42, 37 });
            LoadVector128(new long[] { 42, -37 });

            LoadVector128(new float[] { 15, 75, 42, 37 });
            LoadVector128(new double[] { 42, 37 });
        }

        private unsafe void LoadVector128<T>(T[] arr)
            where T : unmanaged
        {
            Assert.AreEqual(Vector128<T>.Count, arr.Length);
            fixed (T* ptr = arr)
            {
                var vector = Sse2<T>.LoadVector128(ptr);
                for (var i = 0; i < Vector128<T>.Count; i++)
                {
                    Assert.AreEqual(vector.GetElement(i), arr[i]);
                }
            }
        }

        #endregion

        #region Store

        [Test]
        public void Store()
        {
            Store(new byte[] { 15, 75, 42, 37, 15, 75, 42, 37, 15, 75, 42, 37, 15, 75, 42, 37 });
            Store(new sbyte[] { 15, -75, 42, 37, 15, -75, 42, 37, 15, -75, 42, 37, 15, -75, 42, 37 });

            Store(new ushort[] { 15, 75, 42, 37, 15, 75, 42, 37 });
            Store(new short[] { 15, -75, 42, 37, 15, -75, 42, 37 });

            Store(new uint[] { 15, 75, 42, 37 });
            Store(new int[] { 15, -75, 42, 37 });

            Store(new ulong[] { 42, 37 });
            Store(new long[] { 42, -37 });

            Store(new float[] { 15, 75, 42, 37 });
            Store(new double[] { 42, 37 });
        }

        private unsafe void Store<T>(T[] arr)
            where T : unmanaged
        {
            Assert.AreEqual(Vector128<T>.Count, arr.Length);

            var vector = VectorHelper<T>.CreateVector128(default);
            fixed (T* ptr = arr)
            {
                Sse2<T>.Store(ptr, vector);
            }

            for (var i = 0; i < Vector128<T>.Count; i++)
            {
                Assert.AreEqual(default(T), arr[i]);
            }
        }

        #endregion

        #region Subtract

        [TestCase(1, 0)]
        [TestCase(1U, 0U)]
        [TestCase(1F, 0F)]
        [TestCase(1L, 0L)]
        [TestCase(1UL, 0UL)]
        [TestCase(1D, 0D)]
        [TestCase((short)1, (short)0)]
        [TestCase((ushort)1, (ushort)0)]
        [TestCase((byte)1, (byte)0)]
        [TestCase((sbyte)1, (sbyte)0)]
        public void Subtract<T>(T value, T expected)
            where T : unmanaged
        {
            var vector = VectorHelper<T>.CreateVector128(value);
            var expectedVector = VectorHelper<T>.CreateVector128(expected);

            var result = Sse2<T>.Subtract(vector, vector);

            Assert.AreEqual(expectedVector, result);
        }

        [TestCase(42, 2, 40)]
        [TestCase(3U, 2U, 1U)]
        [TestCase(3F, 2F, 1F)]
        [TestCase(3L, 2L, 1L)]
        [TestCase(3UL, 2UL, 1UL)]
        [TestCase(5D, 2D, 3D)]
        [TestCase((short)5, (short)2, (short)3)]
        [TestCase((ushort)5, (ushort)2, (ushort)3)]
        [TestCase((byte)5, (byte)2, (byte)3)]
        [TestCase((sbyte)5, (sbyte)2, (sbyte)3)]
        public void Subtract<T>(T a, T b, T expected)
            where T : unmanaged
        {
            var vectorA = VectorHelper<T>.CreateVector128(a);
            var vectorB = VectorHelper<T>.CreateVector128(b);
            var expectedVector = VectorHelper<T>.CreateVector128(expected);

            var result = Sse2<T>.Subtract(vectorA, vectorB);

            Assert.AreEqual(expectedVector, result);
        }

        #endregion
    }
}
