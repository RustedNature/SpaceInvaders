namespace SpaceInvaders.EntityRelated
{
    internal abstract class Entity
    {
        private Collider collider;
        private Coordinate2D coord;
        private Sprite sprite;
        private Tags tag;

        public Entity(string spritePath, float posX, float posY, Tags tag)
        {
            Sprite = new Sprite(spritePath);
            Coord = new Coordinate2D(posX, posY);
            Collider = new Collider(this);
            Collider.OnCollision += OnCollision;
            Tag = tag;
        }

        public Sprite Sprite { get => sprite; set => sprite = value; }

        internal Collider Collider { get => collider; set => collider = value; }

        internal Coordinate2D Coord { get => coord; set => coord = value; }

        internal Tags Tag { get => tag; set => tag = value; }

        public virtual void Move()
        {
            Collider.IsColliding();
            return;
        }

        internal abstract void Destroy();

        internal abstract void OnCollision(Entity sender, EventArgs e);
    }
}