// See https://aka.ms/new-console-template for more information

using GameOfLife.Cli.Ui;
using GameOfLife.Data;

Console.Clear();
var world = new World(
    Console.WindowHeight - 4,
    Console.WindowWidth - 4);
var pane = new Pane(
    Console.WindowHeight - 4,
    Console.WindowWidth - 4,
    2,
    2);

var timer = new System.Timers.Timer();
timer.Interval = 50;
timer.Elapsed += (sender, e) =>
{
    lock (world)
    {
        pane.Reset();
        pane.Write(world.ToString());
        world.Iterate();
    }
};

world.Randomize(0.30f);
timer.Start();
Console.ReadLine();



    
    




