﻿using System;
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

        public Enemy(int posX, int posY)
            : base(Assets.Assets.AssetsPath + "\\enemy.png", posX, posY)
        {
            maxX = posX + 50;
            minX = posX - 50;
        }

        public void Move()
        {
            if (isMoveingLeft)
            {
                Coord.X -= moveSpeed * ((float)GameWindow.deltaTime);
                if (minX > Coord.X)
                {
                    isMoveingLeft = false;
                }
            }

            if (!isMoveingLeft)
            {
                Coord.X += moveSpeed * ((float)GameWindow.deltaTime);

                if (maxX < Coord.X)
                {
                    isMoveingLeft = true;
                }
            }
        }
    }
}