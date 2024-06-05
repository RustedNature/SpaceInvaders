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

                RecolorEnemyBullet();
            }
        }

        private void RecolorEnemyBullet()
        {
            for (int i = 0; i < Sprite.SpriteImage.Width; i++)
            {
                for (int y = 0; y < Sprite.SpriteImage.Height; y++)
                {
                    if (Sprite.SpriteImage.GetPixel(i, y).A != 255)
                    {
                        continue;
                    }
                    Sprite.SpriteImage.SetPixel(i, y, Color.LightSeaGreen);
                }
            }
        }

        public override void Move()
        {
            float deltaTime = (float)GameLoop.DeltaTime;
            int screenHeight = GameWindow.ScreenHeight;

            switch (Tag)
            {
                case Tags.PlayerBullet:
                    Coord.Y -= MoveSpeed * deltaTime;
                    if (Coord.Y <= 50)
                        Destroy();
                    break;

                case Tags.EnemyBullet:
                    Coord.Y += MoveSpeed * deltaTime;
                    if (Coord.Y >= screenHeight)
                        Destroy();
                    break;
            }

            base.Move();
        }

        internal override void Destroy()
        {
            EntityManager.MarkForRemove(this);
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