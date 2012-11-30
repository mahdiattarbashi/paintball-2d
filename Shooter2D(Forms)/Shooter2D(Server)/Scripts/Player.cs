using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter2D_Server
{
    public class Player : Objeto
    {
        public string nome;
        public Bala[] minhasBalas;
        public int contador;
        bool podeAtirar;

        public Player(double posicaoX, double posicaoY, float rotacao, int largura, int altura, string nome)
            : base(posicaoX, posicaoY, rotacao, largura, altura)
        {
            this.nome = nome;
            minhasBalas = new Bala[3];
        }

        public void Atirar()
        {
            if (contador == minhasBalas.Length)
                contador -= minhasBalas.Length;

            Vector posBala = Vector.CreateVectorFromAngle(this.rotacao, this.radianoColisao);

            minhasBalas[contador] = new Bala(posBala.X, posBala.Y, this.rotacao, 10, 10, this);
        }
    }
}
