using System.Collections.Generic;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using IntrinsicsGeneric.Helpers;
using IntrinsicsGeneric.Simd;

namespace IntrinsicsGeneric.Extensions
{
    public static partial class VectorExtensions
    {
        /// <summary>
        /// Determines whether a sequence contains a specified value through SIMD.
        /// </summary>
        public static bool Contains<T>(this Vector256<T> vector, T value)
            where T : unmanaged
        {
            var element = VectorHelper<T>.CreateVector256(value);
            var mask = Avx2<T>.CompareEqual(vector, element);
            return !Avx<T>.TestAllZeros(mask, mask);
        }
        
        /// <summary>
        /// Determines whether a sequence contains a specified value through SIMD.
        /// </summary>
        public static bool Contains<T>(this Vector128<T> vector, T value)
            where T : unmanaged
        {
            if (Sse41.IsSupported)
            {
                return Sse41<T>.Contains(vector, value);
            }
            if (Sse2.IsSupported && 
                typeof(T) == typeof(byte) ||
                typeof(T) == typeof(sbyte) ||
                typeof(T) == typeof(float) ||
                typeof(T) == typeof(double))
            {
                return Sse2<T>.Contains(vector, value);
            }

            var comparer = Comparer<T>.Default;

            for (int i = 0; i < Vector256<T>.Count; i++)
            {
                if (comparer.Compare(vector.GetElement(i), value) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Determines whether a sequence contains a value in specified vector through SIMD.
        /// </summary>
        public static bool Contains<T>(this Vector128<T> vector, Vector128<T> value)
            where T : unmanaged
        {
            if (Sse41.IsSupported)
            {
                return Sse41<T>.Contains(vector, value);
            }

            if (Sse2.IsSupported && 
                typeof(T) == typeof(byte) ||
                typeof(T) == typeof(sbyte) ||
                typeof(T) == typeof(float) ||
                typeof(T) == typeof(double))
            {
                return Sse2<T>.Contains(vector, value);
            }

            var comparer = Comparer<T>.Default;

            for (int i = 0; i < Vector256<T>.Count; i++)
            {
                if (comparer.Compare(vector.GetElement(i), value.GetElement(i)) == 0)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}