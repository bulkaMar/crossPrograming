namespace LAB2
{
    public class Program
    {
        static void Main()
        {
            string inputFilePath1 = @"C:\Users\61sun\Source\Repos\crossPrograming\LAB2\INPUT1.TXT";
            string inputFilePath2 = @"C:\Users\61sun\Source\Repos\crossPrograming\LAB2\INPUT2.TXT";
            string outputFilePath1 = @"C:\Users\61sun\Source\Repos\crossPrograming\LAB2\OUTPUT1.TXT";
            string outputFilePath2 = @"C:\Users\61sun\Source\Repos\crossPrograming\LAB2\OUTPUT2.TXT";

            if (!File.Exists(inputFilePath1) || !File.Exists(inputFilePath2))
            {
                Console.WriteLine("Один або більше файлів не знайдено.");
                return;
            }

           
            string labyrinth1 = File.ReadAllText(inputFilePath1);
            string labyrinth2 = File.ReadAllText(inputFilePath2);

            int result1 = ProcessLabyrinthFromString(labyrinth1);
            int result2 = ProcessLabyrinthFromString(labyrinth2);

            File.WriteAllText(outputFilePath1, result1.ToString());
            File.WriteAllText(outputFilePath2, result2.ToString());
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
