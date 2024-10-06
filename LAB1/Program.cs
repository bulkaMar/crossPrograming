using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

/*
    Задача полягає в тому, щоб знайти кількість різних перестановок (анаграм) даного слова з урахуванням повторень літер.

    Алгоритм моїх дій:

    1. Спочатку підраховую кількість кожної літери у слові. Якщо букви в слові повторюються, це зменшує кількість унікальних перестановок.
    
    2. Обчислюю факторіал від довжини слова. Тобто це факторіал від довжини слова n! дає загальну кількість перестановок, якби всі букви були б унікальними.

    3. Далі ділю факторіал довжини слова на добуток факторіалів кількостей повторюваних літер. Тепер якщо літери повторюються, то кількість перестановок зменшується.
    Ось така формула для кількості унікальних перестановок: P = n! / (k1! * k2! * ... * km!), n — це загальна кількість літер,
    k1, k2, ..., km — це кількість кожної унікальної літери.

    Для слова "solo" використовую формулу яку написала вище. 
    Отже, довжина слова: n = 4.
    Далі підраховую кількість кожної унікальної літери всі літери, окрім 'o' зустрічаються один раз.
    окрім 'o'
    За формулою вище все пірахувала і вийшов такий результат: P = 4! / (1! * 2! * 1!) = 24 / 2 = 12.
*/

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        string inputFilePath = args.Length > 0 ? args[0] : Path.Combine("LAB1", "INPUT.TXT");
        string outputFilePath = Path.Combine("LAB1", "OUTPUT.TXT");

        string word = File.ReadAllText(inputFilePath).Trim();

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

        
        File.WriteAllText(outputFilePath, totalPermutations.ToString());
        Console.WriteLine($"Кількість унікальних перестановок слова \"{word}\": {totalPermutations}");
    }
}
