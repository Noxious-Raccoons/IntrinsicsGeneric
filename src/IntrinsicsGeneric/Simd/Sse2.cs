using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using IntrinsicsGeneric.Extensions;
using IntrinsicsGeneric.Helpers;

namespace IntrinsicsGeneric.Simd
{
    public abstract unsafe class Sse2<T>
        where T : unmanaged
    {
        protected Sse2() { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains(Vector128<T> vector, T value)
        {
            var element = VectorHelper<T>.CreateVector128(value);
            var mask = CompareEqual(vector, element);
            return MoveMask(mask) != 0xFFFF;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains(Vector128<T> vector, Vector128<T> value)
        {
            var mask = CompareEqual(vector, value);
            return MoveMask(mask) != 0xFFFF;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MoveMask(Vector128<T> a)
        {
            if (typeof(T) == typeof(byte))
            {
                return Sse2.MoveMask(a.As<T, byte>());
            }
            if (typeof(T) == typeof(sbyte))
            {
                return Sse2.MoveMask(a.As<T, sbyte>());
            }
            if (typeof(T) == typeof(float))
            {
                return Sse.MoveMask(a.As<T, float>());
            }
            if (typeof(T) == typeof(double))
            {
                return Sse2.MoveMask(a.As<T, double>());
            }

            throw new NotSupportedException();
        }

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
    }
}
