namespace GameOfLife.Cli.Ui;

public class Helpers
{
     public static ConsoleSnap TakeSnapshot()
     {
          var position = Console.GetCursorPosition();
          return new ConsoleSnap
          {
               Top = position.Top,
               Left = position.Left
          };
     }

     public static void ApplySnapshot(ConsoleSnap snap)
     {
          Console.SetCursorPosition(snap.Left, snap.Top);
     }
}