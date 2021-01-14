﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace IntrinsicsGeneric.Simd
{
    public abstract unsafe class Avx<T> : Sse2<T>
        where T : unmanaged
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> LoadVector256(T* address)
        {
            if (typeof(T) == typeof(sbyte))
            {
                return Avx.LoadVector256((sbyte*) address).As<sbyte, T>();
            }
            if (typeof(T) == typeof(byte))
            {
                return Avx.LoadVector256((byte*) address).As<byte, T>();
            }
            if (typeof(T) == typeof(short))
            {
                return Avx.LoadVector256((short*) address).As<short, T>();
            }
            if (typeof(T) == typeof(ushort))
            {
                return Avx.LoadVector256((ushort*) address).As<ushort, T>();
            }
            if (typeof(T) == typeof(int))
            {
                return Avx.LoadVector256((int*) address).As<int, T>();
            }
            if (typeof(T) == typeof(uint))
            {
                return Avx.LoadVector256((uint*) address).As<uint, T>();
            }
            if (typeof(T) == typeof(long))
            {
                return Avx.LoadVector256((long*) address).As<long, T>();
            }
            if (typeof(T) == typeof(ulong))
            {
                return Avx.LoadVector256((ulong*) address).As<ulong, T>();
            }
            if (typeof(T) == typeof(float))
            {
                return Avx.LoadVector256((float*) address).As<float, T>();
            }
            if (typeof(T) == typeof(double))
            {
                return Avx.LoadVector256((double*) address).As<double, T>();
            }

            throw new NotSupportedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Store(T* address, Vector256<T> vector256)
        {
            if (typeof(T) == typeof(sbyte))
            {
                Avx.Store((sbyte*) address, vector256.As<T, sbyte>());
            }
            else if (typeof(T) == typeof(byte))
            {
                Avx.Store((byte*) address, vector256.As<T, byte>());
            }
            else if (typeof(T) == typeof(short))
            {
                Avx.Store((short*) address, vector256.As<T, short>());
            }
            else if (typeof(T) == typeof(ushort))
            {
                Avx.Store((ushort*) address, vector256.As<T, ushort>());
            }
            else if (typeof(T) == typeof(int))
            {
                Avx.Store((int*) address, vector256.As<T, int>());
            }
            else if (typeof(T) == typeof(uint))
            {
                Avx.Store((uint*) address, vector256.As<T, uint>());
            }
            else if (typeof(T) == typeof(long))
            {
                Avx.Store((long*) address, vector256.As<T, long>());
            }
            else if (typeof(T) == typeof(ulong))
            {
                Avx.Store((ulong*) address, vector256.As<T, ulong>());
            }
            else if (typeof(T) == typeof(float))
            {
                Avx.Store((float*) address, vector256.As<T, float>());
            }
            else if (typeof(T) == typeof(double))
            {
                Avx.Store((double*) address, vector256.As<T, double>());
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}