using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace IntrinsicsGeneric.Simd
{
    public abstract class Fma<T> : Avx<T>
        where T : unmanaged
    {
        protected Fma() { }

        /// <para>Synopsis:</para>
        /// <para>__m256i _mm256_add_epi8 (__m256i a, __m256i b)</para>
        /// VPADDB ymm, ymm, ymm/m256
        /// <para>CPUID Flags: AVX2, AVX(float, double)</para>
        /// <remarks>
        /// <para>Description:</para>
        /// Multiply packed double-precision (32/64-bit) floating-point elements in a and b,
        /// add the intermediate result to packed elements in c, and store the results in dst.
        /// </remarks>
        /// <code>
        /// Operation:
        /// FOR j := 0 to 1
        /// >> i := j * BIT
        /// >> dst[i+BIT-1:i] := (a[i+BIT-1:i] * b[i+BIT-1:i]) + c[i+BIT-1:i]
        /// ENDFOR
        /// dst[MAX:128] := 0
        /// </code>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector128<T> MultiplyAdd(Vector128<T> a, Vector128<T> b, Vector128<T> c)
        {
            if (typeof(T) == typeof(float))
            {
                return Fma.MultiplyAdd(a.As<T, float>(), b.As<T, float>(), c.As<T, float>()).As<float, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Fma.MultiplyAdd(a.As<T, double>(), b.As<T, double>(), c.As<T, double>()).As<double, T>();
            }

            Sse2.X64.ConvertScalarToVector128Double(a.As<T, double>(), 15);
            throw new NotSupportedException();
        }
    }
}
