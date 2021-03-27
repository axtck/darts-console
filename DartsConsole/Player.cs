using System;
using System.Collections.Generic;
using System.Text;

namespace DartsConsole
{
    class Player
    {
        // player name
        public string Name { get; set; }

        // score stats
        public int Turns { get; set; }
        public int Score { get; set; }
        public int TotalScore { get; set; }
        public int ScoreLeft { get; set; }
        public double Average { get; set; }


        public Player(string name)
        {
            this.Name = name;
        }

        public string GetRecord()
        {
            // return a record for a throw
            return $"Name: {this.Name} --- Score left: {this.ScoreLeft} --- Points last turn: {this.Score} --- Average: {this.Average}\n";
        }

        public void CalcScore()
        {
            this.Turns++; // add a turn
            this.TotalScore += this.Score; // add score to total
            this.ScoreLeft -= this.TotalScore; // subtract total from points left
        }


        public void CalcAverage()
        {
            this.Average = this.TotalScore / this.Turns; // calculate average
        }
    }
}
