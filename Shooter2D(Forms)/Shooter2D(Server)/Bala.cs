using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter2D_Server
{
    public class Bala : Objeto
    {
        DateTime start;
        public Player meuPlayer;

        public Bala(double posicaoX, double posicaoY, float rotacao, int largura, int altura, Player meuPlayer)
            : base(posicaoX, posicaoY, rotacao, largura, altura)
        {
            this.meuPlayer = meuPlayer;

            DateTime now = DateTime.Now;
            double deltaTime = (now - start).Milliseconds / 1000.0;
            start = now;

            this.velocidade = Vector.CreateVectorFromAngle(this.rotacao, 100);

            this.velocidade += (this.velocidade * deltaTime);

        }
    }
}
