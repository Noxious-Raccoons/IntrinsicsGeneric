using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace IntrinsicsGeneric.Extensions
{
    public class VectorHelper<T>
        where T : unmanaged
    {
        protected VectorHelper() { }

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

        public static Vector128<T> RandomBitsSet128
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var random = new Random();
                var a1 = random.Next();
                var a2 = random.Next();
                var a3 = random.Next();
                var a4 = random.Next();

                return Vector128.Create(a1, a2, a3, a4).As<int, T>();
            }
        }

        public static Vector256<T> RandomBitsSet256
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var random = new Random();
                var a1 = random.Next();
                var a2 = random.Next();
                var a3 = random.Next();
                var a4 = random.Next();
                var a5 = random.Next();
                var a6 = random.Next();
                var a7 = random.Next();
                var a8 = random.Next();

                return Vector256.Create(a1, a2, a3, a4, a5, a6, a7, a8).As<int, T>();
            }
        }
    }
}
