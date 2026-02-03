using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace kataraktaCS
{
    public class kataraktaVersion
    {
        // For normal releases
        public static string VersionName = "Release 1.0.1";

        // For Tester Builds
        //public static string VersionName = "Tester Build 1 Fix 2";
    }

    // Find Level Texture

    public class LevelTexture : IEquatable<LevelTexture>
    {
        public UInt32 SegAddr {  get; set; }
        public string Format { get; set; }
        public UInt16 Width { get; set; }
        public UInt16 Height { get; set; }

        public bool Equals(LevelTexture other)
        {
            if (other == null) return false;
            return SegAddr == other.SegAddr;
        }
    }

    public class RippedTexture
    {
        public Bitmap Texture { get; set; }
        public UInt32 SegAddr { get; set; }
        public long VirAddr { get; set; }
        public string Format { get; set; }
        public UInt16 Width { get; set; }
        public UInt16 Height { get; set; }
    }

    public class SegAddrWithNumber : IComparable<SegAddrWithNumber>
    {
        public byte Number { get; set; }
        public UInt32 SegAddr { get; set; }

        public int CompareTo(SegAddrWithNumber other)
        {
            if (other == null) return 1;

            return this.Number.CompareTo(other.Number);
        }
    }

    // Texture tree

    public class NodeData
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string HotkeyDisplay { get; set; }
        public Image Icon { get; set; }
        public bool Cached { get; set; }
    }

    // Texture applying

    public class RAMConvertItem
    {
        public string RAMFormat { get; set; }
        public Color[] Pixels { get; set; }
        public uint SegAddress { get; set; }
    }

    public class RAMApplyItem
    {
        public byte[] Pixels { get; set; }
        public uint SegAddress { get; set; }
    }

    public class TPApplyItem
    {
        public string AbsolutePath { get; set; }
        public string Filename { get; set; }
    }

    // Settings

    public partial class kCSSettingsClass
    {
        public string TexturePack_HiResPath { get; set; }
        public string TexturePack_MainGameName { get; set; }
        public List<string> TexturePack_OtherGamesNames { get; set; }
        public bool CheckForUpdates { get; set; }
        public bool EnableStayOnTop { get; set; }
        public bool TreeView_UseSimplifiedTreeView { get; set; }
        public bool TreeView_DisplayIcons { get; set; }
        public bool TreeView_DisplayCache { get; set; }
        public bool TreeView_DisplayCacheOnRight { get; set; }
        public string Appearance_TextureBG { get; set; }
    }

    // Folders and Templates

    public partial class kCSFolderTemplate
    {
        public string Filename { get; set; }
        public bool CoverSubfolders { get; set; }
    }

    public partial class kCSFolderClass
    {
        public string kCSFolderRevision { get; set; }
        public kCSFolderTemplate Template { get; set; }
    }

    public partial class kCSTemplateTexture
    {
        public string Title { get; set; }
        public bool Display { get; set; }
        public string AlternativeFilename { get; set; }
        public string TexturePackFilename { get; set; }
        public string RAM { get; set; }
        public string RAMFormat { get; set; }
    }

    public partial class kCSTemplateClass
    {
        public string kCSTemplateRevision { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<kCSTemplateTexture> UsedTextures { get; set; }
    }

    // Template texture but it also contains the absolute path to the texture
    public partial class kCSTemplateTextureAbsolutePath
    {
        public string Title { get; set; }
        public bool Display { get; set; }
        public string AlternativeFilename { get; set; }
        public string TexturePackFilename { get; set; }
        public string AbsolutePath { get; set; }
        public string RAM { get; set; }
        public string RAMFormat { get; set; }
    }

    #region Old template and folder settings revisions

    public partial class kCSFolderTemplateRev1
    {
        public string Type { get; set; }
        public string Filename { get; set; }
        public bool CoverSubfolders { get; set; }
    }

    public partial class kCSFolderClassRev1
    {
        public string kCSFolderRevision { get; set; }
        public string FolderVersion { get; set; }
        public kCSFolderTemplateRev1 Template { get; set; }
    }

    public partial class kCSFolderRootRev1
    {
        public kCSFolderClassRev1 kCSFolder { get; set; }
    }

    public partial class kCSTemplateTextureRev1
    {
        public string Title { get; set; }
        public string Display { get; set; }
        public string AlternativeFilename { get; set; }
        public string TexturePackFilename { get; set; }
        public string RAM { get; set; }
        public string RAMFormat { get; set; }
    }

    public partial class kCSTemplateClassRev1
    {
        public string kCSTemplateRevision { get; set; }
        public string TemplateVersion { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<kCSTemplateTextureRev1> UsedTextures { get; set; }
    }

    public partial class kCSTemplateRootRev1
    {
        public kCSTemplateClassRev1 kCSTemplate { get; set; }
    }

    #endregion

    public class RoundedCorners
    {
        // The enum flag for DwmSetWindowAttribute's second parameter, which tells the function what attribute to set.
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
        // what value of the enum to set.
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            DWMWCP_DEFAULT = 0,
            DWMWCP_DONOTROUND = 1,
            DWMWCP_ROUND = 2,
            DWMWCP_ROUNDSMALL = 3
        }

        // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern long DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                         uint cbAttribute);
    }
}
