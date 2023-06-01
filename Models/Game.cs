using System;
using System.Linq;

namespace AdaBattleships.Models;

public class Game
{
    public static Game Instance;
    public PlayerBase CurrentPlayer;
    public PlayerBase SecondPlayer;

    public int CurrentPlayerNumber = 1;

    public Game()
    {
        Instance = this;
    }

    public Game(PlayerBase currentPlayer, PlayerBase secondPlayer) : this()
    {
        CurrentPlayer = currentPlayer;
        SecondPlayer = secondPlayer;
    }

    public void Start()
    {
        PreFlightChecks();
        PlayGame();
    }
    
    private void PlayGame()
    {
        while (true)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"Player {CurrentPlayerNumber}'s Turn");
            Console.WriteLine($"Player {CurrentPlayerNumber} Board:");
            CurrentPlayer.PrintBoard();

            CurrentPlayer.TakeTurn();
            // Check if game is over
            if (SecondPlayer.Board.Ships.All(x => x.Hits.Count >= x.Size))
            {
                Console.WriteLine($"Player {CurrentPlayerNumber} Wins!");
                break;
            }
            SwitchPlayers();
        }
    }

    private void PreFlightChecks()
    {
        Console.WriteLine("\nPlayer 1 Setup:");
        CurrentPlayer.SetupPlayer();
        Console.WriteLine("\nPlayer 2 Setup:");
        SecondPlayer.SetupPlayer();
    }

    public void SwitchPlayers()
    {
        (CurrentPlayer, SecondPlayer) = (SecondPlayer, CurrentPlayer);

        CurrentPlayerNumber = CurrentPlayerNumber == 1 ? 2 : 1;
    }
}