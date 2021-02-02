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

            throw new NotSupportedException();
        }
    }
}
