using AdaBattleships.Config;
using AdaBattleships.Interfaces;

namespace AdaBattleships.Models
{
    public abstract class PlayerBase : IPlayer
    {
        public Board Board { get; set; }

        public PlayerBase() : this(new Board(Configuration.GetConfig().BoardConfig))
        {
        }

        public PlayerBase(Board board)
        {
            Board = board;
        }

        public abstract void TakeTurn();
        public abstract void PrintBoard();
    }
}