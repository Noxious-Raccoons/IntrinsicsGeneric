using IntrinsicsGeneric.Simd;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace IntrinsicsGeneric.Extensions
{
    public static unsafe class VectorHelper<T>
        where T : unmanaged
    {
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
                byte[] bytes = new byte[16];
                random.NextBytes(bytes);

                fixed (byte* ptr = bytes)
                {
                    return Sse2<byte>.LoadVector128(ptr).As<byte, T>();
                }
            }
        }

        public static Vector256<T> RandomBitsSet256
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var random = new Random();
                byte[] bytes = new byte[32];
                random.NextBytes(bytes);

                fixed (byte* ptr = bytes)
                {
                    return Avx2<byte>.LoadVector256(ptr).As<byte, T>();
                }
            }
        }
    }
}
