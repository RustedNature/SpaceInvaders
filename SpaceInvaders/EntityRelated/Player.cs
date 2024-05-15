using SpaceInvaders.Controls;
using System;
using System.Collections;
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
        private float moveSpeed = 100f;

        public Player(string name, int posX, int posY)
            : base("C:\\Users\\Nico\\source\\repos\\C#\\SpaceInvaders\\SpaceInvaders\\Assets\\Panzer.png", posX, posY)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }

        public void Move()
        {
            BitArray keys = InputController.Keys;
            if (keys[((int)KeyIndex.Left)] || keys[((int)KeyIndex.A)])
            {
                Coord.X -= moveSpeed * (float)GameWindow.deltaTime;
            }
            else if (keys[((int)KeyIndex.Right)] || keys[(int)KeyIndex.D])
            {
                Coord.X += moveSpeed * (float)GameWindow.deltaTime;
            }
        }
    }
}