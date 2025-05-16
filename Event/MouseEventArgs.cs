using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NullMenu.Event
{
    public class MouseEventArgs:EventArgs
    {
        public Vector2 MousePos { get; set; }
        public Vector2 MouseDelta { get; set; }
        public MouseEventArgs(Vector2 mousePos, Vector2 mouseDelta)
        {
            this.MousePos = mousePos;
            this.MouseDelta = mouseDelta;
        }
    }
}
