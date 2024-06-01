using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.EntityRelated
{
    internal class Bullet : Entity
    {
        private float moveSpeed = 250f;

        private static string spritePath = Assets.Assets.AssetsPath + "\\bullet.png";

        public Bullet(float posX, float posY) : base(SpritePath, posX, posY)
        {
        }

        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public static string SpritePath { get => spritePath; set => spritePath = value; }

        public override void Move()
        {
            if (Coord.Y <= 50)
            {
                EntityHandler.MarkForRemove(this);
                return;
            }
            Coord.Y -= MoveSpeed * (float)GameWindow.DeltaTime;
            base.Move();
        }

        ~Bullet()
        {
            ColliderList.Collider.Remove(this.Collider);
            Debug.WriteLine(this.ToString() + " destroyed");
        }
    }
}