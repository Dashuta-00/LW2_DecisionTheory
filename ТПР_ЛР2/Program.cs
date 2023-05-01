using System;
using System.Collections.Generic;

namespace Дейкстра
{
    class Program
    {
        struct Metka
        {
            public int dist;
            public int previousVertex;
        }
        static void Main(string[] args)
        {
            int matrixSeed = 45; 
            const int vertexCount = 7;
            int[,] matrix = new int[vertexCount, vertexCount];
            Metka[] metki = new Metka[vertexCount];
            Random rand = new Random(matrixSeed); 
            matrix[0, 0] = -1;                    
            matrix[0, 1] = -1; matrix[1, 0] = -1; 
            matrix[0, 2] = 1; matrix[2, 0] = 1;   
            matrix[0, 3] = 1; matrix[3, 0] = 1;   
            matrix[0, 4] = 1; matrix[4, 0] = 1;   
            matrix[0, 5] = -1; matrix[5, 0] = -1; 
            matrix[0, 6] = -1; matrix[6, 0] = -1; 
            for (int i = 1; i < vertexCount; i++)
            {
                for (int j = i; j < vertexCount; j++)
                {
                    if (i != j && Convert.ToBoolean(rand.Next(1, 2)))
                    {
                        matrix[i, j] = rand.Next(1, 20);
                        matrix[j, i] = matrix[i, j];
                    }
                    else
                    {
                        matrix[i, j] = -1;
                        matrix[j, i] = matrix[i, j];
                    }
                }
            }
            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            metki[0].dist = 0; metki[0].previousVertex = 0;
            for (int i = 1; i < vertexCount; i++) metki[i].dist = int.MaxValue;
            List<int> nextVetrexs = new List<int> { 0 }; 
            for (int i = 0; i < nextVetrexs.Count; i++)
            {
                int nv = nextVetrexs[i];
                for (int j = 0; j < vertexCount; j++)
                {
                    if (matrix[nv, j] != -1 && metki[j].dist > metki[nv].dist + matrix[nv, j])
                    {
                        nextVetrexs.Add(j);
                        metki[j].dist = metki[nv].dist + matrix[nv, j];
                        metki[j].previousVertex = nv;
                    }
                }
            }
            Console.Write($"dist = {metki[vertexCount - 1].dist}\nPath = {vertexCount}-");
            for (int i = vertexCount - 1; metki[i].previousVertex != 0;)
            {
                i = metki[i].previousVertex;
                Console.Write($"{i + 1}-");
            }
            Console.WriteLine(1);
            Console.WriteLine($"Узел   Метка     Статус метки");
            for (int i = 0; i < vertexCount; i++)
            {
                Console.WriteLine($" {i + 1}     [{metki[i].dist.ToString() +", " + (metki[i].previousVertex + 1).ToString(), 5}]   Постоянная");
            }
        }
    }
}
