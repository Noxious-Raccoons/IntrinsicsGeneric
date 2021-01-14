using System;
using System.Runtime.CompilerServices;

namespace IntrinsicsGeneric.InternalHelpers
{
    internal static class MathUnsafe<T>
        where T : unmanaged
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Add(T left, T right)
        {
            if (typeof(T) == typeof(float))
            {
                var sum = Unsafe.As<T, float>(ref left) + Unsafe.As<T, float>(ref right);
                return Unsafe.As<float, T>(ref sum);
            }
            if (typeof(T) == typeof(double))
            {
                var sum = Unsafe.As<T, double>(ref left) + Unsafe.As<T, double>(ref right);
                return Unsafe.As<double, T>(ref sum);
            }
            if (typeof(T) == typeof(decimal))
            {
                var sum = Unsafe.As<T, decimal>(ref left) + Unsafe.As<T, decimal>(ref right);
                return Unsafe.As<decimal, T>(ref sum);
            }

            if (typeof(T) == typeof(int))
            {
                var sum = Unsafe.As<T, int>(ref left) + Unsafe.As<T, int>(ref right);
                return Unsafe.As<int, T>(ref sum);
            }
            if (typeof(T) == typeof(uint))
            {
                var sum = Unsafe.As<T, uint>(ref left) + Unsafe.As<T, uint>(ref right);
                return Unsafe.As<uint, T>(ref sum);
            }

            if (typeof(T) == typeof(long))
            {
                var sum = Unsafe.As<T, long>(ref left) + Unsafe.As<T, long>(ref right);
                return Unsafe.As<long, T>(ref sum);
            }
            if (typeof(T) == typeof(ulong))
            {
                var sum = Unsafe.As<T, ulong>(ref left) + Unsafe.As<T, ulong>(ref right);
                return Unsafe.As<ulong, T>(ref sum);
            }

            if (typeof(T) == typeof(short))
            {
                var sum = Unsafe.As<T, short>(ref left) + Unsafe.As<T, short>(ref right);
                return Unsafe.As<int, T>(ref sum);
            }
            if (typeof(T) == typeof(ushort))
            {
                var sum = Unsafe.As<T, ushort>(ref left) + Unsafe.As<T, ushort>(ref right);
                return Unsafe.As<int, T>(ref sum);
            }

            if (typeof(T) == typeof(sbyte))
            {
                var sum = Unsafe.As<T, sbyte>(ref left) + Unsafe.As<T, sbyte>(ref right);
                return Unsafe.As<int, T>(ref sum);
            }
            if (typeof(T) == typeof(byte))
            {
                var sum = Unsafe.As<T, byte>(ref left) + Unsafe.As<T, byte>(ref right);
                return Unsafe.As<int, T>(ref sum);
            }

            throw new NotSupportedException();
        }
    }
}
