using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntitiyRelated
{
    internal class Enemy : Entity
    {
        public Enemy(int posX, int posY)
            : base("C:\\Users\\Nico\\source\\repos\\C#\\SpaceInvaders\\SpaceInvaders\\Assets\\Enemy.png", posX, posY)
        {
        }
    }
}