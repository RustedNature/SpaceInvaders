using SpaceInvaders.EntityRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    internal static class Renderer
    {
        private static Bitmap bufferMap = new(GameWindow.ScreenWidth, GameWindow.ScreenHeight);
        private static Graphics bufferGraphics = Graphics.FromImage(BufferMap);

        public static Bitmap BufferMap { get => bufferMap; set => bufferMap = value; }
        public static Graphics BufferGraphics { get => bufferGraphics; set => bufferGraphics = value; }

        internal static void Render(PaintEventArgs e, Color BackColor)
        {
            BufferGraphics.Clear(BackColor);
            RenderEntities();

            e.Graphics.DrawImage(BufferMap, 0, 0);
        }

        private static void RenderEntities()
        {
            EntityManager.Entities.ForEach(e =>
            {
                BufferGraphics.DrawImage(e.Sprite.SpriteImage, e.Coord.X, e.Coord.Y, e.Sprite.SpriteImage.Width, e.Sprite.SpriteImage.Height);
                //Debug.WriteLine($"{e} drawn at X:{e.Coord.X} Y:{e.Coord.Y} and its {e.Sprite.SpriteImage.Width}x{e.Sprite.SpriteImage.Height}");
            });
        }
    }
}