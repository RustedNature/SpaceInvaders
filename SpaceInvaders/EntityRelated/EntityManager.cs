namespace SpaceInvaders.EntityRelated
{
    internal static class EntityManager
    {
        private const int MaxEnemies = 10;
        private const int SpriteWidth = 46;
        private const int SpriteHeight = 46;
        private const int GapSpots = 11;
        private const int VerticalGapBetweenEnemies = 15;
        private const int EnemyRowsPlusOne = 6;
        private const int MaxEnemyBullet = 5;
        private const int MaxPlayerBullet = 1;

        private static List<Entity> activeEntities = new();
        private static List<Entity> markedForRemoveEntities = new();

        internal static List<Entity> Entities { get => activeEntities; set => activeEntities = value; }
        internal static List<Entity> MarkedForRemoveEntities { get => markedForRemoveEntities; set => markedForRemoveEntities = value; }

        public static void CreateBullet(float startX, float starY, Tags tag)
        {
            if (tag == Tags.PlayerBullet && MaxPlayerBullet > GetAmountOfEntitiesWithTag(tag))
            {
                Bullet bullet = new(startX, starY, tag);
                bullet.AdjustSpritePosition();
                activeEntities.Add(bullet);
            }
            else if (tag == Tags.EnemyBullet && MaxEnemyBullet > GetAmountOfEntitiesWithTag(tag))
            {
                Bullet bullet = new(startX, starY, tag);
                bullet.AdjustSpritePosition();
                activeEntities.Add(bullet);
            }
        }

        public static Enemy CreateEnemy(int posX, int posY)
        {
            Enemy e = new(posX, posY);
            activeEntities.Add(e);
            return e;
        }

        public static void CreateEntities()
        {
            CreateEnemyGrid();

            CreatePlayer("Player", 400, 600 - SpriteHeight);
        }

        private static void CreateEnemyGrid()
        {
            int distanceBetweenTwoEnemies = (GameWindow.ScreenWidth - (MaxEnemies * SpriteWidth)) / GapSpots;
            for (int y = 1; y < EnemyRowsPlusOne; y++)
            {
                for (int x = 1; x < GapSpots; x++)
                {
                    if (x == 1)
                    {
                        CreateEnemy(distanceBetweenTwoEnemies, (SpriteHeight + VerticalGapBetweenEnemies) * y);
                        continue;
                    }
                    CreateEnemy((distanceBetweenTwoEnemies * x) + ((x - 1) * SpriteWidth), (SpriteHeight + VerticalGapBetweenEnemies) * y);
                }
            }
        }

        public static Player CreatePlayer(string name, int posX, int posY)
        {
            Player p = new(name, posX, posY);
            activeEntities.Add(p);
            return p;
        }

        public static int GetAmountOfEntitiesWithTag(Tags tag)
        {
            return activeEntities.Count(e => e.Tag == tag);
        }

        public static void UpateActiveEntitiesList()
        {
            foreach (var marked in MarkedForRemoveEntities)
            {
                activeEntities.Remove(marked);
            }

            MarkedForRemoveEntities.Clear();
        }

        internal static void MarkForRemove(Entity entity)
        {
            MarkedForRemoveEntities.Add(entity);
        }

        internal static void MoveEntities()
        {
            //Copy into temporary list to bypass exception
            var tempEntities = new List<Entity>(Entities);

            tempEntities.ForEach(e => e.Move());
        }
    }
}