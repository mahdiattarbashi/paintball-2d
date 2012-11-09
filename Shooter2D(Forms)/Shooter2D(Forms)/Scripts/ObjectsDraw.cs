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

        public Dictionary<string, Point> objectsForDraw = new Dictionary<string, Point>();

        public void ClearList()
        {
            objectsForDraw.Clear();
        }

        public ObjectsDraw()
        {
            ClearList();
        }

        public void AddList(string director, Point position) 
        {
            objectsForDraw.Add(director, position);
        }

        public void RemoveList(string diretorio)
        {
            objectsForDraw.Remove(diretorio);
        }
    }
}
