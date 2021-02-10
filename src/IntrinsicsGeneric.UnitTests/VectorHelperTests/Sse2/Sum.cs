using IntrinsicsGeneric.Extensions;
using IntrinsicsGeneric.Helpers;
using Xunit;
using Xunit.Sdk;

namespace IntrinsicsGeneric.UnitTests.VectorHelperTests.Sse2
{
    public class Sum
    {
        public Sum()
        {
            if (!System.Runtime.Intrinsics.X86.Sse2.IsSupported)
            {
                TestSkipped.DisconnectAll();
            }
        }
        
        [Fact]
        public void ResultOfSumShouldBeEqualExpectedValue()
        {
            // Arrange
            var vInt = VectorHelper<int>.CreateVector128(1);
            var vByte = VectorHelper<byte>.CreateVector128(1);
            var vSByte = VectorHelper<sbyte>.CreateVector128(1);
            var vUshort = VectorHelper<ushort>.CreateVector128(1);
            var vUInt = VectorHelper<uint>.CreateVector128(1);
            var vFloat = VectorHelper<float>.CreateVector128(1);
            
            // Act Assert
            Assert.Equal(4, vInt.Sum());
            Assert.Equal(16, vByte.Sum());
            Assert.Equal(16, vSByte.Sum());
            Assert.Equal(8, vUshort.Sum());
            Assert.Equal((uint) 4, vUInt.Sum());
            Assert.Equal(4, vFloat.Sum());
        }
    }
}