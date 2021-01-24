using System.Runtime.CompilerServices;

namespace IntrinsicsGeneric.InternalHelpers
{
    internal static class TypeHelper<T>
        where T : unmanaged
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsFloatingPoint()
        {
            return typeof(T) == typeof(double) ||
                   typeof(T) == typeof(float);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsSupport32Bit()
        {
            return typeof(T) == typeof(byte) ||
                   typeof(T) == typeof(sbyte) ||
                   typeof(T) == typeof(short) ||
                   typeof(T) == typeof(ushort) ||
                   typeof(T) == typeof(int) ||
                   typeof(T) == typeof(uint);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsSupportInteger()
        {
            return typeof(T) == typeof(byte) ||
                   typeof(T) == typeof(sbyte) ||
                   typeof(T) == typeof(short) ||
                   typeof(T) == typeof(ushort) ||
                   typeof(T) == typeof(int) ||
                   typeof(T) == typeof(uint) ||
                   typeof(T) == typeof(long) ||
                   typeof(T) == typeof(ulong);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsSupport64Bit()
        {
            return typeof(T) == typeof(byte) ||
                   typeof(T) == typeof(sbyte) ||
                   typeof(T) == typeof(short) ||
                   typeof(T) == typeof(ushort) ||
                   typeof(T) == typeof(int) ||
                   typeof(T) == typeof(uint) ||
                   typeof(T) == typeof(long) ||
                   typeof(T) == typeof(ulong);
        }
    }
}