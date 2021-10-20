using System;
using AdaBattleships.Models;

namespace AdaBattleships
{
    public class MainMenu : IMenu
    {
        private Game _game;

        public void PrintMenu()
        {
            Console.WriteLine("\nMain Menu\n" +
                              "Please select an option:\n" +
                              "1. Player vs Player\n" +
                              "2. Player vs Computer\n" +
                              "3. Quit\n"
                              );
        }

        public void Execute(int option)
        {
            switch (option)
            {
                case 1:
                {
                    _game = new Game(new RealPlayer(), new RealPlayer());
                    _game.Start();
                    break;
                }
                case 2:
                {
                    _game = new Game(new RealPlayer(), new AIPlayer());                               
                    _game.Start();
                    break;
                }
                case 3:
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid Option, please try again!\n");
                    break;
                }
            }
        }
    }
}