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
    class Bala : Sprite
    {
        public int MaxX { get; set; }
        public int MinX { get; set; }
        public int MaxY { get; set; }
        public int MinY { get; set; }

        DateTime start;

        public Image imageSprite;
        private Point point;
        

        public Bala(Point firstPosition, float angulo, Image image)
            : base(firstPosition, angulo)
        {
            imageSprite = image;
        }

        public void MoverBala(float angulo, int distance)
        {
            DateTime now = DateTime.Now;
            double deltaTime = (now - start).Milliseconds / 1000.0;
            start = now;
            float contador = 0;  
        }
        
    }
}
