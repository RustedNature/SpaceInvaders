using SpaceInvaders.Controls;
using System.Collections;
using SpaceInvaders.EntityRelated;

namespace SpaceInvaders.EntityRelated
{
    internal class Player : Entity
    {
        private static readonly string spritePath = Assets.Assets.AssetsPath + "\\panzer.png";
        private readonly float moveSpeed = 100f;
        private bool isShooting = false;
        private string name;

        public Player(string name, int posX, int posY)
            : base(SpritePath, posX, posY, Tags.Player)
        {
            Name = name;
        }

        public static string SpritePath => spritePath;
        public string Name { get => name; set => name = value; }

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
                EntityHandler.CreateBullet(Coord.X, Coord.Y, Tags.PlayerBullet);
                isShooting = true;
            }
            else
            {
                isShooting = false;
            }
            base.Move();
        }

        internal override void Destroy()
        {
            throw new NotImplementedException();
        }

        internal override void OnCollision(Entity sender, EventArgs e)
        {
            if (sender.Tag == Tags.EnemyBullet)
            {
            }
        }
    }
}