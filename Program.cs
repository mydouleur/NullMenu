﻿using NullMenu.Controls;
using NullMenu.CustomShader;
using NullMenu.Utils;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace NullMenu
{
    internal class Program
    {
        static View? view;
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 800;
            const int screenHeight = 450;
            SetConfigFlags(ConfigFlags.TransparentWindow | ConfigFlags.UndecoratedWindow);
            InitWindow(screenWidth, screenHeight, "NullMenu");
            SetTargetFPS(60);
            ShaderManager.Initial();
            //--------------------------------------------------------------------------------------
            view = View.Initial();
            var temptag = new NullTag();
            view.Children.Add(temptag);
            temptag.MouseUp += temptag.click;
            // Main game loop
            while (!WindowShouldClose())
            {
                // Update
                //----------------------------------------------------------------------------------
                // NOTE: All variables update happens inside GUI control functions
                //----------------------------------------------------------------------------------
                Thread.Sleep(10);
                MouseTrigger.TrigMouseDown(view);
                MouseTrigger.TrigMouseUp(view);
                // Draw
                //----------------------------------------------------------------------------------
                    BeginDrawing();
                    ClearBackground(new Color(0, 0, 0, 0));
                    view.Render();
                    EndDrawing();
                //----------------------------------------------------------------------------------
            }
            CloseWindow();
            //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
