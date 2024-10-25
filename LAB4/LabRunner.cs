using System;
using System.IO;
using System.Text;
using LAB1;
using LAB2;
using LAB3;

public class LabRunner
{
    public void RunLab1(string inputFile, string outputFile)
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            string word = File.ReadAllText(inputFile).Trim();

            Dictionary<char, int> letterCount = word.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            long Factorial(int n)
            {
                long result = 1;
                for (int i = 2; i <= n; i++)
                    result *= i;
                return result;
            }

            long totalPermutations = Factorial(word.Length);
            foreach (var count in letterCount.Values)
                totalPermutations /= Factorial(count);

            File.WriteAllText(outputFile, totalPermutations.ToString());

            Console.WriteLine("File OUTPUT.TXT successfully created");
            Console.WriteLine("LAB #1");
            Console.WriteLine($"The number of unique word permutations \"{word}\": {totalPermutations}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public void RunLab2(string inputFile, string outputFile1, string outputFile2)
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            string labyrinth = File.ReadAllText(inputFile);
            int result = LAB2.Program.ProcessLabyrinthFromString(labyrinth);

            File.WriteAllText(outputFile1, result.ToString());
            File.WriteAllText(outputFile2, result.ToString()); // Можливо, це інший результат, якщо потрібно

            Console.WriteLine("Files OUTPUT1.TXT and OUTPUT2.TXT successfully created");
            Console.WriteLine("LAB #2");
            Console.WriteLine($"Results for {inputFile}: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    public void RunLab3(string inputFile, string outputFile)
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            var input = File.ReadAllLines(inputFile);
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

            bool isTree = LAB3.Program.IsTree(adjMatrix, N);

            File.WriteAllText(outputFile, isTree ? "YES" : "NO");
            Console.WriteLine("File OUTPUT.TXT successfully created");
            Console.WriteLine("LAB #3");
            Console.WriteLine(isTree ? "YES" : "NO");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}