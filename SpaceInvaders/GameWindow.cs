using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.VisualBasic.Devices;
using SpaceInvaders.EntitiyRelated;
using SpaceInvaders.EntityRelated;
using SpaceInvaders.Controls;

namespace SpaceInvaders
{
    internal class GameWindow : Form
    {
        private readonly System.Timers.Timer gameTimer;
        private Player p;
        private int frameCounter = 1;
        private readonly Stopwatch stopwatch = new Stopwatch();

        public static double deltaTime = 0;

        public GameWindow()
        {
            Width = 800;
            Height = 600;
            BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Space Invaders";

            p = EntityHandler.CreatePlayer("p", 400, 500);
            EntityHandler.CreateEnemy(400, 100);
            EntityHandler.CreateEnemy(100, 100);
            EntityHandler.CreateEnemy(700, 100);

            KeyDown += OnKeyDown;
            KeyUp += OnKeyUp;
            gameTimer = new()
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
            deltaTime = stopwatch.Elapsed.TotalSeconds;
            stopwatch.Restart();

            GameUpdate();

            Invalidate();
        }

        private void GameUpdate()
        {
            p.Move();
            MoveEnemies();
            Debuging();
        }

        private static void MoveEnemies()
        {
            var enemies = EntityHandler.Entities.OfType<Enemy>();

            foreach (var enemy in enemies)
            {
                enemy.Move();
            }
        }

        private void Debuging()
        {
            Debug.WriteLine($"Frame: {frameCounter++}");
            Debug.WriteLine($"LastDeltaTime: {deltaTime}");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            RenderEntities(e);

            base.OnPaint(e);
        }

        private static void RenderEntities(PaintEventArgs e)
        {
            foreach (var entity in EntityHandler.Entities)
            {
                e.Graphics.DrawImage(entity.Sprite.SpriteImage, entity.Coord.X, entity.Coord.Y, 45, 45);
            }
        }
    }
}