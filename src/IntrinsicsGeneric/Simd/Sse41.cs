using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using IntrinsicsGeneric.Extensions;
using IntrinsicsGeneric.Helpers;

namespace IntrinsicsGeneric.Simd
{
    public abstract class Sse41<T> : Sse2<T>
        where T : unmanaged
    {
        protected Sse41() { }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public new static bool Contains(Vector128<T> vector, T value)
        {
            var element = VectorHelper<T>.CreateVector128(value);
            var mask = CompareEqual(vector, element);
            return !TestAllZeros(mask, mask);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public new static bool Contains(Vector128<T> vector, Vector128<T> value)
        {
            var mask = CompareEqual(vector, value);
            return !TestAllZeros(mask, mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public new static Vector128<T> CompareEqual(Vector128<T> va, Vector128<T> vb)
        {
            if (typeof(T) == typeof(long))
            {
                return Sse41.CompareEqual(va.As<T, long>(), vb.As<T, long>()).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Sse41.CompareEqual(va.As<T, ulong>(), vb.As<T, ulong>()).As<ulong, T>();
            }
            
            return Sse2<T>.CompareEqual(va, vb);
        }
        
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TestAllOnes(Vector128<T> va, Vector128<T> vb)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Sse41.TestC(va.As<T, sbyte>(), vb.As<T, sbyte>());
            }
            if (typeof(T) == typeof(byte))
            {
                return Sse41.TestC(va.As<T, byte>(), vb.As<T, byte>());
            }
            if (typeof(T) == typeof(short))
            {
                return Sse41.TestC(va.As<T, short>(), vb.As<T, short>());
            }
            if (typeof(T) == typeof(ushort))
            {
                return Sse41.TestC(va.As<T, ushort>(), vb.As<T, ushort>());
            }
            if (typeof(T) == typeof(int))
            {
                return Sse41.TestC(va.As<T, int>(), vb.As<T, int>());
            }
            if (typeof(T) == typeof(uint))
            {
                return Sse41.TestC(va.As<T, uint>(), vb.As<T, uint>());
            }
            if (typeof(T) == typeof(long))
            {
                return Sse41.TestC(va.As<T, long>(), vb.As<T, long>());
            }
            if (typeof(T) == typeof(ulong))
            {
                return Sse41.TestC(va.As<T, ulong>(), vb.As<T, ulong>());
            }
            
            throw new NotSupportedException();
        }
    }
}