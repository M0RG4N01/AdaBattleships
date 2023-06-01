namespace AdaBattleships.Interfaces;

public interface IPlayer
{
    //Method for taking turn 
    public void TakeTurn();
    //Player print own board to screen
    public void PrintBoard();

    public void SetupPlayer();
}