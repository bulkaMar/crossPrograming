using System;
using Xunit;

namespace LAB2.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Test_LabyrinthWithNoPath()
        {
            string input = "3 1\n000\n010\n000";
            int result = Program.ProcessLabyrinthFromString(input);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_LabyrinthWithObstacles()
        {
            string input = "3 1\n000\n010\n000";
            int result = Program.ProcessLabyrinthFromString(input);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_LabyrinthWithIsolatedCells()
        {
            string input = "4 1\n0000\n0110\n0000\n0000";
            int result = Program.ProcessLabyrinthFromString(input);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_LabyrinthWithMultipleObstacles()
        {
            string input = "5 3\n00000\n00100\n00000\n00100\n00000";
            int result = Program.ProcessLabyrinthFromString(input);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test_LabyrinthWithFive()
        {
            string input = "3 6\n000\n101\n100";
            int result = Program.ProcessLabyrinthFromString(input);
            Assert.Equal(5, result);
        }
    }
}
