using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace IntrinsicsGeneric
{
    public class Avx2<T> where T : unmanaged
    {
        internal Avx2() { }

        //public static Vector256<byte> Abs(Vector256<sbyte> value) => Abs(value);

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

        //public static Vector256<sbyte> AddSaturate(Vector256<sbyte> left, Vector256<sbyte> right) => AddSaturate(left, right);
        //public static Vector256<sbyte> AlignRight(Vector256<sbyte> left, Vector256<sbyte> right, byte mask) => AlignRight(left, right, mask);
        //public static Vector256<sbyte> And(Vector256<sbyte> left, Vector256<sbyte> right) => And(left, right);
        //public static Vector256<sbyte> AndNot(Vector256<sbyte> left, Vector256<sbyte> right) => AndNot(left, right);
        //public static Vector256<byte> Average(Vector256<byte> left, Vector256<byte> right) => Average(left, right);
        //public static Vector128<int> Blend(Vector128<int> left, Vector128<int> right, byte control) => Blend(left, right, control);
        //public static Vector256<sbyte> BlendVariable(Vector256<sbyte> left, Vector256<sbyte> right, Vector256<sbyte> mask) => BlendVariable(left, right, mask);
        //public static Vector128<byte> BroadcastScalarToVector128(Vector128<byte> value) => BroadcastScalarToVector128(value);
        //public static Vector256<byte> BroadcastScalarToVector256(Vector128<byte> value) => BroadcastScalarToVector256(value);
        //public static unsafe Vector256<byte> BroadcastScalarToVector256(byte* source) => BroadcastScalarToVector256(source);
        //public static Vector256<sbyte> CompareEqual(Vector256<sbyte> left, Vector256<sbyte> right) => CompareEqual(left, right);
        //public static Vector256<sbyte> CompareGreaterThan(Vector256<sbyte> left, Vector256<sbyte> right) => CompareGreaterThan(left, right);
        //public static int ConvertToInt32(Vector256<int> value) => ConvertToInt32(value);
        //public static Vector256<int> ConvertToVector256Int32(Vector128<ushort> value) => ConvertToVector256Int32(value);
        //public static Vector256<long> ConvertToVector256Int64(Vector128<int> value) => ConvertToVector256Int64(value);

        /*
Abs
Add
AddSaturate
AlignRight
And
AndNot
Average
Blend
BlendVariable
BroadcastScalarToVector128
BroadcastScalarToVector256
BroadcastVector128ToVector256
CompareEqual
CompareGreaterThan
ConvertToInt32
ConvertToUInt32
ConvertToVector256Int16
ConvertToVector256Int32
ConvertToVector256Int64
ExtractVector128
GatherMaskVector128
GatherMaskVector256
GatherVector128
GatherVector256
HorizontalAdd
HorizontalAddSaturate
HorizontalSubtract
HorizontalSubtractSaturate
InsertVector128
LoadAlignedVector256NonTemporal
MaskLoad
MaskStore
Max
Min
MoveMask
MultipleSumAbsoluteDifferences
Multiply
MultiplyAddAdjacent
MultiplyHigh
MultiplyHighRoundScale
MultiplyLow
Or
PackSignedSaturate
PackUnsignedSaturate
Permute2x128
Permute4x64
PermuteVar8x32
ShiftLeftLogical
ShiftLeftLogical128BitLane
ShiftLeftLogicalVariable
ShiftRightArithmetic
ShiftRightArithmeticVariable
ShiftRightLogical
ShiftRightLogical128BitLane
ShiftRightLogicalVariable
Shuffle
ShuffleHigh
ShuffleLow
Sign
Subtract
SubtractSaturate
SumAbsoluteDifferences
UnpackHigh
UnpackLow
Xor
         */
    }
}