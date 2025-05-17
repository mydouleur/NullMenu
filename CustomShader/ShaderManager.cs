using NullMenu.Utils;
using Raylib_cs;
namespace NullMenu.CustomShader
{
    public static class ShaderManager
    {
        public static Shader Glow;
        public static void Initial()
        {
        //    var glowMemory = ResourceLoader.ReadTextResource("glow.frag");
         //   Glow = Raylib.LoadShaderFromMemory(null, "glow.frag");
            Glow = Raylib.LoadShader(null, "glow.frag");
        }
    }
}
