using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntitiyRelated
{
    internal class Entity
    {
        private Coordinate2D coord;
        private Sprite sprite;

        public Entity(string spritePath, int posX, int posY)
        {
            Sprite = new Sprite(spritePath);
            Coord = new Coordinate2D(posX - Sprite.Pivot.X, posY - Sprite.Pivot.Y);
        }

        public Sprite Sprite { get => sprite; set => sprite = value; }
        internal Coordinate2D Coord { get => coord; set => coord = value; }
    }
}