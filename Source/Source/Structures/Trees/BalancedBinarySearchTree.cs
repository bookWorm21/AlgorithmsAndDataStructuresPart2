using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey;
        public BSTNode Parent;
        public BSTNode LeftChild;
        public BSTNode RightChild;
        public int Level;

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }
    
    public class BalancedBST
    {
        public BSTNode Root;
	
        public BalancedBST() 
        { 
            Root = null;
        }
		
        public void GenerateTree(int[] a)
        {
            Array.Sort(a);
            Root = GenerateNode(0, a.Length - 1, null);
            
            BSTNode GenerateNode(int left, int right, BSTNode parent)
            {
                if (left > right)
                    return null;

                var middle = left + (right - left) / 2;
                var node = new BSTNode(a[middle], parent)
                {
                    Level = parent != null ? parent.Level + 1 : 0,
                    Parent = parent
                };
                node.LeftChild = GenerateNode(left, middle - 1, node);
                node.RightChild = GenerateNode(middle + 1, right, node);
                return node;
            }
        }

        public bool IsBalanced(BSTNode root)
        {
            if (root == null)
                return true;

            if (!IsBalanced(root.LeftChild) || !IsBalanced(root.RightChild))
                return false;

            return Math.Abs((root.LeftChild?.Level ?? 0) -
                            (root.RightChild?.Level ?? 0)) <= 1;
        }
    }
}