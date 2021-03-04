using System;
using System.Globalization;

namespace data
{
    class Data
    {
        private DateTime now = DateTime.Now;
        private int[] numbersAmount = new int[10];
        private void CalculateNumbersAmount(int[] numbersAmount, int number)
        {
            int itterationAmount = 0;
            while (number > 0)
            {
                numbersAmount[number % 10]++;
                number /= 10;
                itterationAmount++;
            }
            if (itterationAmount < 2)
            {
                numbersAmount[0]++;
            }
        }
        public void PrintDataFormats()
        {
            Console.WriteLine(now.ToString("dd.MM.yyyy HH:mm:ss"));
            Console.WriteLine(now.ToString("ddd dd MMM yyyy hh:mm:ss tt", CultureInfo.InvariantCulture));
        }
        public void PrintAmountOfNumbers()
        {
            CalculateNumbersAmount(numbersAmount, now.Year);
            CalculateNumbersAmount(numbersAmount, now.Month);
            CalculateNumbersAmount(numbersAmount, now.Day);
            CalculateNumbersAmount(numbersAmount, now.Hour);
            CalculateNumbersAmount(numbersAmount, now.Minute);
            CalculateNumbersAmount(numbersAmount, now.Second);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Amount of " + i + ": " + numbersAmount[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Data todayData = new Data();
            todayData.PrintDataFormats();
            todayData.PrintAmountOfNumbers();
            Console.ReadKey();
        }
    }
}
