using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter2D_Server
{
    public abstract class Objeto
    {

        public Vector velocidade { get; set; }
        public double radianoColisao;
        public double posicaoX;
        public double posicaoY;
        public float rotacao;
        public int largura;
        public int altura;

        

        public Objeto(double posicaoX, double posicaoY, float rotacao, int largura, int altura)
        {
            this.rotacao = rotacao;
            this.posicaoX = posicaoX;
            this.posicaoY = posicaoY;
            this.largura = largura;
            this.altura = altura;
            this.radianoColisao = ((altura + largura) / 2) * .48;
        }

        public static bool Collides(Objeto s1, Objeto s2)
        {
            Vector v = new Vector((s1.posicaoX) - (s2.posicaoX), (s1.posicaoY) - (s2.posicaoY));
            if (s1.radianoColisao + s2.radianoColisao > v.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CollideWall(Objeto s1, double telaX, double telaY)
        {
            Vector v = new Vector((s1.posicaoX) - (telaX), (s1.posicaoY) - (telaY));
            if (s1.radianoColisao > v.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
