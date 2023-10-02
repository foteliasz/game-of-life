using GameOfLife.Common;

namespace GameOfLife.Cli.Ui;

public class Pane
{
    private readonly ConsoleColor _backgroundColor;
    private readonly Point _topLeft;
    private readonly Point _bottomRight;
    private Point _position;

    public Pane(
        int rows, 
        int columns, 
        int offsetLeft, 
        int offsetTop,
        ConsoleColor backgroundColor = default)
    {
        _backgroundColor = backgroundColor;
        _topLeft = new Point { X = offsetLeft, Y = offsetTop };
        _bottomRight = new Point
        {
            X = _topLeft.X + columns,
            Y = _topLeft.Y + rows
        };
        _position = new Point { X = _topLeft.X, Y = _topLeft.Y };
    }

    public void Write(string phrase)
    {
        var snap = Helpers.TakeSnapshot();
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.BackgroundColor = _backgroundColor;

        phrase = phrase.SanitizeNewLines();
        var lines = phrase.SplitToPieces(_bottomRight.X - _topLeft.X).ToArray();
        var last = lines.Last();
        foreach (var line in lines)
        {
            Console.Write(line);
            if (!line.Equals(last))
                Console.SetCursorPosition(
                    _topLeft.X,
                    Console.CursorTop + 1);
        }

        var temp = Console.GetCursorPosition();
        _position = new Point { X = temp.Left, Y = temp.Top };
        Helpers.ApplySnapshot(snap);
    }

    public void Reset()
    {
        _position = new Point { X = _topLeft.X, Y = _topLeft.Y };
    }
}