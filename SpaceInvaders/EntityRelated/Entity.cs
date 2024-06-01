using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntityRelated
{
    internal class Entity
    {
        private Coordinate2D coord;
        private Sprite sprite;
        private Collider collider;

        public Entity(string spritePath, float posX, float posY)
        {
            Sprite = new Sprite(spritePath);
            Coord = new Coordinate2D(posX, posY);
            Collider = new Collider(this);
        }

        public Sprite Sprite { get => sprite; set => sprite = value; }
        internal Coordinate2D Coord { get => coord; set => coord = value; }
        internal Collider Collider { get => collider; set => collider = value; }

        public virtual void Move()
        {
            Collider.IsColliding();
            return;
        }
    }
}