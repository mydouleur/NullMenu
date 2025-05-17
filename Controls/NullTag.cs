using NullMenu.CustomShader;
using NullMenu.Enum;
using NullMenu.Event;
using NullMenu.Utils;
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
        public string Text { get; set; } = "0";
        public int FontSize { get; set; } = 20;
        public float Spacing { get; set; } = 2;
        public Color Background { get; set; } = Color.Blue;
        public Color Foreground { get; set; } = Color.White;
        public Color GlowColor { get; set; } = new Color(255, 200, 0, 150);
        public float GlowWidth { get; set; } = 100.0f;
        public Font Font { get; set; } = Raylib.GetFontDefault();
        public HorizontalAlign HorizontalAlign { get; set; } = HorizontalAlign.Center;
        private static Shader glow => ShaderManager.Glow;
        public override bool IsTriggered()
        {
            if (MouseTrigger.MousePos.X > PosX && MouseTrigger.MousePos.X < PosX + Width)
            {
                if (MouseTrigger.MousePos.Y > PosY && MouseTrigger.MousePos.Y < PosY + Height)
                {
                    return true;
                }
            }
            return false;
        }
        public override void Render()
        {
            Raylib.DrawRectangleV(new Vector2(PosX, PosY), new Vector2(Width, Height), Background);
            var texLen = Raylib.MeasureText(Text, FontSize);
            // Raylib.DrawTextEx(Font, Text, new Vector2(PosX + (int)(HorizontalAlign) * 0.5f * (Width - texLen), PosY + 0.5f * Height - FontSize * 0.5f), FontSize, Spacing, Foreground);
            DrawGlowText();
            base.Render();
        }
        public void click(object sender, MouseButtonEventArgs e)
        {
            this.Text = (Convert.ToInt32(Text) + 1 + "");
        }
        public void DrawGlowText()
        {
            // 测量文本尺寸
            var textSize = Raylib.MeasureTextEx(Font, Text, FontSize, Spacing);
            // 计算文本位置
            Vector2 textPos = new Vector2(PosX + (int)(HorizontalAlign) * 0.5f * (Width - textSize.X), PosY + 0.5f * Height - FontSize * 0.5f);
            //声明一个文本纹理并将文本绘制进去
            var tempRenderTarget = Raylib.LoadRenderTexture((int)textSize.X + 20, (int)textSize.Y + 20);
            Raylib.BeginTextureMode(tempRenderTarget);
            Raylib.ClearBackground(Color.Blank);
            Raylib.DrawTextEx(Font, Text, new Vector2(10, 10), FontSize, Spacing, Foreground);
            Raylib.EndTextureMode();
            //应用片段着色器
            Raylib.BeginShaderMode(glow);
            float[] texelSize = { 1.0f / tempRenderTarget.Texture.Width, 1.0f / tempRenderTarget.Texture.Height };
            Raylib.SetShaderValue(glow, Raylib.GetShaderLocation(glow, "texelSize"), texelSize, ShaderUniformDataType.Vec2);
            float[] glowColorArray = { GlowColor.R / 255.0f, GlowColor.G / 255.0f, GlowColor.B / 255.0f, GlowColor.A / 255.0f };
            Raylib.SetShaderValue(glow, Raylib.GetShaderLocation(glow, "glowColor"), glowColorArray, ShaderUniformDataType.Vec4);
            Raylib.SetShaderValue(glow, Raylib.GetShaderLocation(glow, "glowWidth"), GlowWidth,
              ShaderUniformDataType.Float);
            Raylib.DrawTextureRec(tempRenderTarget.Texture, new Rectangle(0, 0, tempRenderTarget.Texture.Width, -tempRenderTarget.Texture.Height), textPos - new Vector2(10, 10), Color.White);
           var valid=  Raylib.IsShaderValid(glow);
            Raylib.EndShaderMode();
        }
    }
}
