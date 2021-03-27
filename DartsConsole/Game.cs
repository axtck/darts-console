using System;
using System.Collections.Generic;
using System.Text;

namespace DartsConsole
{
    class Game
    {
        public enum GameType
        {
            DoubleOut,
            Cricket
        }

        public GameType Type { get; set; }

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

        // default 501 double out game with players and legs 
        public Game(List<Player> players, int legs)
        {
            this.Type = GameType.DoubleOut;
            this.Players = players;
            this.CurrentPlayer = players[0];
            this.StartScore = 501;
            this.Legs = legs;
            this.Sets = 1;
            this.Records = new List<string>();
        }

        // full game with options
        public Game(GameType type, List<Player> players, int startScore, int legs, int sets)
        {
            this.Type = type;
            this.Players = players;
            this.CurrentPlayer = players[0];
            this.StartScore = startScore;
            this.Legs = legs;
            this.Sets = sets;
            this.Records = new List<string>();
        }

        public void Start()
        {
            Console.Write("Starting!\n");
        }

        public void DisplayCurrentPlayer()
        {
            Console.Write(this.CurrentPlayer.GetRecord());
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
    }
}
