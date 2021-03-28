using System;
using System.Collections.Generic;
using System.Text;

namespace DartsConsole
{
    class Game
    {
        public string Mode { get; set; }

        // players in game
        public List<Player> Players { get; set; }

        // player that has turn
        public Player CurrentPlayer { get; set; }

        // score stats 
        public int StartScore { get; set; }
        public int Legs { get; set; }
        public int Sets { get; set; }

        // game records
        public List<string> Records { get; set; }

        // meta for gametype
        private GameMeta gameMeta = new GameMeta();

        private int playerIndex = 0; // index for player that has turn
        private int starterIndex = 0; // index for player that has to start leg

        // default 501 double out game with players 
        public Game(List<Player> players)
        {
            this.Mode = gameMeta.GameModes[0];
            this.Players = players;
            this.CurrentPlayer = players[playerIndex];
            this.StartScore = 501;
            this.Legs = 5;
            this.Sets = 3;
            this.Records = new List<string>();
        }

        // full game with options
        public Game(string mode, List<Player> players, int startScore, int legs, int sets)
        {
            this.Mode = mode;
            this.Players = players;
            this.CurrentPlayer = players[playerIndex];
            this.StartScore = startScore;
            this.Legs = legs;
            this.Sets = sets;
            this.Records = new List<string>();
        }

        public void Play()
        {
            while (true)
            {
                Console.Write($"{this.CurrentPlayer.Name} to throw, you require {this.CurrentPlayer.ScoreLeft}.\n");
                this.GetCurrentPlayerScore(); // get the current player score
                this.CurrentPlayer.DoCalculations(); // calculate score and average

                Console.Write($"{this.CurrentPlayer.GetRecord()}\n\n"); // write record to console
                this.SaveRecord(); // save current record to records

                // leg won
                if (this.CurrentPlayer.ScoreLeft == 0)
                {
                    this.CurrentPlayer.LegsWon++; // add leg to record

                    // reset players score
                    for (int i = 0; i < this.Players.Count; i++)
                    {
                        this.Players[i].ScoreLeft = this.StartScore;
                    }

                    this.CurrentPlayer.Win("leg");

                    starterIndex++; // start index +1

                    if (starterIndex >= this.Players.Count)
                    {
                        starterIndex = 0; // reset starter index if last player has started a leg
                    }

                    playerIndex = starterIndex; // set player index equal to start index
                }
                else
                {
                    // if leg is in play
                    playerIndex++; // player index +1
                    if (playerIndex >= this.Players.Count)
                    {
                        playerIndex = 0; // reset player index when last player has thrown
                    }

                }

                // set won
                if (this.CurrentPlayer.LegsWon == this.Legs)
                {
                    // reset players legs
                    for (int i = 0; i < this.Players.Count; i++)
                    {
                        this.Players[i].LegsWon = 0;
                    }

                    this.CurrentPlayer.SetsWon++;
                    this.CurrentPlayer.Win("set");
                }

                // game won
                if (this.CurrentPlayer.SetsWon == this.Sets)
                {
                    this.CurrentPlayer.Win("game");
                    break; // game over
                }

                this.CurrentPlayer = this.Players[playerIndex]; // set new current player
            }
        }

        public void GetCurrentPlayerScore()
        {
            Console.Write("Points scored: ");

            while (true)
            {
                string line = Console.ReadLine();

                try
                {
                    this.CurrentPlayer.Score = Convert.ToInt32(line);

                    // check if score is in range 0 - 180
                    if (this.CurrentPlayer.Score >= 0 && this.CurrentPlayer.Score < 181)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.Write("Please fill in a valid score.\n");
                }
            }

            Console.Write($"{this.CurrentPlayer.Score} scored by {this.CurrentPlayer.Name}.\n");
        }

        public void SaveRecord()
        {
            this.Records.Add(this.CurrentPlayer.GetRecord());
        }

        public void DisplayRecords()
        {
            for (int i = 0; i < this.Records.Count; i++)
            {
                Console.Write($"{this.Records[i]}\n");
            }
        }

        public void ShowStatus()
        {
            Console.Write("\nGame status\n");
            Console.Write($"Game mode: {this.Mode} --- Sets: {this.Sets} --- Legs: {this.Legs} --- variant: {StartScore}\n");
            Console.Write("Players:\n");

            for (int i = 0; i < this.Players.Count; i++)
            {
                Console.Write($"Player {i + 1}: {this.Players[i].GetInfo()}\n");
            }
        }
    }
}
