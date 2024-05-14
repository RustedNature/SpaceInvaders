using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntitiyRelated
{
    internal class Player : Entitiy
    {
        private string name;

        public Player(string name, int posX, int posY)
            : base("C:\\Users\\Nico\\source\\repos\\C#\\SpaceInvaders\\SpaceInvaders\\Assets\\Panzer.png", posX, posY)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}