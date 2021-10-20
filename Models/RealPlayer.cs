using AdaBattleships.Interfaces;

namespace AdaBattleships.Models
{
    public class RealPlayer : PlayerBase, IPlayer
    {
        public RealPlayer()
        {
        }

        public RealPlayer(Board board) : base(board)
        {
        }

        public void TakeTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}