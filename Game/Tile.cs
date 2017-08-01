using System.Collections.Generic;

namespace GameLibrary
{
    public class Tile
    {
        public TileType Type { get; set; }
        public bool Passable { get; set; }
        public string Colour { get; set; }
        public Coordinate Coordinate { get; set; }
        public List<Coordinate> Neighbours { get; set; }
    }

    public enum TileType
    {
        DeepWater,
        MediumWater,
        ShallowWater,
        Spawn,
        Sand,
        Grass,
        Foliage,
        Tree,
        Dirt,
        Rock
    }
}
