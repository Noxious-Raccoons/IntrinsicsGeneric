using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using IntrinsicsGeneric.Simd;

namespace IntrinsicsGeneric.Helpers
{
    public static unsafe partial class VectorHelper<T>
        where T : unmanaged
    {
        /// <summary>
        /// Determines whether a sequence contains a specified value through SIMD.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains(T[] array, T value)
        {
            if (array.Length < 1)
            {
                return false;
            }
            
            var i = 0;
            
            if (Avx2.IsSupported)
            {
                fixed (T* ptr = array)
                {
                    var size = Vector256<T>.Count;
                    var lastIndexBlock = array.Length - array.Length % size;
                
                    var elementVec = CreateVector256(value);
                
                    for (; i < lastIndexBlock; i += size)
                    {
                        var curr = Avx<T>.LoadVector256(ptr + i);
                        var mask = Avx2<T>.CompareEqual(curr, elementVec);
                    
                        if (!Avx<T>.TestAllZeros(mask, mask))
                        {
                            return true;
                        }
                    }
                }
            }
            else if (Sse41.IsSupported)
            {
                fixed (T* ptr = array)
                {
                    var size = Vector128<T>.Count;
                    var lastIndexBlock = array.Length - array.Length % size;
                
                    var elementVec = CreateVector128(value);
                
                    for (; i < lastIndexBlock; i += size)
                    {
                        Sse41<T>.Contains(Sse41<T>.LoadVector128(ptr + i), elementVec);
                    }
                }
            }
            else if (Sse2.IsSupported && 
                typeof(T) == typeof(byte) ||
                typeof(T) == typeof(sbyte) ||
                typeof(T) == typeof(float) ||
                typeof(T) == typeof(double))
            {
                fixed (T* ptr = array)
                {
                    var size = Vector128<T>.Count;
                    var lastIndexBlock = array.Length - array.Length % size;
                
                    var elementVec = CreateVector128(value);
                
                    for (; i < lastIndexBlock; i += size)
                    {
                        Sse2<T>.Contains(Sse2<T>.LoadVector128(ptr + i), elementVec);
                    }
                }
            }
            var comparer = Comparer<T>.Default;
            
            for (; i < (uint) array.Length; i++)
            {
                if (comparer.Compare(array[i], value) == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
