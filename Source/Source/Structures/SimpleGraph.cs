﻿using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T> 
    {
        public T Value;
        public bool Hit;
        public bool InTriangle;

        public Vertex<T> Prev;

        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public int FreeIndex { get; private set; }

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int [size, size];
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
            } while (path.Count > 0);

            return new List<Vertex<T>>();
        }

        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
        {
            foreach (var vert in vertex)
            {
                vert.Hit = false;
                vert.Prev = null;
            }

            var width = new Queue<int>();
            vertex[VFrom].Hit = true;
            width.Enqueue(VFrom);
            var isFind = false;

            do
            {
                var current = width.Dequeue();

                for (var i = 0; i < max_vertex; ++i)
                {
                    if (m_adjacency[current, i] == 0 || vertex[i].Hit)
                        continue;

                    vertex[i].Hit = true;
                    vertex[i].Prev = vertex[current];
                    width.Enqueue(i);

                    if (i == VTo)
                    {
                        isFind = true;
                        break;
                    }
                }
            } while (width.Count > 0 && !isFind);

            if (vertex[VTo].Prev == null)
                return new List<Vertex<T>>();

            var prev = vertex[VTo];
            var path = new List<Vertex<T>>();
            while (prev != null)
            {
                path.Add(prev);
                prev = prev.Prev;
            }

            path.Reverse();
            return path;
        }

        public List<Vertex<T>> WeakVertices()
        {
            var vertToNeigh = new Dictionary<int, List<int>>();
            var result = new List<Vertex<T>>();
            for (var i = 0; i < max_vertex; ++i)
            {
                vertex[i].Hit = false;
                vertex[i].InTriangle = false;
            }

            for (var i = 0; i < max_vertex; ++i)
            {
                if (vertex[i].Hit)
                    continue;

                var currentNeighbours = GetNeighbours(i);
                for (var j = 0; j < max_vertex; ++j)
                {
                    if (m_adjacency[i, j] == 0)
                        continue;

                    var neighbourNeighbours = GetNeighbours(j);
                    var hasIntersect = currentNeighbours.Intersect(neighbourNeighbours).Any();

                    if (hasIntersect)
                    {
                        vertex[i].InTriangle = true;

                        vertex[j].InTriangle = true;
                        vertex[j].Hit = true;
                        break;
                    }
                }

                vertex[i].Hit = true;
            }

            for (var i = 0; i < max_vertex; ++i)
            {
                if (!vertex[i].InTriangle)
                {
                    result.Add(vertex[i]);
                }
            }

            return result;

            List<int> GetNeighbours(int vertIndex)
            {
                if (vertToNeigh.TryGetValue(vertIndex, out var neighbours))
                    return neighbours;

                neighbours = new List<int>();
                for (var k = 0; k < max_vertex; ++k)
                {
                    if (m_adjacency[vertIndex, k] != 0)
                        neighbours.Add(k);
                }

                vertToNeigh[vertIndex] = neighbours;
                return neighbours;
            }
        }
    }
}