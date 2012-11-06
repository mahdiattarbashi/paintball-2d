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
    public abstract class Sprite
    {
        DateTime start;
        
        public Vector velocidade { get; set; }
        public Image spriteImage { get; set; }
        public double radianoColisao;
        public Point posicao;

        public Sprite(Point initialPosition)
        {
            posicao = initialPosition;
            //spriteImage = new Bitmap(sprite);
            //radianoColisao = spriteImage.Width * .48;
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
