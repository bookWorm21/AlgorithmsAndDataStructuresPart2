using System.Collections.Generic;
using System.Linq;
using AlgorithmsDataStructures2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Structures.Trees
{
    [TestClass]
    public class SimpleGraphTests
    {
        [TestMethod]
        public void SimpleGraphCornel()
        {
            var graph = new SimpleGraph<int>(3);
            graph.AddVertex(5);
            graph.AddVertex(10);

            Assert.AreEqual(5, graph.vertex[0].Value);
            Assert.AreEqual(10, graph.vertex[1].Value);

            Assert.IsFalse(graph.IsEdge(0, 1));

            graph.AddEdge(0, 1);

            Assert.IsTrue(graph.IsEdge(0, 1));

            graph.AddVertex(15);

            Assert.IsFalse(graph.IsEdge(1, 2));
            
            graph.AddEdge(1, 2);

            Assert.IsTrue(graph.IsEdge(1, 2));

            graph.RemoveEdge(1, 2);

            Assert.IsTrue(graph.IsEdge(0, 1));
            Assert.IsFalse(graph.IsEdge(1, 2));

            graph.AddEdge(1, 2);

            graph.RemoveVertex(2);

            Assert.IsFalse(graph.IsEdge(1, 2));
            Assert.IsFalse(graph.IsEdge(0, 2));
        }

        [TestMethod]
        public void DepthFirstSearchTests()
        {
            var graph = new SimpleGraph<int>(5);

            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);

            graph.AddEdge(0, 3);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            var result = graph.DepthFirstSearch(0, 4).Select(ver => ver.Value);
            Assert.IsTrue(result
                .SequenceEqual(new List<int>{0, 3, 4}));

            result = graph.DepthFirstSearch(0, 5).Select(ver => ver.Value);
            Assert.IsTrue(result.SequenceEqual(new List<int>()));
        }
    }
}