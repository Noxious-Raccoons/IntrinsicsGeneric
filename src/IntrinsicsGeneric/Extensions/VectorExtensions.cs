using IntrinsicsGeneric.InternalHelpers;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace IntrinsicsGeneric.Extensions
{
    public static class VectorExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Sum<T>(this Vector128<T> vector)
            where T : unmanaged
        {
            var sum = default(T);
            for (var i = 0; i < Vector128<T>.Count; i++)
            {
                sum = MathUnsafe<T>.Add(sum, vector.GetElement(i));
            }

            return sum;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Sum<T>(Vector256<T> a)
            where T : unmanaged
        {
            var sum = default(T);
            for (var i = 0; i < Vector256<T>.Count; i++)
            {
                sum = MathUnsafe<T>.Add(sum, a.GetElement(i));
            }
            return sum;
        }
    }
}