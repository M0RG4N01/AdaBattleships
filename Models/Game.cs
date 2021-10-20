using AdaBattleships.Config;
using AdaBattleships.Interfaces;

namespace AdaBattleships.Models
{
    public class Game
    {
        public static Game Instance;
        public PlayerBase CurrentPlayer;
        public PlayerBase SecondPlayer;

        public Game()
        {
            Instance = this;
        }

        public Game(PlayerBase currentPlayer, PlayerBase secondPlayer)
        {
            CurrentPlayer = currentPlayer;
            SecondPlayer = secondPlayer;
        }

        public void Start()
        {
            
        }

        public void SwitchPlayers()
        {
            (CurrentPlayer, SecondPlayer) = (SecondPlayer, CurrentPlayer);
        }
    }
}