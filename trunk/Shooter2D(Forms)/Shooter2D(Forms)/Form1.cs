using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        
        //Graphics d;
        //Matrix m = new Matrix();
        

        System.Windows.Forms.Timer timer;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            
            player = new Player(new Point(0, 0), 0, 1, "MoreiraTk", new Bitmap(@"Images\Player3.png"));

            //m.Rotate(30);
            //d.Transform = m;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 40;
            timer.Tick += new EventHandler(update);
            timer.Enabled = true;

        }
        
        private Bitmap rotateImage(Image b)
        {
            Bitmap returnBitmap = new Bitmap(b.Width + 200, b.Height + 100);
            Graphics gg = Graphics.FromImage(returnBitmap);
            gg.TranslateTransform((float)returnBitmap.Width / 2, (float)returnBitmap.Height / 2);
            gg.RotateTransform(player.rotacao);
            gg.TranslateTransform(-(float)returnBitmap.Height / 2, -(float)returnBitmap.Width / 2);
            gg.DrawImage(b, new Point(b.Height / 2 -50, b.Width / 2));
            return returnBitmap;
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.RotateTransform();
            /*Bitmap returnBitmap = new Bitmap(player.imageSprite.Height, player.imageSprite.Width);
            g.TranslateTransform((float)returnBitmap.Width / 2, (float)returnBitmap.Height / 2);
            g.RotateTransform(player.rotacao);
            g.TranslateTransform(-((float)player.imageSprite.Height / 2) - (player.posicao.Y), -((float)player.imageSprite.Width / 2) - (player.posicao.X));

            g.DrawImage(player.imageSprite, player.posicao);
            g.DrawImage(returnBitmap, player.posicao);*/

            g.DrawImage(rotateImage(player.imageSprite), player.posicao);
        }

        private void update(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            double deltaTime = (now - start).Milliseconds / 1000.0;
            start = now;

            label1.Text = "posicao" + player.posicao + "    rotacao" + player.rotacao;
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

            if (e.KeyCode == Keys.Right)
            {
                player.rotacao += 5;
            }
            if (e.KeyCode == Keys.Left)
            {
                player.rotacao -= 5;
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
