using SpaceInvaders.Controls;
using SpaceInvaders.EntityRelated;
using System.Diagnostics;

namespace SpaceInvaders
{
    internal class GameWindow : Form
    {
        private const int screenHeigth = 600;
        private const int screenWidth = 800;
        private static double deltaTime = 0;
        private readonly System.Timers.Timer gameTimer;
        private readonly object graphicsLock = new();
        private readonly Stopwatch stopwatch = new();

        private int frameCounter = 1;
        private bool isGameLoopRunning;

        public GameWindow()
        {
            Width = ScreenWidth;
            Height = ScreenHeight;
            BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Space Invaders";
            ClientSize = new Size(Width, Height);

            EntityManager.CreateEntities();

            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;

            gameTimer = new System.Timers.Timer
            {
                Interval = 1000f / 60f
            };
            Debug.WriteLine(gameTimer.Interval);
            gameTimer.Elapsed += GameLoop;
            stopwatch.Start();
            gameTimer.Start();
        }

        public static double DeltaTime { get => deltaTime; private set => deltaTime = value; }

        public static int ScreenHeight => screenHeigth;
        public static int ScreenWidth => screenWidth;

        protected override void OnPaint(PaintEventArgs e)
        {
            lock (graphicsLock)
            {
                Renderer.Render(e);
            }

            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do nothing to prevent flickering
        }

        private static void MoveEntities()
        {
        }

        private void Debugging()
        {
            Debug.WriteLine($"Frame: {frameCounter++}");
            Debug.WriteLine($"LastDeltaTime: {DeltaTime}");
        }

        private void GameLoop(object? sender, EventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<object, EventArgs>(GameLoop), sender, e);
                    return;
                }

                if (isGameLoopRunning)
                    return;

                lock (graphicsLock)
                {
                    if (isGameLoopRunning)
                        return;
                    isGameLoopRunning = true;
                }

                DeltaTime = stopwatch.Elapsed.TotalSeconds;
                stopwatch.Restart();

                GameUpdate();

                Invalidate();
            }
            finally
            {
                isGameLoopRunning = false;
            }
        }

        private void GameUpdate()
        {
            EntityManager.MoveEntities();
            EntityManager.UpateActiveEntitiesList();
            ColliderList.UpdateColliderList();
            Debugging();
        }

        private void OnKeyDown(object? sender, KeyEventArgs e)
        {
            InputController.SetKey(e.KeyCode);
        }

        private void OnKeyUp(object? sender, KeyEventArgs e)
        {
            InputController.ResetKey(e.KeyCode);
        }
    }
}