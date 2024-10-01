using System;
using Xunit;
using LAB3;


namespace LAB3.Tests
{
    public class GraphTests
    {
        [Fact]
        public void Test_IsTree_Example1()
        {
            int N = 3;
            int[,] adjMatrix = new int[,]
            {
            { 0, 1, 0 },
            { 1, 0, 1 },
            { 0, 1, 0 }
            };

            bool result = Program.IsTree(adjMatrix, N);
            Assert.True(result);
        }

        [Fact]
        public void Test_IsTree_Example2()
        {
            int N = 3;
            int[,] adjMatrix = new int[,]
            {
            { 0, 1, 1 },
            { 1, 0, 1 },
            { 1, 1, 0 }
            };

            bool result = Program.IsTree(adjMatrix, N);
            Assert.False(result);
        }

        [Fact]
        public void Test_IsTree_Example3_SingleNode()
        {
            int N = 1;
            int[,] adjMatrix = new int[,]
            {
            { 0 }
            };

            bool result = Program.IsTree(adjMatrix, N);
            Assert.True(result);
        }

        [Fact]
        public void Test_IsTree_Example5_CycleGraph()
        {
            int N = 4;
            int[,] adjMatrix = new int[,]
            {
            { 0, 1, 0, 1 },
            { 1, 0, 1, 0 },
            { 0, 1, 0, 1 },
            { 1, 0, 1, 0 }
            };

            bool result = Program.IsTree(adjMatrix, N);
            Assert.False(result); 
        }

        [Fact]
        public void Test_IsTree_Example6_DisconnectedGraph()
        {
            int N = 4;
            int[,] adjMatrix = new int[,]
            {
            { 0, 1, 0, 0 },
            { 1, 0, 0, 0 },
            { 0, 0, 0, 1 },
            { 0, 0, 1, 0 }
            };

            bool result = Program.IsTree(adjMatrix, N);
            Assert.False(result);
        }
    }

}
