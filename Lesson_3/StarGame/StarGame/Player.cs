using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace StarGame
{
    class Player : Base
    {
        private static Bullet _bullet;

        private const int WIDTH_PICTURE = 80;
        private const int HALF_HEIGHT_PICTURE = 34;
        private int _score;

        public Bullet Bullet
        {
            get
            {
                return _bullet;
            }

            set
            {
                _bullet = value;
            }
        }

        public Player(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _score = 0;
        }

        public int Score
        {
            get { return _score; }
        }

        public void IncrementScore()
        {
            _score++;
        }

        public void Direction(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                 pos_.Y = pos_.Y + dir_.Y;

                if (pos_.Y > StarGame.Height)
                {
                    pos_.Y = 0;
                }
            }

            if (e.KeyData == Keys.Up)
            {
                pos_.Y = pos_.Y - dir_.Y;

                if (pos_.Y < 0)
                {
                    pos_.Y = StarGame.Height + size_.Height;
                }
            }

            if (e.KeyData == Keys.Left)
            {
                pos_.X = pos_.X - dir_.X;

                if (pos_.X < 0)
                {
                    pos_.X = StarGame.Width + size_.Width;
                }
            }

            if (e.KeyData == Keys.Right)
            {
                pos_.X = pos_.X + dir_.X;

                if (pos_.X > StarGame.Width)
                {
                    pos_.X = 0;
                }
            }
        }

        public void Shot(KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ' && 
                _bullet == null)
            {
                _bullet = new Bullet(
                    new Point(pos_.X + WIDTH_PICTURE, pos_.Y + HALF_HEIGHT_PICTURE), 
                    pos_, 
                    new Size(4, 1));
            }
        }

        public override void Draw()
        {
            try
            {
                Image image = Image.FromFile(@".\Pic\StarShip.png");

                StarGame.Buffer.Graphics.DrawImage(image, pos_.X, pos_.Y);

            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
