using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceInvaders.EntitiyRelated
{
    internal class Player : Entity
    {
        private string name;

        public Player(string name, int posX, int posY)
            : base("C:\\Users\\Nico\\source\\repos\\C#\\SpaceInvaders\\SpaceInvaders\\Assets\\Panzer.png", posX, posY)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }

        public void Move(Keys keyDown)
        {
            if (keyDown == Keys.A)
            {
                Coord.X--;
            }
            else if (keyDown == Keys.D)
            {
                Coord.X++;
            }
            Debug.WriteLine($"{keyDown}");
        }
    }
}