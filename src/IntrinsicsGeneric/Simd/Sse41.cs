using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace IntrinsicsGeneric.Simd
{
    public abstract class Sse41<T> : Sse2<T>
        where T : unmanaged
    {
        protected Sse41() { }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TestAllZeros(Vector128<T> va, Vector128<T> vb)
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