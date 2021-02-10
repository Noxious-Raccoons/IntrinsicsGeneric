using IntrinsicsGeneric.Extensions;
using IntrinsicsGeneric.InternalHelpers;
using IntrinsicsGeneric.Simd;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace IntrinsicsGeneric.Helpers
{
    public static unsafe partial class VectorHelper<T>
        where T : unmanaged
    {
        /// <summary>
        /// Gets sum of array.
        /// </summary>
        /// <param name="array">array</param>
        /// <typeparam name="T">unmanaged type</typeparam>
        /// <returns>Sum of array</returns>
        public static T Sum(T[] array)
        {
            var length = array.Length;
            
            if (length < 1)
            {
                return default;
            }
            
            var i = 0;
            T result = default;
            
            fixed (T* ptr = array)
            {
                if (Sse2.IsSupported)
                {
                    result = SoftwareFallback(ptr, length, ref i);
                }
                
                for (; i < length; i++)
                {
                    result = MathUnsafe<T>.Add(result, *(ptr + i));
                }
            } 
            
            return result;
            
            static T SoftwareFallback(T* ptr, int length, ref int i)
            {
                var size = Vector128<T>.Count;
                    
                if (length < size)
                {
                    return Sum(ptr, length);
                }

                var temp = Vector128<T>.Zero;
                var lastIndexBlock = length - length % size;
                    
                for (; i < lastIndexBlock; i += size)
                {
                    temp = Sse2<T>.Add(temp, Sse2<T>.LoadVector128(ptr + i));
                }

                return temp.Sum();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T Sum(T* array, int count)
        {
            T sum = default;
            for (int i = 0; i < count; i++)
            {
                sum = MathUnsafe<T>.Add(sum, *(array + i));
            }
            return sum;
        }
    }
}
