using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LAB1.Tests
{
    public class UnitTest1
    {
        // Метод для підрахунку факторіалу
        private long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;

            return result;
        }

        // Метод для підрахунку кількості перестановок
        private long CalculatePermutations(string word)
        {
            Dictionary<char, int> letterCount = word.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            long totalPermutations = Factorial(word.Length);

            foreach (var count in letterCount.Values)
            {
                totalPermutations /= Factorial(count);
            }

            return totalPermutations;
        }

        // Тести

        [Fact]
        public void Test_SimpleWord_NoRepeats()
        {
            // Тест для слова без повторів (abcd)
            string word = "abcd";
            long expectedPermutations = 24; // 4!
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Fact]
        public void Test_WordWithRepeats_AABB()
        {
            // Тест для слова з повторами (aabb)
            string word = "aabb";
            long expectedPermutations = 6; // 4! / (2! * 2!) = 6
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Fact]
        public void Test_WordWithSingleLetter_A()
        {
            // Тест для слова з однією буквою (a)
            string word = "a";
            long expectedPermutations = 1; // 1! = 1
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Fact]
        public void Test_WordWithAllSameLetters_AAAA()
        {
            // Тест для слова з усіма однаковими буквами (aaaa)
            string word = "aaaa";
            long expectedPermutations = 1; // 4! / 4! = 1
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Fact]
        public void Test_WordWithThreeSameLetters_AAAB()
        {
            // Тест для слова з трьома однаковими буквами (aaab)
            string word = "aaab";
            long expectedPermutations = 4; // 4! / 3! = 4
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Fact]
        public void Test_Word_Solo()
        {
            // Тест для слова "solo"
            string word = "solo";
            long expectedPermutations = 12; // 4! / (2!) = 12
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }
    }
}
