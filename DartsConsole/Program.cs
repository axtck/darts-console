using System;
using System.Collections.Generic;

namespace DartsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to Darts Console!\n");
            Console.Write("-------------------------\n\n");

            // players
            Player player1 = new Player("Alexander", 501);
            Player player2 = new Player("Hendrik", 501);

            // add players
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            // game
            Game game = new Game(players, 5);

            game.Start();

            player1.Score = 55;
            player1.CalcScore();
            player1.CalcAverage();
            game.DisplayCurrentPlayer();

            player1.Score = 44;
            player1.CalcScore();
            player1.CalcAverage();
            game.DisplayCurrentPlayer();


            Console.Read();


        }
    }
}
