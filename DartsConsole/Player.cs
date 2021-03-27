using System;
using System.Collections.Generic;
using System.Text;

namespace DartsConsole
{
    class Player
    {
        public string Name { get; set; }

        public int Score { get; set; }
        public double Average { get; set; }


        public Player(string name)
        {
            this.Name = name;
        }


    }
}
