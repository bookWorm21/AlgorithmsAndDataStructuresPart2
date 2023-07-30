using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;

namespace UnitTests.Structures.Trees
{
    [TestClass]
    public class BalancedBinarySearchTreeTests
    {
        [TestMethod]
        public void GenerateBBSTArray()
        {
            var empty = Array.Empty<int>();
            Assert.IsTrue(Array.Empty<int>().SequenceEqual(BalancedBSTUtils.GenerateBBSTArray(empty)));
            
            var withOneElement = new int[1];
            withOneElement[0] = 121;
            
            Assert.IsTrue(new List<int> {121}.ToArray().SequenceEqual(BalancedBSTUtils.GenerateBBSTArray(withOneElement)));
            
            var withTwoElement = new int[3] {120, 130, 100};
            Assert.IsTrue(new List<int>{120, 100, 130}.SequenceEqual(BalancedBSTUtils.GenerateBBSTArray(withTwoElement)));
            
            //                     20 
            //           10                  30
            //         5    15         25          35
            //        0 8  12 17      22 27     33    40
            var treeElements = new[] {10, 5, 15, 0, 8, 12, 17, 20, 25, 30, 35, 22, 27, 40, 33};
            var expected = new[] {20, 10, 30, 5, 15, 25, 35, 0, 8, 12, 17, 22, 27, 33, 40};

            Assert.IsTrue(expected.SequenceEqual(BalancedBSTUtils.GenerateBBSTArray(treeElements)));
        }

        [TestMethod]
        public void GenerateTreeCornel()
        {
            //                     20 
            //           10                  30
            //         5    15         25          35
            //        0 8  12 17      22 27     33    40
            var treeElements = new[] {10, 5, 15, 0, 8, 12, 17, 20, 25, 30, 35, 22, 27, 40, 33};

            var balancedTree = new BalancedBST();

            Assert.IsTrue(balancedTree.IsBalanced(balancedTree.Root));
            
            balancedTree.GenerateTree(treeElements);

            Assert.IsTrue(balancedTree.IsBalanced(balancedTree.Root));
        }
    }
}