using System;
using System.Collections.Generic;
using System.Linq;

namespace bullsCows
{
    class Game
    {
        private static List<int> allVariants = new List<int>();
        private static List<int> candidates = new List<int>();
        private static bool[] possibleCombinations = new bool[10001];
        private static (int, int)[,] bullsCows = new (int, int)[10001, 10001]; //первый бык, второй корова
        private static (int, int) answer;
        private static int query = 1234;
        private static void buildAllVariants()//все возможные варианты загаданного числа (5040 чисел)
        {
            for (int i = 100; i < 9999; i++)
            {
                int[] digits = new int[10];
                int x = i, digitsQuantity = 0;
                while (x > 0)
                {
                    digits[x % 10]++;
                    digitsQuantity++;
                    x /= 10;
                }
                if (digitsQuantity < 4)
                {
                    digits[0]++;
                }
                bool correct = true;
                for (int j = 0; j < 10; j++)
                {
                    if (digits[j] > 1)
                    {
                        correct = false;
                        break;
                    }
                }
                if (correct)
                {
                    allVariants.Add(i);
                }
            }
            candidates = allVariants;
        }
        private static void buildBullsCows() //количество быков и коров у каждой пары возможных комбинаций
        {
            for (int i = 0; i < allVariants.Count(); i++)//номер каждой цифры числа справа налево начиная с 1
            {
                int[] orderOfDigits = new int[10];
                int x = allVariants[i];
                for (int k = 1; k <= 4; k++)
                {
                    orderOfDigits[x % 10] = k;
                    x /= 10;
                }
                bullsCows[allVariants[i], allVariants[i]] = (4, 0);
                for (int j = i + 1; j < allVariants.Count(); j++)
                {
                    x = allVariants[j];
                    for (int k = 1; k <= 4; k++)
                    {
                        if (orderOfDigits[x % 10] == k)//если позиция и цифра повторяется в 2 числах добавляем быков
                        {
                            bullsCows[allVariants[i], allVariants[j]].Item1++;
                            bullsCows[allVariants[j], allVariants[i]].Item1++;
                        }
                        else if (orderOfDigits[x % 10] > 0)//если повторяется цифра, но не позиция - коров
                        {
                            bullsCows[allVariants[i], allVariants[j]].Item2++;
                            bullsCows[allVariants[j], allVariants[i]].Item2++;
                        }
                        x /= 10;
                    }
                }
            }
        }
        private static void process()
        {
            List<int> newCandidates = new List<int>();
            for (int i = 0; i < candidates.Count(); i++)//убираем из кандидатов все, что не подходит под данный запрос введенный пользователем
            {
                if (bullsCows[query, candidates[i]] == answer)
                {
                    newCandidates.Add(candidates[i]);
                    possibleCombinations[candidates[i]] = true;
                }
                else
                {
                    possibleCombinations[candidates[i]] = false;
                }
            }
            candidates = newCandidates;
            int minRating = Int32.MaxValue; //ищем новый запрос
            for (int i = 0; i < allVariants.Count(); i++)
            {
                int currentRating = -1;
                int[,] numberOfAnswers = new int[5, 5];//считаем рейтинг для данной комбинации как максимум из возможных
                for (int j = 0; j < candidates.Count(); j++)
                {
                    (int, int) currentAnswer = bullsCows[allVariants[i], candidates[j]];
                    numberOfAnswers[currentAnswer.Item1, currentAnswer.Item2]++;
                    currentRating = Math.Max(currentRating, numberOfAnswers[currentAnswer.Item1, currentAnswer.Item2]);
                }
                if (currentRating < minRating || (possibleCombinations[allVariants[i]] == true && currentRating == minRating))
                {
                    minRating = currentRating;
                    query = allVariants[i];
                }
            }
        }
        private static void input()//обработка пользовательского ввода быков и коров
        {
            bool falseInput = true;
            int bulls = 0, cows = 0;
            while (falseInput)
            {
                Console.WriteLine("Enter number of bulls(first) and cows separeted by a one space/sign");
                string input = Console.ReadLine();
                if (input.Length == 3 && input[0] >= 48 && input[0] <= 52 && input[2] >= 48 && input[2] <= 52 && input[0] + input[2] - 96 <= 4)
                {
                    bulls = input[0] - 48;
                    cows = input[2] - 48;
                    falseInput = false;
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again");
                }
            }
            answer.Item1 = bulls;
            answer.Item2 = cows;
        }
        public static void newGame()
        {
            string output = query.ToString();
            Console.CursorVisible = true;
            Console.WriteLine("Wish your number");
            buildAllVariants();
            buildBullsCows();
            Console.WriteLine("Your number is " + query + "?");
            input();
            while (answer.Item1 != 4 && candidates.Count > 0)
            {
                process();
                if (query < 1000)
                {
                    Console.WriteLine("Your number is " + "0" + query + "?");
                    output = "0" + query.ToString();
                }
                else
                {
                    Console.WriteLine("Your number is " + query + "?");
                    output = query.ToString();
                }
                input();
            }
            if (answer.Item1 == 4)
            {
                Console.WriteLine("Your number is " + output);
            }
            if (candidates.Count == 0)
            {
                Console.WriteLine("You've made mistake during the game. Please check everything and try again");
            }
            allVariants.Clear();
            candidates.Clear();
            for (int i = 0; i < 10001; i++)
            {
                for (int j = 0; j < 10001; j++)
                {
                    bullsCows[i, j] = (0, 0);
                }
                possibleCombinations[i] = true;
            }
            query = 1234;
        }
    }
}
