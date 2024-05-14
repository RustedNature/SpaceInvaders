using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntitiyRelated
{
    internal class Sprite
    {
        private Bitmap spriteImage;
        private Coordinate2D pivot;

        public Sprite(string spriteImagePath)
        {
            SpriteImage = new Bitmap(spriteImagePath);

            Pivot = new Coordinate2D(spriteImage.Width / 2, spriteImage.Height / 2);
        }

        public Bitmap SpriteImage { get => spriteImage; set => spriteImage = value; }
        internal Coordinate2D Pivot { get => pivot; set => pivot = value; }
    }
}