using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Structures.Trees
{
    [TestClass]
    public class BinarySearchTreeBaseArrayTests
    {
        [TestMethod]
        public void FindKeyIndexCornel()
        {
            var tree = new aBST(2);

            var finded = tree.FindKeyIndex(8);

            Assert.IsFalse(finded == null);
            Assert.IsTrue((int) finded == 0);

            tree.Tree[0] = 8;

            finded = tree.FindKeyIndex(8);

            Assert.IsFalse(finded == null);
            Assert.IsTrue((int) finded == 0);

            finded = tree.FindKeyIndex(10);

            Assert.IsFalse(finded == null);
            Assert.IsTrue((int) finded == -2);

            finded = tree.FindKeyIndex(0);

            Assert.IsFalse(finded == null);
            Assert.IsTrue((int) finded == -1);

            tree.Tree[2] = 9;

            finded = tree.FindKeyIndex(9);
            
            Assert.IsFalse(finded == null);
            Assert.AreEqual(2, (int) finded);

            finded = tree.FindKeyIndex(10);

            Assert.IsTrue(finded == null);
        }

        [TestMethod]
        public void AddKeyCornel()
        {
            var tree = new aBST(2);

            var addResult = tree.AddKey(20);
            Assert.AreEqual(0, addResult);
            Assert.AreEqual(20, tree.Tree[0]);

            addResult = tree.AddKey(20);
            Assert.AreEqual(0, addResult);

            addResult = tree.AddKey(10);
            Assert.AreEqual(1, addResult);

            addResult = tree.AddKey(8);
            Assert.AreEqual(-1, addResult);
        }
    }
}