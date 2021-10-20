using AdaBattleships.Interfaces;

namespace AdaBattleships.Models
{
    public class RealPlayer : PlayerBase
    {
        public RealPlayer()
        {
        }

        public RealPlayer(Board board) : base(board)
        {
        }

        public override void TakeTurn()
        {
            throw new System.NotImplementedException();
        }

        public override void PrintBoard()
        {
            throw new System.NotImplementedException();
        }
    }
}