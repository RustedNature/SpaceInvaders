using SpaceInvaders.EntityRelated;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpaceInvaders
{
    internal static class GameLoop
    {
        private static bool isRunning = false;
        private static Stopwatch frametime = new Stopwatch();
        private static int cnt = 0;
        private static GameWindow? gameWindowReference;
        private static double deltaTime = 0;
        private static ManualResetEventSlim renderCompleted = new ManualResetEventSlim();

        public static bool IsRunning { get => isRunning; set => isRunning = value; }
        public static Stopwatch Frametime { get => frametime; set => frametime = value; }
        public static int Cnt { get => cnt; set => cnt = value; }
        internal static GameWindow? GameWindowReference { get => gameWindowReference; set => gameWindowReference = value; }
        public static double DeltaTime { get => deltaTime; set => deltaTime = value; }
        public static ManualResetEventSlim RenderCompleted { get => renderCompleted; set => renderCompleted = value; }

        internal static void StartGameLoop(GameWindow gameWindow)
        {
            GameWindowReference = gameWindow;
            EntityManager.CreateEntities();
            while (true)
            {
                long timeStamp = Stopwatch.GetTimestamp();
                Stopwatch.StartNew();

                LoopGame();
                DeltaTime = (double)Stopwatch.GetElapsedTime(timeStamp).TotalSeconds;
            }
        }

        internal static void LoopGame()
        {
            Debug.Print($"Run {Cnt++} Frametime: {DeltaTime}s");

            Update();
            RenderCompleted.Reset();
            GameWindowReference!.Invalidate();
            RenderCompleted.Wait();
        }

        private static void Update()
        {
            EntityManager.MoveEntities();
            EntityManager.UpateActiveEntitiesList();
            ColliderList.UpdateColliderList();
        }
    }
}