using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Collections.Generic;

namespace StarGame
{
    class Player : Base
    {
        public static event Message MessageDie;        public void Die()
        {
            _sounds[DESTROY_STARSHIP].Play();
            MessageDie?.Invoke();
        }

        private const int WIDTH_PICTURE = 80;
        private const int HALF_HEIGHT_PICTURE = 34;
        private const int FULL_ENERGY = 100;
        private const string PATH_PICTURE = @".\Pic\StarShip.png";
        private const string PATH_ATTACK_SOUND = @".\Media\Hit_Hurt2.wav";
        private const string PATH_DAMAGE_SOUND = @".\Media\Damage.wav";
        private const string PATH_DESTROY_ASTEROID_SOUND = @".\Media\DestroyAsteroid.wav";
        private const string PATH_DESTROY_STARSHIP_SOUND = @".\Media\DestroyStarShip.wav";
        private const string PATH_POWER_UP_SOUND = @".\Media\Powerup.wav";

        private const string ATTACK = "attack";
        private const string POWERUP = "powerup";
        private const string DESTROY_STARSHIP = "destroyStarship";
        private const string DESTROY_ASTEROID = "destroyAsteroid";
        private const string DAMAGE = "damageStarship";

        private int _energy = FULL_ENERGY;
        private int _score;
        private static Bullet _bullet;
        private Dictionary<string, SoundPlayer> _sounds;

        public int Energy
        {
            get { return _energy; }

            set
            {
                _sounds[POWERUP].Play();

                if (_energy + value >= FULL_ENERGY)
                {
                    _energy = FULL_ENERGY;

                }
                else
                {
                    _energy += value;
                }
            }
        }

        public void EnergyLow(int n)
        {
            _sounds[DAMAGE].Play();

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

            _sounds = new Dictionary<string, SoundPlayer>();

            try
            {
                _sounds.Add(ATTACK, new SoundPlayer(PATH_ATTACK_SOUND));
                _sounds.Add(POWERUP, new SoundPlayer(PATH_POWER_UP_SOUND));
                _sounds.Add(DESTROY_STARSHIP, new SoundPlayer(PATH_DESTROY_STARSHIP_SOUND));
                _sounds.Add(DESTROY_ASTEROID, new SoundPlayer(PATH_DESTROY_ASTEROID_SOUND));
                _sounds.Add(DAMAGE, new SoundPlayer(PATH_DAMAGE_SOUND));
            }
            catch (Exception e)
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
            _sounds[DESTROY_ASTEROID].Play();

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
            } else
            if (e.KeyData == Keys.Up)
            {
                pos_.Y = pos_.Y - dir_.Y;

                if (pos_.Y < 0)
                {
                    pos_.Y = StarGame.Height + size_.Height;
                }
            } else
            if (e.KeyData == Keys.Left)
            {
                pos_.X = pos_.X - dir_.X;

                if (pos_.X < 0)
                {
                    pos_.X = StarGame.Width + size_.Width;
                }
            } else
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
                _sounds[ATTACK].Play();

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

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
