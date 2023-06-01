using System.Collections.Generic;
using AdaBattleships.Config;

namespace AdaBattleships.Models;

public class Board
{
    public readonly BoardConfig _boardConfig;
    
    public List<Ship> Ships { get; set; } = new();
    
    public List<(int, int)> Shots { get; set; } = new();
        
    public Board(BoardConfig boardConfig)
    {
        _boardConfig = boardConfig;
    }
}