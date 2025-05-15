using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullMenu.Controls
{
    public class View : RootControl
    {
        public static View Init()
        {
            return new View() { Parent=null,Children=new()};
        }
        public override bool IsTriggered()
        {
            return true;
        }
        public override void Render()
        {
            Raylib.DrawFPS(10, 10);
            base.Render();
        }

    }
}
