using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using kataraktaCS.Properties;

namespace kataraktaCS
{
    public class HotkeyManager
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private Form form;
        private int nextId = 0;
        private Dictionary<int, Action> actions = new Dictionary<int, Action>();

        private const int WM_HOTKEY = 0x0312;

        public HotkeyManager(Form form)
        {
            this.form = form;
        }

        public int RegisterHotkey(Keys keys, Action action)
        {
            uint mods = 0;
            if ((keys & Keys.Control) == Keys.Control) mods |= 0x2;
            if ((keys & Keys.Shift) == Keys.Shift) mods |= 0x4;
            if ((keys & Keys.Alt) == Keys.Alt) mods |= 0x1;

            uint vk = (uint)(keys & Keys.KeyCode);

            int id = nextId++;
            if (!RegisterHotKey(form.Handle, id, mods, vk))
            {
                throw new InvalidOperationException(Resources.Error_CouldNotRegisterHotkey);
            }

            actions[id] = action;
            return id;
        }

        public void HandleMessage(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int id = m.WParam.ToInt32();
                if (actions.ContainsKey(id))
                {
                    actions[id]();
                }
            }
        }

        public void UnregisterAll()
        {
            foreach (var kvp in actions)
            {
                UnregisterHotKey(form.Handle, kvp.Key);
            }
            actions.Clear();
        }
    }

    public class HotkeyConverter
    {
        public string HotkeyToString(Keys keys)
        {
            List<string> parts = new List<string>();

            if ((keys & Keys.Control) == Keys.Control) parts.Add("Ctrl");
            if ((keys & Keys.Shift) == Keys.Shift) parts.Add("Shift");
            if ((keys & Keys.Alt) == Keys.Alt) parts.Add("Alt");

            Keys mainKey = keys & Keys.KeyCode; // remove modifiers
            parts.Add(mainKey.ToString());

            return string.Join("+", parts); // e.g. "Ctrl+Shift+P"
        }

        public Keys StringToHotkey(string str)
        {
            Keys keys = Keys.None;
            string[] parts = str.Split('+');

            foreach (string part in parts)
            {
                switch (part.Trim())
                {
                    case "Ctrl": keys |= Keys.Control; break;
                    case "Shift": keys |= Keys.Shift; break;
                    case "Alt": keys |= Keys.Alt; break;
                    default:
                        try
                        {
                            keys |= (Keys)Enum.Parse(typeof(Keys), part, true);
                        }
                        catch
                        {
                            // invalid key name, ignore or handle
                        }
                        break;
                }
            }

            return keys;
        }
    }

    public class HotkeyEdit
    {
        public void ModifyHotkeys(string PathOfHotkey = "", bool RemoveInsteadOfAdd = false, string TheHotkey = "")
        {
            if (File.Exists(MainDefinitions.HotkeysPath))
            {
                var HotkeyList = new List<kCSHotkey>();
                kCSHotkeysClass JSONHotkeys =
                    JsonConvert.DeserializeObject<kCSHotkeysClass>
                    (File.ReadAllText($"{MainDefinitions.kataraktaPath}Hotkeys.json"));

                foreach (var hotkey in JSONHotkeys.Hotkeys)
                {
                    try
                    {
                        string StringPath = hotkey.Path;
                        string StringKeys = hotkey.Keys;

                        if (PathOfHotkey != "")
                        {
                            if (StringPath == PathOfHotkey) continue;
                        }
                        else continue;

                        HotkeyList.Add(new kCSHotkey { Path = StringPath, Keys = StringKeys });
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (!RemoveInsteadOfAdd && PathOfHotkey != "" && TheHotkey != "")
                {
                    HotkeyList.Add(new kCSHotkey { Path = PathOfHotkey, Keys = TheHotkey.Replace(" ", "") });
                }
                HotkeyList.Sort((a, b) => string.Compare(a.Path, b.Path, StringComparison.OrdinalIgnoreCase));

                var HotkeyFile = new
                {
                    kCSHotkeysRevision = "1",
                    Hotkeys = HotkeyList
                };

                using (var SW = new StreamWriter(MainDefinitions.HotkeysPath))
                using (var Writer = new JsonTextWriter(SW))
                {
                    Writer.Formatting = Formatting.Indented;
                    Writer.IndentChar = '\t';
                    Writer.Indentation = 1;
                    
                    var Serializer = new JsonSerializer();
                    Serializer.Serialize(Writer, HotkeyFile);
                }
            }
            else
            {
                var NewHotkeys = new
                {
                    kCSHotkeysRevision = "2",
                    Hotkeys = Array.Empty<string>()
                };

                using (var SW = new StreamWriter(MainDefinitions.HotkeysPath))
                using (var Writer = new JsonTextWriter(SW))
                {
                    Writer.Formatting = Formatting.Indented;
                    Writer.IndentChar = '\t';
                    Writer.Indentation = 1;

                    var Serializer = new JsonSerializer();
                    Serializer.Serialize(Writer, NewHotkeys);
                }
            }
        }
    }

    public class frmHotkeySettingsNodeData
    {
        public string Path { get; set; }
        public string Hotkey { get; set; }
    }

    public partial class kCSHotkey
    {
        public string Path { get; set; }
        public string Keys { get; set; }
    }

    public partial class kCSHotkeysClass
    {
        public string kCSHotkeysRevision { get; set; }
        public List<kCSHotkey> Hotkeys { get; set; }
    }
}
