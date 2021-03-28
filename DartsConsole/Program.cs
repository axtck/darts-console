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

            Console.Clear();
            game.ShowStatus(); // show status after setup

            game.Play(); // play game

            Console.Read();
        }

        static Game GetGameSetup()
        {
            // get meta data
            GameMeta gameMeta = new GameMeta();
            string[] startOptions = gameMeta.StartOptions;
            string[] gameModes = gameMeta.GameModes;

            List<Player> players = GetPlayers();

            // while not confirmed
            while (!ConfirmPlayers(players))
            {
                // clear console and override players
                Console.Clear();
                players.Clear();
                players = GetPlayers();
            }

            Game game = new Game(players); // create game with players

            Console.Clear();

            Console.Write($"{players.Count} players added!\n");
            Console.Write("Select game mode\n");

            int startOptionIndex = GetOptionsIndex(startOptions); // get start options (quick game / setup)


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
                    Console.Write("Please fill in a valid option.\n");
                }
            }

            return index;
        }


        static List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();

            Console.Write("Enter player names\nType done when ready\n\n");

            while (true)
            {
                string line = Console.ReadLine();

                if (line.ToLower() == "done")
                {
                    break;
                }

                Player player = new Player(line);
                players.Add(player); // fill up list with players

                Console.Write($"Player {player.Name} added.\n");
            }

            return players;
        }

        static bool ConfirmPlayers(List<Player> players)
        {
            Console.Write("Players added:\n");

            for (int i = 0; i < players.Count; i++)
            {
                Console.Write($"{players[i].Name}\n");
            }

            Console.Write("Confirm (y/n): ");

            while (true)
            {
                string line = Console.ReadLine();

                if (line.ToLower() == "y" || line == "")
                {
                    return true;
                }
                else if (line.ToLower() == "n")
                {
                    return false;
                }
                else
                {
                    Console.Write("Please fill in a valid option.\n");
                }
            }
        }
    }
}
