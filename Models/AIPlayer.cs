using AdaBattleships.Interfaces;

namespace AdaBattleships.Models
{
    public class AIPlayer : PlayerBase
    {
        public AIPlayer()
        {
        }

        public AIPlayer(Board board) : base(board)
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