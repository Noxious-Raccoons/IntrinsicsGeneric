using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using Xunit;

namespace IntrinsicsGeneric.UnitTests
{
    public class XUnitTest
    {
#if NET5_0
        [Fact]
        public void AllBitsSet256X()
        {
            // Arrange
            BitArray expected = new BitArray(256);
            expected.SetAll(true);
            
            List<byte> bytes = new List<byte>(sizeof(byte) * Vector256<byte>.Count);
            Vector256<byte> vector = Vector256<byte>.AllBitsSet;
            
            // Act
            for (int i = 0; i < Vector256<byte>.Count; i++)
            {
                var element = vector.GetElement(i);
                bytes.AddRange(new[] { Unsafe.As<byte, byte>(ref element) });
            }
            
            BitArray actual = new BitArray(bytes.ToArray());
            
            // Assert
            Assert.True(actual.Cast<bool>().All(b => b));
            Assert.Equal(expected, actual);
        }
#endif
    }
}