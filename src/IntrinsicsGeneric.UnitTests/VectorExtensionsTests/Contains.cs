using IntrinsicsGeneric.Extensions;
using IntrinsicsGeneric.Helpers;
using Xunit;

namespace IntrinsicsGeneric.UnitTests.VectorExtensionsTests
{
    public class Contains
    {
        [Fact]
        public void Contains256_True()
        {
            var vByte = VectorHelper<byte>.CreateVector256(
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120);
            
            var vSbyte = VectorHelper<sbyte>.CreateVector256(
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120);
            
            var vUshort = VectorHelper<ushort>.CreateVector256(
                15, 20, 42, 37, 79, 67, 7, 120, 15, 13, 42, 37, 79, 67, 7, 120);
            
            var vShort = VectorHelper<short>.CreateVector256(
                15, 20, 42, 37, 79, 67, 7, 120, -15, 13, 42, 37, 79, 67, 7, 120);
            
            var vInt = VectorHelper<int>.CreateVector256(-15, 20, 42, 37, 79, 67, 7, 120);
            var vUInt = VectorHelper<uint>.CreateVector256(15, 20, 42, 37, 79, 67, 7, 120);
            var vFloat = VectorHelper<float>.CreateVector256(15, 20, 42, 37, 79, 67.9f, 7, 120);
            var vDouble = VectorHelper<double>.CreateVector256(15, 12.9d, 42, 37);
            var vLong = VectorHelper<long>.CreateVector256(-15, 20, 42, 37);
            var vULong = VectorHelper<ulong>.CreateVector256(15, 20, 42, 37);
            
            Assert.True(vByte.Contains<byte>(120));
            Assert.True(vSbyte.Contains<sbyte>(-75));
            Assert.True(vUshort.Contains<ushort>(7));
            Assert.True(vShort.Contains<short>(-15));
            Assert.True(vUInt.Contains<uint>(7));
            Assert.True(vULong.Contains<ulong>(20));
            Assert.True(vLong.Contains(42));
            Assert.True(vInt.Contains(-15));
            Assert.True(vFloat.Contains(67.9f));
            Assert.True(vDouble.Contains(12.9d));
        }
        
        [Fact]
        public void Contains256_False()
        {
            var vByte = VectorHelper<byte>.CreateVector256(
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 137, 79, 67, 7, 120);
            
            var vSbyte = VectorHelper<sbyte>.CreateVector256(
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, -37, 79, 67, 7, 120);
            
            var vUshort = VectorHelper<ushort>.CreateVector256(
                15, 20, 42, 37, 79, 67, 7, 120, 15, 13, 42, 37, 79, 67, 7, 120);
            
            var vShort = VectorHelper<short>.CreateVector256(
                15, 20, 42, 37, 79, 67, 7, 120, -15, 13, 42, 37, 79, 67, 7, 120);
            
            var vInt = VectorHelper<int>.CreateVector256(-15, 20, 42, 37, 79, 67, 7, 120);
            var vUInt = VectorHelper<uint>.CreateVector256(15, 20, 42, 37, 79, 67, 7, 120);
            var vFloat = VectorHelper<float>.CreateVector256(15, 20, 42, 37, 79, 67.9f, 7, 120);
            var vDouble = VectorHelper<double>.CreateVector256(15, 12.9d, 42, 37);
            var vLong = VectorHelper<long>.CreateVector256(-15, 20, 42, 37);
            var vULong = VectorHelper<ulong>.CreateVector256(15, 20, 42, 37);
            
            Assert.False(vByte.Contains<byte>(74));
            Assert.False(vSbyte.Contains<sbyte>(-74));
            Assert.False(vUshort.Contains<ushort>(6));
            Assert.False(vShort.Contains<short>(9));
            Assert.False(vUInt.Contains<uint>(11));
            Assert.False(vULong.Contains<ulong>(12));
            Assert.False(vLong.Contains(44));
            Assert.False(vInt.Contains(-44));
            Assert.False(vFloat.Contains(68.9f));
            Assert.False(vDouble.Contains(1.4d));
        }
    }
}
