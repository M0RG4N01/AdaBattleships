using System.Collections.Generic;
using AdaBattleships.Models;

namespace AdaBattleships;

public static class Utilities
{
    public static string IntToLetter(int i)
    {
        return ((char) (i + 65)).ToString();
    }
    
    public static int LetterToInt(string letter)
    {
        return letter[0] - 65;
    }
    
    public static Ship? GetShipInPosition(int x, int y, List<Ship> ships)
    {
        foreach (var ship in ships)
        {
            if (ship.IsHorizontal)
            {
                if (y == ship.Y && x >= ship.X && x < ship.X + ship.Size)
                {
                    return ship;
                }
            }
            else
            {
                if (x == ship.X && y >= ship.Y && y < ship.Y + ship.Size)
                {
                    return ship;
                }
            }
        }
        return null;
    }
}