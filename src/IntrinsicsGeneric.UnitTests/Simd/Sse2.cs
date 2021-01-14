using IntrinsicsGeneric.Simd;
using NUnit.Framework;
using System.Runtime.Intrinsics;

namespace IntrinsicsGeneric.UnitTests.Simd
{
    [TestFixture]
    public class Sse2
    {
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
            var vector = Simd<T>.CreateVector128(value);
            var expectedVector = Simd<T>.CreateVector128(expected);

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
            var vectorA = Simd<T>.CreateVector128(a);
            var vectorB = Simd<T>.CreateVector128(b);
            var expectedVector = Simd<T>.CreateVector128(expected);

            var result = Sse2<T>.Add(vectorA, vectorB);

            Assert.AreEqual(expectedVector, result);
        }

        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(0b1010, 0b1010)]
        [TestCase(0b1010, 0b0101)]
        [TestCase(0b10101010, 0b10101010)]
        [TestCase(0b10101010, 0b00111010)]
        public void AndInt(int a, int b)
        {
            var vectorA = Vector128.Create(a);
            var vectorB = Vector128.Create(b);

            var expectedVector = System.Runtime.Intrinsics.X86.Sse2.And(vectorA, vectorB);

            var result = Sse2<int>.And(vectorA, vectorB);
            
            Assert.AreEqual(expectedVector, result);
        }

        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(0b1010, 0b1010)]
        [TestCase(0b1010, 0b0101)]
        [TestCase(0b10101010, 0b10101010)]
        [TestCase(0b10101010, 0b00111010)]
        public void AndLong(long a, long b)
        {
            var vectorA = Vector128.Create(a);
            var vectorB = Vector128.Create(b);

            var expectedVector = System.Runtime.Intrinsics.X86.Sse2.And(vectorA, vectorB);

            var result = Sse2<long>.And(vectorA, vectorB);
            
            Assert.AreEqual(expectedVector, result);
        }

        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(0b1010, 0b1010)]
        [TestCase(0b1010, 0b0101)]
        [TestCase(0b10101010, 0b10101010)]
        [TestCase(0b10101010, 0b00111010)]
        public void AndShort(short a, short b)
        {
            var vectorA = Vector128.Create(a);
            var vectorB = Vector128.Create(b);

            var expectedVector = System.Runtime.Intrinsics.X86.Sse2.And(vectorA, vectorB);

            var result = Sse2<short>.And(vectorA, vectorB);
            
            Assert.AreEqual(expectedVector, result);
        }

        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(0b1010, 0b1010)]
        [TestCase(0b1010, 0b0101)]
        public void AndByte(byte a, byte b)
        {
            var vectorA = Vector128.Create(a);
            var vectorB = Vector128.Create(b);

            var expectedVector = System.Runtime.Intrinsics.X86.Sse2.And(vectorA, vectorB);

            var result = Sse2<byte>.And(vectorA, vectorB);
            
            Assert.AreEqual(expectedVector, result);
        }
    }
}