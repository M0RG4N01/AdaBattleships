using System;
using AdaBattleships;
using AdaBattleships.Config;

Configuration.GetConfig();
Console.WriteLine("Ada Battleships v1.0!");
var activeMenu = new MainMenu();
activeMenu.PrintMenu();
activeMenu.Execute(Convert.ToInt32(Console.ReadLine()));
