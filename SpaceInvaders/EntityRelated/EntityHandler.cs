using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntityRelated
{
    internal static class EntityHandler
    {
        private static List<Entity> entities = new();

        internal static List<Entity> Entities { get => entities; set => entities = value; }

        public static Player CreatePlayer(string name, int posX, int posY)
        {
            Player p = new(name, posX, posY);
            entities.Add(p);
            return p;
        }

        public static Enemy CreateEnemy(int posX, int posY)
        {
            Enemy e = new(posX, posY);
            entities.Add(e);
            return e;
        }
    }
}