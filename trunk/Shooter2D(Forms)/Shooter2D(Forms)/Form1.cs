using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Shooter2D
{
    public partial class Form1 : Form
    {
        DateTime start;
        Player player;


        System.Windows.Forms.Timer timer;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            
            player = new Player(new Point(100, 100), 1, "MoreiraTk", new Bitmap(@"Images\Player.png"));

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 40;
            timer.Tick += new EventHandler(update);
            timer.Enabled = true;

        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(player.imageSprite, player.posicao);
        }

        private void update(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            double deltaTime = (now - start).Milliseconds / 1000.0;
            start = now;



            player.posicao += (player.velocidade * deltaTime);

            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                player.velocidade = Vector.CreateVectorFromAngle(0, 100);
            }
            if (e.KeyCode == Keys.S)
            {
                player.velocidade = Vector.CreateVectorFromAngle(180, 100);
            }
            if (e.KeyCode == Keys.D)
            {
                player.velocidade = Vector.CreateVectorFromAngle(90, 100);
            }
            if (e.KeyCode == Keys.A)
            {
                player.velocidade = Vector.CreateVectorFromAngle(270, 100);
            }
        }

         private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

             // colocar p/ ele andar pelo KeyPress
            /*if (e.KeyCode == Keys.W)
            {
                player.velocidade = Vector.CreateVectorFromAngle(0, 100);
            }
            if (e.KeyCode == Keys.S)
            {
                player.velocidade = Vector.CreateVectorFromAngle(180, 100);
            }
            if (e.KeyCode == Keys.A)
            {
                player.velocidade = Vector.CreateVectorFromAngle(90, 100);
            }
            if (e.KeyCode == Keys.D)
            {
                player.velocidade = Vector.CreateVectorFromAngle(270, 100);
            }*/
        } 

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                player.velocidade = new Vector(0, 0);
            }
            if (e.KeyCode == Keys.S)
            {
                player.velocidade = new Vector(0, 0);
            }
            if (e.KeyCode == Keys.A)
            {
                player.velocidade = new Vector(0, 0);
            }
            if (e.KeyCode == Keys.D)
            {
                player.velocidade = new Vector(0, 0);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }   
    }
}
