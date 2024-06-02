namespace SpaceInvaders.EntityRelated
{
    internal class Enemy : Entity
    {
        private static readonly string spritePath = Assets.Assets.AssetsPath + "\\enemy.png";
        private bool isMoveingLeft = true;
        private float maxX;
        private float minX;
        private float moveSpeed = 50f;

        public Enemy(int posX, int posY)
            : base(spritePath, posX, posY, Tags.Enemy)
        {
            maxX = posX + 50;
            minX = posX - 50;
        }

        public override void Move()
        {
            if (isMoveingLeft)
            {
                Coord.X -= moveSpeed * ((float)GameWindow.DeltaTime);
                if (minX > Coord.X)
                {
                    isMoveingLeft = false;
                }
            }

            if (!isMoveingLeft)
            {
                Coord.X += moveSpeed * ((float)GameWindow.DeltaTime);

                if (maxX < Coord.X)
                {
                    isMoveingLeft = true;
                }
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
            if (sender.Tag == Tags.PlayerBullet)
            {
                Destroy();
            }
        }
    }
}