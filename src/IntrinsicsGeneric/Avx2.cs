using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace IntrinsicsGeneric
{
    public abstract class Avx2<T> : Sse2<T>
        where T : unmanaged
    {
        internal Avx2() { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> Add(Vector256<T> va, Vector256<T> vb)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Avx2.Add(va.As<T, sbyte>(), vb.As<T, sbyte>()).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Avx2.Add(va.As<T, byte>(), vb.As<T, byte>()).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Avx2.Add(va.As<T, short>(), vb.As<T, short>()).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Avx2.Add(va.As<T, ushort>(), vb.As<T, ushort>()).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Avx2.Add(va.As<T, int>(), vb.As<T, int>()).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Avx2.Add(va.As<T, uint>(), vb.As<T, uint>()).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Avx2.Add(va.As<T, long>(), vb.As<T, long>()).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Avx2.Add(va.As<T, ulong>(), vb.As<T, ulong>()).As<ulong, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Avx.Add(va.As<T, float>(), vb.As<T, float>()).As<float, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Avx.Add(va.As<T, double>(), vb.As<T, double>()).As<double, T>();
            }

            throw new NotSupportedException();
        }
    }
}
