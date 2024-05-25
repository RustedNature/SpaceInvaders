using SpaceInvaders.Controls;
using SpaceInvaders.EntityRelated;
using System.Diagnostics;

namespace SpaceInvaders
{
    internal class GameWindow : Form, IDisposable
    {
        private readonly System.Timers.Timer gameTimer;
        private int frameCounter = 1;
        private readonly Stopwatch stopwatch = new();
        private const int screenWidth = 800;
        private const int screenHeigth = 600;
        private static double deltaTime = 0;

        private Bitmap bufferMap;
        private Graphics bufferGraphics;
        private bool isGameLoopRunning;
        private readonly object graphicsLock = new();

        public static double DeltaTime { get => deltaTime; private set => deltaTime = value; }

        public static int ScreenWidth => screenWidth;

        public static int ScreenHeigth => screenHeigth;

        public GameWindow()
        {
            Width = ScreenWidth;
            Height = ScreenHeigth;
            BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Space Invaders";
            ClientSize = new Size(Width, Height);

            bufferMap = new Bitmap(ScreenWidth, ScreenHeigth);
            bufferGraphics = Graphics.FromImage(bufferMap);

            EntityHandler.CreateEntities();

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

        private void OnKeyUp(object? sender, KeyEventArgs e)
        {
            InputController.ResetKey(e.KeyCode);
        }

        private void OnKeyDown(object? sender, KeyEventArgs e)
        {
            InputController.SetKey(e.KeyCode);
        }

        private void GameLoop(object? sender, EventArgs e)
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

            try
            {
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
            MoveEntities();
            EntityHandler.UpateActiveEntitiesList();
            Debugging();
        }

        private static void MoveEntities()
        {
            //Copy into temporary list to bypass exception
            var tempEntities = new List<Entity>(EntityHandler.Entities);

            foreach (var entity in tempEntities)
            {
                entity.Move();
            }
        }

        private void Debugging()
        {
            Debug.WriteLine($"Frame: {frameCounter++}");
            Debug.WriteLine($"LastDeltaTime: {DeltaTime}");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            lock (graphicsLock)
            {
                bufferGraphics.Clear(BackColor);
                RenderEntities();

                e.Graphics.DrawImage(bufferMap, 0, 0);
            }

            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do nothing to prevent flickering
        }

        private void RenderEntities()
        {
            EntityHandler.Entities.ForEach(e =>
            {
                bufferGraphics.DrawImage(e.Sprite.SpriteImage, e.Coord.X, e.Coord.Y, e.Sprite.SpriteImage.Width, e.Sprite.SpriteImage.Height);
                //Debug.WriteLine($"{e} drawn at X:{e.Coord.X} Y:{e.Coord.Y} and its {e.Sprite.SpriteImage.Width}x{e.Sprite.SpriteImage.Height}");
            });
        }
    }
}