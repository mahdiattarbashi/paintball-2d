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
    public class Player : Sprite
    {
        public int MaxX { get; set; }
        public int MinX { get; set; }
        public int MaxY { get; set; }
        public int MinY { get; set; }

        public int id { get; set; }
        public string name { get; set; }

        public Image imageSprite;

        public Player(Point firstPosition, int ident, string nick, Image image)
            : base(firstPosition)
        {
            id = ident;
            name = nick;
            imageSprite = image;
        }

        
    }
}
