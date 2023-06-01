using System;
using System.Linq;
using AdaBattleships.Config;
using AdaBattleships.Interfaces;

namespace AdaBattleships.Models;

public abstract class PlayerBase : IPlayer
{
    public Board Board { get; }

    protected PlayerBase()
    {
        this.Board = new Board(Configuration.GetConfig().BoardConfig);
    }

    public abstract void TakeTurn();

    public abstract void SetupPlayer();

    public virtual void PrintBoard()
    {
        for (var x = 0; x < Board._boardConfig.BoardX; x++)
        {
            if (x == 0)
            {
                Console.Write("\t");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Utilities.IntToLetter(x));
            Console.Write("    ");
            Console.ResetColor();
        }

        Console.WriteLine("");
        for (var y = 0; y < Board._boardConfig.BoardY; y++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{y + 1}\t");
            Console.ResetColor();
            for (var x = 0; x < Board._boardConfig.BoardX; x++)
            {
                var ship = Utilities.GetShipInPosition(x, y, Board.Ships);
                if (ship != null)
                {
                    var isShipHit = ship.Hits.Contains((x, y));
                    if (isShipHit)
                    {
                        if (ship.Hits.Count >= ship.Size)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("X");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("X");
                        }

                        Console.Write("    ");
                        Console.ResetColor();
                        continue;
                    }
                    Console.Write(ship.Name[0]);
                    Console.Write("    ");
                    continue;
                }
                
                var isShot = Board.Shots.Contains((x, y));
                if (isShot)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("O");
                    Console.Write("    ");
                    Console.ResetColor();
                    continue;
                }

                Console.Write("~");
                Console.Write("    ");
            }

            Console.WriteLine("");
        }

        Console.WriteLine("");
    }

    public virtual void AutoPlaceShips()
    {
        var maxX = this.Board._boardConfig.BoardX;
        var maxY = this.Board._boardConfig.BoardY;
        var ships = Configuration.GetConfig().ShipsConfig.Ships.ToList();

        foreach (var ship in ships)
        {
            var isPlaced = false;

            // Try placing the ship until it fits and doesn't overlap with existing ships
            while (!isPlaced)
            {
                var randomX = Random.Shared.Next(maxX);
                var randomY = Random.Shared.Next(maxY);
                var isHorizontal = Random.Shared.Next(2) == 0; 

                // Check if the ship fits horizontally
                if (isHorizontal && randomX + ship.Size <= maxX)
                {
                    var isOverlap = false;

                    // Check for overlap with existing ships
                    for (var i = randomX; i < randomX + ship.Size; i++)
                    {
                        if (Utilities.GetShipInPosition(i, randomY, this.Board.Ships) != null)
                        {
                            isOverlap = true;
                            break;
                        }
                    }

                    if (!isOverlap)
                    {
                        ship.X = randomX;
                        ship.Y = randomY;
                        ship.IsHorizontal = true;
                        isPlaced = true;
                        break;
                    }
                }

                // Check if the ship fits vertically
                if (!isHorizontal && randomY + ship.Size <= maxY)
                {
                    var isOverlap = false;

                    // Check for overlap with existing ships
                    for (var i = randomY; i < randomY + ship.Size; i++)
                    {
                        if (Utilities.GetShipInPosition(randomX, i, this.Board.Ships) != null)
                        {
                            isOverlap = true;
                            break;
                        }
                    }

                    if (!isOverlap)
                    {
                        ship.X = randomX;
                        ship.Y = randomY;
                        ship.IsHorizontal = false;
                        isPlaced = true;
                        break;
                    }
                }
            }
            
            if (isPlaced)
            {
                this.Board.Ships.Add(ship);
            }
        }
    }
}