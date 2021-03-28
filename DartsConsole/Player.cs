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
        public int LegsWon { get; set; }
        public int SetsWon { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }

        public string GetRecord()
        {
            // return a record for a throw
            return $"Name: {this.Name} --- Score left: {this.ScoreLeft} --- Points last turn: {this.Score} " +
                $"--- Average: {this.Average} --- Legs won: {this.LegsWon} --- Sets won: {this.SetsWon}";
        }

        public string GetInfo()
        {
            return $"Name: {this.Name}";
        }

        public void CalcScore()
        {
            this.Turns++; // add a turn
            this.TotalScore += this.Score; // add score to total
            this.ScoreLeft -= this.Score; // subtract score from points left
        }

        public void CalcAverage()
        {
            this.Average = this.TotalScore / this.Turns; // calculate average
        }

        public void DoCalculations()
        {
            this.CalcScore();
            this.CalcAverage();
        }

        public void Win(string matchPart)
        {
            Console.Clear();
            Console.Write($"{this.Name} has won the {matchPart}!\n\n");
        }
    }
}
