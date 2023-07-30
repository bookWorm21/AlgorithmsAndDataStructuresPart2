using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Structures.Trees
{
    [TestClass]
    public class HeapTests
    {
        [TestMethod]
        public void MakeHeapOneElement()
        {
            var heap = new Heap();
            heap.MakeHeap(new List<int> {5}.ToArray(), 1);

            Assert.IsTrue(heap.HeapArray[0] == 5);
            Assert.IsTrue(heap.Size == 1);
        }
        
        [TestMethod]
        public void MakeHeapOrderTest()
        {
            var random = new Random(999);
            var depth = 4;
            var count = 13;

            var values = new int[count];
            for (int i = 0; i < values.Length; ++i)
            {
                values[i] = random.Next(1, 100);
            }
            
            var heap = new Heap();
            heap.MakeHeap(values, depth);
            var length = heap.Size;

            Check(0);

            void Check(int index)
            {
                if (index >= length)
                    return;

                var left = index * 2 + 1;
                var right = index * 2 + 2;

                Assert.IsTrue(heap.HeapArray[index] >= heap.HeapArray[left]);
                Assert.IsTrue(heap.HeapArray[index] >= heap.HeapArray[right]);

                Check(left);
                Check(right);
            }
        }

        [TestMethod]
        public void GetMaxOrderTest()
        {            var random = new Random(999);
            var depth = 4;
            var count = 13;

            var values = new int[count];
            for (int i = 0; i < values.Length; ++i)
            {
                values[i] = random.Next(1, 100);
            }
            
            var heap = new Heap();
            heap.MakeHeap(values, depth);

            Array.Sort(values);
            Array.Reverse(values);
            
            for (int i = 0; i < values.Length; ++i)
            {
                Assert.AreEqual(values[i], heap.GetMax());
                Assert.AreEqual(values.Length - i - 1, heap.Size);
            }

            Assert.AreEqual(-1, heap.GetMax());
        }

        [TestMethod]
        public void AddTest()
        {
            var random = new Random(999);
            var depth = 4;

            var values = Array.Empty<int>();

            var heap = new Heap();
            heap.MakeHeap(values, depth);

            while (heap.Add(random.Next(1, 100)))
            {
            }
            
            var length = heap.Size;

            Assert.AreEqual((int) Math.Pow(2, depth + 1) - 1, length);

            Check(0);

            void Check(int index)
            {
                if (index >= length)
                    return;
                
                var parent = (index - 1) / 2;

                if (parent >= 0)
                {
                    Assert.IsTrue(heap.HeapArray[parent] >= heap.HeapArray[index]);
                }
                
                var left = index * 2 + 1;
                var right = index * 2 + 2;

                Check(left);
                Check(right);
            }
        }
    }
}