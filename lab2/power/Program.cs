using System;

namespace Power
{
    class PowerOfTwos
    {
        private ulong first;
        private ulong second;
        public ulong GetFirst()
        {
            return first;
        }
        public ulong GetSecond()
        {
            return second;
        }
        private ulong Enter()
        {
            ulong number;
            string firstNumber = Console.ReadLine();
            while (ulong.TryParse(firstNumber, out number) == false && number == 0)
            {
                Console.WriteLine("Try again");
                firstNumber = Console.ReadLine();
            }
            return number;
        }
        public void EnterData()
        {
            Console.WriteLine("Enter first number");
            first = Enter();
            Console.WriteLine("Enter second number");
            second = Enter();
            Change();
        }
        private ulong MaxPowerOfNumber(ulong number)
        {
            ulong twoPower = 2;
            ulong maxPowerOfNumber = 0;
            while (number / twoPower > 0)
            {
                maxPowerOfNumber += (number / twoPower);
                twoPower *= 2;
            }
            return maxPowerOfNumber;
        }
        private void Change()
        {
            if (first > second)
            {
                ulong temp = first;
                first = second;
                second = temp;
            }
        }
        public void CountPrintMaxPower()
        {
            ulong maxPowerOfInterval = MaxPowerOfNumber(second) - MaxPowerOfNumber(first - 1);
            Console.WriteLine(maxPowerOfInterval);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            PowerOfTwos interval = new PowerOfTwos();
            interval.EnterData();
            Console.WriteLine("Your interval is [" + interval.GetFirst() + ";" + interval.GetSecond() + "]");
            Console.Write("Power is: ");
            interval.CountPrintMaxPower();
            Console.ReadKey();
        }
    }
}
