using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplashScreen
{
    class Player : Base
    {
        public Player(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public void Direction(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                Console.WriteLine("Вниз");

                pos_.Y = pos_.Y + dir_.Y;

                if (pos_.Y > SplashScreen.Height)
                {
                    pos_.Y = 0;
                }
            }

            if (e.KeyData == Keys.Up)
            {
                pos_.Y = pos_.Y - dir_.Y;

                if (pos_.Y  < 0)
                {
                    pos_.Y = SplashScreen.Height + size_.Height;
                }
            }

            if (e.KeyData == Keys.Left)
            {
                pos_.X = pos_.X - dir_.X;

                if (pos_.X < 0)
                {
                    pos_.X = SplashScreen.Width + size_.Width;
                }
            }

            if (e.KeyData == Keys.Right)
            {
                pos_.X = pos_.X + dir_.X;

                if (pos_.X > SplashScreen.Width)
                {
                    pos_.X = 0;
                }
            }
        }
    }
}
