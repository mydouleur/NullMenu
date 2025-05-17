#version 330

// 输入
in vec2 fragTexCoord;
in vec4 fragColor;

// 输出
out vec4 finalColor;

// 纹理采样器
uniform sampler2D texture0;
uniform vec2 texelSize;
uniform vec4 glowColor;
uniform float glowWidth;

void main()
{
    // 原始纹理颜色
    vec4 texColor = texture(texture0, fragTexCoord);
    
    // 只在透明区域生成光晕
    if (texColor.a == 0.0) {
        float glow = 0.0;
        
        // 采样周围像素
        for (float x = -glowWidth; x <= glowWidth; x += 1.0) {
            for (float y = -glowWidth; y <= glowWidth; y += 1.0) {
                vec2 offset = vec2(x, y) * texelSize;
                vec4 sample = texture(texture0, fragTexCoord + offset);
                glow += sample.a;
            }
        }
        
        // 计算平均光晕强度
        glow /= pow(glowWidth * 2.0 + 1.0, 2.0);
        
        // 混合光晕颜色
        finalColor = glowColor * glow;
    } else {
        // 原始文本颜色
        finalColor = texColor * fragColor;
    }
}