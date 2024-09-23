using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LAB1.Tests
{
    public class UnitTest1
    {
        private long Factorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;

            return result;
        }
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

        [Fact]
        public void Test_SimpleWord_NoRepeats()
        {
            string word = "abcd";
            long expectedPermutations = 24; // 4!
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Fact]
        public void Test_WordWithRepeats_AABB()
        {
            string word = "aabb";
            long expectedPermutations = 6; // 4! / (2! * 2!) = 6
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Fact]
        public void Test_WordWithSingleLetter_A()
        {
            string word = "a";
            long expectedPermutations = 1; // 1! = 1
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Fact]
        public void Test_WordWithAllSameLetters_AAAA()
        {
            string word = "aaaa";
            long expectedPermutations = 1; // 4! / 4! = 1
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Fact]
        public void Test_WordWithThreeSameLetters_AAAB()
        {
            string word = "aaab";
            long expectedPermutations = 4; // 4! / 3! = 4
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Fact]
        public void Test_Word_Solo()
        {
            string word = "solo";
            long expectedPermutations = 12; // 4! / (2!) = 12
            long actualPermutations = CalculatePermutations(word);

            Assert.Equal(expectedPermutations, actualPermutations);
        }
    }
}
