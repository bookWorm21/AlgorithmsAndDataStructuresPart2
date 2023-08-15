using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T> 
    {
        public T Value;
        public bool Hit;
        
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }
  
    public class SimpleGraph<T>
    {
        public Vertex<T> [] vertex;
        public int [,] m_adjacency;
        public int max_vertex;

        public int FreeIndex { get; private set; }

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int [size,size];
            vertex = new Vertex<T>[size];
        }
	
        public void AddVertex(T value)
        {
            if (FreeIndex >= max_vertex)
            {
                return;
            }

            vertex[FreeIndex] = new Vertex<T>(value);
            ++FreeIndex;
        }
        
        public void RemoveVertex(int v)
        {
            vertex[v] = null;

            for (var i = 0; i < FreeIndex; ++i)
            {
                m_adjacency[i, v] = 0;
            }

            --FreeIndex;
        }
	
        public bool IsEdge(int v1, int v2)
        {
            return m_adjacency[v1, v2] == 1;
        }
	
        public void AddEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
        }
	
        public void RemoveEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
        }
        
        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            foreach (var vert in vertex)
            {
                vert.Hit = false;
            }

            var path = new Stack<int>();
            var current = VFrom;
            path.Push(current);

            do
            {
                current = path.Peek();
                vertex[current].Hit = true;

                var haveNext = false;
                for (int i = 0; i < max_vertex; ++i)
                {
                    if (m_adjacency[current, i] == 0 || vertex[i].Hit)
                        continue;

                    if (i == VTo)
                    {
                        path.Push(i);
                        return path.Select(ind => vertex[ind]).Reverse().ToList();
                    }

                    current = i;
                    haveNext = true;
                    path.Push(current);
                    break;
                }

                if (!haveNext && path.Count > 0)
                {
                    path.Pop();
                }
            } 
            while (path.Count > 0);

            return new List<Vertex<T>>();
        }
    }
}