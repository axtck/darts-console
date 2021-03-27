using System;
using System.Collections.Generic;

namespace DartsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to Darts Console!\n\n"); // write welcome message

            Game game = GetGameSetup(); // get game setup

            game.ShowStatus(); // show status after setup

            Console.Read();
        }

        static Game GetGameSetup()
        {
            // get meta data
            GameMeta gameMeta = new GameMeta();
            string[] startOptions = gameMeta.StartOptions;
            string[] gameModes = gameMeta.GameModes;


            // get players
            Console.Write("Enter player names\nType done when ready\n\n");
            List<Player> players = GetPlayers();
            Console.Write($"{players.Count} players added!\n");

            int startOptionIndex = GetOptionsIndex(startOptions); // get start options (quick game / setup)

            Game game = new Game(players); // add game with players

            // if setup is chosen
            if (startOptionIndex == 1)
            {
                int gameModeIndex = GetOptionsIndex(gameModes); // get game mode
                game = new Game(gameModes[gameModeIndex], players, 501, 5, 3); // override game with more setup options
            }

            // give players their start score
            for (int i = 0; i < players.Count; i++)
            {
                players[i].ScoreLeft = game.StartScore;
            }

            return game;
        }

        static int GetOptionsIndex(string[] options)
        {
            // display options
            for (int i = 0; i < options.Length; i++)
            {
                Console.Write($"({i + 1}){options[i]}\t");
            }

            Console.Write("\n");

            int index;

            while (true)
            {
                string line = Console.ReadLine();

                try
                {
                    index = Convert.ToInt32(line); // try converting to int

                    // get index
                    if (index > 0 && index < options.Length + 1)
                    {
                        index = index - 1;
                        break;
                    }
                    else
                    {
                        throw new Exception(); // throw exception to catch
                    }
                }
                catch
                {
                    Console.WriteLine("Please fill in a valid option.");
                }
            }

            return index;
        }

        
        static List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "done")
                {
                    break;
                }

                Player player = new Player(line);
                players.Add(player); // fill up list with players

                Console.Write($"Player {player.Name} added.\n");
            }

            return players;
        }
    }
}
