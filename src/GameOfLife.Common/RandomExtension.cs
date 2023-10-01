namespace GameOfLife.Common;

public static class RandomExtension
{
    public static bool NextBoolean(this Random random, float? ratio = null)
    {
        return random.NextSingle() <= (ratio ?? 0.5f);
    }
}