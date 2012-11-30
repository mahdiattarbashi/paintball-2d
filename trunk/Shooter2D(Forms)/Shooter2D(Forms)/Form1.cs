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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Shooter2D
{
    public partial class Form1 : Form
    {
        DateTime start;
        Player player;
        Player player2;
        Bala bala;
        KeyManager keyMananger;
        ObjectsDraw listDraw;

        bool podeAtirar;

        bool game = true;

        TcpClient client;
        StreamReader leitorNet = null;
        StreamWriter escritorNet = null;

        System.Windows.Forms.Timer timer;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);

            listDraw = new ObjectsDraw();
            keyMananger = new KeyManager();
            player = new Player(new Point(50, 50), 0, 1, "MoreiraTk", new Bitmap(@"Images\Player4.png"));
            player2 = new Player(new Point(300, 300), 0, 1, "123", new Bitmap(@"Images\Player4.png"));
            bala = new Bala(new Point(-40, -40), 0, new Bitmap(@"Images\Bala.png"));

            listDraw.AddList(player.imageSprite, player.posicao);



            timer = new System.Windows.Forms.Timer();
            timer.Interval = 40;
            timer.Tick += new EventHandler(update);
            timer.Enabled = true;

        }
        
        /*private Bitmap rotateImage(Image b, float rotation)
        {
            Bitmap returnBitmap = new Bitmap(b.Width * 2, b.Height * 2);
            Graphics gg = Graphics.FromImage(returnBitmap);
            gg.TranslateTransform((float)returnBitmap.Width / 2, (float)returnBitmap.Height / 2);
            gg.RotateTransform(rotation);
            gg.TranslateTransform(-(float)returnBitmap.Height, -(float)returnBitmap.Width);
            gg.DrawImage(b, new Point(returnBitmap.Height - b.Height/2, returnBitmap.Width / 2));
            return returnBitmap;
        }*/

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawImage(bala.imageSprite, bala.posicao);
            g.DrawImage(player2.imageSprite, player2.posicao.Y, player2.posicao.Y, player2.imageSprite.Width, player2.imageSprite.Height);
            

            g.RotateTransform(player.rotacao);
            g.TranslateTransform((float)player.posicao.X, ((float)player.posicao.Y), MatrixOrder.Append);
            
            //g.DrawRectangle(new Pen(Color.Blue, 3), -100, -40, 200, 80);
            g.DrawImage(player.imageSprite, -player.imageSprite.Width / 2, -player.imageSprite.Height / 2, player.imageSprite.Width, player.imageSprite.Height);
        }

        private void update(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            double deltaTime = (now - start).Milliseconds / 1000.0;
            start = now;

            player.posicao += (player.velocidade * deltaTime);
            bala.posicao += (bala.velocidade * deltaTime);

            if (game)
            {
                PainelGeral.Visible = false;
                PainelGeral.Enabled = false;
            }
            else {
                PainelGeral.Visible = true;
                PainelGeral.Enabled = true;
            }
            
            if (bala.posicao.X > Size.Width || bala.posicao.X < 0 || bala.posicao.Y > Size.Height || bala.posicao.Y < 0)
            { podeAtirar = true; } else { podeAtirar = false; }

            if (player.posicao.X > Size.Width || player.posicao.X < 0 || player.posicao.Y > Size.Height || player.posicao.Y < 0)
            {
                player.velocidade = Vector.CreateVectorFromAngle(0, 0);
            }

            if (Sprite.Collides(bala, player2))
            {
                bala.posicao = new Point(-5000, -5000);
                player2.posicao = new Point(-4000, -4000);
            }

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

            if (e.KeyCode == Keys.Space && podeAtirar == true)
            {
                //MoverBala(player.rotacao / 2, 50);
                bala.posicao = player.posicao;
                bala.velocidade = Vector.CreateVectorFromAngle(player.rotacao, 1000);
            }

            keyMananger.Add(e);

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

            keyMananger.Remove(e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ConectarButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                int porta = Int32.Parse(PortaTextBox.Text);
                client = new TcpClient(IPTextBox.Text, porta);
                NetworkStream stream = client.GetStream();
                leitorNet = new StreamReader(stream);
                escritorNet = new StreamWriter(stream);
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro : " + err.Message);
            }
        }


        private void CheckMenssage()
        {
            try
            {
                string data = leitorNet.ReadLine();

                while (data != null)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        //reactToMessage(data);
                        //coloca a ação q deseja.
                    });
                    data = leitorNet.ReadLine();
                }

                client.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro lendo do servidor : " + err.Message);
            }
        }


        public void Send(string acao)
        {
            escritorNet.Write(acao);
            escritorNet.WriteLine();
            escritorNet.Flush();
        }

    }
}
