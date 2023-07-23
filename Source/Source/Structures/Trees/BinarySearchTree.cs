using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public abstract class BSTNode
    {
        public int NodeKey;
        public BSTNode Parent;
        public BSTNode LeftChild;
        public BSTNode RightChild;
    }

    public class BSTNode<T> : BSTNode
    {
        public T NodeValue;

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BSTFind<T>
    {
        public BSTNode<T> Node;

        public bool NodeHasKey;

        public bool ToLeft;

        public BSTFind()
        {
            Node = null;
        }
    }

    public class BST<T>
    {
        BSTNode<T> Root;

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            if (Root == null)
                return new BSTFind<T>();

            return FindNode(Root);

            BSTFind<T> FindNode(BSTNode<T> node)
            {
                if (node.NodeKey == key)
                {
                    return new BSTFind<T>
                    {
                        Node = node,
                        NodeHasKey = true,
                        ToLeft = node.Parent != null && node.Parent.LeftChild == node
                    };
                }

                if (key < node.NodeKey && node.LeftChild != null)
                    return FindNode((BSTNode<T>) node.LeftChild);

                if (key < node.NodeKey && node.LeftChild == null)
                    return new BSTFind<T>
                    {
                        Node = node,
                        NodeHasKey = false,
                        ToLeft = true
                    };

                if (key > node.NodeKey && node.RightChild != null)
                    return FindNode((BSTNode<T>) node.RightChild);

                if (key > node.NodeKey && node.RightChild == null)
                    return new BSTFind<T>
                    {
                        Node = node,
                        NodeHasKey = false,
                        ToLeft = false
                    };

                return new BSTFind<T>();
            }
        }

        public bool AddNode(BSTNode<T> addNode)
        {
            var finded = FindNodeByKey(addNode.NodeKey);

            if (finded.Node == null)
            {
                addNode.Parent = null;
                Root = addNode;
                return true;
            }

            if (finded.NodeHasKey)
            {
                return false;
            }

            if (finded.ToLeft)
            {
                addNode.Parent = finded.Node;
                finded.Node.LeftChild = addNode;
            }
            else
            {
                addNode.Parent = finded.Node;
                finded.Node.RightChild = addNode;
            }

            return true;
        }

        public bool AddKeyValue(int key, T val)
        {
            var finded = FindNodeByKey(key);

            if (finded.Node == null)
            {
                Root = new BSTNode<T>(key, val, null);
                return true;
            }

            if (finded.NodeHasKey)
            {
                return false;
            }

            if (finded.ToLeft)
            {
                finded.Node.LeftChild = new BSTNode<T>(key, val, finded.Node);
            }
            else
            {
                finded.Node.RightChild = new BSTNode<T>(key, val, finded.Node);
            }

            return true;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            return FindMax ? FindMaxNode(FromNode) : FindMinNode(FromNode);

            BSTNode<T> FindMaxNode(BSTNode node)
            {
                if (node == null)
                    return null;

                while (true)
                {
                    if (node.RightChild == null)
                        return (BSTNode<T>) node;

                    node = node.RightChild;
                }
            }

            BSTNode<T> FindMinNode(BSTNode node)
            {
                if (node == null)
                    return null;

                while (true)
                {
                    if (node.LeftChild == null)
                        return (BSTNode<T>) node;

                    node = node.LeftChild;
                }
            }
        }

        public bool DeleteNodeByKey(int key)
        {
            var finded = FindNodeByKey(key);

            if (!finded.NodeHasKey)
            {
                return false;
            }

            if (finded.Node.Parent == null)
            {
                Root = null;
                return true;
            }

            if (finded.Node.LeftChild == null && finded.Node.RightChild == null && finded.ToLeft)
            {
                finded.Node.Parent.LeftChild = null;
                return true;
            }

            if (finded.Node.LeftChild == null && finded.Node.RightChild == null)
            {
                finded.Node.Parent.RightChild = null;
                return true;
            }

            if (finded.Node.LeftChild == null && finded.ToLeft)
            {
                finded.Node.RightChild.Parent = finded.Node.Parent;
                finded.Node.Parent.LeftChild = finded.Node.RightChild;

                return true;
            }

            if (finded.Node.LeftChild == null)
            {
                finded.Node.RightChild.Parent = finded.Node.Parent;
                finded.Node.Parent.RightChild = finded.Node.RightChild;

                return true;
            }

            if (finded.Node.RightChild == null && finded.ToLeft)
            {
                finded.Node.LeftChild.Parent = finded.Node.Parent;
                finded.Node.Parent.LeftChild = finded.Node.LeftChild;

                return true;
            }

            if (finded.Node.RightChild == null)
            {
                finded.Node.LeftChild.Parent = finded.Node.Parent;
                finded.Node.Parent.RightChild = finded.Node.LeftChild;

                return true;
            }

            var minOnRight = FinMinMax((BSTNode<T>) finded.Node.RightChild, false);

            if (finded.ToLeft)
            {
                finded.Node.Parent.LeftChild = minOnRight;
            }
            else
            {
                finded.Node.Parent.RightChild = minOnRight;
            }

            if (minOnRight.Parent.LeftChild == minOnRight)
            {
                minOnRight.Parent.LeftChild = null;
            }
            else
            {
                minOnRight.Parent.RightChild = null;
            }

            minOnRight.Parent = finded.Node.Parent;
            minOnRight.LeftChild = finded.Node.LeftChild;
            minOnRight.RightChild = finded.Node.RightChild;
            minOnRight.LeftChild.Parent = minOnRight;
            minOnRight.RightChild.Parent = minOnRight;

            return true;
        }

        public int Count()
        {
            var count = 0;
            RecursiveCounting(Root);
            return count;

            void RecursiveCounting(BSTNode node)
            {
                if (node == null)
                    return;

                ++count;

                RecursiveCounting(node.LeftChild);
                RecursiveCounting(node.RightChild);
            }
        }
        
        public List<BSTNode> WideAllNodes()
        {
            var result = new List<BSTNode>();

            if (Root == null)
            {
                return result;
            }

            var queue = new Queue<BSTNode>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current);

                if (current.LeftChild != null)
                {
                    queue.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    queue.Enqueue(current.RightChild);
                }
            }
            
            return result;
        }
        
        /// <summary>
        /// 0 - in-order (left leaves first),
        /// 1 - post-order (bottom leaves first, root - last),
        /// 2 - pre-order (root-first, bottom leaves last)
        /// </summary>
        /// <returns></returns>
        public List<BSTNode> DeepAllNodes(int order)
        {
            var result = new List<BSTNode>();
            RecursiveDeep(Root);
            return result;
            
            void RecursiveDeep(BSTNode node)
            {
                if (node == null)
                    return;

                if (order == 2)
                {
                    result.Add(node);
                }
                
                RecursiveDeep(node.LeftChild);

                if (order == 0)
                {
                    result.Add(node);
                }
                
                RecursiveDeep(node.RightChild);

                if (order == 1)
                {
                    result.Add(node);
                }
            }
        }
    }
}