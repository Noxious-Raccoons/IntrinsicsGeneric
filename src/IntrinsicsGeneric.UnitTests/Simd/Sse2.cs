﻿using IntrinsicsGeneric.Helpers;
using IntrinsicsGeneric.Simd;
using System.Runtime.Intrinsics;
using Xunit;

namespace IntrinsicsGeneric.UnitTests.Simd
{
    public class Sse2
    {
        public Sse2()
        {
            if (!System.Runtime.Intrinsics.X86.Sse2.IsSupported)
            {
                LongLivedMarshalByRefObject.DisconnectAll();
            }
        }
        #region Add
        
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(1U, 2U, 3U)]
        [InlineData(1F, 2F, 3F)]
        [InlineData(1L, 2L, 3L)]
        [InlineData(1UL, 2UL, 3UL)]
        [InlineData(1D, 2D, 3D)]
        [InlineData((short)1, (short)2, (short)3)]
        [InlineData((ushort)1, (ushort)2, (ushort)3)]
        [InlineData((byte)1, (byte)2, (byte)3)]
        [InlineData((sbyte)1, (sbyte)2, (sbyte)3)]
        public void Add<T>(T a, T b, T expected)
            where T : unmanaged
        {
            var vectorA = VectorHelper<T>.CreateVector128(a);
            var vectorB = VectorHelper<T>.CreateVector128(b);
            var expectedVector = VectorHelper<T>.CreateVector128(expected);

            var result = Sse2<T>.Add(vectorA, vectorB);

            Assert.Equal(expectedVector, result);
        }

        #endregion

        #region And

        [Theory]
        [InlineData((sbyte)1, (sbyte)0, (sbyte)0)]
        [InlineData((sbyte)1, (sbyte)1, (sbyte)1)]
        [InlineData((sbyte)0b1010, (sbyte)0b1010, (sbyte)0b1010)]
        [InlineData((sbyte)0b1010, (sbyte)0b0101, (sbyte)0)]
        [InlineData((sbyte)0b00101010, (sbyte)0b00101010, (sbyte)0b00101010)]
        [InlineData((sbyte)0b00101010, (sbyte)0b00111000, (sbyte)0b00101000)]
        [InlineData((byte)1, (byte)0, (byte)0)]
        [InlineData((byte)1, (byte)1, (byte)1)]
        [InlineData((byte)0b1010, (byte)0b1010, (byte)0b1010)]
        [InlineData((byte)0b1010, (byte)0b0101, (byte)0)]
        [InlineData((byte)0b10101010, (byte)0b10101010, (byte)0b10101010)]
        [InlineData((byte)0b10101010, (byte)0b00111010, (byte)0b00101010)]
        [InlineData((short)1, (short)0, (short)0)]
        [InlineData((short)1, (short)1, (short)1)]
        [InlineData((short)0b1010, (short)0b1010, (short)0b1010)]
        [InlineData((short)0b1010, (short)0b0101, (short)0)]
        [InlineData((short)0b10101010, (short)0b10101010, (short)0b10101010)]
        [InlineData((short)0b10101010, (short)0b00111010, (short)0b00101010)]
        [InlineData((ushort)1, (ushort)0, (ushort)0)]
        [InlineData((ushort)1, (ushort)1, (ushort)1)]
        [InlineData((ushort)0b1010, (ushort)0b1010, (ushort)0b1010)]
        [InlineData((ushort)0b1010, (ushort)0b0101, (ushort)0)]
        [InlineData((ushort)0b10101010, (ushort)0b10101010, (ushort)0b10101010)]
        [InlineData((ushort)0b10101010, (ushort)0b00111010, (ushort)0b00101010)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(0b1010, 0b1010, 0b1010)]
        [InlineData(0b1010, 0b0101, 0)]
        [InlineData(0b10101010, 0b10101010, 0b10101010)]
        [InlineData(0b10101010, 0b00111010, 0b00101010)]
        [InlineData((uint)1, (uint)0, (uint)0)]
        [InlineData((uint)1, (uint)1, (uint)1)]
        [InlineData((uint)0b1010, (uint)0b1010, (uint)0b1010)]
        [InlineData((uint)0b1010, (uint)0b0101, (uint)0)]
        [InlineData((uint)0b10101010, (uint)0b10101010, (uint)0b10101010)]
        [InlineData((uint)0b10101010, (uint)0b00111010, (uint)0b00101010)]
        [InlineData((float)1, (float)0, (float)0)]
        [InlineData((float)1, (float)1, (float)1)]
        [InlineData((float)0b1010, (float)0b1010, (float)0b1010)]
        [InlineData((float)0b10101010, (float)0b10101010, (float)0b10101010)]
        [InlineData((float)0b10101010, (float)0b00111010, (float)0b00101010)]
        [InlineData((double)1, (double)0, (double)0)]
        [InlineData((double)1, (double)1, (double)1)]
        [InlineData((double)0b1010, (double)0b1010, (double)0b1010)]
        [InlineData((double)0b10101010, (double)0b10101010, (double)0b10101010)]
        [InlineData((double)0b10101010, (double)0b00111010, (double)0b00101010)]
        [InlineData((long)1, (long)0, (long)0)]
        [InlineData((long)1, (long)1, (long)1)]
        [InlineData((long)0b1010, (long)0b1010, (long)0b1010)]
        [InlineData((long)0b1010, (long)0b0101, (long)0)]
        [InlineData((long)0b10101010, (long)0b10101010, (long)0b10101010)]
        [InlineData((long)0b10101010, (long)0b00111010, (long)0b00101010)]
        [InlineData((ulong)1, (ulong)0, (ulong)0)]
        [InlineData((ulong)1, (ulong)1, (ulong)1)]
        [InlineData((ulong)0b1010, (ulong)0b1010, (ulong)0b1010)]
        [InlineData((ulong)0b1010, (ulong)0b0101, (ulong)0)]
        [InlineData((ulong)0b10101010, (ulong)0b10101010, (ulong)0b10101010)]
        [InlineData((ulong)0b10101010, (ulong)0b00111010, (ulong)0b00101010)]
        public void And<T>(T a, T b, T expected)
            where T : unmanaged
        {
            var vectorA = VectorHelper<T>.CreateVector128(a);
            var vectorB = VectorHelper<T>.CreateVector128(b);

            var expectedVector = VectorHelper<T>.CreateVector128(expected);

            var result = Sse2<T>.And(vectorA, vectorB);

            Assert.Equal(expectedVector, result);
        }

