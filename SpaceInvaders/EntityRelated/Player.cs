using SpaceInvaders.Controls;
using System.Collections;

namespace SpaceInvaders.EntityRelated
{
    internal class Player : Entity
    {
        private string name;
        private readonly float moveSpeed = 100f;

        public Player(string name, int posX, int posY)
            : base(Assets.Assets.AssetsPath + "\\panzer.png", posX, posY)
        {
            Name = name;
        }

        public string Name { get => name; set => name = value; }

        public void Move()
        {
            BitArray keys = InputController.Keys;
            if (keys[(int)KeyIndex.Left] || keys[(int)KeyIndex.A])
            {
                Coord.X -= moveSpeed * (float)GameWindow.deltaTime;
            }
            else if (keys[(int)KeyIndex.Right] || keys[(int)KeyIndex.D])
            {
                Coord.X += moveSpeed * (float)GameWindow.deltaTime;
            }
            if (keys[(int)KeyIndex.Space])
            {
            }
        }
    }
}