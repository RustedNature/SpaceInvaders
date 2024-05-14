using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal class GameWindow : Form
    {
        private readonly System.Timers.Timer gameTimer;
        private int playerY = 300;
        private int playerX = 400;

        public GameWindow()
        {
            Width = 800;
            Height = 600;
            BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Space Invaders";

            gameTimer = new()
            {
                Interval = 1000 / 30
            };
            gameTimer.Elapsed += GameLoop;
            gameTimer.Start();
        }

        private void GameLoop(object? sender, EventArgs e)
        {
            GameUpdate();

            Invalidate();
        }

        private void GameUpdate()
        {
            playerY++;
            playerX--;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            e.Graphics.FillRectangle(Brushes.White, playerX - 25, playerY - 25, 50, 50);

            base.OnPaint(e);
        }
    }
}