using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary
{
    public static class Game
    {
        private static object update_lock = new object();
        private static List<Actions.Action> ActionQueue = new List<Actions.Action>();
        private static List<Player> Players = new List<Player>();

        public static Map Map = new Map();

        public static int Turn = 1;
        public static bool Started = false;

        public static List<Player> GetPlayers()
        {
            return Players;
        }
        public static Player AddNewPlayer(string guid, string nick_name)
        {
            lock (update_lock)
            {
                Player player = new Player
                {
                    ID = Guid.Parse(guid),
                    Nickname = nick_name,
                    Colour = "#FFFF00",
                    Connected = true,

                    Vision = 4,
                    Health = 10,
                    Stamina = 10,
                    Damage = 1,
                    Alive = true,

                    Location = GetSpawnLocation()
                };
                player.VisibleTiles = GetVisibleTiles(player);
                Players.Add(player);

                return player;
            }
        }
        public static void RemovePlayer(string guid)
        {
            lock (update_lock)
            {
                Players.Where(p => p.ID == Guid.Parse(guid)).ToList().ForEach(p => { p.Connected = false; });
            }
        }

        public static void AddNewAction(Actions.Action action)
        {
            ActionQueue.Add(action);
        }
        public static bool GotAllActions()
        {
            return ActionQueue.Select(a => a.Player.ID).Intersect(Players.Select(p => p.ID)).Count() == Players.Count();
        }

        private static Coordinate GetSpawnLocation()
        {
            Random random = new Random();
            int location = random.Next(0, Map.SpawnLocations.Count - 1);
            return Map.SpawnLocations[location];
        }
        private static List<Tile> GetVisibleTiles(Player player)
        {
            List<Coordinate> coordiantes = new List<Coordinate>();
            AddVisibleTiles(ref coordiantes, player.Location, player.Vision);

            List<Tile> tiles = new List<Tile>();
            coordiantes.ForEach(c =>
            {
                tiles.Add(Map.Tiles[c.X, c.Y]);
            });

            return tiles;
        }
        private static void AddVisibleTiles(ref List<Coordinate> coordiantes, Coordinate coordinate, int level)
        {
            List<Coordinate> temp_coordiantes = coordiantes;

            if (!temp_coordiantes.Any(c => c.X == coordinate.X && c.Y == coordinate.Y))
                temp_coordiantes.Add(coordinate);

            if (level == 0)
            {
                coordiantes = temp_coordiantes;
                return;
            }

            Map.Tiles[coordinate.X, coordinate.Y].Neighbours.ForEach(n =>
            {
                AddVisibleTiles(ref temp_coordiantes, n, level - 1);
            });

            coordiantes = temp_coordiantes;
        }

        public static void Update()
        {
            lock (update_lock)
            {
                ActionQueue.RemoveAll(a => Players.Where(p => p.Connected == false).ToList().Any(p => p.ID == a.Player.ID));
                Players.RemoveAll(p => p.Connected == false);

                ActionQueue.ForEach(a =>
                {
                    a.PerformAction(Map, Players);
                });

                Players.ForEach(p =>
                {
                    p.VisibleTiles = GetVisibleTiles(p);
                });

                ActionQueue.Clear();
            }
        }
    }
}