        [Fact]
        public void AndFloat_Additional()
        {
            var vectorA = Vector128.Create(5F);
            var vectorB = Vector128.Create(10F);

            var expectedVector = System.Runtime.Intrinsics.X86.Sse.And(vectorA, vectorB);
            var result = Sse2<float>.And(vectorA, vectorB);

            Assert.Equal(expectedVector, result);
        }

        [Fact]
        public void AndDouble_Additional()
        {
            var vectorA = Vector128.Create(5D);
            var vectorB = Vector128.Create(10D);

            var expectedVector = System.Runtime.Intrinsics.X86.Sse2.And(vectorA, vectorB);
            var result = Sse2<double>.And(vectorA, vectorB);

            Assert.Equal(expectedVector, result);
        }

        #endregion

        #region LoadVector128

        [Fact]
        public void LoadVector128Test()
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
            Assert.Equal(Vector128<T>.Count, arr.Length);
            fixed (T* ptr = arr)
            {
                var vector = Sse2<T>.LoadVector128(ptr);
                for (var i = 0; i < Vector128<T>.Count; i++)
                {
                    Assert.Equal(vector.GetElement(i), arr[i]);
                }
            }
        }

        #endregion

        #region Store

        [Fact]
        public void StoreTest()
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
            Assert.Equal(Vector128<T>.Count, arr.Length);

            var vector = VectorHelper<T>.CreateVector128(default);
            fixed (T* ptr = arr)
            {
                Sse2<T>.Store(ptr, vector);
            }

            for (var i = 0; i < Vector128<T>.Count; i++)
            {
                Assert.Equal(default(T), arr[i]);
            }
        }

        #endregion

        #region Subtract

        [Theory]
        [InlineData(42, 2, 40)]
        [InlineData(3U, 2U, 1U)]
        [InlineData(3F, 2F, 1F)]
        [InlineData(3L, 2L, 1L)]
        [InlineData(3UL, 2UL, 1UL)]
        [InlineData(5D, 2D, 3D)]
        [InlineData((short)5, (short)2, (short)3)]
        [InlineData((ushort)5, (ushort)2, (ushort)3)]
        [InlineData((byte)5, (byte)2, (byte)3)]
        [InlineData((sbyte)5, (sbyte)2, (sbyte)3)]
        public void Subtract<T>(T a, T b, T expected)
            where T : unmanaged
        {
            var vectorA = VectorHelper<T>.CreateVector128(a);
            var vectorB = VectorHelper<T>.CreateVector128(b);
            var expectedVector = VectorHelper<T>.CreateVector128(expected);

            var result = Sse2<T>.Subtract(vectorA, vectorB);

            Assert.Equal(expectedVector, result);
        }

        #endregion
    }
}
