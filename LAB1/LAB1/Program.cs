using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string word = File.ReadAllText("INPUT.TXT").Trim();
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

        File.WriteAllText("OUTPUT.TXT", totalPermutations.ToString());   
    }
}