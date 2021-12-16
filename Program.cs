using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Homework4_Year2_Term1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                      { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                      { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                      { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                      { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            Dijkstra dijk = new Dijkstra();
            dijk.dijkstra_Algor(graph, 0);
        }
    }

    public class Dijkstra
    {
        static int Vertex_number = 9;

        int minDistance(int[] distance, bool[] sptSet)
        { 
            int min = int.MaxValue, min_index = -1;
            for (int v = 0; v < Vertex_number; v++)
            {
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = distance[v];
                    min_index = v;
                }
            }
            return min_index;
        }

        void printPath(int[] distance, int n, int srcVert)
        {
            Console.Write("Vertex Distance from Source {0}\n", srcVert);
            for (int i = 0; i < Vertex_number; i++)
            {
                Console.Write(i + " \t\t " + distance[i] + "\n");
            }
        }

        public void dijkstra_Algor(int[,] graph, int sourceVert)
        {
            int[] distance = new int[Vertex_number;
            bool[] sptSet = new bool[Vertex_number];

            for (int i = 0; i < Vertex_number; i++)
            {
                distance[i] = int.MaxValue;
                sptSet[i] = false;
            }
            distance[sourceVert] = 0;

            for (int count = 0; count < Vertex_number - 1; count++)
            {
                int min_Distance_Index = minDistance(distance, sptSet);
                sptSet[min_Distance_Index] = true;
                for (int indx = 0; indx < Vertex_number; indx++)
                {
                    if (!sptSet[indx] && graph[min_Distance_Index, indx] != 0 && distance[min_Distance_Index] != int.MaxValue && distance[min_Distance_Index] + graph[min_Distance_Index, indx] < distance[indx])
                    {
                        distance[indx] = distance[min_Distance_Index] + graph[min_Distance_Index, indx];
                    }
                }
            }
            printPath(distance, Vertex_number, sourceVert);
        }
    }
}