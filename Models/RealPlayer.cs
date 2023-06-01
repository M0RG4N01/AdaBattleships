using System;
using System.Linq;
using AdaBattleships.Config;

namespace AdaBattleships.Models;

public class RealPlayer : PlayerBase
{
    public override void TakeTurn()
    {
        while (true)
        {
            Console.WriteLine("DEBUG SECOND PLAYER BOARD:::::");
            Game.Instance.SecondPlayer.PrintBoard();
            Console.WriteLine(":::::END DEBUG SECOND PLAYER BOARD");

            Console.WriteLine("Enter the coordinates for your attack (e.g., A2): ");
            var input = Console.ReadLine();

            // Parse user input to get X and Y coordinates
            if (input is { Length: >= 2 })
            {
                var columnChar = char.ToUpper(input[0]);
                var row = -1;
                if (int.TryParse(input[1..], out var rowNumber))
                {
                    row = rowNumber - 1;
                }

                // Validate input
                if (row >= 0 && row < this.Board._boardConfig.BoardY && columnChar >= 'A' && columnChar < 'A' + this.Board._boardConfig.BoardX)
                {
                    var column = columnChar - 'A';
                    var enemyShips = Game.Instance.SecondPlayer.Board.Ships;

                    // Check if any ship is hit at the specified position
                    var hitShip = Utilities.GetShipInPosition(column, row, enemyShips);
                    if (hitShip != null)
                    {
                        // Add hit coordinates to the ship's Hits list
                        hitShip.Hits.Add((column, row));
                        Console.WriteLine("Hit!");
                    }
                    else
                    {
                        Console.WriteLine("Miss!");
                    }

                    Game.Instance.SecondPlayer.Board.Shots.Add((column, row));
                }
                else
                {
                    Console.WriteLine("Invalid coordinates. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }

            break;
        }
    }

    public override void SetupPlayer()
    {
        Console.WriteLine("Would you like ship placement to be automatic or manual?\n" +
                          "1. Automatic\n" +
                          "2. Manual");
            
        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
                AutoPlaceShips();
                break;
            case 2:
                ManuallyPlaceShips();
                break;
            default:
                Console.WriteLine("Invalid Option!");
                break;
        }
    }
    
    public virtual void ManuallyPlaceShips()
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
                Console.WriteLine($"Enter the coordinates for your {ship.Name} (size: {ship.Size}): ");
                var input = Console.ReadLine();

                // Parse user input to get X and Y coordinates
                if (input is { Length: >= 2 })
                {
                    var columnChar = char.ToUpper(input[0]);
                    var row = -1;
                    if (int.TryParse(input[1..], out var rowNumber))
                    {
                        row = rowNumber - 1;
                    }

                    // Validate input
                    if (row >= 0 && row < maxY && columnChar >= 'A' && columnChar < 'A' + maxX)
                    {
                        var column = columnChar - 'A';
                        
                        // Ask user if they would like the ship to be placed virtically or horizontally
                        Console.WriteLine("Would you like the ship to be placed vertically or horizontally? (V/H)");
                        var orientation = Console.ReadLine()?.ToUpper();
                        var isHorizontal = orientation == "H";
                        var isOverlap = false;

                        // Check if the ship fits horizontally
                        if (column + ship.Size <= maxX)
                        {
                            isHorizontal = true;

                            // Check for overlap with existing ships
                            for (var i = column; i < column + ship.Size; i++)
                            {
                                if (Utilities.GetShipInPosition(i, row, this.Board.Ships) != null)
                                {
                                    isOverlap = true;
                                    break;
                                }
                            }
                        }

                        // Check if the ship fits vertically
                        if (!isHorizontal && row + ship.Size <= maxY)
                        {
                            // Check for overlap with existing ships
                            for (var i = row; i < row + ship.Size; i++)
                            {
                                if (Utilities.GetShipInPosition(column, i, this.Board.Ships) != null)
                                {
                                    isOverlap = true;
                                    break;
                                }
                            }
                        }

                        if (!isOverlap)
                        {
                            ship.X = column;
                            ship.Y = row;
                            ship.IsHorizontal = isHorizontal;
                            isPlaced = true;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }
            }
            
            // Add the ship to the board
            if (isPlaced)
            {
                this.Board.Ships.Add(ship);
                this.PrintBoard();
            }
        }
    }
}