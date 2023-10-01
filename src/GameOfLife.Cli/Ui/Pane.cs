namespace GameOfLife.Cli.Ui;

public class Pane
{
    private readonly Point _topLeft;
    private readonly Point _bottomRight;
    public Point Position { get; private set; }

    public Pane(
        int rows, 
        int columns, 
        int offsetLeft, 
        int offsetTop)
    {
        _topLeft = new Point { X = offsetLeft, Y = offsetTop };
        _bottomRight = new Point
        {
            X = _topLeft.X + columns,
            Y = _topLeft.Y + rows
        };
        Position = new Point { X = _topLeft.X, Y = _topLeft.Y };
    }

    public void Write(string phrase)
    {
        var snap = Helpers.TakeSnapshot();
        Console.SetCursorPosition(Position.X, Position.Y);
        foreach (var character in phrase)
        {
            if (Console.CursorLeft > _bottomRight.X)
            {
                Console.SetCursorPosition(
                    _topLeft.X,                     // Reset left position
                    Console.CursorTop + 1);         // and go to next row
            }
            Console.Write(character);
        }

        var temp = Console.GetCursorPosition();
        Position = new Point { X = temp.Left, Y = temp.Top };
        Helpers.ApplySnapshot(snap);
    }
}