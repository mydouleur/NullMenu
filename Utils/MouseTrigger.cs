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

        public static void TrigMouseDown(View view)
        {
            MousePos = Raylib.GetMousePosition();
            for (int i = 0; i <= 6; i++)
            {
                if (Raylib.IsMouseButtonPressed((MouseButton)i))
                {
                    var control = RootControl.GetTrigControl(view);
                    if (control.MouseDown != null)
                    {
                        control.MouseDown.Invoke(control, new MouseButtonEventArgs((MouseButton)i, MousePos, Raylib.GetMouseDelta()));
                    }
                }
            }
        }
        public static void TrigMouseUp(View view)
        {
            MousePos = Raylib.GetMousePosition();
            for (int i = 0; i <= 6; i++)
            {
                if (Raylib.IsMouseButtonReleased((MouseButton)i))
                {
                    var control = RootControl.GetTrigControl(view);
                    if (control.MouseUp != null)
                    {
                        control.MouseUp.Invoke(control, new MouseButtonEventArgs((MouseButton)i, MousePos, Raylib.GetMouseDelta()));
                    }
                }
            }
        }
    }
}
