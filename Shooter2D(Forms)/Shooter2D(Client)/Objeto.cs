using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Shooter2D_Client_
{
    public class Objeto
    {
        public bool instanciado = false;

        public Point posicao;
        public int rotacao;
        public int largura;
        public int altura;
        public string nome;
        public int id;
        private string urlImagem = "";
        public Bitmap imagemSprite;

        public Objeto(Point posicao,int rotacao, int largura, int altura, string nome, int id, string imagem)
        {
            this.posicao = posicao;
            this.rotacao = rotacao;
            this.largura = largura;
            this.altura = altura;
            this.nome = nome;
            this.id = id;
            this.urlImagem = @"Shooter2D(Client)\Images\" + imagem + ".png";
            this.imagemSprite = new Bitmap(urlImagem);
        }
    }
}