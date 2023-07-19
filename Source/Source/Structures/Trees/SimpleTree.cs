using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue;
        public SimpleTreeNode<T> Parent;
        public List<SimpleTreeNode<T>> Children;
	
        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = new List<SimpleTreeNode<T>>();
        }
    }
	
    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root;

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }
	
        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            if (ParentNode == null)
            {
                Root = NewChild;
                NewChild.Parent = null;
                return;
            }

            NewChild.Parent = ParentNode;
            ParentNode.Children.Add(NewChild);
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            if (NodeToDelete.Parent == null)
            {
                Root = null;
                return;
            }
            
            NodeToDelete.Parent.Children.Remove(NodeToDelete);
            NodeToDelete.Parent = null;
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            var result = new List<SimpleTreeNode<T>>();
            RecursiveMakingNodes(Root);
            return result;

            void RecursiveMakingNodes(SimpleTreeNode<T> node)
            {
                if (node == null)
                    return;

                result.Add(node);

                foreach (var child in node.Children)
                {
                    RecursiveMakingNodes(child);
                }
            }
        }
	
        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            var result = new List<SimpleTreeNode<T>>();
            RecursiveFinding(Root);
            return result;

            void RecursiveFinding(SimpleTreeNode<T> node)
            {
                if (node == null)
                    return;

                if (node.NodeValue.Equals(val))
                {
                    result.Add(node);
                }

                foreach (var child in node.Children)
                {
                    RecursiveFinding(child);
                }
            }
        }
   
        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            DeleteNode(OriginalNode);
            AddChild(NewParent, OriginalNode);
        }
   
        public int Count()
        {
            int count = 0;
            RecursiveCounting(Root);
            return count;

            void RecursiveCounting(SimpleTreeNode<T> node)
            {
                if (node == null)
                    return;

                ++count;
                foreach (var child in node.Children)
                {
                    RecursiveCounting(child);
                }
            }
        }

        public int LeafCount()
        {
            int count = 0;
            RecursiveCounting(Root);
            return count;

            void RecursiveCounting(SimpleTreeNode<T> node)
            {
                if (node == null)
                    return;

                if (node.Children.Count == 0)
                {
                    ++count;
                }

                foreach (var child in node.Children)
                {
                    RecursiveCounting(child);
                }
            }
        }
    }
}