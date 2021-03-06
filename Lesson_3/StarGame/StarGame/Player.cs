﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace StarGame
{
    class Player : Base
    {
        public static event Message MessageDie;        public void Die()
        {
            MessageDie?.Invoke();
        }

        private const int WIDTH_PICTURE = 80;
        private const int HALF_HEIGHT_PICTURE = 34;
        private const int FULL_ENERGY = 100;
        private const string PATH_PICTURE = @".\Pic\StarShip.png";
        private const string PATH_HIT = @".\Media\Hit_Hurt2.wav";

        private int _energy = FULL_ENERGY;
        private int _score;
        private static Bullet _bullet;
        private SoundPlayer _simpleSound;

        public int Energy
        {
            get { return _energy; }

            set
            {
                if (_energy + value >= FULL_ENERGY)
                {
                    _energy = FULL_ENERGY;

                } else
                {
                    _energy += value;
                }
            }
        }

        public void EnergyLow(int n)
        {
            _energy -= n;
        }

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

            try
            {
                _simpleSound = new SoundPlayer(PATH_HIT);

            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
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
                _simpleSound.Play();

                _bullet = new Bullet(
                    new Point(pos_.X + WIDTH_PICTURE, pos_.Y + HALF_HEIGHT_PICTURE), 
                    pos_, 
                    new Size(10, 5));
            }
        }

        public override void Draw()
        {
            try
            {
                Image image = Image.FromFile(PATH_PICTURE);

                StarGame.Buffer.Graphics.DrawImage(image, pos_.X, pos_.Y);

            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
