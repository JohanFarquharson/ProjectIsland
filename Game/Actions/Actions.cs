using System;
using System.Collections.Generic;
using System.Linq;

namespace GameLibrary.Actions
{
    public class MoveAction : Action
    {
        public MoveAction() : base((int)ActionType.Move)
        { }

        public override void PerformAction(Map map, List<Player> players)
        {
            var player = players.Where(p => p.ID == Player.ID).FirstOrDefault();

            switch (Direction)
            {
                case ActionDirection.North:
                    if (map.Tiles[player.Location.X, player.Location.Y - 1].Passable)
                    {
                        player.Location.Y--;
                        Status = ActionStatus.Valid;
                    }
                    else
                    {
                        Status = ActionStatus.Invalid;
                    }
                    break;

                case ActionDirection.NorthEast:
                    if (map.Tiles[player.Location.X + 1, (player.Location.X % 2 == 0) ? player.Location.Y - 1 : player.Location.Y].Passable)
                    {
                        if (player.Location.X % 2 == 0)
                            player.Location.Y--;
                        player.Location.X++;
                        Status = ActionStatus.Valid;
                    }
                    else
                    {
                        Status = ActionStatus.Invalid;
                    }
                    break;

                case ActionDirection.NorthWest:
                    if (map.Tiles[player.Location.X - 1, (player.Location.X % 2 == 0) ? player.Location.Y - 1 : player.Location.Y].Passable)
                    {
                        if (player.Location.X % 2 == 0)
                            player.Location.Y--;
                        player.Location.X--;
                        Status = ActionStatus.Valid;
                    }
                    else
                    {
                        Status = ActionStatus.Invalid;
                    }
                    break;

                case ActionDirection.South:
                    if (map.Tiles[player.Location.X, player.Location.Y + 1].Passable)
                    {
                        player.Location.Y++;
                        Status = ActionStatus.Valid;
                    }
                    else
                    {
                        Status = ActionStatus.Invalid;
                    }
                    break;

                case ActionDirection.SouthEast:
                    if (map.Tiles[player.Location.X + 1, (player.Location.X % 2 != 0) ? player.Location.Y + 1 : player.Location.Y].Passable)
                    {
                        if (player.Location.X % 2 != 0)
                            player.Location.Y++;
                        player.Location.X++;
                        Status = ActionStatus.Valid;
                    }
                    else
                    {
                        Status = ActionStatus.Invalid;
                    }
                    break;

                case ActionDirection.SouthWest:
                    if (map.Tiles[player.Location.X - 1, (player.Location.X % 2 != 0) ? player.Location.Y + 1 : player.Location.Y].Passable)
                    {
                        if (player.Location.X % 2 != 0)
                            player.Location.Y++;
                        player.Location.X--;
                        Status = ActionStatus.Valid;
                    }
                    else
                    {
                        Status = ActionStatus.Invalid;
                    }

                    break;
            }

            Player = player;
        }
    }
    public class UseAction : Action
    {
        public UseAction() : base((int)ActionType.Use)
        { }

        public override void PerformAction(Map map, List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
    public class InspectAction : Action
    {
        public InspectAction() : base((int)ActionType.Inspect)
        { }

        public override void PerformAction(Map map, List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
    public class TakeAction : Action
    {
        public TakeAction() : base((int)ActionType.Take)
        { }

        public override void PerformAction(Map map, List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
    public class DropAction : Action
    {
        public DropAction() : base((int)ActionType.Drop)
        { }

        public override void PerformAction(Map map, List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
    public class AttackAction : Action
    {
        public AttackAction() : base((int)ActionType.Attack)
        { }

        public override void PerformAction(Map map, List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
}
