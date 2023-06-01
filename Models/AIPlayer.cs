using System;
using System.Collections.Generic;
using System.Threading;

namespace AdaBattleships.Models;

public class AIPlayer : PlayerBase
{
    public override void TakeTurn()
    {
        Console.WriteLine("Computer is taking a turn...");

        var maxX = this.Board._boardConfig.BoardX;
        var maxY = this.Board._boardConfig.BoardY;

        // Generate random coordinates for the computer's attack
        var randomX = Random.Shared.Next(maxX);
        var randomY = Random.Shared.Next(maxY);
        
        // Check if the computer has already attacked the randomly generated position
        while (Game.Instance.SecondPlayer.Board.Shots.Contains((randomX, randomY)))
        {
            randomX = Random.Shared.Next(maxX);
            randomY = Random.Shared.Next(maxY);
        }

        var playerShips = Game.Instance.SecondPlayer.Board.Ships;

        // Check if any ship is hit at the randomly generated position
        var hitShip = Utilities.GetShipInPosition(randomX, randomY, playerShips);
        if (hitShip != null)
        {
            // Add hit coordinates to the ship's Hits list
            hitShip.Hits.Add((randomX, randomY));
            Console.WriteLine($"Computer's attack: Hit at ({Utilities.IntToLetter(randomX)}{randomY + 1})");
        }
        else
        {
            Console.WriteLine($"Computer's attack: Miss at ({Utilities.IntToLetter(randomX)}{randomY + 1})");
        }
        
        Game.Instance.SecondPlayer.Board.Shots.Add((randomX, randomY));

        Thread.Sleep(300);
    }

    public override void SetupPlayer()
    {
        this.AutoPlaceShips();
        Console.WriteLine("....Automatic Setup of AI Complete!");
    }
}