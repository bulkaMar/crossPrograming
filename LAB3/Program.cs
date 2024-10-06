
//Програма спочатку перевіряє наявність файлу та читає матрицю суміжності.
//Вона рахує кількість ребер і перевіряє, чи дорівнює вона 𝑁 - 1 (обов'язкова умова для дерева).
//Потім за допомогою DFS перевіряє зв'язність графа.
//Якщо всі вершини досяжні й кількість ребер правильна, граф є деревом, і виводиться "YES". Інакше — "NO".
using System;
using System.IO;
using System.Text;

namespace LAB3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string inputFilePath = args.Length > 0 ? args[0] : Path.Combine("LAB3", "INPUT.TXT");
            string outputFilePath = Path.Combine("LAB3", "OUTPUT.TXT");

            var input = File.ReadAllLines(inputFilePath);
            int N = int.Parse(input[0]);
            int[,] adjMatrix = new int[N, N];

            for (int i = 1; i <= N; i++)
            {
                var row = input[i].Split();
                for (int j = 0; j < N; j++)
                {
                    adjMatrix[i - 1, j] = int.Parse(row[j]);
                }
            }

            bool isTree = IsTree(adjMatrix, N);

           
            File.WriteAllText(outputFilePath, isTree ? "YES" : "NO");
            Console.WriteLine("LAB #3");
            Console.WriteLine(isTree ? "YES" : "NO");
        }

        public static bool IsTree(int[,] adjMatrix, int N)
        {
            int edgeCount = CountEdges(adjMatrix, N);
            if (edgeCount != N - 1)
            {
                return false;
            }

            bool[] visited = new bool[N];
            DFS(0, adjMatrix, visited, N);

            foreach (bool visit in visited)
            {
                if (!visit)
                {
                    return false;
                }
            }

            return true;
        }

        public static int CountEdges(int[,] adjMatrix, int N)
        {
            int edgeCount = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (adjMatrix[i, j] == 1)
                    {
                        edgeCount++;
                    }
                }
            }
            return edgeCount;
        }

        public static void DFS(int v, int[,] adjMatrix, bool[] visited, int N)
        {
            visited[v] = true;
            for (int i = 0; i < N; i++)
            {
                if (adjMatrix[v, i] == 1 && !visited[i])
                {
                    DFS(i, adjMatrix, visited, N);
                }
            }
        }
    }
}
