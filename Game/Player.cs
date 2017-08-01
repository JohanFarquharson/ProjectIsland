using System;
using System.Collections.Generic;

namespace GameLibrary
{
    public class Player
    {
        public Guid ID { get; set; }
        public string Nickname { get; set; }
        public string Colour { get; set; }
        public bool Connected { get; set; }

        public int Vision { get; set; }
        public int Health { get; set; }
        public int Stamina { get; set; }

        public int Damage { get; set; }
        public bool Alive { get; set; }

        public Coordinate Location { get; set; }
        public List<Tile> VisibleTiles { get; set; }
        //public Point GlobalLocation { get; set; }

        //public int[,] VisibleItems { get; set; }
        //public int[] Inventory { get; set; }
    }
}
