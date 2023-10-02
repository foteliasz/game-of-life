namespace GameOfLife.Data;

public class BlockBuilder
{
    public void Build(
        IWorld world,
        int offsetLeft = 1, 
        int offsetTop = 1)
    {
        world.Set(offsetLeft, offsetTop);
        world.Set(offsetLeft + 1, offsetTop);
        world.Set(offsetLeft, offsetTop + 1);
        world.Set(offsetLeft + 1, offsetTop + 1);
    }
}