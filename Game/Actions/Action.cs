using System.Collections.Generic;

namespace GameLibrary.Actions
{
    public abstract class Action
    {
        public Player Player { get; set; }

        public ActionType Type { get; private set; }
        public ActionDirection Direction { get; set; }
        public ActionStatus Status { get; set; }

        public Action(int action)
        {
            switch (action)
            {
                case (int)ActionType.Move: Type = ActionType.Move; break;
                default: break;
            }
        }

        public abstract void PerformAction(Map map, List<Player> players);
    }

    public enum ActionType
    {
        Move,
        Use,
        Inspect,
        Take,
        Drop,
        Attack
    }
    public enum ActionDirection
    {
        North,
        NorthEast,
        NorthWest,
        South,
        SouthEast,
        SouthWest
    }
    public enum ActionStatus
    {
        Invalid,
        Valid
    }
}
