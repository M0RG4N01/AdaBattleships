using AdaBattleships.Config;
using AdaBattleships.Interfaces;

namespace AdaBattleships.Models
{
    public class Game
    {
        public static Game Instance;
        public IPlayer CurrentPlayer;
        public IPlayer SecondPlayer;

        public Game()
        {
            Instance = this;
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