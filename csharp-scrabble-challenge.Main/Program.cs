// See https://aka.ms/new-console-template for more information
using csharp_scrabble_challenge.Main;
Console.WriteLine("Welcome to Scrabble!");


while (true)
{
    Console.WriteLine("Write a Scrabble-word to get it's score(q to quit):");
    string input = Console.ReadLine();
    if (input == "q")
    {
        break;
    }

    Scrabble scrabble = new Scrabble(input);
    Console.WriteLine(scrabble.score());
}