using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }
  
    public class SimpleGraph
    {
        public Vertex [] vertex;
        public int [,] m_adjacency;
        public int max_vertex;

        public int FreeIndex { get; private set; }

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int [size,size];
            vertex = new Vertex [size];
        }
	
        public void AddVertex(int value)
        {
            if (FreeIndex >= max_vertex)
            {
                return;
            }

            vertex[FreeIndex] = new Vertex(value);
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
    }
}