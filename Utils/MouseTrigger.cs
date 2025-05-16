using NullMenu.Controls;
using NullMenu.Event;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NullMenu.Utils
{
    public static class MouseTrigger
    {
        public static Vector2 MousePos { get; set; } = new Vector2();
        public static bool TrigMouseDown(View view)
        {
            MousePos = Raylib.GetMousePosition();
            for (int i = 0; i <= 6; i++)
            {
                if (Raylib.IsMouseButtonDown((MouseButton)i))
                {
                    var control = RootControl.GetTrigControl(view);
                    if (control.MouseDown != null)
                    {
                        control.MouseDown.Invoke(control, new MouseButtonEventArgs((MouseButton)i, MousePos, Raylib.GetMouseDelta()));
                    }
                }
            }
            return false;
        }
    }
}
