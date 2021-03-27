﻿using System;
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
        GameMeta gameMeta = new GameMeta();

        // default 501 double out game with players and legs 
        public Game(List<Player> players)
        {
            this.Mode = gameMeta.GameModes[0];
            this.Players = players;
            this.CurrentPlayer = players[0];
            this.StartScore = 501;
            this.Legs = 5;
            this.Sets = 1;
            this.Records = new List<string>();
        }

        // full game with options
        public Game(string mode, List<Player> players, int startScore, int legs, int sets)
        {
            this.Mode = mode;
            this.Players = players;
            this.CurrentPlayer = players[0];
            this.StartScore = startScore;
            this.Legs = legs;
            this.Sets = sets;
            this.Records = new List<string>();
        }

        public void DisplayCurrentPlayer()
        {
            Console.Write(this.CurrentPlayer.GetRecord());
        }

        public void DisplayPlayers()
        {
            for (int i = 0; i < this.Players.Count; i++)
            {
                Console.Write($"{this.Players[i].Name}\n");
            }
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
            Console.Write("Game status\n");
            Console.Write($"Game mode: {this.Mode}\n");

            for (int i = 0; i < this.Players.Count; i++)
            {
                Console.Write($"{this.Players[i].GetRecord()}\n");
            }
        }
    }
}
