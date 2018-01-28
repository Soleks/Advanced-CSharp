using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StarGame
{
    class StarGame
    {
        private static BufferedGraphicsContext context;
        private static BufferedGraphics buffer;
        public static Base[] objs;
        private static List<Asteroid> asteroids;
        private static List<RepairKit> rKit;
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static Random random = new Random();
        private static Player player;

        private static Log log;

        private static Timer timer = new Timer { Interval = 70 };

        public static BufferedGraphics Buffer
        {
            get { return buffer; }
        }

        public static Player Player
        {
            get { return player; }
        }

        public StarGame()
        {

        }

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60,
            FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
        private static void Message(object o, GameLogEventArgs message)
        {
            string logFile = (message.Type == "Info" ? @".\Log\LogInfo.txt" :
                              message.Type == "Game event" ? @".\Log\LogGameEvent.txt" :
                              string.Empty);

            if (!string.IsNullOrEmpty(logFile))
            {
                using (StreamWriter sw = new StreamWriter(logFile, true))
                {
                    DateTime date = DateTime.Now;

                    sw.WriteLine(date.ToString() + " " + message.Message);
                }
            }

            Console.WriteLine("{0}: {1}", message.Type, message.Message);
        }

        public static void Init(Form form)
        {
            Graphics graphics;

            log = new Log();

            form.Width = Screen.PrimaryScreen.Bounds.Width;
            form.Height = Screen.PrimaryScreen.Bounds.Height;
            form.Location = Screen.PrimaryScreen.Bounds.Location;

            random.Next(1, 100);

            context = BufferedGraphicsManager.Current;
            graphics = form.CreateGraphics();

            Width = form.Width;
            Height = form.Height;

            buffer = context.Allocate(
            graphics, new Rectangle(0, 0, Width, Height));

            Load();
            log.WriteLogToConsole("Info", "initialization successful", Message);            Player.MessageDie += Finish;

            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            buffer.Graphics.Clear(Color.Black);

            foreach (Base obj in objs)
            {
                obj.Draw();
            }

            foreach (Asteroid obj in asteroids)
            {
                obj.Draw();
            }

            foreach (RepairKit rk in rKit)
            {
                rk.Draw();
            }

            player.Draw();
            Buffer.Graphics.DrawString("Energy:" + player.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);

            if (player.Bullet != null)
            {
                player.Bullet.Draw();
            }

            buffer.Render();
        }

        public static void Update()
        {
            foreach (Base obj in objs)
            {
                obj.Update();
            }

            for (int i = 0; i < rKit.Count; i++)
            {
                rKit[i].Update();

                if (player.Collision(rKit[i]))
                {
                    log.WriteLogToConsole("Game event", "repear", Message);

                    player.Energy = rKit[i].Repair;

                    rKit.RemoveAt(i);

                    int r = random.Next(5, 50);

                    rKit.Add(new RepairKit(
                    new Point(Width, random.Next(0, random.Next(0, Height))),
                    new Point(-r / 5, r),
                    new Size(r, r)));
                }
            }

            for (int i = 0; i < asteroids.Count; i++)
            {
                asteroids[i].Update();

                if (player.Bullet != null &&
                    player.Bullet.X >= Width)
                {
                    player.Bullet = null;
                }

                if (player.Collision(asteroids[i]))
                {
                    log.WriteLogToConsole("Game event", "collision", Message);

                    player?.EnergyLow(random.Next(1, 10));

                    if (player.Energy <= 0)
                    {
                        log.WriteLogToConsole("Game event", "starship destroy", Message);

                        player.Die();
                    }
                }

                if (player.Bullet != null &&
                    asteroids[i].Collision(player.Bullet))
                {
                    player.Bullet = null;

                    asteroids.RemoveAt(i);

                    log.WriteLogToConsole("Game event", "hit", Message);

                    player.IncrementScore();
                }

                if (asteroids.Count == 0)
                {
                    Asteroid.IncrementAsteroids();

                    for (int j = 0; j < Asteroid.Count; j++)
                    {
                        int r = random.Next(5, 50);

                        asteroids.Add(new Asteroid(
                            new Point(Width, random.Next(0, StarGame.Height)),
                            new Point(-r / 5, r),
                            new Size(r, r)));
                    }
                }
            }

            if (player.Bullet != null)
            {
                player.Bullet.Update();
            }
        }

        public static void Load()
        {
            objs = new Base[30];
            rKit = new List<RepairKit>();
            asteroids = new List<Asteroid>();

            player = new Player(
                new Point(Width / 2, Height / 2),
                new Point(10, 10),
                new Size(20, 20));

            for (int i = 0; i < objs.Length; i++)
            {
                objs[i] = new Star(new Point(random.Next(Width), random.Next(Height)),
                   new Point(-3 * i, 0), new Size(2, 2));
            }

            int r = random.Next(5, 50);

            asteroids.Add(new Asteroid(
                new Point(Width, random.Next(0, StarGame.Height)),
                new Point(-r / 5, r),
                new Size(r, r)));

            Asteroid.IncrementAsteroids();

            rKit.Add(new RepairKit(
            new Point(Width, random.Next(0, random.Next(0, Height))),
            new Point(-r / 5, r),
            new Size(r, r)));
        }
    }
}
