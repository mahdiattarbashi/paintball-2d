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
            
            player = new Player(new Point(0, 0), 1, "MoreiraTk", new Bitmap(@"Images\Player.png"));

            //m.Rotate(30);
            //d.Transform = m;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 40;
            timer.Tick += new EventHandler(update);
            timer.Enabled = true;

        }

        private Bitmap rotateImage(Image b)
        {
            Bitmap returnBitmap = new Bitmap(b.Height, b.Width);
            Graphics gg = Graphics.FromImage(returnBitmap);
            gg.TranslateTransform((float)returnBitmap.Width / 2, (float)returnBitmap.Height / 2);
            gg.RotateTransform(90);
            gg.TranslateTransform(-(float)b.Height / 2, -(float)b.Width / 2-20);
            gg.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.RotateTransform();
            Bitmap returnBitmap = new Bitmap(player.imageSprite.Height, player.imageSprite.Width);
            g.TranslateTransform((float)returnBitmap.Width / 2, (float)returnBitmap.Height / 2);
            g.RotateTransform(180);
            g.TranslateTransform(-(float)player.imageSprite.Height / 2, -(float)player.imageSprite.Width / 2);

            g.DrawImage(returnBitmap, new Point(0, 0));
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
