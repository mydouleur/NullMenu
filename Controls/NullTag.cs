using NullMenu.Enum;
using Raylib_cs;
using System.Numerics;
namespace NullMenu.Controls
{
    public class NullTag : RootControl
    {
        public float PosX { get; set; } = 50;
        public float PosY { get; set; } = 100;
        public float Width { get; set; } = 100;
        public float Height { get; set; } = 50;
        public string Text { get; set; } = "BDDDDDS";
        public int FontSize { get; set; } = 20;
        public float Spacing { get; set; } = 2;
        public Color Background { get; set; } = Color.Blue;
        public Color Foreground { get; set; } = Color.White;
        public Font Font { get; set; } = Raylib.GetFontDefault();
        public HorizontalAlign HorizontalAlign { get; set; } = HorizontalAlign.Center;
        public override bool IsTriggered()
        {
            return true;
        }
        public override void Render()
        {
            Raylib.DrawRectangleV(new Vector2(PosX, PosY), new Vector2(Width, Height), Background);
            var texLen = Raylib.MeasureText(Text, FontSize);
            Raylib.DrawTextEx(Font, Text, new Vector2(PosX + (int)(HorizontalAlign) * 0.5f * (Width - texLen), PosY + 0.5f * Height - FontSize * 0.5f), FontSize, Spacing, Foreground);
            base.Render();
        }
    }
}
