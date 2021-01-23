using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace IntrinsicsGeneric.Simd
{
    public abstract class Avx2<T> : Avx<T>
        where T : unmanaged
    {
        protected Avx2() { }

        /// <para>Synopsis:</para>
        /// <para>__m256i _mm256_add_epi8 (__m256i a, __m256i b)</para>
        /// VPADDB ymm, ymm, ymm/m256
        /// <para>CPUID Flags: AVX2, AVX(float, double)</para>
        /// <remarks>
        /// <para>Description:</para>
        /// Add packed X-bit integers in a and b, and store the results in dst.
        /// </remarks>
        /// <code>
        /// Operation:
        /// FOR j := 0 to BIT - 1
        /// >> i := j * VECTOR_SIZE - 1
        /// >> dst[i+VECTOR_SIZE-1:i]] := a[i+VECTOR_SIZE-1:i] + b[i+VECTOR_SIZE-1:i]]
        /// ENDFOR
        /// dst[MAX:256] := 0
        /// </code>
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

        /// <para>Synopsis:</para>
        /// __m256i _mm256_and_si256 (__m256i a, __m256i b)
        /// <para>VPAND ymm, ymm, ymm/m256</para>
        /// <para>CPUID Flags: AVX2, AVX(float, double)</para>
        /// <remarks>
        /// <para>Description:</para>
        /// Compute the bitwise AND of 256 bits (representing integer data) in a and b, and store the result in dst.
        /// </remarks>
        /// <code>
        /// Operation:
        /// dst[255:0] := (a[255:0] AND b[255:0])
        /// dst[MAX:256] := 0
        /// </code>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> And(Vector256<T> va, Vector256<T> vb)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Avx2.And(va.As<T, sbyte>(), vb.As<T, sbyte>()).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Avx2.And(va.As<T, byte>(), vb.As<T, byte>()).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Avx2.And(va.As<T, short>(), vb.As<T, short>()).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Avx2.And(va.As<T, ushort>(), vb.As<T, ushort>()).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Avx2.And(va.As<T, int>(), vb.As<T, int>()).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Avx2.And(va.As<T, uint>(), vb.As<T, uint>()).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Avx2.And(va.As<T, long>(), vb.As<T, long>()).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Avx2.And(va.As<T, ulong>(), vb.As<T, ulong>()).As<ulong, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Avx.And(va.As<T, float>(), vb.As<T, float>()).As<float, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Avx.And(va.As<T, double>(), vb.As<T, double>()).As<double, T>();
            }

            throw new NotSupportedException();
        }

        /// <para>Synopsis:</para>
        /// __m256i _mm256_sub_epi8 (__m256i a, __m256i b)
        /// <para>VPAND ymm, ymm, ymm/m256</para>
        /// <para>CPUID Flags: AVX2, AVX(float, double)</para>
        /// <remarks>
        /// <para>Description:</para>
        /// Subtract packed 8-bit integers in b from packed 8-bit integers in a, and store the results in dst.
        /// </remarks>
        /// <code>
        /// FOR j := 0 to BIT - 1
        /// >> i := j * i + VECTOR_SIZE - 1
        /// >> dst[i+VECTOR_SIZE-1:i] := a[i+VECTOR_SIZE-1:i] - b[i+VECTOR_SIZE-1:i]
        /// ENDFOR
        /// dst[MAX:256] := 0
        /// </code>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> Subtract(Vector256<T> va, Vector256<T> vb)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Avx2.Subtract(va.As<T, sbyte>(), vb.As<T, sbyte>()).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Avx2.Subtract(va.As<T, byte>(), vb.As<T, byte>()).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Avx2.Subtract(va.As<T, short>(), vb.As<T, short>()).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Avx2.Subtract(va.As<T, ushort>(), vb.As<T, ushort>()).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Avx2.Subtract(va.As<T, int>(), vb.As<T, int>()).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Avx2.Subtract(va.As<T, uint>(), vb.As<T, uint>()).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Avx2.Subtract(va.As<T, long>(), vb.As<T, long>()).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Avx2.Subtract(va.As<T, ulong>(), vb.As<T, ulong>()).As<ulong, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Avx.Subtract(va.As<T, float>(), vb.As<T, float>()).As<float, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Avx.Subtract(va.As<T, double>(), vb.As<T, double>()).As<double, T>();
            }

            throw new NotSupportedException();
        }
    }
}
