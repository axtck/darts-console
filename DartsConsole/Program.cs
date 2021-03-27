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
            Console.Write("What game do you want to play?\n");


            GameMeta gameMeta = new GameMeta();
            string[] gameTypes = gameMeta.GameModes;

            string gameMode = SelectGameMode(gameTypes);
            List<Player> players = GetPlayers();

            

            Game game = new Game(players, 5);

            game.DisplayPlayers();

            Console.Read();
        }

        static string SelectGameMode(string[] gameTypes)
        {
            for (int i = 0; i < gameTypes.Length; i++)
            {
                Console.Write($"{gameTypes[i]} ({i + 1}) ");
            }

            Console.Write("\n");

            string gameType;

            while (true)
            {
                string line = Console.ReadLine();

                try
                {
                    int gameTypeIndex = Convert.ToInt32(line); // try converting to int
                    if (gameTypeIndex > 0 && gameTypeIndex < gameTypes.Length + 1)
                    {
                        gameType = gameTypes[gameTypeIndex - 1]; // set gameType
                        break;
                    }
                    else
                    {
                        throw new Exception(); // throw an exception to catch  
                    }
                }
                catch
                {
                    Console.WriteLine("Please fill in a valid option");
                }
            }

            return gameType;
        }

        static List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();
            Console.Write("Enter player names\nType done when ready\n\n");

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "done")
                {
                    break;
                }

                Player player = new Player(line, 501);
                players.Add(player);

                Console.Write($"Player {player.Name} added\n");
            }

            Console.Write($"{players.Count} players added!\n");

            return players;
        }
    }
}
