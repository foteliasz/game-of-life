using System.Text;
using GameOfLife.Common;

namespace GameOfLife.Data;

public class World : IWorld
{
    private bool[,] _matrix;
    private readonly Random _seeded;
    
    public int Columns { get; }
    public int Rows { get; }

    public World(int rows, int columns)
    {
        _seeded = new Random();
        _matrix = new bool[rows + 2, columns + 2];
        Rows = rows;
        Columns = columns;
    }

    public void Iterate()
    {
        // Creating an empty matrix to store next iteration data
        var future = new bool[Rows + 2, Columns + 2];
        
        for (var row = 1; row <= Rows; row++)
        {
            for (var column = 1; column <= Columns; column++)
            {
                var count = CountNeighbours(row, column);
                var cell = _matrix[row, column];

                if (cell)
                {
                    future[row, column] = count switch
                    {
                        < 2 => false,       // Underpopulation
                        2 or 3 => true,     // Lives on
                        _ => false          // Overpopulation
                    };
                }
                else
                {
                    if (count is 3) future[row, column] = true;     // Reproduction
                }
            }
        }

        _matrix = future;
    }

    public void Set(int row, int column, bool value = true)
    {
        _matrix[row + 1, column + 1] = value;
    }

    private int CountNeighbours(int row, int column)
    {
        var count = 0;
        if (_matrix[row - 1, column - 1]) count += 1;       // Top, Left
        if (_matrix[row - 1, column]) count += 1;           // Top, Center
        if (_matrix[row - 1, column + 1]) count += 1;       // Top, Right
        if (_matrix[row, column - 1]) count += 1;           // Center, Left
        if (_matrix[row, column + 1]) count += 1;           // Center, Right
        if (_matrix[row + 1, column - 1]) count += 1;       // Bottom, Left
        if (_matrix[row + 1, column]) count += 1;           // Bottom, Center
        if (_matrix[row + 1, column + 1]) count += 1;       // Bottom, Right
        return count;
    }
    
    public void Randomize(float? ratio = null)
    {
        for (var row = 1; row <= Rows; row++)
        {
            for (var column = 1; column <= Columns; column++)
            {
                _matrix[row, column] = _seeded.NextBoolean(ratio);
            }
        }
    }

    public override string ToString()
    {
        var writer = new StringBuilder();
        for (var row = 1; row <= Rows; row++)
        {
            for (var column = 1; column <= Columns; column++)
            {
                writer.Append(_matrix[row, column]
                    ? "■"
                    : " ");
            }

            if (row != Rows) writer.AppendLine();
        }

        return writer.ToString();
    }
}