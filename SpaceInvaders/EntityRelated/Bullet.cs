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
            if (Tag == Tags.PlayerBullet)
            {
                Coord.X -= Sprite.SpriteImage.Width / 2;
            }
            else if (Tag == Tags.EnemyBullet)
            {
                Coord.X -= Sprite.SpriteImage.Width / 2;
                Coord.Y += Sprite.SpriteImage.Height;

                Sprite.SpriteImage.RotateFlip(RotateFlipType.Rotate180FlipNone);

                for (int i = 0; i < Sprite.SpriteImage.Width; i++)
                {
                    for (int y = 0; y < Sprite.SpriteImage.Height; y++)
                    {
                        if (Sprite.SpriteImage.GetPixel(i, y).A != 255)
                        {
                            continue;
                        }
                        Sprite.SpriteImage.SetPixel(i, y, Color.Aquamarine);
                    }
                }
            }
        }

        public override void Move()
        {
            if (Tag == Tags.PlayerBullet)
            {
                if (Coord.Y <= 50)
                {
                    Destroy();
                    return;
                }
                Coord.Y -= MoveSpeed * (float)GameWindow.DeltaTime;
            }
            else if (Tag == Tags.EnemyBullet)
            {
                if (Coord.Y >= GameWindow.ScreenHeigth)
                {
                    Destroy();
                    return;
                }
                Coord.Y += MoveSpeed * (float)GameWindow.DeltaTime;
            }

            base.Move();
        }

        internal override void Destroy()
        {
            EntityHandler.MarkForRemove(this);
            ColliderList.MarkForRemove(Collider);
        }

        internal override void OnCollision(Entity sender, EventArgs e)
        {
            if ((Tag == Tags.PlayerBullet && sender.Tag != Tags.Player && sender.Tag != Tags.PlayerBullet)
                || (Tag == Tags.EnemyBullet && sender.Tag != Tags.Enemy && sender.Tag != Tags.EnemyBullet))
            {
                Destroy();
                sender.Destroy();
            }
        }
    }
}