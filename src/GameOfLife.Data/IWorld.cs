namespace GameOfLife.Data;

public interface IWorld
{
    void Iterate();

    void Set(int row, int column, bool value = true);
}