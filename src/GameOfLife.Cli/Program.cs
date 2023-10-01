// See https://aka.ms/new-console-template for more information

using GameOfLife.Cli.Ui;
using GameOfLife.Common;
using GameOfLife.Data;

Console.Clear();
var world = new World(
    Console.WindowHeight - 4,
    Console.WindowWidth - 4);
world.Randomize(0.05f);

var pane = new Pane(
    Console.WindowHeight - 4,
    Console.WindowWidth - 4,
    2,
    2);
pane.Write(world.ToString().SanitizeNewLines());
