using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;

namespace UnitTests.Structures.Trees
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void AddKeyToEmptyTree()
        {
            var tree = new BST<int>(null);

            Assert.AreEqual(true, tree.AddKeyValue(5, 10));
            Assert.AreEqual(false, tree.AddKeyValue(5, 10));

            Assert.AreEqual(true, tree.AddKeyValue(7, 10));
            Assert.AreEqual(true, tree.AddKeyValue(4, 10));
        }

        [TestMethod]
        public void CountAfterAddedToEmptyTree()
        {
            var tree = new BST<int>(null);

            Assert.AreEqual(0, tree.Count());
            
            tree.AddKeyValue(5, 10);
            tree.AddKeyValue(6, 10);
            tree.AddKeyValue(4, 10);
            tree.AddKeyValue(10, 10);
            tree.AddKeyValue(11, 10);

            Assert.AreEqual(5, tree.Count());
        }

        [TestMethod]
        public void FindMinMaxTest1()
        {
            var root = new BSTNode<int>(5, 8, null);
            var node1 = new BSTNode<int>(6, 9, null);
            var node2 = new BSTNode<int>(4, 10, null);
            var node3 = new BSTNode<int>(10, 11, null);
            
            var tree = new BST<int>(null);

            Assert.AreEqual(null, tree.FinMinMax(null, true));
            Assert.AreEqual(null, tree.FinMinMax(null, false));

            tree.AddNode(root);
            tree.AddNode(node1);
            tree.AddNode(node2);
            tree.AddNode(node3);

            Assert.AreEqual(node3, tree.FinMinMax(root, true));
            Assert.AreEqual(node2, tree.FinMinMax(root, false));
            Assert.AreEqual(node2, tree.FinMinMax(node2, true));
            Assert.AreEqual(node2, tree.FinMinMax(node2, false));
            Assert.AreEqual(node3, tree.FinMinMax(node1, true));
        }
        

        //                     20 
        //           10                  30
        //         5    15         25          35
        //        0 8  12 17      22 27       
        [TestMethod]
        public void DeleteNodeByKeyCornel()
        {
            var tree = new BST<int>(null);

            Assert.AreEqual(false, tree.DeleteNodeByKey(5));
            
            var root20 = new BSTNode<int>(20, 8, null);
            var node10 = new BSTNode<int>(10, 8, null);
            var node30 = new BSTNode<int>(30, 8, null);
            var node5 = new BSTNode<int>(5, 8, null);
            var node15 = new BSTNode<int>(15, 8, null);
            var node0 = new BSTNode<int>(0, 8, null);
            var node8 = new BSTNode<int>(8, 8, null);
            var node12 = new BSTNode<int>(12, 8, null);
            var node17 = new BSTNode<int>(17, 8, null);
            var node25 = new BSTNode<int>(25, 8, null);
            var node22 = new BSTNode<int>(22, 8, null);
            var node27 = new BSTNode<int>(27, 8, null);
            var node35 = new BSTNode<int>(35, 8, null);
            
            tree.AddNode(root20);
            tree.AddNode(node10);
            tree.AddNode(node5);
            tree.AddNode(node8);
            tree.AddNode(node0);
            tree.AddNode(node15);
            tree.AddNode(node17);
            tree.AddNode(node12);
            tree.AddNode(node30);
            tree.AddNode(node35);
            tree.AddNode(node25);
            tree.AddNode(node27);
            tree.AddNode(node22);

            Assert.IsTrue(tree.DeleteNodeByKey(35));
            Assert.IsTrue(node30.RightChild == null);

            Assert.IsTrue(tree.DeleteNodeByKey(27));
            Assert.IsTrue(node25.RightChild == null);

            Assert.IsTrue(tree.DeleteNodeByKey(25));
            Assert.IsTrue(node30.LeftChild == node22);

            Assert.IsTrue(tree.DeleteNodeByKey(10));
            Assert.IsTrue(root20.LeftChild == node12);
            Assert.IsTrue(node12.Parent == root20);
            Assert.IsTrue(node5.Parent == node12);
            Assert.IsTrue(node15.Parent == node12);
            Assert.IsTrue(node15.LeftChild == null);
            Assert.IsTrue(node12.LeftChild == node5);
            Assert.IsTrue(node12.RightChild == node15);
        }
        
        [TestMethod]
        public void FindNodeByKeyCornel()
        {
            var root = new BSTNode<int>(5, 8, null);

            var tree = new BST<int>(null);

            var finded = tree.FindNodeByKey(5);
            
            Assert.IsTrue(finded.Node == null);
            Assert.IsFalse(finded.NodeHasKey);

            tree.AddNode(root);

            finded = tree.FindNodeByKey(5);
            Assert.IsTrue(finded.Node == root);
            Assert.IsTrue(finded.NodeHasKey);

            finded = tree.FindNodeByKey(8);

            Assert.IsTrue(finded.Node == root);
            Assert.IsFalse(finded.NodeHasKey);
            Assert.IsFalse(finded.ToLeft);

            finded = tree.FindNodeByKey(4);

            Assert.IsTrue(finded.Node == root);
            Assert.IsFalse(finded.NodeHasKey);
            Assert.IsTrue(finded.ToLeft);
        }

        //                     20 
        //           10                  30
        //         5    15         25          35
        //        0 8  12 17      22 27       
        [TestMethod]
        public void WideAllNodesTest()
        {
            var tree = new BST<int>(null);

            Assert.AreEqual(false, tree.DeleteNodeByKey(5));
            
            var root20 = new BSTNode<int>(20, 8, null);
            var node10 = new BSTNode<int>(10, 8, null);
            var node30 = new BSTNode<int>(30, 8, null);
            var node5 = new BSTNode<int>(5, 8, null);
            var node15 = new BSTNode<int>(15, 8, null);
            var node0 = new BSTNode<int>(0, 8, null);
            var node8 = new BSTNode<int>(8, 8, null);
            var node12 = new BSTNode<int>(12, 8, null);
            var node17 = new BSTNode<int>(17, 8, null);
            var node25 = new BSTNode<int>(25, 8, null);
            var node22 = new BSTNode<int>(22, 8, null);
            var node27 = new BSTNode<int>(27, 8, null);
            var node35 = new BSTNode<int>(35, 8, null);
            
            tree.AddNode(root20);
            tree.AddNode(node10);
            tree.AddNode(node5);
            tree.AddNode(node8);
            tree.AddNode(node0);
            tree.AddNode(node15);
            tree.AddNode(node17);
            tree.AddNode(node12);
            tree.AddNode(node30);
            tree.AddNode(node35);
            tree.AddNode(node25);
            tree.AddNode(node27);
            tree.AddNode(node22);

            var expected = new List<BSTNode>
            {
                root20, node10, node30, node5, node15, node25, node35, node0, node8, node12, node17, node22, node27
            };

            Assert.IsTrue(expected.SequenceEqual(tree.WideAllNodes()));
        }
        
        //                     20 
        //           10                  30
        //         5    15         25          35
        //        0 8  12 17      22 27       
        [TestMethod]
        public void DeepAllNodesTest()
        {
            var tree = new BST<int>(null);

            Assert.AreEqual(false, tree.DeleteNodeByKey(5));
            
            var root20 = new BSTNode<int>(20, 8, null);
            var node10 = new BSTNode<int>(10, 8, null);
            var node30 = new BSTNode<int>(30, 8, null);
            var node5 = new BSTNode<int>(5, 8, null);
            var node15 = new BSTNode<int>(15, 8, null);
            var node0 = new BSTNode<int>(0, 8, null);
            var node8 = new BSTNode<int>(8, 8, null);
            var node12 = new BSTNode<int>(12, 8, null);
            var node17 = new BSTNode<int>(17, 8, null);
            var node25 = new BSTNode<int>(25, 8, null);
            var node22 = new BSTNode<int>(22, 8, null);
            var node27 = new BSTNode<int>(27, 8, null);
            var node35 = new BSTNode<int>(35, 8, null);
            
            tree.AddNode(root20);
            tree.AddNode(node10);
            tree.AddNode(node5);
            tree.AddNode(node8);
            tree.AddNode(node0);
            tree.AddNode(node15);
            tree.AddNode(node17);
            tree.AddNode(node12);
            tree.AddNode(node30);
            tree.AddNode(node35);
            tree.AddNode(node25);
            tree.AddNode(node27);
            tree.AddNode(node22);

            var expectedInOrder = new List<BSTNode>
            {
                node0, node5, node8, node10, node12, node15, node17, root20, node22, node25, node27, node30, node35
            };

            Assert.IsTrue(expectedInOrder.SequenceEqual(tree.DeepAllNodes(0)));

            var expectedPostOrder = new List<BSTNode>
            {
                node0, node8, node5, node12, node17, node15, node10, node22, node27, node25, node35, node30, root20
            };
            
            Assert.IsTrue(expectedPostOrder.SequenceEqual(tree.DeepAllNodes(1)));

            var expectedPreOrder = new List<BSTNode>
            {
                root20, node10, node5, node0, node8, node15, node12, node17, node30, node25, node22,node27, node35
            };

            Assert.IsTrue(expectedPreOrder.SequenceEqual(tree.DeepAllNodes(2)));
        }
    }
}