using Raylib_cs;

namespace NullMenu.Controls
{
    public class NullTag : RootControl
    {
        public int PosX { get; set; } = 50;
        public int PosY { get; set; } = 100;
        public int Width { get; set; } = 100;
        public int Height { get; set; } = 50;
        public string Text { get; set; } = "Text";
        public int fontSize { get; set; } = 20;
        public Color Background { get; set; } = Color.Blue;
        public Color Foreground { get; set; } = Color.White;

        public override bool IsTriggered()
        {
            return true;
        }
        public override void Render()
        {
            Raylib.DrawRectangle(PosX, PosY, Width, Height, Background);
            Raylib.DrawText(Text, PosX, PosY, fontSize, Foreground);
            base.Render();
        }
    }
}
