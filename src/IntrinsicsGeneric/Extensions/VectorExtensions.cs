using IntrinsicsGeneric.InternalHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
//#if NETCOREAPP3_1
using System.Diagnostics;
using System.Numerics;
using IntrinsicsGeneric.Simd;

//#endif

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
        public static T Sum<T>(this Vector256<T> a)
            where T : unmanaged
        {
            var sum = default(T);
            for (var i = 0; i < Vector256<T>.Count; i++)
            {
                sum = MathUnsafe<T>.Add(sum, a.GetElement(i));
            }
            return sum;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<T>(this Vector128<T> vector, T value)
            where T : unmanaged
        {
            bool result = false;
            for (var i = 0; i < Vector128<T>.Count && !result; i++)
            {
                result = vector.GetElement(i).Equals(value);
            }

            return result;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool Contains<T>(T[] array, T value)
            where T : unmanaged
        {
            if (array.Length < 1)
            {
                return false;
            }
            
            fixed (T* ptr = array)
            {
                var i = 0;
                var size = Vector256<T>.Count;
                var lastIndexBlock = array.Length - array.Length % size;
                
                var elementVec = VectorHelper<T>.CreateVector256(value);
                
                for (; i < lastIndexBlock; i += size)
                {
                    var curr = Avx<T>.LoadVector256(ptr + i);
                    var mask = Avx2<T>.CompareEqual(curr, elementVec);
                    
                    if (!Avx<T>.TestZ(mask, mask))
                    {
                        return true;
                    }
                }
                
                
                var comparer = Comparer<T>.Default;
                
                for (; i < array.Length; i++)
                {
                    if (comparer.Compare(array[i], value) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public static bool Contains<T>(this Vector256<T> vector, T value)
            where T : unmanaged
        {
            bool result = false;
            for (var i = 0; i < Vector256<T>.Count && !result; i++)
            {
                result = vector.GetElement(i).Equals(value);
            }

            return result;
        }

        public static unsafe BitArray ToBitArray<T>(this Vector128<T> vector)
            where T : unmanaged
        {
            List<byte> bytes = new List<byte>(sizeof(T) * Vector128<T>.Count);

            for (int i = 0; i < Vector128<T>.Count; i++)
            {
                bytes.AddRange(GetBytes(vector.GetElement(i)));
            }

            return new BitArray(bytes.ToArray());
        }

        public static unsafe BitArray ToBitArray<T>(this Vector256<T> vector)
            where T : unmanaged
        {
            List<byte> bytes = new List<byte>(sizeof(T) * Vector256<T>.Count);

            for (int i = 0; i < Vector256<T>.Count; i++)
            {
                bytes.AddRange(GetBytes(vector.GetElement(i)));
            }

            return new BitArray(bytes.ToArray());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte[] GetBytes<T>(T value)
            where T : unmanaged
        {
            if (typeof(T) == typeof(float))
            {
                return BitConverter.GetBytes(Unsafe.As<T, float>(ref value));
            }
            if (typeof(T) == typeof(double))
            {
                return BitConverter.GetBytes(Unsafe.As<T, double>(ref value));
            }

            if (typeof(T) == typeof(int))
            {
                return BitConverter.GetBytes(Unsafe.As<T, int>(ref value));
            }
            if (typeof(T) == typeof(uint))
            {
                return BitConverter.GetBytes(Unsafe.As<T, uint>(ref value));
            }

            if (typeof(T) == typeof(long))
            {
                return BitConverter.GetBytes(Unsafe.As<T, long>(ref value));
            }
            if (typeof(T) == typeof(ulong))
            {
                return BitConverter.GetBytes(Unsafe.As<T, ulong>(ref value));
            }

            if (typeof(T) == typeof(short))
            {
                return BitConverter.GetBytes(Unsafe.As<T, short>(ref value));
            }
            if (typeof(T) == typeof(ushort))
            {
                return BitConverter.GetBytes(Unsafe.As<T, ushort>(ref value));
            }

            if (typeof(T) == typeof(sbyte))
            {
                return new[] { (byte)Unsafe.As<T, sbyte>(ref value) };
            }
            if (typeof(T) == typeof(byte))
            {
                return new[] { Unsafe.As<T, byte>(ref value) };
            }

            throw new NotSupportedException();
        }

//#if NETCOREAPP3_1

        public static Vector128<T> AsVector128<T>(this Vector<T> value)
            where T : struct
        {
            Debug.Assert(Vector<T>.Count >= Vector128<T>.Count);
            return Unsafe.As<Vector<T>, Vector128<T>>(ref value);
        }

        public static Vector256<T> AsVector256<T>(this Vector<T> value)
            where T : struct
        {
            Debug.Assert(Vector256<T>.Count >= Vector<T>.Count);

            //Vector256<T> result = default;
            //Unsafe.WriteUnaligned(ref Unsafe.As<Vector256<T>, byte>(ref result), value);
            //return result;
            return Unsafe.As<Vector<T>, Vector256<T>>(ref value);
        }
//#endif
    }
}
