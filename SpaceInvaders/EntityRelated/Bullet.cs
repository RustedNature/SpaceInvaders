using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntityRelated
{
    internal class Bullet : Entity
    {
        private static string spritePath = Assets.Assets.AssetsPath + "\\bullet.png";
        private float moveSpeed = 250f;

        public Bullet(float posX, float posY, Tags tag) : base(SpritePath, posX, posY, tag)
        {
        }

        public static string SpritePath { get => spritePath; set => spritePath = value; }
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

        public void AdjustSpritePosition()
        {
            Coord.X -= Sprite.SpriteImage.Width / 2;
        }

        public override void Move()
        {
            if (Coord.Y <= 50)
            {
                Destroy();
                return;
            }
            Coord.Y -= MoveSpeed * (float)GameWindow.DeltaTime;
            base.Move();
        }

        internal override void Destroy()
        {
            EntityHandler.MarkForRemove(this);
            ColliderList.MarkForRemove(Collider);
        }

        internal override void OnCollision(Entity sender, EventArgs e)
        {
            if (sender.Tag != Tags.Player && sender.Tag != Tags.PlayerBullet)
            {
                Destroy();
                sender.Destroy();
            }
        }
    }
}