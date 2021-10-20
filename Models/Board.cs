using AdaBattleships.Config;

namespace AdaBattleships.Models
{
    public class Board
    {
        private readonly BoardConfig _boardConfig;
        
        public Board(BoardConfig boardConfig)
        {
            _boardConfig = boardConfig;
        }
    }
}