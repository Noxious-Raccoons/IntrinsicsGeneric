using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace IntrinsicsGeneric.Extensions
{
    public class VectorHelper<T>
        where T : unmanaged
    {
        public static Vector256<T> AllBitsSet128
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if NET5_0
                return Vector256<T>.AllBitsSet;
#elif NETCOREAPP3_1
                return Vector256.Create(0xFFFFFFFF).As<uint, T>();
#endif
            }
        }

        public static Vector128<T> AllBitsSet256
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if NET5_0
                return Vector128<T>.AllBitsSet;
#elif NETCOREAPP3_1
                return Vector128.Create(0xFFFFFFFF).As<uint, T>();
#endif
            }
        }
    }
}