using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NullMenu.Utils
{
    public static class ResourceLoader
    {
        // 根据资源名称获取流
        public static Stream GetResourceStream(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(resourceName);
        }

        // 读取文本资源
        public static string ReadTextResource(string resourceName)
        {
            using (var stream = GetResourceStream(resourceName))
            {
                if (stream == null)
                    throw new FileNotFoundException($"资源 '{resourceName}' 未找到");

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        // 获取资源名称（用于调试）
        public static string[] GetAllResourceNames()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceNames();
        }
    }
}
