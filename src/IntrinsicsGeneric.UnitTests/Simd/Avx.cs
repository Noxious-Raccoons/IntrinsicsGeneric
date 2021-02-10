using IntrinsicsGeneric.Helpers;
using IntrinsicsGeneric.Simd;
using System.Runtime.Intrinsics;
using Xunit;

namespace IntrinsicsGeneric.UnitTests.Simd
{
    public class Avx
    {
        public Avx()
        {
            if (!System.Runtime.Intrinsics.X86.Avx.IsSupported)
            {
                LongLivedMarshalByRefObject.DisconnectAll();
            }
        }

        #region Load
        
        [Fact]
        public void LoadVector256Test()
        {
            LoadVector256(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120
            });
            LoadVector256(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120
            });

            LoadVector256(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120 });
            LoadVector256(new short[] { 15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120 });

            LoadVector256(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 });
            LoadVector256(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 });

            LoadVector256(new ulong[] { 42, 37, 7, 120 });
            LoadVector256(new long[] { 42, -37, 7, 120 });

            LoadVector256(new float[] { 15, 75, 42, 37, 79, 67, 7, 120 });
            LoadVector256(new double[] { 42, 37, 42, 37 });
        }

        private unsafe void LoadVector256<T>(T[] arr)
            where T : unmanaged
        {
            Assert.Equal(Vector256<T>.Count, arr.Length);
            fixed (T* ptr = arr)
            {
                var vector = Avx<T>.LoadVector256(ptr);
                for (var i = 0; i < Vector256<T>.Count; i++)
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
            Store(new byte[]
            {
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120,
                15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120
            });
            Store(new sbyte[]
            {
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120,
                15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120
            });

            Store(new ushort[] { 15, 75, 42, 37, 79, 67, 7, 120, 15, 75, 42, 37, 79, 67, 7, 120 });
            Store(new short[] { 15, -75, 42, 37, 79, 67, 7, 120, 15, -75, 42, 37, 79, 67, 7, 120 });

            Store(new uint[] { 15, 75, 42, 37, 79, 67, 7, 120 });
            Store(new int[] { 15, -75, 42, 37, 79, 67, 7, 120 });

            Store(new ulong[] { 42, 37, 7, 120 });
            Store(new long[] { 42, -37, 7, 120 });

            Store(new float[] { 15, 75, 42, 37, 79, 67, 7, 120 });
            Store(new double[] { 42, 37, 42, 37 });
        }

        private unsafe void Store<T>(T[] arr)
            where T : unmanaged
        {
            Assert.Equal(Vector256<T>.Count, arr.Length);

            var vector = VectorHelper<T>.CreateVector256(default);
            fixed (T* ptr = arr)
            {
                Avx<T>.Store(ptr, vector);
            }

            for (var i = 0; i < Vector256<T>.Count; i++)
            {
                Assert.Equal(default(T), arr[i]);
            }
        }

        #endregion
    }
}

