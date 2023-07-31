using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {
        public int [] HeapArray;
        public int Size { get; private set; }

        public Heap()
        {
            HeapArray = null;
            Size = 0;
        }
		
        public void MakeHeap(int[] a, int depth)
        {
            var heapSize = (int)Math.Pow(2, depth + 1) - 1;
            HeapArray = new int[heapSize];

            foreach (var element in a)
            {
                Add(element);
            }
        }
		
        public int GetMax()
        {
            if (Size == 0)
                return -1;

            var max = HeapArray[0];
            HeapArray[0] = HeapArray[Size - 1];
            HeapArray[Size - 1] = -1;
            --Size;
            PropagateToBottom(0);
            return max;
        }

        public bool Add(int key)
        {
            if (Size == HeapArray.Length)
                return false;
            
            HeapArray[Size] = key;
            ++Size;
            PropagateToTop(Size - 1);
            return true;
        }
        
        private void PropagateToTop(int index)
        {
            if (index == 0)
                return;

            var parent = (index - 1) / 2;
            var left = parent * 2 + 1;
            var right = parent * 2 + 2;

            var maxIndex = left;
            if (right < Size && HeapArray[right] > HeapArray[left])
            {
                maxIndex = right;
            }

            if (HeapArray[maxIndex] > HeapArray[parent])
            {
                (HeapArray[maxIndex], HeapArray[parent]) = (HeapArray[parent], HeapArray[maxIndex]);
                PropagateToTop(parent);
            }
        }

        private void PropagateToBottom(int index)
        {
            var left = index * 2 + 1;
            var right = index * 2 + 2;

            if (left >= Size)
            {
                return;
            }

            var maxIndex = left;
            if (right < Size && HeapArray[right] > HeapArray[left])
            {
                maxIndex = right;
            }
            
            if (HeapArray[maxIndex] > HeapArray[index])
            {
                (HeapArray[maxIndex], HeapArray[index]) = (HeapArray[index], HeapArray[maxIndex]);
                PropagateToBottom(maxIndex);
            }
        }
    }
}