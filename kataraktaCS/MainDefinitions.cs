using System.IO;
using System.Reflection;

namespace kataraktaCS
{
    public class MainDefinitions
    {
        public string GameName = "SUPER MARIO 64";
        public string FolderSettingsFile = "FolderSettings.json";
        public string CacheFilename = "kcscache.bin";
        public static string kataraktaPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Addons\\kataraktaCS\\";
        public static string MainFolderPath = kataraktaPath + "Textures\\";
        public static string SettingsPath = kataraktaPath + "Settings.json";
        public static string HotkeysPath = kataraktaPath + "Hotkeys.json";
    }
}
