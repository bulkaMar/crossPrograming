using System;
using System.IO;
using System.Text;

namespace LAB2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string inputFilePath1 = args.Length > 0 ? args[0] : Path.Combine("LAB2", "INPUT1.TXT");
            string inputFilePath2 = args.Length > 1 ? args[1] : Path.Combine("LAB2", "INPUT2.TXT");
            string outputFilePath1 = Path.Combine("LAB2", "OUTPUT1.TXT");
            string outputFilePath2 = Path.Combine("LAB2", "OUTPUT2.TXT");

            if (!File.Exists(inputFilePath1) || !File.Exists(inputFilePath2))
            {
                Console.WriteLine("One or more files not found.");
                return;
            }

            string labyrinth1 = File.ReadAllText(inputFilePath1);
            string labyrinth2 = File.ReadAllText(inputFilePath2);

            int result1 = ProcessLabyrinthFromString(labyrinth1);
            int result2 = ProcessLabyrinthFromString(labyrinth2);

            File.WriteAllText(outputFilePath1, result1.ToString());
            File.WriteAllText(outputFilePath2, result2.ToString());
             Console.WriteLine("LAB #2");
            Console.WriteLine($"Results for INPUT1.TXT: {result1}");
            Console.WriteLine($"Results for INPUT2.TXT: {result2}");
        }

        public static int ProcessLabyrinthFromString(string input)
        {
            string[] lines = input.Trim().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] firstLine = lines[0].Split();
            int N = int.Parse(firstLine[0]);
            int K = int.Parse(firstLine[1]);

            char[,] grid = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                string line = lines[i + 1];
                for (int j = 0; j < N; j++)
                {
                    grid[i, j] = line[j];
                }
            }

            int[,,] a = new int[2, N + 2, N + 2];
            a[0, 1, 1] = 1;

            for (int m = 1; m <= K; m++)
            {
                for (int i = 0; i <= N + 1; i++)
                    for (int j = 0; j <= N + 1; j++)
                        a[m % 2, i, j] = 0;

                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= N; j++)
                    {
                        if (grid[i - 1, j - 1] == '0')
                        {
                            a[m % 2, i, j] = a[(m - 1) % 2, i - 1, j]
                                           + a[(m - 1) % 2, i + 1, j]
                                           + a[(m - 1) % 2, i, j - 1]
                                           + a[(m - 1) % 2, i, j + 1];
                        }
                    }
                }
            }
            return a[K % 2, N, N];
        }
    }
}
