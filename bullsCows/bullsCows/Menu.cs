using System;
using System.Collections.Generic;

namespace bullsCows
{
    class Menu
    {
        private int index;
        private List<string> menuItem;
        public Menu()
        {
            index = 0;
            menuItem = new List<string>
            {
                "Start Game",
                "Game Rules",
                "Exit"
            };

        }
        private string buildMenu(List<string> menuItem)
        {
            Console.CursorVisible = false;
            for (int i = 0; i < menuItem.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(menuItem[i]);
                Console.ResetColor();
            }
            ConsoleKeyInfo pressKey = Console.ReadKey();
            Console.Clear();
            if (pressKey.Key == ConsoleKey.DownArrow && index != menuItem.Count - 1)
            {
                index++;
            }
            else if (pressKey.Key == ConsoleKey.UpArrow && index != 0)
            {
                index--;
            }
            else if (pressKey.Key == ConsoleKey.Enter)
            {
                return menuItem[index];
            }
            return "";
        }
        public void gameMenu()
        {
            while (true)
            {
                string selectedMenu = buildMenu(menuItem);
                if (selectedMenu == "Game Rules")
                {
                    Console.Clear();
                    Console.WriteLine("You write down a secret number and ask computer to guess what the number is. When computer makes a guess, you provide a hint with the following info:");
                    Console.WriteLine("-The number of bulls, which are digits in the guess that are in the correct position.");
                    Console.WriteLine("-The number of cows, which are digits in the guess that are in your secret number but are located in the wrong position");
                    Console.WriteLine("The hint should be formatted as 'x y', where x is the number of bulls and y is the number of cows. Your number may not contain duplicate digits and must have 4 digits");
                    Console.WriteLine("Press something to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (selectedMenu == "Exit")
                {
                    Environment.Exit(0);
                }
                else if (selectedMenu == "Start Game")
                {
                    Console.Clear();
                    Game myGame = new Game();
                    myGame.newGame();
                    Console.WriteLine("Press something to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
