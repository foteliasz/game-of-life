using System.Text;
using GameOfLife.Common;

namespace GameOfLife.Data;

public class World
{
    private readonly bool[,] _matrix;
    private readonly Random _seeded;
    
    public World(int rows, int columns)
    {
        _seeded = new Random();
        _matrix = new bool[rows, columns];
        Rows = rows;
        Columns = columns;
    }

    public int Columns { get; }
    public int Rows { get; }

    public void Randomize(float? ratio = null)
    {
        for (var row = 0; row < Rows; row++)
        {
            for (var column = 0; column < Columns; column++)
            {
                _matrix[row, column] = _seeded.NextBoolean(ratio);
            }
        }
    }

    public override string ToString()
    {
        var writer = new StringBuilder();
        for (var row = 0; row < Rows; row++)
        {
            for (var column = 0; column < Columns; column++)
            {
                writer.Append(_matrix[row, column]
                    ? "■"
                    : " ");
            }

            writer.AppendLine();
        }

        return writer.ToString();
    }
}