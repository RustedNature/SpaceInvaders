using SpaceInvaders.Controls;
using SpaceInvaders.EntityRelated;
using System.Diagnostics;

namespace SpaceInvaders
{
    internal class GameWindow : Form
    {
        private const int screenHeigth = 600;
        private const int screenWidth = 800;
        private readonly object graphicsLock = new();

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

            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;

            Task.Run(() => { GameLoop.StartGameLoop(this); });
        }

        public static int ScreenHeight => screenHeigth;
        public static int ScreenWidth => screenWidth;

        protected override void OnPaint(PaintEventArgs e)
        {
            lock (graphicsLock)
            {
                Renderer.Render(e, BackColor);
                GameLoop.RenderCompleted.Set();
            }

            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Do nothing to prevent flickering
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