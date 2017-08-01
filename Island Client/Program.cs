using GameLibrary;
using GameLibrary.Actions;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace GameClient
{
    class Program
    {
        private static IHubProxy _hub;
        private static HubConnection _connection;
        private static Player _player;

        private static string _nick_name;

        private static EventHandler _closing_handler;

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);
        private delegate bool EventHandler(CtrlType sig);

        static void Main(string[] args)
        {
            _closing_handler += new EventHandler(ClosingHandler);
            SetConsoleCtrlHandler(_closing_handler, true);

            Console.Write("Enter URL: ");
            string url = Console.ReadLine().Trim();

            Console.Write("Enter player name: ");
            _nick_name = Console.ReadLine().Trim();

            _connection = new HubConnection(url);
            _hub = _connection.CreateHubProxy("ServerHub");

            _hub.On("Init", guid => Init(guid));
            _hub.On("Update", player => Update(player));
            _hub.On("MakeMove", () => MakeMove());

            _connection.Start().Wait();

            Console.ReadLine();
        }

        private static void Init(string guid)
        {
            _hub.Invoke("SpawnPlayer", new object[] { guid, _nick_name });
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " => Init...");
        }
        private static void Update(string player)
        {
            _player = Json.DeserializeWithTypeHandling<Player>(player);
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " => UpdatePlayer... " + _player.Nickname + " (" + _player.ID + ")");
        }
        private static void MakeMove()
        {
            Random random = new Random();
            int direction = random.Next(0, 5);

            _hub.Invoke("MakeMove", Json.SerializeWithTypeHandling(new MoveAction { Player = _player, Direction = (ActionDirection)direction }));
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " => MakeMove...");
        }

        private static bool ClosingHandler(CtrlType sig)
        {
            _connection.Stop();

            return true;
        }
        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
    }
}
