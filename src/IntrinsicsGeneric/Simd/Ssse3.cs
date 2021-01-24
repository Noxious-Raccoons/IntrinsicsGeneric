using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

namespace IntrinsicsGeneric.Simd
{
    public abstract unsafe class Ssse3<T> : Sse2<T>
        where T : unmanaged
    {
        protected Ssse3() { }
        
        public new static bool IsSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Ssse3.IsSupported;
        }
    }
}