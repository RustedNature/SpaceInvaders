namespace SpaceInvaders.EntityRelated
{
    internal class Sprite
    {
        private Coordinate2D pivot;
        private Bitmap spriteImage;

        public Sprite(string spriteImagePath)
        {
            SpriteImage = new Bitmap(spriteImagePath);

            Pivot = new Coordinate2D(spriteImage.Width / 2, spriteImage.Height / 2);
        }

        public Bitmap SpriteImage { get => spriteImage; set => spriteImage = value; }
        internal Coordinate2D Pivot { get => pivot; set => pivot = value; }
    }
}