using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace IntrinsicsGeneric.Helpers
{
    public static partial class VectorHelper<T>
        where T : unmanaged
    {
        /// <summary>
        /// Creates a new Vector128<T/> instance with each element initialized to the corresponding specified value.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Throws exception if SIMD instruction is not supported for current type.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector128<T> CreateVector128(T value)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Vector128.Create(Unsafe.As<T, sbyte>(ref value)).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Vector128.Create(Unsafe.As<T, byte>(ref value)).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Vector128.Create(Unsafe.As<T, short>(ref value)).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Vector128.Create(Unsafe.As<T, ushort>(ref value)).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Vector128.Create(Unsafe.As<T, int>(ref value)).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Vector128.Create(Unsafe.As<T, uint>(ref value)).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Vector128.Create(Unsafe.As<T, long>(ref value)).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Vector128.Create(Unsafe.As<T, ulong>(ref value)).As<ulong, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Vector128.Create(Unsafe.As<T, float>(ref value)).As<float, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Vector128.Create(Unsafe.As<T, double>(ref value)).As<double, T>();
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates a new Vector256<T/> instance with each element initialized to the corresponding specified value.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Throws exception if SIMD instruction is not supported for current type.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> CreateVector256(T value)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Vector256.Create(Unsafe.As<T, sbyte>(ref value)).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Vector256.Create(Unsafe.As<T, byte>(ref value)).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Vector256.Create(Unsafe.As<T, short>(ref value)).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Vector256.Create(Unsafe.As<T, ushort>(ref value)).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Vector256.Create(Unsafe.As<T, int>(ref value)).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Vector256.Create(Unsafe.As<T, uint>(ref value)).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Vector256.Create(Unsafe.As<T, long>(ref value)).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Vector256.Create(Unsafe.As<T, ulong>(ref value)).As<ulong, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Vector256.Create(Unsafe.As<T, float>(ref value)).As<float, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Vector256.Create(Unsafe.As<T, double>(ref value)).As<double, T>();
            }

            throw new NotSupportedException();
        }
        
        /// <summary>
        /// Creates a new Vector256<T/> instance with each element initialized to the corresponding specified value.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Throws exception if SIMD instruction is not supported for current type.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> CreateVector256(T e1, T e2, T e3, T e4, T e5, T e6, T e7, T e8,
            T e9,  T e10, T e11, T e12, T e13, T e14, T e15, T e16,
            T e17, T e18, T e19, T e20, T e21, T e22, T e23, T e24,
            T e25, T e26, T e27, T e28, T e29, T e30, T e31, T e32)
        {
            if (typeof(T) == typeof(byte))
            {
                return Vector256.Create(
                    Unsafe.As<T, byte>(ref e1),  Unsafe.As<T, byte>(ref e2),  Unsafe.As<T, byte>(ref e3),  Unsafe.As<T, byte>(ref e4),
                    Unsafe.As<T, byte>(ref e5),  Unsafe.As<T, byte>(ref e6),  Unsafe.As<T, byte>(ref e7),  Unsafe.As<T, byte>(ref e8),
                    Unsafe.As<T, byte>(ref e9),  Unsafe.As<T, byte>(ref e10), Unsafe.As<T, byte>(ref e11), Unsafe.As<T, byte>(ref e12),
                    Unsafe.As<T, byte>(ref e13), Unsafe.As<T, byte>(ref e14), Unsafe.As<T, byte>(ref e15), Unsafe.As<T, byte>(ref e16), 
                    Unsafe.As<T, byte>(ref e17), Unsafe.As<T, byte>(ref e18), Unsafe.As<T, byte>(ref e19), Unsafe.As<T, byte>(ref e20), 
                    Unsafe.As<T, byte>(ref e21), Unsafe.As<T, byte>(ref e22), Unsafe.As<T, byte>(ref e23), Unsafe.As<T, byte>(ref e24),
                    Unsafe.As<T, byte>(ref e25), Unsafe.As<T, byte>(ref e26), Unsafe.As<T, byte>(ref e27), Unsafe.As<T, byte>(ref e28),
                    Unsafe.As<T, byte>(ref e29), Unsafe.As<T, byte>(ref e30), Unsafe.As<T, byte>(ref e31), Unsafe.As<T, byte>(ref e32)
                ).As<byte, T>();
            }
            if (typeof(T) == typeof(sbyte))
            {
                return Vector256.Create(
                    Unsafe.As<T, sbyte>(ref e1),  Unsafe.As<T, sbyte>(ref e2),  Unsafe.As<T, sbyte>(ref e3),  Unsafe.As<T, sbyte>(ref e4),
                    Unsafe.As<T, sbyte>(ref e5),  Unsafe.As<T, sbyte>(ref e6),  Unsafe.As<T, sbyte>(ref e7),  Unsafe.As<T, sbyte>(ref e8),
                    Unsafe.As<T, sbyte>(ref e9),  Unsafe.As<T, sbyte>(ref e10), Unsafe.As<T, sbyte>(ref e11), Unsafe.As<T, sbyte>(ref e12),
                    Unsafe.As<T, sbyte>(ref e13), Unsafe.As<T, sbyte>(ref e14), Unsafe.As<T, sbyte>(ref e15), Unsafe.As<T, sbyte>(ref e16), 
                    Unsafe.As<T, sbyte>(ref e17), Unsafe.As<T, sbyte>(ref e18), Unsafe.As<T, sbyte>(ref e19), Unsafe.As<T, sbyte>(ref e20), 
                    Unsafe.As<T, sbyte>(ref e21), Unsafe.As<T, sbyte>(ref e22), Unsafe.As<T, sbyte>(ref e23), Unsafe.As<T, sbyte>(ref e24),
                    Unsafe.As<T, sbyte>(ref e25), Unsafe.As<T, sbyte>(ref e26), Unsafe.As<T, sbyte>(ref e27), Unsafe.As<T, sbyte>(ref e28),
                    Unsafe.As<T, sbyte>(ref e29), Unsafe.As<T, sbyte>(ref e30), Unsafe.As<T, sbyte>(ref e31), Unsafe.As<T, sbyte>(ref e32)
                ).As<sbyte, T>();
            }
            
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates a new Vector256<T/> instance with each element initialized to the corresponding specified value.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Throws exception if SIMD instruction is not supported for current type.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> CreateVector256(T e1, T e2, T e3, T e4, T e5, T e6, T e7, T e8,
            T e9, T e10, T e11, T e12, T e13, T e14, T e15, T e16)
        {
            if (typeof(T) == typeof(byte))
            {
                return Vector256.Create(
                    Unsafe.As<T, byte>(ref e1),  default,
                    Unsafe.As<T, byte>(ref e2),  default,
                    Unsafe.As<T, byte>(ref e3),  default, 
                    Unsafe.As<T, byte>(ref e4),  default,
                    Unsafe.As<T, byte>(ref e5),  default, 
                    Unsafe.As<T, byte>(ref e6),  default, 
                    Unsafe.As<T, byte>(ref e7),  default, 
                    Unsafe.As<T, byte>(ref e8),  default,
                    Unsafe.As<T, byte>(ref e9),  default, 
                    Unsafe.As<T, byte>(ref e10), default,
                    Unsafe.As<T, byte>(ref e11), default, 
                    Unsafe.As<T, byte>(ref e12), default,
                    Unsafe.As<T, byte>(ref e13), default, 
                    Unsafe.As<T, byte>(ref e14), default, 
                    Unsafe.As<T, byte>(ref e15), default,
                    Unsafe.As<T, byte>(ref e16), default
                ).As<byte, T>();
            }
            if (typeof(T) == typeof(sbyte))
            {
                return Vector256.Create(
                    Unsafe.As<T, sbyte>(ref e1),  default,
                    Unsafe.As<T, sbyte>(ref e2),  default,
                    Unsafe.As<T, sbyte>(ref e3),  default, 
                    Unsafe.As<T, sbyte>(ref e4),  default,
                    Unsafe.As<T, sbyte>(ref e5),  default, 
                    Unsafe.As<T, sbyte>(ref e6),  default, 
                    Unsafe.As<T, sbyte>(ref e7),  default, 
                    Unsafe.As<T, sbyte>(ref e8),  default,
                    Unsafe.As<T, sbyte>(ref e9),  default, 
                    Unsafe.As<T, sbyte>(ref e10), default,
                    Unsafe.As<T, sbyte>(ref e11), default, 
                    Unsafe.As<T, sbyte>(ref e12), default,
                    Unsafe.As<T, sbyte>(ref e13), default, 
                    Unsafe.As<T, sbyte>(ref e14), default, 
                    Unsafe.As<T, sbyte>(ref e15), default,
                    Unsafe.As<T, sbyte>(ref e16), default
                ).As<sbyte, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Vector256.Create(
                    Unsafe.As<T, ushort>(ref e1),
                    Unsafe.As<T, ushort>(ref e2),
                    Unsafe.As<T, ushort>(ref e3),
                    Unsafe.As<T, ushort>(ref e4),
                    Unsafe.As<T, ushort>(ref e5),
                    Unsafe.As<T, ushort>(ref e6),
                    Unsafe.As<T, ushort>(ref e7),
                    Unsafe.As<T, ushort>(ref e8),
                    Unsafe.As<T, ushort>(ref e9),
                    Unsafe.As<T, ushort>(ref e10),
                    Unsafe.As<T, ushort>(ref e11),
                    Unsafe.As<T, ushort>(ref e12),
                    Unsafe.As<T, ushort>(ref e13),
                    Unsafe.As<T, ushort>(ref e14),
                    Unsafe.As<T, ushort>(ref e15),
                    Unsafe.As<T, ushort>(ref e16)
                ).As<ushort, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Vector256.Create(
                    Unsafe.As<T, short>(ref e1),
                    Unsafe.As<T, short>(ref e2),
                    Unsafe.As<T, short>(ref e3),
                    Unsafe.As<T, short>(ref e4),
                    Unsafe.As<T, short>(ref e5),
                    Unsafe.As<T, short>(ref e6),
                    Unsafe.As<T, short>(ref e7),
                    Unsafe.As<T, short>(ref e8),
                    Unsafe.As<T, short>(ref e9),
                    Unsafe.As<T, short>(ref e10),
                    Unsafe.As<T, short>(ref e11),
                    Unsafe.As<T, short>(ref e12),
                    Unsafe.As<T, short>(ref e13),
                    Unsafe.As<T, short>(ref e14),
                    Unsafe.As<T, short>(ref e15),
                    Unsafe.As<T, short>(ref e16)
                ).As<short, T>();
            }
            throw new NotSupportedException();
        }
        
        /// <summary>
        /// Creates a new Vector256<T/> instance with each element initialized to the corresponding specified value.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Throws exception if SIMD instruction is not supported for current type.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> CreateVector256(T e1, T e2, T e3, T e4, T e5, T e6, T e7, T e8)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Vector256.Create(
                    Unsafe.As<T, sbyte>(ref e1), default, default, default,
                    Unsafe.As<T, sbyte>(ref e2), default, default, default,
                    Unsafe.As<T, sbyte>(ref e3), default, default, default,
                    Unsafe.As<T, sbyte>(ref e4), default, default, default,
                    Unsafe.As<T, sbyte>(ref e5), default, default, default,
                    Unsafe.As<T, sbyte>(ref e6), default, default, default,
                    Unsafe.As<T, sbyte>(ref e7), default, default, default,
                    Unsafe.As<T, sbyte>(ref e8), default, default, default
                ).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Vector256.Create(
                    Unsafe.As<T, byte>(ref e1), default, default, default,
                    Unsafe.As<T, byte>(ref e2), default, default, default,
                    Unsafe.As<T, byte>(ref e3), default, default, default,
                    Unsafe.As<T, byte>(ref e4), default, default, default,
                    Unsafe.As<T, byte>(ref e5), default, default, default,
                    Unsafe.As<T, byte>(ref e6), default, default, default,
                    Unsafe.As<T, byte>(ref e7), default, default, default,
                    Unsafe.As<T, byte>(ref e8), default, default, default
                ).As<byte, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Vector256.Create(
                    Unsafe.As<T, ushort>(ref e1), default,
                    Unsafe.As<T, ushort>(ref e2), default,
                    Unsafe.As<T, ushort>(ref e3), default,
                    Unsafe.As<T, ushort>(ref e4), default,
                    Unsafe.As<T, ushort>(ref e5), default,
                    Unsafe.As<T, ushort>(ref e6), default,
                    Unsafe.As<T, ushort>(ref e7), default,
                    Unsafe.As<T, ushort>(ref e8), default
                ).As<ushort, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Vector256.Create(
                    Unsafe.As<T, short>(ref e1), default,
                    Unsafe.As<T, short>(ref e2), default,
                    Unsafe.As<T, short>(ref e3), default,
                    Unsafe.As<T, short>(ref e4), default,
                    Unsafe.As<T, short>(ref e5), default,
                    Unsafe.As<T, short>(ref e6), default,
                    Unsafe.As<T, short>(ref e7), default,
                    Unsafe.As<T, short>(ref e8), default
                ).As<short, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Vector256.Create(
                    Unsafe.As<T, uint>(ref e1),
                    Unsafe.As<T, uint>(ref e2),
                    Unsafe.As<T, uint>(ref e3),
                    Unsafe.As<T, uint>(ref e4),
                    Unsafe.As<T, uint>(ref e5),
                    Unsafe.As<T, uint>(ref e6),
                    Unsafe.As<T, uint>(ref e7),
                    Unsafe.As<T, uint>(ref e8)
                ).As<uint, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Vector256.Create(
                    Unsafe.As<T, int>(ref e1),
                    Unsafe.As<T, int>(ref e2),
                    Unsafe.As<T, int>(ref e3),
                    Unsafe.As<T, int>(ref e4),
                    Unsafe.As<T, int>(ref e5),
                    Unsafe.As<T, int>(ref e6),
                    Unsafe.As<T, int>(ref e7),
                    Unsafe.As<T, int>(ref e8)
                ).As<int, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Vector256.Create(
                    Unsafe.As<T, float>(ref e1),
                    Unsafe.As<T, float>(ref e2),
                    Unsafe.As<T, float>(ref e3),
                    Unsafe.As<T, float>(ref e4),
                    Unsafe.As<T, float>(ref e5),
                    Unsafe.As<T, float>(ref e6),
                    Unsafe.As<T, float>(ref e7),
                    Unsafe.As<T, float>(ref e8)
                ).As<float, T>();
            }

            throw new NotSupportedException();
        }
        
        /// <summary>
        /// Creates a new Vector256<T/> instance with each element initialized to the corresponding specified value.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Throws exception if SIMD instruction is not supported for current type.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> CreateVector256(T e1, T e2, T e3, T e4)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Vector256.Create(
                    Unsafe.As<T, sbyte>(ref e1), default, default, default, default, default, default, default,
                    Unsafe.As<T, sbyte>(ref e2), default, default, default, default, default, default, default,
                    Unsafe.As<T, sbyte>(ref e2), default, default, default, default, default, default, default,
                    Unsafe.As<T, sbyte>(ref e4), default, default, default, default, default, default, default
                ).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Vector256.Create(
                    Unsafe.As<T, byte>(ref e1), default, default, default, default, default, default, default,
                    Unsafe.As<T, byte>(ref e2), default, default, default, default, default, default, default,
                    Unsafe.As<T, byte>(ref e2), default, default, default, default, default, default, default,
                    Unsafe.As<T, byte>(ref e4), default, default, default, default, default, default, default
                ).As<byte, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Vector256.Create(
                    Unsafe.As<T, ushort>(ref e1), default, default, default,
                    Unsafe.As<T, ushort>(ref e2), default, default, default,
                    Unsafe.As<T, ushort>(ref e2), default, default, default,
                    Unsafe.As<T, ushort>(ref e4), default, default, default
                ).As<ushort, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Vector256.Create(
                    Unsafe.As<T, short>(ref e1), default, default, default,
                    Unsafe.As<T, short>(ref e2), default, default, default,
                    Unsafe.As<T, short>(ref e2), default, default, default,
                    Unsafe.As<T, short>(ref e4), default, default, default
                ).As<short, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Vector256.Create(
                    Unsafe.As<T, int>(ref e1), default,
                    Unsafe.As<T, int>(ref e2), default,
                    Unsafe.As<T, int>(ref e2), default,
                    Unsafe.As<T, int>(ref e4), default
                ).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Vector256.Create(
                    Unsafe.As<T, uint>(ref e1), default,
                    Unsafe.As<T, uint>(ref e2), default,
                    Unsafe.As<T, uint>(ref e2), default,
                    Unsafe.As<T, uint>(ref e4), default
                ).As<uint, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Vector256.Create(
                    Unsafe.As<T, float>(ref e1), default,
                    Unsafe.As<T, float>(ref e2), default,
                    Unsafe.As<T, float>(ref e2), default,
                    Unsafe.As<T, float>(ref e4), default
                ).As<float, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Vector256.Create(
                    Unsafe.As<T, ulong>(ref e1),
                    Unsafe.As<T, ulong>(ref e2),
                    Unsafe.As<T, ulong>(ref e3),
                    Unsafe.As<T, ulong>(ref e4)
                ).As<ulong, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Vector256.Create(
                    Unsafe.As<T, long>(ref e1),
                    Unsafe.As<T, long>(ref e2),
                    Unsafe.As<T, long>(ref e3),
                    Unsafe.As<T, long>(ref e4)
                ).As<long, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Vector256.Create(
                    Unsafe.As<T, double>(ref e1),
                    Unsafe.As<T, double>(ref e2),
                    Unsafe.As<T, double>(ref e3),
                    Unsafe.As<T, double>(ref e4)
                ).As<double, T>();
            }

            throw new NotSupportedException();
        }
    }
}