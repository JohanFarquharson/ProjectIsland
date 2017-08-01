using CefSharp;
using GameLibrary;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GameServer
{
    [HubName("ServerHub")]
    public class ServerHub : Hub
    {
        private static object _lock = new object();

        public ServerHub()
        {
            if (!GameServerForm.ServerInitialized)
            {
                GameServerForm.TurnTimer = new System.Timers.Timer();
                GameServerForm.TurnTimer.Interval = 5000;
                GameServerForm.TurnTimer.Elapsed += TurnTimer_Elapsed;

                GameServerForm.ServerInitialized = true;
            }
        }

        private void TurnTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            GameServerForm.Self.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : Turn expired...");
            Turn();
        }

        public override Task OnConnected()
        {
            Clients.Caller.Init(Context.ConnectionId);
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stop_called)
        {
            Game.RemovePlayer(Context.ConnectionId);
            GameServerForm.Self.WriteToLog("Player disconnected => { ID : " + Context.ConnectionId + " }");
            return base.OnDisconnected(stop_called);
        }

        public void SpawnPlayer(string guid, string nick_name)
        {
            if (!Game.Started)
            {
                Game.Started = true;
                GameServerForm.TurnTimer.Start();
            }

            Player player = Game.AddNewPlayer(guid, nick_name);
            Clients.Caller.Update(Json.SerializeWithTypeHandling(player));

            GameServerForm.Self.WriteToLog("Player connected => { Player : " + player.Nickname + ", ID : " + player.ID + " }");
            ExecuteScript("UpdateLog('<span style=\"color: #FFFF00;\">" + player.Nickname + "</span> washed up on the shore.');");
            ExecuteScript($"UpdateMap({Json.SerializeWithoutTypeHandling(Game.GetPlayers()) });");
        }

        public void Turn()
        {
            GameServerForm.TurnTimer.Enabled = false;

            if (GameServerForm.Self.Stopped)
                return;

            Game.Update();
            Game.GetPlayers().ForEach(p =>
            {
                Clients.Client(p.ID.ToString()).Update(Json.SerializeWithoutTypeHandling(p));
            });
            Thread.Sleep(300);
            ExecuteScript($"UpdateMap({Json.SerializeWithoutTypeHandling(Game.GetPlayers()) });");


            Clients.All.MakeMove();

            GameServerForm.Self.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : Starting turn " + Game.Turn++ + "...");
            GameServerForm.TurnTimer.Enabled = true;


            //TurnTime++;

            //ExecuteScript($"UpdateMap('{ Game.Turn } ({ TurnTime }s)',{ Newtonsoft.Json.JsonConvert.SerializeObject(Game.Players) });");

            //if (TurnTime == TurnTimeout || (Game.ActionQueue.Count == Game.Players.Where(x => x.Alive).Count() && TurnTime == 1 && Game.ActionQueue.Count > 0))
            //{
            //    startTurnTime = DateTime.Now;
            //    Clients.All.Turn(Game.Turn++);
            //    TurnTime = 0;
            //    Game.ActionQueue.Clear();
            //    Game.Players.ForEach(x => x.Alive = false);
            //}
        }

        public void MakeMove(string action)
        {
            lock (_lock)
            {
                Game.AddNewAction(Json.DeserializeWithTypeHandling<GameLibrary.Actions.Action>(action));
                //GameServerForm.Self.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : Action added...");

                if (Game.GotAllActions())
                {
                    Turn();
                    GameServerForm.Self.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : Turn completed...");
                }
            }
        }

        //public void Alive(string playerID)
        //{
        //    GameServerForm.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : " + playerID + " => ready...");

        //    //Game.Players.Where(x => x.ID == Guid.Parse(playerID)).First().Alive = true;
        //}

        //public object PlayerState(Player player)
        //{
        //    //hides properties that the clients don't need to see
        //    return new
        //    {
        //        ID = player.ID,
        //        Health = player.Health,
        //        Vision = player.Vision,
        //        Stamina = player.Stamina,
        //        Inventory = player.Inventory,
        //        Location = player.Location,
        //        Nickname = player.Nickname,
        //        VisibleMap = player.VisibleMap,
        //        VisibleItems = player.VisibleItems,
        //        Damage = player.Damage
        //    };
        //}



        public void ExecuteScript(string script)
        {
            try
            {
                GameServerForm.ChromeBrowser.GetMainFrame().ExecuteJavaScriptAsync(script);
            }
            catch (Exception)
            { }
        }

        //public void DoAction(string action, string location, string playerID)
        //{
        //    Player player = Game.Players.Where(x => x.ID == Guid.Parse(playerID)).FirstOrDefault();
        //    TimeSpan ts = DateTime.Now - startTurnTime;
        //    int timeTook = ts.Milliseconds;
        //    player.Alive = true;

        //    bool ActionUsesTurn = false;
        //    /*
        //        move        - move player
        //        take        - pick up item
        //        use         - use item
        //        useInv      - use item in inventory
        //        inspect     - look at item properties
        //        inspectInv  - look at item properties in inventory
        //        drop        - drop item from Inventory
        //        attack      - attack target
        //    */
        //    switch (action)
        //    {
        //        case "move":
        //            ActionUsesTurn = true;
        //            break;
        //        case "use":
        //            ActionUsesTurn = true;
        //            break;
        //        case "useInv":
        //            ActionUsesTurn = true;
        //            break;
        //        case "inspect":
        //            ActionUsesTurn = true;
        //            break;
        //        case "inspectInv":
        //            ActionUsesTurn = true;
        //            break;
        //        case "take":
        //            ActionUsesTurn = false;
        //            break;
        //        case "drop":
        //            ActionUsesTurn = false;
        //            break;
        //        case "attack":
        //            ActionUsesTurn = true;
        //            break;
        //        default:
        //            ActionUsesTurn = false;
        //            break;
        //    }

        //    if (ActionUsesTurn)
        //    {
        //        //if (Game.ActionQueue.Where(x => x.Key == player.ID).Count() == 0)
        //        //{
        //        //    Game.ActionQueue.Add(new KeyValuePair<Guid, Action>(player.ID, new Action(action, location, timeTook)));
        //        //    //player.LastActionStatus = ActionStatus.Valid;
        //        //}
        //        //else
        //        //    //player.LastActionStatus = ActionStatus.Invalid;
        //    }
        //    else
        //    {
        //        //TODO:: Validate actions that don't take turns
        //    }

        //    //Clients.Caller.Response(PlayerState(player));
        //}
    }
}