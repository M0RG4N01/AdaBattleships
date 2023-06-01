using System;

namespace AdaBattleships;

public interface IMenu
{
    public void PrintMenu();
    public void Execute(int option);
}