using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarGame
{
    class BaseObject
    {
        protected Point pos_;
        protected Point dir_;
        protected Size size_;

        public BaseObject(Point pos, Point dir, Size size)
        {
            pos_ = pos;
            dir_ = dir;
            size_ = size;
        }

        public virtual void Draw()
        {
            Game.buffer.Graphics.DrawEllipse(Pens.White, pos_.X, pos_.Y, size_.Width, size_.Height);
        }

        public virtual void Update()
        {
            pos_.X = pos_.X + dir_.X;
            pos_.Y = pos_.Y + dir_.Y;

            if (pos_.X < 0)
            {
                dir_.X = -dir_.X;
            }

            if (pos_.X > Game.Width)
            {
                dir_.X = -dir_.X;
            }

            if (pos_.Y < 0)
            {
                dir_.Y = -dir_.Y;
            }

            if (pos_.Y > Game.Height)
            {
                dir_.Y = -dir_.Y;
            }
        }
    }
}
