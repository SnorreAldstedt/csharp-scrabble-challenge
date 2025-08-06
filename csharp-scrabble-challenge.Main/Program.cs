// See https://aka.ms/new-console-template for more information
using csharp_scrabble_challenge.Main;
Console.WriteLine("Hello, World!");

Scrabble scrabble = new Scrabble("tEst123");
scrabble.Test();

Scrabble scrabble2 = new Scrabble("\"\\n\\r\\t\\b\\f\"Halloooo");
scrabble2.Test();