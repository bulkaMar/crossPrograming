using LAB5.Models;
using Microsoft.AspNetCore.Mvc;
using LAB1;



namespace LAB5.Controllers
{
    public class LabController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public LabController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Lab1()
        {
            var model = new LabViewModel
            {
                TaskNumber = "1",
                TaskVariant = "7",
                TaskDescription = "На день народження Петі подарували набір карток із літерами. Тепер Петя з великим інтересом складає з них різні слова. " +
                "І ось, одного разу, склавши чергове слово, Петя зацікавився питанням:" +
                " \"А скільки різних слів можна скласти з тих самих карток, що й це?\".",
                OutputDescription = "У вихідний файл OUTPUT.TXT виведіть одне ціле число – відповідь на поставлене завдання.",
                TestCases = new List<TestCase>
            {
                new TestCase { Input = "solo", Output = "12" },
            }
            };
            return View(model);
        }

        public IActionResult Lab2()
        {
            var model = new LabViewModel
            {
                TaskNumber = "2",
                TaskVariant = "7",
                TaskDescription = "Карта лабіринту є квадратне поле розміром N×N. Деякі квадрати цього поля заборонені для проходження. " +
                "Крок у лабіринті – переміщення з однієї дозволеної клітини до іншої дозволеної клітини, суміжної з першою стороною. " +
                "Шлях – це певна послідовність таких кроків. При цьому кожну клітину, включаючи початкову та кінцеву, можна відвідувати кілька разів.\r\n" +
                "Потрібно написати програму, яка підрахує кількість різних шляхів із клітини (1, 1) у клітину (N, N) рівно за K кроків (тобто опинитися у клітині (N, N) після K-го кроку).\r\n",
                InputDescription = "Вхідний файл INPUT.TXT містить у першому рядку числа N і K, розділені пробілом (1 < N ≤ 15, 0 < K ≤ 30). Наступні N рядків, N символів у кожному, містять карту лабіринту, починаючи з клітини (1, 1)." +
                "Символ \"0\" означає не заборонену для проходження клітину, а символ \"1\" - заборонену. " +
                "Початкова та кінцева клітини завжди дозволені для проходження.",
                OutputDescription = "Вихідний файл OUTPUT.TXT повинен містити кількість можливих різних шляхів довжини K. У всіх тестах це значення не перевищуватиме 2147483647",
                TestCases = new List<TestCase>
            {
                new TestCase { Input = "3 6 \n" +
                                       "000 \n" +
                                       "101 \n" +
                                       "100", Output = "5"
                },
                new TestCase { Input = "2 8 \n" +
                                       "01 \n" +
                                       "10", Output = "0" 
                }
                }
            };
            return View(model);
        }

        public IActionResult Lab3()
        {
            var model = new LabViewModel
            {
                TaskNumber = "3",
                TaskVariant = "7",
                TaskDescription = "Неорієнтований граф без петель та кратних ребер заданий матрицею суміжності. Потрібно визначити, чи цей граф є деревом.",
                InputDescription = "У вхідному файлі INPUT.TXT записано спочатку число N - кількість вершин графа (від 1 до 100). " +
                "Далі записана матриця суміжності розміром N N, в якій 1 позначає наявність ребра, 0 - його відсутність. Матриця симетрична щодо головної діагоналі.",
                OutputDescription = "У вихідний файл OUTPUT.TXT виведіть повідомлення YES, якщо граф є деревом, і NO інакше.",
                TestCases = new List<TestCase>
            {
                new TestCase
                {
                    Input = "3\n0 1 0 \n1 0 1 \n0 1 0",
                    Output = "YES"
                }
            }
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProcessLab(int labNumber, IFormFile inputFile)
        {
            if (inputFile == null || inputFile.Length == 0)
                return BadRequest("Please upload a file");

            string[] lines;
            using (var reader = new StreamReader(inputFile.OpenReadStream()))
            {
                var fileContent = await reader.ReadToEndAsync();
                lines = fileContent.Split(Environment.NewLine);
            }

            string output = null;

            switch (labNumber)
            {
                case 1:
                    output = LAB1.Program.CalculateUniquePermutation(lines[0]).ToString();
                    break;
                case 2:
                    output = LAB2.Program.ProcessLabyrinthFromString(string.Join(Environment.NewLine, lines)).ToString();
                    break;
                case 3:
                    int N = int.Parse(lines[0]);
                    int[,] adjMatrix = new int[N, N];
                    for (int i = 1; i <= N; i++)
                    {
                        var row = lines[i].Split();
                        for (int j = 0; j < N; j++)
                        {
                            adjMatrix[i - 1, j] = int.Parse(row[j]);
                        }
                    }
                    bool istree = LAB3.Program.IsTree(adjMatrix, N);
                    output = istree ? "YES" : "NO";
                    break;
                default:
                    return BadRequest("Invalid lab number");
            }

            var result = new { output = output };
            return Json(result);
        }

    }
}
