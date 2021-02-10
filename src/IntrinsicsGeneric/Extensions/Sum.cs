using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using IntrinsicsGeneric.InternalHelpers;

namespace IntrinsicsGeneric.Extensions
{
    public static partial class VectorExtensions
    {
        /// <summary>
        /// Gets sum of Vector128<T/>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Sum<T>(this Vector128<T> va)
            where T : unmanaged
        {
            if (typeof(T) == typeof(sbyte))
            {
                return SumVector128(va);
            }
            if (typeof(T) == typeof(byte))
            {
                return SumVector128(va);
            }
            if (typeof(T) == typeof(short))
            {
                if (Ssse3.IsSupported)
                { 
                    var sum = va.As<T, short>();
                    sum = Ssse3.HorizontalAdd(sum, sum);
                    sum = Ssse3.HorizontalAdd(sum, sum); 
                    sum = Ssse3.HorizontalAdd(sum, sum);
                    return sum.As<short, T>().ToScalar();
                }
                return SumVector128(va);
            }
            if (typeof(T) == typeof(ushort))
            {
                return SumVector128(va);
            }
            if (typeof(T) == typeof(int))
            {
                if (Ssse3.IsSupported)
                {
                    var sum = va.As<T, int>();
                    sum = Ssse3.HorizontalAdd(sum, sum);
                    sum = Ssse3.HorizontalAdd(sum, sum);
                    return sum.As<int, T>().ToScalar();
                }
                return HorizontalSumVector128(va);
            }
            if (typeof(T) == typeof(uint))
            {
                return HorizontalSumVector128(va);
            }
            if (typeof(T) == typeof(long))
            {
                return MathUnsafe<T>.Add(va.GetElement(0), va.GetElement(1));
            }
            if (typeof(T) == typeof(ulong))
            {
                return MathUnsafe<T>.Add(va.GetElement(0), va.GetElement(1));
            }
            if (typeof(T) == typeof(float))
            {
                if (Sse3.IsSupported)
                {
                    var sum = va.As<T, float>();
                    sum = Sse3.HorizontalAdd(sum, sum);
                    sum = Sse3.HorizontalAdd(sum, sum);
                    return sum.As<float, T>().ToScalar();
                }
                return HorizontalSumVector128(va);
            }
            if (typeof(T) == typeof(double))
            {
                if (Sse3.IsSupported)
                {
                    var sum = va.As<T, double>();
                    sum = Sse3.HorizontalAdd(sum, sum);
                    return sum.As<double, T>().ToScalar();
                }
                return MathUnsafe<T>.Add(va.GetElement(0), va.GetElement(1));
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets sum of Vector256<T/>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Sum<T>(this Vector256<T> a)
            where T : unmanaged
        {
            var sum = default(T);
            for (var i = 0; i < (uint) Vector256<T>.Count; i++)
            {
                sum = MathUnsafe<T>.Add(sum, a.GetElement(i));
            }
            return sum;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T HorizontalSumVector128<T>(Vector128<T> a)
            where T : unmanaged
        {
            var vb = a.As<T, float>();
            var shuf = Sse.Shuffle(vb, vb, 177);
            var sums = Sse.Add(vb, shuf);
            shuf = Sse.MoveHighToLow(shuf, sums);
            sums = Sse.AddScalar(sums, shuf);
            return sums.As<float, T>().ToScalar();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T SumVector128<T>(Vector128<T> a)
            where T : unmanaged
        {
            var sum = default(T);
            for (var i = 0; i < (uint) Vector128<T>.Count; i++)
            {
                sum = MathUnsafe<T>.Add(sum, a.GetElement(i));
            }
            return sum;
        }
    }
}
