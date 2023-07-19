using System.Linq;
using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Structures.Trees
{
    [TestClass]
    public class SimpleTreeTests
    {
        [TestMethod]
        public void AddChild_ToEmptyTree()
        {
            var tree = new SimpleTree<int>(null);
            Assert.AreEqual(null, tree.Root);

            var node = new SimpleTreeNode<int>(5, null);
            tree.AddChild(null, node);

            Assert.AreEqual(node, tree.Root);
            Assert.IsTrue(tree.Root.Parent == null);
            Assert.IsTrue(tree.Root.Children != null && tree.Root.Children.Count == 0);
        }

        [TestMethod]
        public void AddChild_TwoNodes()
        {
            var tree = new SimpleTree<int>(null);
            Assert.AreEqual(null, tree.Root);

            var node = new SimpleTreeNode<int>(5, null);
            var node2 = new SimpleTreeNode<int>(10, null);

            tree.AddChild(null, node);
            tree.AddChild(node, node2);

            Assert.IsTrue(tree.Root == node);
            Assert.IsTrue(tree.Root.Children.Contains(node2));
            Assert.IsTrue(node2.Parent == node);
        }

        [TestMethod]
        public void DeleteNode_RootWithChild()
        {
            var tree = new SimpleTree<int>(null);
            Assert.AreEqual(null, tree.Root);

            var node = new SimpleTreeNode<int>(5, null);
            var node2 = new SimpleTreeNode<int>(10, null);

            tree.AddChild(null, node);
            tree.AddChild(node, node2);

            tree.DeleteNode(node);

            Assert.IsTrue(tree.Root == null);
        }
        
        [TestMethod]
        public void DeleteNode_ChildOnRoot()
        {
            var tree = new SimpleTree<int>(null);
            Assert.AreEqual(null, tree.Root);

            var node = new SimpleTreeNode<int>(5, null);
            var node2 = new SimpleTreeNode<int>(10, null);

            tree.AddChild(null, node);
            tree.AddChild(node, node2);

            tree.DeleteNode(node2);

            Assert.IsTrue(tree.Root == node);
            Assert.IsFalse(tree.Root.Children.Contains(node2));
        }

        [TestMethod]
        public void MoveNode_1()
        {
            var tree = new SimpleTree<int>(null);
            Assert.AreEqual(null, tree.Root);

            var node = new SimpleTreeNode<int>(5, null);
            var node2 = new SimpleTreeNode<int>(5, null);
            var node3 = new SimpleTreeNode<int>(8, null);
            var node4 = new SimpleTreeNode<int>(5, null);
            var node5 = new SimpleTreeNode<int>(10, null);
            var node6 = new SimpleTreeNode<int>(51, null);

            tree.AddChild(null, node);
            tree.AddChild(node, node2);
            tree.AddChild(node2, node3);
            tree.AddChild(node2, node4);
            tree.AddChild(node, node5);
            tree.AddChild(node5, node6);

            tree.MoveNode(node2, node5);

            Assert.IsFalse(node.Children.Contains(node2));
            Assert.IsTrue(node2.Parent == node5);
            Assert.IsTrue(node5.Children.Contains(node2));
            Assert.IsTrue(node5.Children.Contains(node6));
        }

        [TestMethod]
        public void GetAllNodes_BambooTreeType()
        {
            var tree = new SimpleTree<int>(null);
            Assert.AreEqual(null, tree.Root);

            var node = new SimpleTreeNode<int>(5, null);
            var node2 = new SimpleTreeNode<int>(5, null);
            var node3 = new SimpleTreeNode<int>(8, null);

            tree.AddChild(null, node);
            tree.AddChild(node, node2);
            tree.AddChild(node2, node3);

            var actual = tree.GetAllNodes();

            Assert.IsTrue(actual.Contains(node));
            Assert.IsTrue(actual.Contains(node2));
            Assert.IsTrue(actual.Contains(node3));
        }

        [TestMethod]
        public void FindNodesByValue_SeveralNodesWithSameValues()
        {
            var tree = new SimpleTree<int>(null);
            Assert.AreEqual(null, tree.Root);

            var node = new SimpleTreeNode<int>(5, null);
            var node2 = new SimpleTreeNode<int>(5, null);
            var node3 = new SimpleTreeNode<int>(8, null);
            var node4 = new SimpleTreeNode<int>(5, null);

            tree.AddChild(null, node);
            tree.AddChild(node, node2);
            tree.AddChild(node2, node3);
            tree.AddChild(node2, node4);

            var actual = tree.FindNodesByValue(5);

            Assert.AreEqual(3, actual.Count);
            Assert.IsTrue(actual.Contains(node));
            Assert.IsTrue(actual.Contains(node2));
            Assert.IsTrue(actual.Contains(node4));
        }
        
        [TestMethod]
        public void Count_1()
        {
            var tree = new SimpleTree<int>(null);
            Assert.AreEqual(null, tree.Root);

            var node = new SimpleTreeNode<int>(5, null);
            var node2 = new SimpleTreeNode<int>(5, null);
            var node3 = new SimpleTreeNode<int>(8, null);
            var node4 = new SimpleTreeNode<int>(5, null);

            tree.AddChild(null, node);
            tree.AddChild(node, node2);
            tree.AddChild(node2, node3);
            tree.AddChild(node2, node4);

            Assert.AreEqual(4, tree.Count());
        }
        
        [TestMethod]
        public void LeafCount_1()
        {
            var tree = new SimpleTree<int>(null);
            Assert.AreEqual(null, tree.Root);

            var node = new SimpleTreeNode<int>(5, null);
            var node2 = new SimpleTreeNode<int>(5, null);
            var node3 = new SimpleTreeNode<int>(8, null);
            var node4 = new SimpleTreeNode<int>(5, null);

            tree.AddChild(null, node);
            tree.AddChild(node, node2);
            tree.AddChild(node2, node3);
            tree.AddChild(node2, node4);

            Assert.AreEqual(2, tree.LeafCount());
        }
        
        [TestMethod]
        [Description("Empty tree")]
        public void LeafCount_2()
        {
            var tree = new SimpleTree<int>(null);
            Assert.AreEqual(null, tree.Root);
            Assert.AreEqual(0, tree.LeafCount());
        }
    }
}