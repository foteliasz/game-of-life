namespace GameOfLife.Cli.Ui;

public static class Helpers
{
     public static ConsoleSnap TakeSnapshot()
     {
          var position = Console.GetCursorPosition();
          return new ConsoleSnap
          {
               Top = position.Top,
               Left = position.Left,
               BackgroundColor = Console.BackgroundColor
          };
     }

     public static void ApplySnapshot(ConsoleSnap snap)
     {
          Console.SetCursorPosition(snap.Left, snap.Top);
          Console.BackgroundColor = snap.BackgroundColor;
     }
}