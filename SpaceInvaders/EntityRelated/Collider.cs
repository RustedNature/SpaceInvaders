using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntityRelated

{
    internal static class ColliderList
    {
        private static List<Collider> collider = new List<Collider>();
        private static List<Collider> colliderMarkedForRemove = new List<Collider>();

        internal static List<Collider> Collider { get => collider; set => collider = value; }
        internal static List<Collider> ColliderMarkedForRemove { get => colliderMarkedForRemove; set => colliderMarkedForRemove = value; }

        internal static void MarkForRemove(Collider collider)
        {
            ColliderMarkedForRemove.Add(collider);
        }

        internal static void UpdateColliderList()
        {
            ColliderMarkedForRemove.ForEach(c => Collider.Remove(c));
            ColliderMarkedForRemove.Clear();
        }
    }

    internal class Collider
    {
        private Entity entity;

        internal Entity Entity { get => entity; private set => entity = value; }

        public event EventHandler OnCollision;

        public Collider(Entity entity)
        {
            this.Entity = entity;
            ColliderList.Collider.Add(this);
        }

        public void IsColliding()
        {
            Coordinate2D coordinateLeftUpper = new(Entity.Coord.X, Entity.Coord.Y);
            Coordinate2D coordinateRightLower = new(Entity.Coord.X + Entity.Sprite.SpriteImage.Width, Entity.Coord.Y + Entity.Sprite.SpriteImage.Height);

            foreach (Collider col in ColliderList.Collider)
            {
                if (col != this)
                {
                    Coordinate2D coordinateLeftUpperCol = new(col.Entity.Coord.X, col.Entity.Coord.Y);
                    Coordinate2D coordinateRightUpperCol = new(col.Entity.Coord.X + col.Entity.Sprite.SpriteImage.Width, col.Entity.Coord.Y);
                    Coordinate2D coordinateLeftLowerCol = new(col.Entity.Coord.X, col.Entity.Coord.Y + col.Entity.Sprite.SpriteImage.Height);
                    Coordinate2D coordinateRightLowerCol = new(col.Entity.Coord.X + col.Entity.Sprite.SpriteImage.Width, col.Entity.Coord.Y + col.Entity.Sprite.SpriteImage.Height);

                    if (coordinateLeftUpper < coordinateLeftUpperCol && coordinateRightLower > coordinateLeftUpperCol
                        || coordinateLeftUpper < coordinateRightUpperCol && coordinateRightLower > coordinateRightUpperCol
                        || coordinateLeftUpper < coordinateLeftLowerCol && coordinateRightLower > coordinateLeftLowerCol
                        || coordinateLeftUpper < coordinateRightLowerCol && coordinateRightLower > coordinateRightLowerCol)
                    {
                        Debug.WriteLine($"{nameof(Entity)} collided with {nameof(col.Entity)}");
                    }
                }
            }
        }
    }
}