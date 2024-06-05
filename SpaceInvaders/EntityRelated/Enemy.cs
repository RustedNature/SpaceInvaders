namespace SpaceInvaders.EntityRelated
{
    internal class Enemy : Entity
    {
        private static readonly string spritePath = Assets.Assets.AssetsPath + "\\enemy.png";
        private bool isMoveingLeft = true;
        private float maxX;
        private float minX;
        private float moveSpeed = 50f;
        private Random random = new();

        public Enemy(int posX, int posY)
            : base(SpritePath, posX, posY, Tags.Enemy)
        {
            MaxX = posX + 30;
            MinX = posX - 30;
        }

        public static string SpritePath => spritePath;

        public bool IsMoveingLeft { get => isMoveingLeft; set => isMoveingLeft = value; }
        public float MaxX { get => maxX; set => maxX = value; }
        public float MinX { get => minX; set => minX = value; }
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public Random Random { get => random; set => random = value; }

        public override void Move()
        {
            if (IsMoveingLeft)
            {
                Coord.X -= MoveSpeed * ((float)GameLoop.DeltaTime);
                if (MinX > Coord.X)
                {
                    IsMoveingLeft = false;
                }
            }

            if (!IsMoveingLeft)
            {
                Coord.X += MoveSpeed * ((float)GameLoop.DeltaTime);

                if (MaxX < Coord.X)
                {
                    IsMoveingLeft = true;
                }
            }

            Shoot();
            base.Move();
        }

        private void Shoot()
        {
            if (Random.NextDouble() >= 0.999d)
            {
                EntityManager.CreateBullet(Coord.X + Sprite.SpriteImage.Width / 2, Coord.Y, Tags.EnemyBullet);
            }
        }

        internal override void Destroy()
        {
            EntityManager.MarkForRemove(this);
            ColliderList.MarkForRemove(Collider);
        }

        internal override void OnCollision(Entity sender, EventArgs e)
        {
            if (sender.Tag == Tags.PlayerBullet)
            {
                sender.Destroy();
                Destroy();
            }
        }
    }
}