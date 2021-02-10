using System.Runtime.Intrinsics;
using IntrinsicsGeneric.Extensions;
using IntrinsicsGeneric.Helpers;
using Xunit;
using Xunit.Sdk;

namespace IntrinsicsGeneric.UnitTests.VectorExtensionsTests.Sse2
{
    public class Contains
    {
        public Contains()
        {
            if (!System.Runtime.Intrinsics.X86.Sse2.IsSupported)
            {
                TestSkipped.DisconnectAll();
            }
        }
        
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
            var vByte = Vector128.Create(15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120).AsByte();
            var vSByte = Vector128.Create(15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120).AsSByte();
            
            var vUshort = Vector128.Create(15, 75, 42, 37, 79, 67, 7, 120).AsUInt16();
            var vShort = Vector128.Create(15, 75, 42, 37, 79, 67, 7, 120).AsInt16();
            
            var vInt = Vector128.Create(15, 75, 42, 37);
            var vUInt = Vector128.Create(15, 75, 42, 37).AsUInt32();
            
            var vFloat= Vector128.Create(15, 75, 61.1f, 37).AsSingle();
            var vDouble = Vector128.Create(12.9d, 37).AsDouble();
            
            var vLong = Vector128.Create(12, 37).AsInt64();
            var vULong = Vector128.Create(12, 10).AsUInt64();
            
            Assert.False(vByte.Contains<byte>(74));
            Assert.False(vSByte.Contains<sbyte>(-74));
            Assert.False(vUshort.Contains<ushort>(6));
            Assert.False(vShort.Contains<short>(9));
            Assert.False(vUInt.Contains<uint>(10));
            Assert.False(vULong.Contains<ulong>(11));
            Assert.False(vLong.Contains(44));
            Assert.False(vInt.Contains(-44));
            Assert.False(vFloat.Contains(68.9f));
            Assert.False(vDouble.Contains(1.4d));
        }
    }
}