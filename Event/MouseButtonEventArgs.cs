using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NullMenu.Event
{
    public class MouseButtonEventArgs:MouseEventArgs
    {
        public MouseButton mouseButton { get; set; }
        public MouseButtonEventArgs(MouseButton mouseButton,Vector2 mousePos,Vector2 mouseDelta) : base(mousePos, mouseDelta)
        {
            this.mouseButton = mouseButton;
        }
    }
}
