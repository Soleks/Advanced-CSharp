using System;
using System.Windows.Forms;

namespace StarGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Hide();
            label2.Hide();
            timer1.Enabled = true;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StarGame.Init(this);
            pictureBox1.Visible = false;
            label1.Show();
            label1_TextChanged(sender, e);
            label2.Show();
            label2_TextChanged(sender, e);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (StarGame.Player == null)
            {
                return;
            }

            StarGame.Player.Direction(e);
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Oleksenko Sergey, demo version StarGame." +
                            "\r\nУпраление: \"стрелки\", огонь \"пробел\"");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (StarGame.Player == null)
            {
                return;
            }

            StarGame.Player.Shot(e);
            label1_TextChanged(sender, e);
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            label1.Text ="Score: " + StarGame.Player.Score.ToString();
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            if (StarGame.Player == null)
            {
                return;
            }
            
            label2.Text = "Hull: " + StarGame.Player.Energy;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2_TextChanged(sender, e);
        }
    }
}
