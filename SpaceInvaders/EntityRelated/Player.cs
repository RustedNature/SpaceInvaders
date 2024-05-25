using SpaceInvaders.Controls;
using System.Collections;
using SpaceInvaders.EntityRelated;

namespace SpaceInvaders.EntityRelated
{
    internal class Player : Entity
    {
        private string name;
        private readonly float moveSpeed = 100f;
        private static readonly string spritePath = Assets.Assets.AssetsPath + "\\panzer.png";
        private bool isShooting = false;

        public Player(string name, int posX, int posY)
            : base(SpritePath, posX, posY)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }

        public static string SpritePath => spritePath;

        public override void Move()
        {
            BitArray keys = InputController.Keys;
            if ((keys[(int)KeyIndex.Left] || keys[(int)KeyIndex.A]) && Coord.X > 0)
            {
                Coord.X -= moveSpeed * (float)GameWindow.DeltaTime;
            }
            else if ((keys[(int)KeyIndex.Right] || keys[(int)KeyIndex.D]) && Coord.X < GameWindow.ScreenWidth - Sprite.SpriteImage.Width)
            {
                Coord.X += moveSpeed * (float)GameWindow.DeltaTime;
            }
            if (keys[(int)KeyIndex.Space] && !isShooting)
            {
                EntityHandler.CreateBullet(Coord.X, Coord.Y);
                isShooting = true;
            }
            else
            {
                isShooting = false;
            }
        }
    }
}