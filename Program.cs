using System;
using AdaBattleships.Config;

namespace AdaBattleships
{
    class Program
    {
        private static IMenu activeMenu; //Set this for every new menu we go inside.
        static void Main(string[] args)
        {
            Configuration.GetConfig();
            Console.WriteLine("Ada Battleships v1.0!");
            activeMenu = new MainMenu();
            activeMenu.PrintMenu();
            activeMenu.Execute(Convert.ToInt32(Console.ReadLine()));
        }
    }
}

















