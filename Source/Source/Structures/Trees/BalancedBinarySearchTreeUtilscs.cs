using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBSTUtils
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            Array.Sort(a);
            var result = new int[a.Length];
            SetValues(0, result.Length - 1, 0);
            return result;

            void SetValues(int left, int right, int index)
            {
                if (left > right)
                    return;
                
                var middle = left + (right - left) / 2;
                result[index] = a[middle];

                SetValues(left, middle - 1, index * 2 + 1);
                SetValues(middle + 1, right, index * 2 + 2);
            }
        }
    }
}