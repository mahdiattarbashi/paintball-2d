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
    public class KeyManager
    {
        HashSet<KeyEventArgs> keys = new HashSet<KeyEventArgs>();
        
        public void Add(KeyEventArgs key)
        {
            keys.Add(key);
        }

        public void Remove(KeyEventArgs key)
        {
            keys.Remove(key);
        }

        public bool isPress(KeyEventArgs key)
        {
            return keys.Contains(key);
        }

    }
}
