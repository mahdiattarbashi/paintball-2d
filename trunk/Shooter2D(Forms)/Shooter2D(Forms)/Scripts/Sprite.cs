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
    public abstract class Sprite
    {
        
        public Vector velocidade { get; set; }
        public Image sprite { get; set; }
        public double radianoColisao;
        public Point posicao;
        public float rotacao;

        public Sprite(Point initialPosition, float angulo , Image image)
        {
            posicao = initialPosition;
            rotacao = angulo;
            sprite = new Bitmap(image);
            radianoColisao = sprite.Width * .48;
        }

        public static bool Collides(Sprite s1, Sprite s2)
        {
            Vector v = new Vector((s1.posicao.X) - (s2.posicao.X), (s1.posicao.Y) - (s2.posicao.Y));
            if (s1.radianoColisao + s2.radianoColisao > v.Length)
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
