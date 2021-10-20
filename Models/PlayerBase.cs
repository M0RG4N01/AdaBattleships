using AdaBattleships.Config;
using AdaBattleships.Interfaces;

namespace AdaBattleships.Models
{
    public class PlayerBase : IPlayer
    {
        public Board Board { get; set; }

        public PlayerBase() : this(new Board(Configuration.GetConfig().BoardConfig))
        {
        }

        public PlayerBase(Board board)
        {
            Board = board;
        }

        public void TakeTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}