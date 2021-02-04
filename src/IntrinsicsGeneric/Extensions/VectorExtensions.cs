using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Numerics;

namespace IntrinsicsGeneric.Extensions
{
    public static partial class VectorExtensions
    {
        /// <summary>
        /// Converts Vector128<T/> to BitArray.
        /// </summary>
        public static unsafe BitArray ToBitArray<T>(this Vector128<T> vector)
            where T : unmanaged
        {
            var bytes = new List<byte>(sizeof(T) * Vector128<T>.Count);

            for (int i = 0; i < Vector128<T>.Count; i++)
            {
                bytes.AddRange(GetBytes(vector.GetElement(i)));
            }

            return new BitArray(bytes.ToArray());
        }

        /// <summary>
        /// Converts Vector256<T/> to BitArray.
        /// </summary>
        public static unsafe BitArray ToBitArray<T>(this Vector256<T> vector)
            where T : unmanaged
        {
            var bytes = new List<byte>(sizeof(T) * Vector256<T>.Count);

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
        
        /// <summary>
        /// Converts Vector<T/> to Vector128<T/>.
        /// </summary>
        public static Vector128<T> AsVector128<T>(this Vector<T> value)
            where T : struct
        {
            return Unsafe.As<Vector<T>, Vector128<T>>(ref value);
        }

        /// <summary>
        /// Converts Vector<T/> to Vector256<T/>.
        /// </summary>
        public static Vector256<T> AsVector256<T>(this Vector<T> value)
            where T : struct
        {
            return Unsafe.As<Vector<T>, Vector256<T>>(ref value);
        }
    }
}
