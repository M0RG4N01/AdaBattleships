using AdaBattleships.Interfaces;

namespace AdaBattleships.Models
{
    public class AIPlayer : PlayerBase, IPlayer
    {
        public AIPlayer()
        {
        }

        public AIPlayer(Board board) : base(board)
        {
        }

        public void TakeTurn()
        {
            throw new System.NotImplementedException();
        }
    }
}