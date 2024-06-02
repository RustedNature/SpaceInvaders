using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntityRelated
{
    internal static class EntityHandler
    {
        private static List<Entity> activeEntities = new();
        private static List<Entity> markedForRemoveEntities = new();

        internal static List<Entity> Entities { get => activeEntities; set => activeEntities = value; }
        internal static List<Entity> MarkedForRemoveEntities { get => markedForRemoveEntities; set => markedForRemoveEntities = value; }

        public static void CreateBullet(float startX, float starY, Tags tag)
        {
            activeEntities.Add(new Bullet(startX, starY, tag));
        }

        public static Enemy CreateEnemy(int posX, int posY)
        {
            Enemy e = new(posX, posY);
            activeEntities.Add(e);
            return e;
        }

        public static void CreateEntities()
        {
            CreateEnemy(400, 100);
            CreateEnemy(100, 100);
            CreateEnemy(700, 100);
            CreatePlayer("Player", 400, 600 - 46);
        }

        public static Player CreatePlayer(string name, int posX, int posY)
        {
            Player p = new(name, posX, posY);
            activeEntities.Add(p);
            return p;
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
    }
}