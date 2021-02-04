using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using IntrinsicsGeneric.Simd;

namespace IntrinsicsGeneric.Helpers
{
    public static unsafe partial class VectorHelper<T>
        where T : unmanaged
    {
        /// <summary>
        /// Gets a new Vector128<T/> with all bits set to 1. 
        /// </summary>
        public static Vector128<T> AllBitsSet128
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if NETCOREAPP3_1
                return Vector128.Create(0xFFFFFFFF).As<uint, T>();
#else
                return Vector128<T>.AllBitsSet;
#endif
            }
        }

        /// <summary>
        /// Gets a new Vector256<T/> with all bits set to 1. 
        /// </summary>
        public static Vector256<T> AllBitsSet256
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if NETCOREAPP3_1
                return Vector256.Create(0xFFFFFFFF).As<uint, T>();
#else
                return Vector256<T>.AllBitsSet;
#endif
            }
        }

        /// <summary>
        /// Gets a new Vector128<T/> with random values. 
        /// </summary>
        public static Vector128<T> RandomBitsSet128
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var random = new Random();
                byte[] bytes = new byte[16];
                random.NextBytes(bytes);

                fixed (byte* ptr = bytes)
                {
                    return Sse2<byte>.LoadVector128(ptr).As<byte, T>();
                }
            }
        }

        /// <summary>
        /// Gets a new Vector256<T/> with random values. 
        /// </summary>
        public static Vector256<T> RandomBitsSet256
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var random = new Random();
                byte[] bytes = new byte[32];
                random.NextBytes(bytes);

                fixed (byte* ptr = bytes)
                {
                    return Avx<byte>.LoadVector256(ptr).As<byte, T>();
                }
            }
        }
    }
}
