using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int? [] Tree;

        public aBST(int depth)
        {
            var treeSize = (int)Math.Pow(2, depth) - 1;
            Tree = new int?[treeSize];
            for (var i = 0; i < treeSize; i++) 
                Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {
            return RecursiveFind(0);

            int? RecursiveFind(int index)
            {
                while (true)
                {
                    if (index >= Tree.Length) 
                        return null;

                    if (Tree[index] == key) 
                        return index;

                    if (Tree[index] == null) 
                        return -index;

                    if (key > Tree[index])
                    {
                        index = index * 2 + 2;
                        continue;
                    }

                    index = index * 2 + 1;
                }
            }
        }
	
        public int AddKey(int key)
        {
            var finded = FindKeyIndex(key);
            if (finded == null)
                return -1;

            int index;
            if (finded < 0)
            {
                index = (int) -finded;
                Tree[index] = key;
                return index;
            }

            index = (int) finded;

            if (Tree[0] == null && index == 0)
            {
                Tree[0] = key;
            }
            
            return index;
        }
	
    }
}