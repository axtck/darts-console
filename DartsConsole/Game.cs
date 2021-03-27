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

        public List<Player> Players { get; set; }
        public int StartScore { get; set; }
        public int Legs { get; set; }
        public int Sets { get; set; }

        // default 501 double out game with players and legs 
        public Game(List<Player> players, int legs)
        {
            this.Type = GameType.DoubleOut;
            this.Players = players;
            this.StartScore = 501;
            this.Sets = 1;
            this.Legs = legs;
        }

        // full game with options
        public Game(GameType type, List<Player> players, int startScore, int legs, int sets)
        {
            this.Type = type;
            this.Players = players;
            this.StartScore = startScore;
            this.Legs = legs;
            this.Sets = sets;
        }

    }
}
