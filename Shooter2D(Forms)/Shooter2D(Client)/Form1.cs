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

namespace Shooter2D_Client_
{
    public partial class Form1 : Form
    {

        DateTime start;

        bool game = false;
        bool playerTerror = false;
        bool playerCT = false;
        string meuTime;
        int quantImagens = 100;
        Objeto[] imagens;
        bool instanciar = false;

        private int idTemp;
        private string nomeTemp;
        private Point posicaoTemp;
        private int larguraTemp;
        private int alturaTemp;
        private int rotacaoTemp;
        private string imagemTemp;

        TcpClient client;
        StreamReader leitorNet = null;
        StreamWriter escritorNet = null;

        HashSet<Keys> keys;

        System.Windows.Forms.Timer timer;

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            imagens = new Objeto[quantImagens];
            keys = new HashSet<Keys>();
            ConectarButton.Enabled = false;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 40;
            timer.Tick += new EventHandler(update);
            timer.Enabled = true;

        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < imagens.Length; i++)
            {
                if (imagens[i] != null)
                {
                    g.RotateTransform(imagens[i].rotacao);
                    g.TranslateTransform((float)imagens[i].posicao.X, ((float)imagens[i].posicao.Y), MatrixOrder.Append);

                    g.DrawImage(imagens[i].imagemSprite, -imagens[i].largura / 2, -imagens[i].altura / 2, imagens[i].largura, imagens[i].altura);
                    i++;
                }
                if (imagens[i+1] != null)
                {
                    g.RotateTransform(imagens[i].rotacao);
                    g.TranslateTransform((float)imagens[i + 1].posicao.X, ((float)imagens[i + 1].posicao.Y), MatrixOrder.Append);

                    g.DrawImage(imagens[i + 1].imagemSprite, -imagens[i + 1].largura / 2, -imagens[i + 1].altura / 2, imagens[i + 1].largura, imagens[i + 1].altura);
                    i++;
                }
                if (imagens[i+2] != null)
                {
                    g.RotateTransform(imagens[i + 2].rotacao);
                    g.TranslateTransform((float)imagens[i + 2].posicao.X, ((float)imagens[i + 2].posicao.Y), MatrixOrder.Append);

                    g.DrawImage(imagens[i + 2].imagemSprite, -imagens[i + 2].largura / 2, -imagens[i + 2].altura / 2, imagens[i + 2].largura, imagens[i + 2].altura);
                    i++;
                }
                if (imagens[i+3] != null)
                {
                    g.RotateTransform(imagens[i + 3].rotacao);
                    g.TranslateTransform((float)imagens[i + 3].posicao.X, ((float)imagens[i + 3].posicao.Y), MatrixOrder.Append);

                    g.DrawImage(imagens[i + 3].imagemSprite, -imagens[i + 3].largura / 2, -imagens[i + 3].altura / 2, imagens[i + 3].largura, imagens[i + 3].altura);
                    i++;
                }
                if (imagens[i+4] != null)
                {
                    g.RotateTransform(imagens[i + 4].rotacao);
                    g.TranslateTransform((float)imagens[i + 4].posicao.X, ((float)imagens[i + 4].posicao.Y), MatrixOrder.Append);

                    g.DrawImage(imagens[i + 4].imagemSprite, -imagens[i + 4].largura / 2, -imagens[i + 4].altura / 2, imagens[i + 4].largura, imagens[i + 4].altura);
                    i++;
                }
                if (imagens[i+5] != null)
                {
                    g.RotateTransform(imagens[i + 5].rotacao);
                    g.TranslateTransform((float)imagens[i + 5].posicao.X, ((float)imagens[i + 5].posicao.Y), MatrixOrder.Append);

                    g.DrawImage(imagens[i + 5].imagemSprite, -imagens[i + 5].largura / 2, -imagens[i + 5].altura / 2, imagens[i + 5].largura, imagens[i + 5].altura);
                    i++;
                }

                if (i >= imagens.Length)
                    i = 0;
            }
        }

        private void update(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            double deltaTime = (now - start).Milliseconds / 1000.0;
            start = now;

            if (game)
            {
                PainelGeral.Visible = false;
                PainelGeral.Enabled = false;
            }
            else
            {
                PainelGeral.Visible = true;
                PainelGeral.Enabled = true;
            }

            foreach (Keys value in keys)
            {
                for (int i = 0; i < keys.Count; i++)
                {
                    Send("" + keys.Take<Keys>(i).ToString());
                }
            }

            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            AddKeys(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RemoveKeys(e.KeyCode);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        { 
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

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
                        ReactToMessage(data);
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

        private void ConectarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int porta = Int32.Parse(PortaTextBox.Text);
                client = new TcpClient(IPTextBox.Text, porta);

                NetworkStream stream = client.GetStream();
                leitorNet = new StreamReader(stream);
                escritorNet = new StreamWriter(stream);

                Send("Time:" + meuTime);
                Send("Nome:" + NomeTextBox.Text);

                Thread thread = new Thread(CheckMenssage);
                thread.Start();

                game = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Erro : " + err.Message);
            }
        }

        private void CTButton_Click(object sender, EventArgs e)
        {
            playerCT = true;
            playerTerror = false;
            meuTime = "CT";
            ConectarButton.Enabled = true;
        }

        private void TerrorButton_Click(object sender, EventArgs e)
        {
            playerTerror = true;
            playerCT = false;
            meuTime = "Terror";
            ConectarButton.Enabled = true;
        }

        public void ReactToMessage(string data)
        {
            try
            {
                //manda instanciar
                if (data.StartsWith("Instanciar"))
                {
                    if (!imagens[idTemp].instanciado)
                    {
                        Instanciar();
                        imagens[idTemp].instanciado = true;
                    }
                }

                // Recebe o id
                if (data.StartsWith("id:"))
                {
                    string dataTemp = data.Replace("id:", "");
                    idTemp = CalculoString(dataTemp);
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].id = idTemp;
                }

                //Recebe o nome
                if (data.StartsWith("nome:"))
                {
                    nomeTemp = data.Replace("nome:", "");
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].nome = nomeTemp;
                }

                //Recebe as posicoes
                if (data.StartsWith("posicaoX:"))
                {
                    posicaoTemp.X = CalculoString(data.Replace("posicaoX:", ""));
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].posicao.X = posicaoTemp.X;
                }       

                if (data.StartsWith("posicaoY:"))
                {
                    posicaoTemp.Y = CalculoString(data.Replace("posicaoY:", ""));
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].posicao.Y = posicaoTemp.Y;
                }

                //Recebe a rotacao
                if (data.StartsWith("rotacao:"))
                {
                    rotacaoTemp = CalculoString(data.Replace("rotacao:", ""));
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].rotacao = rotacaoTemp;
                }

                //Recebe a largura e altura
                if (data.StartsWith("largura:"))
                {
                    larguraTemp = CalculoString(data.Replace("largura:", ""));
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].largura = larguraTemp;
                }

                if (data.StartsWith("altura:"))
                {
                    alturaTemp = CalculoString(data.Replace("altura:", ""));
                    if (!imagens[idTemp].instanciado)
                        imagens[idTemp].altura = alturaTemp;
                }

                //Recebe que imagem ele é
                if (data.StartsWith("imagem:"))
                    imagemTemp = data.Replace("imagem:", "");

            }
            catch { }
        }

        public void Instanciar()
        {
            imagens[idTemp] = new Objeto(posicaoTemp, rotacaoTemp, larguraTemp, alturaTemp, nomeTemp, idTemp, imagemTemp);
        }

        public int CalculoString(string data)
        {
            int numeros = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (numeros != 0 && data.Length > 1)
                    numeros *= 10;

                if (data[i] != ' ')
                {
                    numeros = (int)data[i];
                }
            }
            return numeros;
        }

        public void AddKeys(Keys key)
        {
            keys.Add(key);
        }

        public void RemoveKeys(Keys key)
        {
            keys.Remove(key);
        }

        public void ClearKeys(Keys key)
        {
            keys.Clear();
        }
    }
}
