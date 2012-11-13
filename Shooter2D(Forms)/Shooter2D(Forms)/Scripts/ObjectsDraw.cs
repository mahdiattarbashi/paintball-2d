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
    public class ObjectsDraw
    {

        //public Dictionary<Image, Point> objectsForDraw = new Dictionary<Image, Point>();
        public Sprite[] objectsForDraw = new Sprite[100];
        public void ClearList()
        {
            //objectsForDraw.Clear();
        }

        public ObjectsDraw()
        {
            ClearList();
        }

        public void AddList(Image director, Point position) 
        {
            //objectsForDraw.Add(director, position);
            
        }

        public void RemoveList(Image director, Point position)
        {
            //objectsForDraw.Remove(diretorio);
        }

    }
}
