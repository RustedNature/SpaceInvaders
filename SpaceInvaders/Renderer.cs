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
        private static Bitmap bufferMap = new Bitmap(GameWindow.ScreenWidth, GameWindow.ScreenHeight);
        private static Graphics bufferGraphics = Graphics.FromImage(bufferMap);

        internal static void Render(PaintEventArgs e)
        {
            bufferGraphics.Clear(Color.Black);
            RenderEntities();

            e.Graphics.DrawImage(bufferMap, 0, 0);
        }

        private static void RenderEntities()
        {
            EntityManager.Entities.ForEach(e =>
            {
                bufferGraphics.DrawImage(e.Sprite.SpriteImage, e.Coord.X, e.Coord.Y, e.Sprite.SpriteImage.Width, e.Sprite.SpriteImage.Height);
                //Debug.WriteLine($"{e} drawn at X:{e.Coord.X} Y:{e.Coord.Y} and its {e.Sprite.SpriteImage.Width}x{e.Sprite.SpriteImage.Height}");
            });
        }
    }
}