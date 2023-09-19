// See https://aka.ms/new-console-template for more information

using GameOfLife.Data;

var world = new World(10, 10);
world.Randomize(0.15f);
Console.Write(world.ToString());
