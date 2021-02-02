using System;
using System.Collections;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using BenchmarkDotNet.Attributes;

namespace ConsoleApp1
{
    public class BenchContains
    {
        private int[] array = new int[512];

        [GlobalSetup]
        public void Setup()
        {
            for (int i = 0; i < 512; i++)
            {
                array[i] = i;
            }
        }
        
        [Benchmark]
        public bool Contains()
        {
            return Contains1(array, 511);
        }
        
        [Benchmark]
        public bool ContainsTestZ()
        {
            return Contains2(array, 511);
        }

        private static unsafe bool Contains1(int[] array, int value)
        {
            if (array.Length < 1)
            {
                return false;
            }
            
            var i = 0;
            
            if (Avx2.IsSupported)
            {
                fixed (int* ptr = array)
                {
                    var size = Vector256<int>.Count;
                    var lastIndexBlock = array.Length - array.Length % size;
                
                    var elementVec = Vector256.Create(value);
                
                    for (; i < lastIndexBlock; i += size)
                    {
                        var curr = Avx.LoadVector256(ptr + i);
                        var mask = Avx2.CompareEqual(curr, elementVec);
                        

                        if (Convert.ToBoolean(res))
                        {
                            return true;
                        }
                    }
                }
            }

            var comparer = Comparer.Default;
            
            for (; i < array.Length; i++)
            {
                if (comparer.Compare(array[i], value) == 0)
                {
                    return true;
                }
            }
            
            return false;
        }

        private static unsafe bool Contains2(int[] array, int value)
         {
            if (array.Length < 1)
            {
                return false;
            }
            
            var i = 0;
            
            if (Avx2.IsSupported)
            {
                fixed (int* ptr = array)
                {
                    var size = Vector256<int>.Count;
                    var lastIndexBlock = array.Length - array.Length % size;
                
                    var elementVec = Vector256.Create(value);
                
                    for (; i < lastIndexBlock; i += size)
                    {
                        var curr = Avx.LoadVector256(ptr + i);
                        var mask = Avx2.CompareEqual(curr, elementVec);
                    
                        if (!Avx.TestZ(mask, mask))
                        {
                            return true;
                        }
                    }
                }
            }

            var comparer = Comparer.Default;
            
            for (; i < array.Length; i++)
            {
                if (comparer.Compare(array[i], value) == 0)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
    
}