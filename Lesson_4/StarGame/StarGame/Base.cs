using System.Drawing;

namespace StarGame
{
    abstract class Base : ICollision
    {
        public delegate void Message();
        protected Point pos_;
        protected Point dir_;
        protected Size size_;      

        protected Base(Point pos, Point dir, Size size)
        {
            pos_ = pos;
            dir_ = dir;
            size_ = size;
        }

        public Rectangle Rect => new Rectangle(pos_, size_);

        public bool Collision(ICollision obj) => obj.Rect.IntersectsWith(this.Rect);      

        public abstract void Draw();

        public virtual void Update()
        {
            pos_.X = pos_.X + dir_.X;
            pos_.Y = pos_.Y + dir_.Y;

            if (pos_.X < 0)
            {
                dir_.X = -dir_.X;
            }

            if (pos_.X > StarGame.Width)
            {
                dir_.X = -dir_.X;
            }

            if (pos_.Y < 0)
            {
                dir_.Y = -dir_.Y;
            }

            if (pos_.Y > StarGame.Height)
            {
                dir_.Y = -dir_.Y;
            }
        }
    }
}
