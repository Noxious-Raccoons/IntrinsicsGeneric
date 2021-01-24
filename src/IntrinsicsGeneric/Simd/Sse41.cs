using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace IntrinsicsGeneric.Simd
{
    public abstract unsafe class Sse41<T> : Sse2<T>
        where T : unmanaged
    {
        protected Sse41() { }
        
        public new static bool IsSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Sse41.IsSupported;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector128<T> CompareEqual(Vector128<T> va, Vector128<T> vb)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Sse2.CompareEqual(va.As<T, sbyte>(), vb.As<T, sbyte>()).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Sse2.CompareEqual(va.As<T, byte>(), vb.As<T, byte>()).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Sse2.CompareEqual(va.As<T, short>(), vb.As<T, short>()).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Sse2.CompareEqual(va.As<T, ushort>(), vb.As<T, ushort>()).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Sse2.CompareEqual(va.As<T, int>(), vb.As<T, int>()).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Sse2.CompareEqual(va.As<T, uint>(), vb.As<T, uint>()).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Sse41.CompareEqual(va.As<T, long>(), vb.As<T, long>()).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Sse41.CompareEqual(va.As<T, ulong>(), vb.As<T, ulong>()).As<ulong, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Sse.CompareEqual(va.As<T, float>(), vb.As<T, float>()).As<float, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Sse2.CompareEqual(va.As<T, double>(), vb.As<T, double>()).As<double, T>();
            }

            throw new NotSupportedException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TestZ(Vector128<T> va, Vector128<T> vb)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Sse41.TestZ(va.As<T, sbyte>(), vb.As<T, sbyte>());
            }
            if (typeof(T) == typeof(byte))
            {
                return Sse41.TestZ(va.As<T, byte>(), vb.As<T, byte>());
            }
            if (typeof(T) == typeof(short))
            {
                return Sse41.TestZ(va.As<T, short>(), vb.As<T, short>());
            }
            if (typeof(T) == typeof(ushort))
            {
                return Sse41.TestZ(va.As<T, ushort>(), vb.As<T, ushort>());
            }
            if (typeof(T) == typeof(int))
            {
                return Sse41.TestZ(va.As<T, int>(), vb.As<T, int>());
            }
            if (typeof(T) == typeof(uint))
            {
                return Sse41.TestZ(va.As<T, uint>(), vb.As<T, uint>());
            }
            if (typeof(T) == typeof(long))
            {
                return Sse41.TestZ(va.As<T, long>(), vb.As<T, long>());
            }
            if (typeof(T) == typeof(ulong))
            {
                return Sse41.TestZ(va.As<T, ulong>(), vb.As<T, ulong>());
            }
            
            throw new NotSupportedException();
        }
    }
}