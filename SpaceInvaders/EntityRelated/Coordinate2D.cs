using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntityRelated
{
    internal class Coordinate2D
    {
        private float x;
        private float y;

        public Coordinate2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public static bool operator <(Coordinate2D c1, Coordinate2D c2)
        {
            return c1.X < c2.X && c1.Y < c2.Y;
        }

        public static bool operator >(Coordinate2D c1, Coordinate2D c2)
        {
            return c1.X > c2.X && c1.Y > c2.Y;
        }
    }
}