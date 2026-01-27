using kataraktaCS.Properties;
using M64MM.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kataraktaCS
{
    public partial class frmQuad64 : Form
    {
        List<RippedTexture> RippedTextures;

        public frmQuad64()
        {
            InitializeComponent();
            listView1.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0);
            pictureBox1.BackColor = Color.FromArgb(0xC0, 0xC0, 0xC0);
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            ResetTextureProperties();

            // Have to set this programmatically because otherwise
            // the ForeColor will still display as black when the
            // textbox is read-only. I love WinForms :DDDDDDDD
            textBoxVirAddr.BackColor = SystemColors.Control;
        }

        public static bool ByteArrayStartsWith(byte[] Source, byte[] Prefix)
        {
            // Null or empty arrays
            if (Source == null || Prefix == null)
            {
                return Source == Prefix; // Both null means true, one null means false
            }

            // If the prefix is longer than the source, it cannot be a prefix
            if (Prefix.Length > Source.Length)
            {
                return false;
            }

            // Compare elements one by one
            for (int i = 0; i < Prefix.Length; i++)
            {
                if (Source[i] != Prefix[i])
                {
                    return false;
                }
            }

            return true;
        }

        // TO DO:
        // • Make it be able to read textures in custom levels
        //   (their code is structured a bit differently)

        public List<LevelTexture> FindLevelTextures()
        {
            UInt32 Seg01 = 0x01000000;
            UInt32 Seg01End = 0;

            UInt32 Seg02 = 0x02000000;
            UInt32 Seg02End = 0;

            UInt32 Seg03 = 0x03000000;
            UInt32 Seg03End = 0;

            UInt32 Seg04 = 0x04000000;
            UInt32 Seg04End = 0;

            UInt32 Seg05 = 0x05000000;
            UInt32 Seg05End = 0;

            UInt32 Seg06 = 0x06000000;
            UInt32 Seg06End = 0;

            UInt32 Seg07 = 0x07000000;
            UInt32 Seg07End = 0;

            UInt32 Seg08 = 0x08000000;
            UInt32 Seg08End = 0;

            UInt32 Seg09 = 0x09000000;
            UInt32 Seg09End = 0;

            UInt32 Seg0E = 0x0E000000;
            UInt32 Seg0EEnd = 0x0E0FFFFF;

            //byte[] SegStartSearch = new byte[] { 0xE7, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            byte[] DisplayListStart = Core.SwapEndian(new byte[] { 0x06, 0x00, 0x00, 0x00 }, 4);
            byte[] TextureSize = Core.SwapEndian(new byte[] { 0xF2, 0x00, 0x00, 0x00 }, 4);

            // Create a list of all 32 segments
            List<SegAddrWithNumber> Segments = new List<SegAddrWithNumber>();
            for (byte i = 0; i <= 32; i++)
            {
                switch (i)
                {
                    default:
                        UInt32 SegAddr = BitConverter.ToUInt32(
                            Core.SwapEndian(
                                Core.ReadBytes(
                                    Core.BaseAddress + 0x33B400 + (4 * i),
                                4),
                            4),
                        0);
                        Segments.Add(new SegAddrWithNumber
                        {
                            SegAddr = SegAddr,
                            Number = i
                        });
                        break;
                    // Segment 1 constantly switches between 0x207D00 and 0x214550, so
                    // I'm going to manually put 0x207D00 here since it starts earlier
                    case 1:
                        Segments.Add(new SegAddrWithNumber
                        {
                            SegAddr = 0x207D00,
                            Number = i
                        });

                        break;
                }
            }

            // Sorted it in order to use it to determine
            // where segmented addresses 07 and 09 end
            Segments.Sort();

            // The beginning of the next segmented address
            // should be where the current address ends
            for (UInt16 i = 0; i <= 32; i++)
            {
                switch (Segments[i].Number)
                {
                    case 0x02:
                        if (i < 31) Seg02End = (UInt32)Segments[i + 1].Number << 24; break;
                    case 0x03:
                        if (i < 31) Seg03End = (UInt32)Segments[i + 1].Number << 24; break;
                    case 0x04:
                        if (i < 31) Seg04End = (UInt32)Segments[i + 1].Number << 24; break;
                    case 0x05:
                        if (i < 31) Seg05End = (UInt32)Segments[i + 1].Number << 24; break;
                    case 0x06:
                        if (i < 31) Seg06End = (UInt32)Segments[i + 1].Number << 24; break;
                    case 0x07:
                        if (i < 31) Seg07End = (UInt32)Segments[i + 1].Number << 24; break;
                    case 0x08:
                        if (i < 31) Seg08End = (UInt32)Segments[i + 1].Number << 24; break;
                    case 0x09:
                        if (i < 31) Seg09End = (UInt32)Segments[i + 1].Number << 24; break;
                    default:
                        break;
                }
            }

            // The “Pointers” scan type is used when there
            // are pointers to the texture loading commands,
            // while “Direct” is used when the commands are
            // located directly in the Fast3D script.
            var SegmentsStartAndEnd = new List<(UInt32 Start, UInt32 End, string ScanType)>
            {
                (Seg07, Seg07End, "Pointers"),
                (Seg09, Seg09End, "Pointers"),
                (Seg01, Seg01End, "Pointers"),
                (Seg02, Seg02End, "Pointers"),
                (Seg03, Seg03End, "Pointers"),
                (Seg04, Seg04End, "Pointers"),
                (Seg04, Seg04End, "Direct"),
                (Seg05, Seg05End, "Pointers"),
                (Seg06, Seg06End, "Pointers"),
                (Seg08, Seg08End, "Pointers"),
                (Seg0E, Seg0EEnd, "Pointers"),
                (Seg0E, Seg0EEnd, "Direct"),
                (0x0, 0x7FFFFF, "Direct")
            };

            UInt32 CurrentTextureAddr = 0;
            string CurrentTextureFormat = "";
            UInt16 CurrentTextureWidth = 0;
            UInt16 CurrentTextureHeight = 0;
            List<LevelTexture> LevelTextures = new List<LevelTexture>();

            // Start scanning the segmented addresses for textures
            foreach (var Seg in SegmentsStartAndEnd)
            {
                CurrentTextureAddr = 0;
                CurrentTextureFormat = "";
                CurrentTextureWidth = 0;
                CurrentTextureHeight = 0;

                UInt32 CurrentPos = (UInt32)Core.SegmentedToVirtual(Seg.Start);
                UInt32 EndPos = (UInt32)Core.SegmentedToVirtual(Seg.End);

                byte[] DLTextureLoad = null;
                while (CurrentPos < EndPos)
                {
                    byte[] CurrentPos8Bytes = Core.ReadBytes(CurrentPos, 8);

                    // Get the texture size
                    if (ByteArrayStartsWith(CurrentPos8Bytes, TextureSize))
                    {
                        byte[] Size = Core.SwapEndian(CurrentPos8Bytes.Skip(4).Take(4).ToArray(), 4);

                        // The width and height are stored as
                        // 12-bit numbers, which is three bytes
                        byte b1 = (byte)Size[1];
                        byte b2 = (byte)Size[2];
                        byte b3 = (byte)Size[3];

                        // Width: b1 + upper nibble of b2
                        uint Width = ((uint)b1 << 4) | ((uint)b2 >> 4);
                        // Height: lower nibble of b2 + b3
                        uint Height = (((uint)b2 & 0x0F) << 8) | b3;

                        // The stored sizes are encoded in a strange way, where
                        // they are decremented by one and then also bit-shifted
                        // to the left by two, and we can undo that by bit-shifting
                        // the number to the right by two and adding one back.
                        CurrentTextureWidth = (UInt16)((Width >> 2) + 1);
                        CurrentTextureHeight = (UInt16)((Height >> 2) + 1);
                    }

                    else if (Seg.ScanType == "Direct" &&
                        CurrentPos8Bytes[3] == 0xFD &&
                        CurrentPos8Bytes[1] == 0x00 &&
                        CurrentPos8Bytes[0] == 0x00)
                    {
                        DLTextureLoad = Core.SwapEndian(CurrentPos8Bytes, 4);
                    }
                    // Get the texture address and format
                    else if (Seg.ScanType == "Pointers" &&
                        ByteArrayStartsWith(CurrentPos8Bytes, DisplayListStart) &&
                        CurrentPos8Bytes[7] < 0x20)
                    {
                        DLTextureLoad =
                            Core.SwapEndian(
                                Core.ReadBytes(
                                    Core.SegmentedToVirtual(
                                        BitConverter.ToUInt32(
                                            CurrentPos8Bytes,
                                        4)
                                    ),
                                8),
                            4);

                        LevelTexture Texture = (ScanTextureLoad(CurrentTextureAddr, CurrentTextureFormat,
                            CurrentTextureWidth, CurrentTextureHeight, DLTextureLoad));
                        if (Texture != null)
                            LevelTextures.Add(Texture);

                        CurrentTextureAddr = 0;
                        CurrentTextureFormat = "";
                        CurrentTextureWidth = 0;
                        CurrentTextureHeight = 0;
                        DLTextureLoad = null;
                    }

                    CurrentPos += 8;

                    if (Seg.ScanType == "Direct" &&
                        DLTextureLoad != null &&
                        CurrentTextureWidth != 0 &&
                        CurrentTextureHeight != 0)
                    {
                        LevelTexture Texture = (ScanTextureLoad(CurrentTextureAddr, CurrentTextureFormat,
                            CurrentTextureWidth, CurrentTextureHeight, DLTextureLoad));
                        if (Texture != null)
                            LevelTextures.Add(Texture);

                        CurrentTextureAddr = 0;
                        CurrentTextureFormat = "";
                        CurrentTextureWidth = 0;
                        CurrentTextureHeight = 0;
                        DLTextureLoad = null;
                    }
                }
            }

            // Clean up the list from duplicates
            List<LevelTexture> CleanLevelTextures =
                LevelTextures
                .GroupBy(item => item.SegAddr)
                .Select(g => g.First())
                .ToList();

            return CleanLevelTextures;
        }

        private Image AdjustTexture(Image original)
        {
            int Size = Math.Max(original.Width, original.Height);
            Bitmap Squared = new Bitmap(Size, Size);
            Squared.MakeTransparent();

            using (Graphics g = Graphics.FromImage(Squared))
            {
                g.Clear(Color.Transparent);

                int offsetX = (Size - original.Width) / 2;
                int offsetY = (Size - original.Height) / 2;

                g.DrawImage(original, offsetX, offsetY);
            }

            return Squared;
        }

        private LevelTexture ScanTextureLoad(UInt32 CurrentTextureAddr, string CurrentTextureFormat,
            UInt16 CurrentTextureWidth, UInt16 CurrentTextureHeight, byte[] DLTextureLoad)
        {
            if (DLTextureLoad == null) return null;

            CurrentTextureAddr = BitConverter.ToUInt32(Core.SwapEndian(DLTextureLoad, 4), 4);

            CurrentTextureFormat = "";
            int CurrentTextureSize = CurrentTextureHeight * CurrentTextureWidth;
            switch (DLTextureLoad[1])
            {
                default: break;
                case 0x80: CurrentTextureFormat = "I4"; break;
                case 0x60: CurrentTextureFormat = "IA4"; break;
                case 0x88: CurrentTextureFormat = "I8"; break;
                case 0x68: CurrentTextureFormat = "IA8"; break;
                case 0x10: CurrentTextureFormat = "RGBA16"; break;

                // For some reason, the command for loading textures
                // can show that IA4/IA8 textures are 0x70, which is
                // IA16, and that I4/I8 textures are 0x90, which is… I16?
                //
                // The only way I can think of for determining what
                // they actually are is by checking their sizes.
                case 0x90:
                    CurrentTextureFormat = "I8";
                    if (CurrentTextureSize > 4096)
                        CurrentTextureFormat = "I4";
                    break;
                case 0x70:
                    CurrentTextureFormat = "IA16";
                    if (CurrentTextureSize > 2048)
                        CurrentTextureFormat = "IA8";
                    if (CurrentTextureSize > 4096)
                        CurrentTextureFormat = "IA4";
                    break;

                case 0x18: CurrentTextureFormat = "RGBA32"; break;
            }

            if (DLTextureLoad[0] == 0xFD && DLTextureLoad[2] == 0x00 && DLTextureLoad[3] == 0x00 &&
                CurrentTextureWidth != 0 && CurrentTextureHeight != 0 && CurrentTextureFormat != "")
            {
                return new LevelTexture
                {
                    SegAddr = CurrentTextureAddr,
                    Format = CurrentTextureFormat,
                    Width = CurrentTextureWidth,
                    Height = CurrentTextureHeight,
                };
            }
            else return null;
        }

        private void ScanForTextures()
        {
            List<LevelTexture> LevelTextures = FindLevelTextures();

            RippedTextures = new List<RippedTexture>();

            foreach (LevelTexture Texture in LevelTextures)
            {
                if (Texture.Format == "I4" || Texture.Format == "IA4" ||
                    Texture.Format == "I8" || Texture.Format == "IA8" ||
                    Texture.Format == "RGBA16" || Texture.Format == "IA16" ||
                    Texture.Format == "RGBA32")
                {
                    try
                    {
                        Bitmap Ripped = ColorFunctions.RipTexture(
                                Texture.SegAddr,
                                Texture.Format,
                                Texture.Width,
                                Texture.Height);
                        RippedTextures.Add(new RippedTexture
                        {
                            Texture = Ripped,
                            SegAddr = Texture.SegAddr,
                            VirAddr = Core.SegmentedToVirtual(Texture.SegAddr, false),
                            Format = Texture.Format,
                            Width = Texture.Width,
                            Height = Texture.Height
                        });
                    }
                    catch
                    {

                    }
                }
            }

            FillFromRippedList();
        }

        private void FillFromRippedList()
        {
            ResetTextureProperties();
            imageList1.Images.Clear();
            listView1.Clear();
            listView1.Items.Clear();
            listView1.LargeImageList = imageList1;

            for (byte j = 0; j <= 31; j++)
            {
                ListViewGroup SegGroup = new ListViewGroup();
                string SegGroupName = Resources.Segment + " " + BitConverter.ToString(new byte[] { j });
                SegGroup.Name = SegGroupName;
                SegGroup.Header = SegGroupName;
                listView1.Groups.Add(SegGroup);
            }

            int i = 0;

            foreach (RippedTexture Texture in RippedTextures)
            {
                string str = AddrToString(Texture.SegAddr);

                Image AdjustedTexture = AdjustTexture(RippedTextures[i].Texture);

                imageList1.Images.Add(str, AdjustedTexture);
                ListViewItem TextureItem = new ListViewItem(str);
                TextureItem.ImageKey = str;
                TextureItem.Tag = Texture;

                string strSeg = str.Substring(0, 2);
                TextureItem.Group = listView1.Groups[Resources.Segment + " " + strSeg];

                listView1.Items.Add(TextureItem);
                i++;
            }
        }

        private string AddrToString(uint SegAddr, string SymbolBetweenBytes = "")
        {
            return BitConverter.ToString(
                    Core.SwapEndian(
                        BitConverter.GetBytes(
                            SegAddr
                        ),
                    4)
                ).Replace("-", SymbolBetweenBytes);
        }

        private string AddrToString(long SegAddr, string SymbolBetweenBytes = "")
        {
            return "8" + BitConverter.ToString(
                    Core.SwapEndian(
                        BitConverter.GetBytes(
                            SegAddr
                        ),
                    4)
                ).Replace("-", SymbolBetweenBytes).Substring(1, 7);
        }

        private void ShowTextureProperties(string SegAddr, string VirAddr, string Format, string Width, string Height, Bitmap Texture)
        {
            textBoxSegAddr.Text = SegAddr;
            textBoxVirAddr.Text = VirAddr;
            textBoxFormat.Text = Format;
            textBoxWidth.Text = Width;
            textBoxHeight.Text = Height;
            pictureBox1.BackgroundImage = Texture;

            foreach (TextBox textBox in new List<TextBox> { textBoxSegAddr, textBoxFormat, textBoxWidth, textBoxHeight })
            {
                Size OriginalSize = textBox.Size;
                Size NewSize = TextRenderer.MeasureText(textBox.Text, textBox.Font);

                textBox.Width = NewSize.Width;
            }
            buttonExportTexture.Enabled = true;
        }

        private void ResetTextureProperties()
        {
            textBoxSegAddr.Text = "…";
            textBoxFormat.Text = "…";
            textBoxWidth.Text = "…";
            textBoxHeight.Text = "…";
            pictureBox1.BackgroundImage = null;
        }

        private void menuScanForTextures_Click(object sender, EventArgs e)
        {
            ScanForTextures();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem Texture = listView1.SelectedItems[0];

                ShowTextureProperties(
                    AddrToString(((RippedTexture)Texture.Tag).SegAddr),
                    AddrToString(((RippedTexture)Texture.Tag).VirAddr),
                    ((RippedTexture)Texture.Tag).Format,
                    ((RippedTexture)Texture.Tag).Width.ToString(),
                    ((RippedTexture)Texture.Tag).Height.ToString(),
                    ((RippedTexture)Texture.Tag).Texture
                    );
            }
        }

        private void menuIconBigger_Click(object sender, EventArgs e)
        {
            Size newSize = new Size(imageList1.ImageSize.Width + 8, imageList1.ImageSize.Height + 8);
            imageList1.ImageSize = newSize;
            FillFromRippedList();
        }

        private void menuIconSmaller_Click(object sender, EventArgs e)
        {
            if (imageList1.ImageSize.Width > 8)
            {
                Size newSize = new Size(imageList1.ImageSize.Width - 8, imageList1.ImageSize.Height - 8);
                imageList1.ImageSize = newSize;
                FillFromRippedList();
            }
        }

        private void buttonExportTexture_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem Texture = listView1.SelectedItems[0];

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = MainDefinitions.kataraktaPath;
                saveFileDialog1.Filter = Resources.Quad64SaveSelectExtension;
                saveFileDialog1.Title = Resources.Quad64SaveTitle;
                saveFileDialog1.FileName =
                    $"{AddrToString(((RippedTexture)Texture.Tag).SegAddr)}.{((RippedTexture)Texture.Tag).Format.ToLower()}.png";
                saveFileDialog1.OverwritePrompt = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    ((RippedTexture)Texture.Tag).Texture.Save(saveFileDialog1.FileName);
            }
        }
    }
}
/*
FD [XX] 00 00 [BB BB BB BB]

[XX] = FFF II 000

B = segmented address of texture
F = Texture format
I = Texture bit-size

Color formats:
0 = RGBA (color and alpha)
1 = YUV (luminance and chrominance)
2 = CI (index and look-up palette)
3 = IA (grayscale and alpha)
4 = I (grayscale)

Bit sizes:
0 = 4-bit (I, IA, and CI)
1 = 8-bit (I, IA, and CI)
2 = 16-bit (RGBA, IA and YUV)
3 = 32-bit (RGBA)

    I4 = 100 00 000 = 80
   IA4 = 011 00 000 = 60
    I8 = 100 01 000 = 88
   IA8 = 011 01 000 = 68
RGBA16 = 000 10 000 = 10
  IA16 = 011 10 000 = 70
RGBA32 = 000 11 000 = 18
*/