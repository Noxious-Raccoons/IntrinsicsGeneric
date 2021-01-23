using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace IntrinsicsGeneric.Simd
{
    public abstract unsafe class Sse2<T>
        where T : unmanaged
    {
        protected Sse2() { }

        /// <para>Synopsis:</para>
        /// <para>__m128i _mm_add_epi8 (__m128i a, __m128i b)</para>
        /// PADDB xmm, xmm/m128
        /// <para>CPUID Flags: SSE2</para>
        /// <remarks>
        /// <para>Description:</para>
        /// Add packed 8-bit integers in a and b, and store the results in dst.
        /// </remarks>
        /// <code>
        /// Operation:
        /// FOR j := 0 to 15
        /// >> i := j*8
        /// >> dst[i+7:i] := a[i+7:i] + b[i+7:i]
        /// ENDFOR
        /// </code>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector128<T> Add(Vector128<T> va, Vector128<T> vb)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Sse2.Add(va.As<T, sbyte>(), vb.As<T, sbyte>()).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Sse2.Add(va.As<T, byte>(), vb.As<T, byte>()).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Sse2.Add(va.As<T, short>(), vb.As<T, short>()).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Sse2.Add(va.As<T, ushort>(), vb.As<T, ushort>()).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Sse2.Add(va.As<T, int>(), vb.As<T, int>()).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Sse2.Add(va.As<T, uint>(), vb.As<T, uint>()).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Sse2.Add(va.As<T, long>(), vb.As<T, long>()).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Sse2.Add(va.As<T, ulong>(), vb.As<T, ulong>()).As<ulong, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Sse2.Add(va.As<T, double>(), vb.As<T, double>()).As<double, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Sse.Add(va.As<T, float>(), vb.As<T, float>()).As<float, T>();
            }

            throw new NotSupportedException();
        }

        /// <para>Synopsis:</para>
        /// <para>__m128i _mm_add_epi8 (__m128i a, __m128i b)</para>
        /// PAND xmm, xmm/m128
        /// <para>CPUID Flags: SSE2</para>
        /// <remarks>
        /// <para>Description:</para>
        /// Compute the bitwise AND of 128 bits (representing integer data) in a and b, and store the result in dst.
        /// </remarks>
        /// <code>
        /// Operation:
        /// dst[127:0] := (a[127:0] AND b[127:0])
        /// </code>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector128<T> And(Vector128<T> va, Vector128<T> vb)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Sse2.And(va.As<T, sbyte>(), vb.As<T, sbyte>()).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Sse2.And(va.As<T, byte>(), vb.As<T, byte>()).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Sse2.And(va.As<T, short>(), vb.As<T, short>()).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Sse2.And(va.As<T, ushort>(), vb.As<T, ushort>()).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Sse2.And(va.As<T, int>(), vb.As<T, int>()).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Sse2.And(va.As<T, uint>(), vb.As<T, uint>()).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Sse2.And(va.As<T, long>(), vb.As<T, long>()).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Sse2.And(va.As<T, ulong>(), vb.As<T, ulong>()).As<ulong, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Sse2.And(va.As<T, double>(), vb.As<T, double>()).As<double, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Sse.And(va.As<T, float>(), vb.As<T, float>()).As<float, T>();
            }

            throw new NotSupportedException();
        }

        /// <para>Synopsis:</para>
        /// <para>__m128i _mm_loadu_si128 (__m128i const* mem_addr)</para>
        /// PMOVDQU xmm, m128
        /// <para>CPUID Flags: SSE2</para>
        /// <remarks>
        /// <para>Description:</para>
        /// Load 128-bits of integer data from memory into dst. mem_addr does not need to be aligned on any particular boundary.
        /// </remarks>
        /// <code>
        /// Operation:
        /// dst[127:0] := MEM[mem_addr+127:mem_addr]
        /// </code>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector128<T> LoadVector128(T* address)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Sse2.LoadVector128((sbyte*)address).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Sse2.LoadVector128((byte*)address).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Sse2.LoadVector128((short*)address).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Sse2.LoadVector128((ushort*)address).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Sse2.LoadVector128((int*)address).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Sse2.LoadVector128((uint*)address).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Sse2.LoadVector128((long*)address).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Sse2.LoadVector128((ulong*)address).As<ulong, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Sse2.LoadVector128((double*)address).As<double, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Sse.LoadVector128((float*)address).As<float, T>();
            }

            throw new NotSupportedException();
        }

        /// <para>Synopsis:</para>
        /// <para>void _mm_storeu_si128 (__m128i* mem_addr, __m128i a)</para>
        /// MOVDQU m128, xmm
        /// <para>CPUID Flags: SSE2</para>
        /// <remarks>
        /// <para>Description:</para>
        /// Store 128-bits of integer data from a into memory. mem_addr does not need to be aligned on any particular boundary.
        /// </remarks>
        /// <code>
        /// Operation:
        /// MEM[mem_addr+127:mem_addr] := a[127:0]
        /// </code>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Store(T* address, Vector128<T> source)
        {
            if (typeof(T) == typeof(sbyte))
            {
                Sse2.Store((sbyte*)address, source.As<T, sbyte>());
            }
            else if (typeof(T) == typeof(byte))
            {
                Sse2.Store((byte*)address, source.As<T, byte>());
            }
            else if (typeof(T) == typeof(short))
            {
                Sse2.Store((short*)address, source.As<T, short>());
            }
            else if (typeof(T) == typeof(ushort))
            {
                Sse2.Store((ushort*)address, source.As<T, ushort>());
            }
            else if (typeof(T) == typeof(int))
            {
                Sse2.Store((int*)address, source.As<T, int>());
            }
            else if (typeof(T) == typeof(uint))
            {
                Sse2.Store((uint*)address, source.As<T, uint>());
            }
            else if (typeof(T) == typeof(long))
            {
                Sse2.Store((long*)address, source.As<T, long>());
            }
            else if (typeof(T) == typeof(ulong))
            {
                Sse2.Store((ulong*)address, source.As<T, ulong>());
            }
            else if (typeof(T) == typeof(double))
            {
                Sse2.Store((double*)address, source.As<T, double>());
            }
            else if (typeof(T) == typeof(float))
            {
                Sse.Store((float*)address, source.As<T, float>());
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <para>Synopsis:</para>
        /// <para>__m128i _mm_sub_epi8 (__m128i a, __m128i b)</para>
        /// PSUBB xmm, xmm/m128
        /// <para>CPUID Flags: SSE2</para>
        /// <remarks>
        /// <para>Description:</para>
        /// Subtract packed X-bit integers in a and b, and store the results in dst.
        /// </remarks>
        /// <code>
        /// Operation:
        /// FOR j := 0 to 15
        /// >> i := j*8
        /// >> dst[i+7:i] := a[i+7:i] - b[i+7:i]
        /// ENDFOR
        /// </code>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector128<T> Subtract(Vector128<T> va, Vector128<T> vb)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Sse2.Subtract(va.As<T, sbyte>(), vb.As<T, sbyte>()).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Sse2.Subtract(va.As<T, byte>(), vb.As<T, byte>()).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Sse2.Subtract(va.As<T, short>(), vb.As<T, short>()).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Sse2.Subtract(va.As<T, ushort>(), vb.As<T, ushort>()).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Sse2.Subtract(va.As<T, int>(), vb.As<T, int>()).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Sse2.Subtract(va.As<T, uint>(), vb.As<T, uint>()).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Sse2.Subtract(va.As<T, long>(), vb.As<T, long>()).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Sse2.Subtract(va.As<T, ulong>(), vb.As<T, ulong>()).As<ulong, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Sse2.Subtract(va.As<T, double>(), vb.As<T, double>()).As<double, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Sse.Subtract(va.As<T, float>(), vb.As<T, float>()).As<float, T>();
            }

            throw new NotSupportedException();
        }
    }
}
