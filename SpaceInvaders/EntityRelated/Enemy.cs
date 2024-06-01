using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntityRelated
{
    internal class Enemy : Entity
    {
        private float maxX;
        private float minX;
        private bool isMoveingLeft = true;
        private float moveSpeed = 50f;
        private static readonly string spritePath = Assets.Assets.AssetsPath + "\\enemy.png";

        public Enemy(int posX, int posY)
            : base(spritePath, posX, posY)
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
    }
}