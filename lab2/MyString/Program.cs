using System;

namespace MyString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string[] reversStr = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = reversStr.Length - 1; i >= 0; i--)
            {
                Console.Write(reversStr[i] + " ");
            }
        }
    }
}
