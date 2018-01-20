using System.Drawing;

namespace SplashScreen
{
    class Base
    {
        protected Point pos_;
        protected Point dir_;
        protected Size size_;      

        public Base(Point pos, Point dir, Size size)
        {
            pos_ = pos;
            dir_ = dir;
            size_ = size;
        }

        public virtual void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawEllipse(
                Pens.White, 
                pos_.X, 
                pos_.Y, 
                size_.Width, 
                size_.Height);
        }

        public virtual void Update()
        {
            pos_.X = pos_.X + dir_.X;
            pos_.Y = pos_.Y + dir_.Y;

            if (pos_.X < 0)
            {
                dir_.X = -dir_.X;
            }

            if (pos_.X > SplashScreen.Width)
            {
                dir_.X = -dir_.X;
            }

            if (pos_.Y < 0)
            {
                dir_.Y = -dir_.Y;
            }

            if (pos_.Y > SplashScreen.Height)
            {
                dir_.Y = -dir_.Y;
            }
        }
    }
}
