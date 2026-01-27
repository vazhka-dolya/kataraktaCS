using M64MM.Utils;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace kataraktaCS
{
    internal class ColorFunctions
    {
        #region Append

        public static byte[] AppendBytes(byte[] original, byte[] toAppend)
        {
            byte[] combined = new byte[original.Length + toAppend.Length];
            Buffer.BlockCopy(original, 0, combined, 0, original.Length);
            Buffer.BlockCopy(toAppend, 0, combined, original.Length, toAppend.Length);
            return combined;
        }

        public static byte[] AppendUInt32(byte[] original, uint value, bool bigEndian = false)
        {
            byte[] valueBytes = BitConverter.GetBytes(value);
            if (bigEndian && BitConverter.IsLittleEndian)
                Array.Reverse(valueBytes);
            return AppendBytes(original, valueBytes);
        }

        #endregion

        #region Encode single pixel

        // 4-bit intensity (I)
        public static byte ColorToI4(Color color)
        {
            // Get and return approximate grayscale color (intensity/luminance) from RGB
            int intensity = color.R * 77 + color.G * 150 + color.B * 29;

            byte i = (byte)(intensity >> 4);

            return (byte)(i >> 4);
        }

        // 4-bit intensity w/alpha (3/1)
        public static byte ColorToIA4(Color color)
        {
            int intensity = color.R * 77 + color.G * 150 + color.B * 29;

            byte i = (byte)(intensity >> 5); // 3 bits
            byte a = (byte)(color.A >> 7); // 1 bit

            return (byte)((i << 1) | a);
        }

        // 8-bit intensity (I)
        public static byte ColorToI8(Color color)
        {
            // Get and return approximate grayscale color (intensity/luminance) from RGB
            int intensity = color.R * 77 + color.G * 150 + color.B * 29;

            byte i = (byte)(intensity >> 8);

            return (byte)(i);
        }

        // 8-bit IA (4/4)
        public static byte ColorToIA8(Color color)
        {
            byte i = (byte)((color.R * 77 + color.G * 150 + color.B * 29) >> 4);
            byte a = (byte)(color.A >> 4);

            return (byte)(((i & 0xF) << 4) | a);
        }

        // 16-bit red, green, blue, alpha (RGBA) (5/5/5/1)
        public static ushort ColorToRGBA16(Color color)
        {
            ushort r = (ushort)((color.R >> 3) << 11);
            ushort g = (ushort)((color.G >> 3) << 6);
            ushort b = (ushort)((color.B >> 3) << 1);
            ushort a = (ushort)(color.A >> 7);

            return (ushort)(r | g | b | a);
        }

        // 16-bit IA (8/8)
        public static ushort ColorToIA16(Color color)
        {
            byte i = (byte)((color.R * 77 + color.G * 150 + color.B * 29) >> 8);

            return (ushort)((i << 8) | color.A);
        }

        // 32-bit RGBA (8/8/8/8)
        public static UInt32 ColorToRGBA32(Color color)
        {
            return (UInt32)((color.R << 24) | (color.G << 16) | (color.B << 8) | color.A);
        }

        // 32-bit RGBA (8/8/8/8) but you can specify alpha
        public static UInt32 ColorToRGBA32CustomAlpha(Color color, byte CustomAlpha = 0x0)
        {
            return (UInt32)((color.R << 24) | (color.G << 16) | (color.B << 8) | CustomAlpha);
        }

        #endregion

        #region Encode whole texture

        public static byte[] EncodeTexture(string RAMFormat, Color[] SourceTexture)
        {
            byte[] ConvertedTexturePixels = new byte[] { };
            switch (RAMFormat)
            {
                case "I4":
                    for (int i = 0; i < SourceTexture.Length; i += 2)
                    {
                        // Since one I4 pixel takes up only half a byte,
                        // we'll join two pixels in one byte like this:

                        byte pixel_first = ColorToI4(SourceTexture[i]);
                        byte pixel_second = ColorToI4(SourceTexture[i + 1]);

                        // In case there's an odd number of pixels
                        if (i + 1 > SourceTexture.Length)
                            pixel_second = 0;

                        byte twopixels = (byte)((pixel_first << 4) | pixel_second);

                        ConvertedTexturePixels =
                            AppendBytes(ConvertedTexturePixels, new byte[] { twopixels });
                    }
                    // Place the data in correct places
                    return Core.SwapEndian(ConvertedTexturePixels, 4);

                case "IA4":
                    for (int i = 0; i < SourceTexture.Length; i += 2)
                    {
                        // Since one IA4 pixel takes up only half a byte,
                        // we'll join two pixels in one byte like this:

                        byte pixel_first = ColorToIA4(SourceTexture[i]);
                        byte pixel_second = ColorToIA4(SourceTexture[i + 1]);

                        // In case there's an odd number of pixels
                        if (i + 1 > SourceTexture.Length)
                            pixel_second = 0;

                        byte twopixels = (byte)((pixel_first << 4) | pixel_second);

                        ConvertedTexturePixels =
                            AppendBytes(ConvertedTexturePixels, new byte[] { twopixels });
                    }
                    // Place the data in correct places
                    return Core.SwapEndian(ConvertedTexturePixels, 4);

                case "I8":
                    foreach (Color pixel in SourceTexture)
                    {
                        ConvertedTexturePixels =
                            AppendBytes(ConvertedTexturePixels, new byte[] { ColorToI8(pixel) });
                    }
                    // Place the data in correct places
                    return Core.SwapEndian(ConvertedTexturePixels, 4);

                case "IA8":
                    foreach (Color pixel in SourceTexture)
                    {
                        ConvertedTexturePixels =
                            AppendBytes(ConvertedTexturePixels, new byte[] { ColorToIA8(pixel) });
                    }
                    // Place the data in correct places
                    return Core.SwapEndian(ConvertedTexturePixels, 4);

                case "RGBA16":
                    foreach (Color pixel in SourceTexture)
                    {
                        ConvertedTexturePixels =
                            ConvertedTexturePixels.Concat
                            (BitConverter.GetBytes(ColorToRGBA16(pixel))).ToArray();
                    }
                    // Place the data in correct places
                    return Core.SwapEndian(Core.SwapEndian(ConvertedTexturePixels, 2), 4);

                case "IA16":
                    foreach (Color pixel in SourceTexture)
                    {
                        ConvertedTexturePixels =
                            ConvertedTexturePixels.Concat
                            (BitConverter.GetBytes(ColorToIA16(pixel))).ToArray();
                    }
                    // Place the data in correct places
                    return Core.SwapEndian(Core.SwapEndian(ConvertedTexturePixels, 2), 4);

                case "RGBA32":
                    foreach (Color pixel in SourceTexture)
                    {
                        ConvertedTexturePixels =
                            ConvertedTexturePixels.Concat
                            (BitConverter.GetBytes(ColorToRGBA32(pixel))).ToArray();
                    }
                    // Place the data in correct places
                    return Core.SwapEndian(Core.SwapEndian(ConvertedTexturePixels, 4), 4);

                default:
                    MessageBox.Show($"Format “{RAMFormat}” is not supported. Make sure that you have correctly written the format and that it's correctly capitalized.");
                    return null;
            }
        }

        #endregion

        #region Decode single pixel

        // 4-bit intensity (I)
        public static Color I4ToColor(byte pixels, bool useUpper)
        {
            int i4 = useUpper ? (pixels >> 4) : (pixels & 0x0F);
            int intensity = (i4 << 4) | i4;

            return Color.FromArgb(255, intensity, intensity, intensity);
        }

        // 4-bit intensity w/alpha (3/1)
        public static Color IA4ToColor(byte pixels, bool useUpper)
        {
            int pixel = useUpper ? (pixels >> 4) : (pixels & 0x0F);

            byte i3 = (byte)((pixel >> 1) & 0x07);
            byte a1 = (byte)(pixel & 0x01);

            int intensity = (i3 << 5) | (i3 << 2) | (i3 >> 1);
            int alpha = 255 * a1;

            return Color.FromArgb(alpha, intensity, intensity, intensity);
        }

        // 8-bit intensity (I)
        public static Color I8ToColor(byte pixel)
        {
            int intensity = pixel;

            return Color.FromArgb(255, intensity, intensity, intensity);
        }

        // 8-bit IA (4/4)
        public static Color IA8ToColor(byte pixel)
        {
            byte i4 = (byte)((pixel >> 4) & 0x0F);
            byte a4 = (byte)(pixel & 0x0F);

            int intensity = (i4 << 4) | i4;
            int alpha = (a4 << 4) | a4;

            return Color.FromArgb(alpha, intensity, intensity, intensity);
        }

        // 16-bit red, green, blue, alpha (RGBA) (5/5/5/1)
        public static Color RGBA16ToColor(ushort pixel)
        {
            int r5 = (pixel >> 11) & 0x1F;
            int g5 = (pixel >> 6) & 0x1F;
            int b5 = (pixel >> 1) & 0x1F;
            int a1 = pixel & 0x01;

            int r = (r5 << 3) | (r5 >> 2);
            int g = (g5 << 3) | (g5 >> 2);
            int b = (b5 << 3) | (b5 >> 2);
            int a = 255 * a1;

            return Color.FromArgb(a, r, g, b);
        }

        // 16-bit IA (8/8)
        public static Color IA16ToColor(ushort pixel)
        {
            byte intensity = (byte)(pixel >> 8);
            byte alpha = (byte)(pixel & 0xFF);

            return Color.FromArgb(alpha, intensity, intensity, intensity);
        }

        // 32-bit RGBA (8/8/8/8)
        public static Color RGBA32ToColor(uint pixel)
        {
            int r = (int)(pixel >> 24) & 0xFF;
            int g = (int)(pixel >> 16) & 0xFF;
            int b = (int)(pixel >> 8) & 0xFF;
            int a = (int)(pixel & 0xFF);

            return Color.FromArgb(a, r, g, b);
        }

        #endregion

        #region Decode whole texture

        public static Color[] DecodeTexture(byte[] Texture, string Format)
        {
            if (Texture.Length == 0)
            {
                throw new ArgumentException("The texture array's length must be an even number.");
            }
            else if (Texture.Length % 2 != 0)
            {
                throw new ArgumentException("The texture array's length cannot be zero.");
            }
            else
            {
                Color[] NewTexture;

                switch (Format)
                {
                    default:
                        throw new ArgumentException($"The format “{Format}” is not supported.");

                    case "I4":
                        NewTexture = new Color[Texture.Length * 2];
                        for (int i = 0; i < (Texture.Length * 2); i += 1)
                        {
                            byte pixels = Texture[i / 2];
                            bool bitshift = i % 2 == 0;
                            NewTexture[i] = I4ToColor(pixels, bitshift);
                        }
                        return NewTexture;

                    case "IA4":
                        NewTexture = new Color[Texture.Length * 2];
                        for (int i = 0; i < (Texture.Length * 2); i += 1)
                        {
                            byte pixels = Texture[i / 2];
                            bool bitshift = i % 2 == 0;
                            NewTexture[i] = IA4ToColor(pixels, bitshift);
                        }
                        return NewTexture;

                    case "I8":
                        NewTexture = new Color[Texture.Length];
                        for (int i = 0; i < (Texture.Length); i += 1)
                        {
                            byte pixel = Texture[i];
                            NewTexture[i] = I8ToColor(pixel);
                        }
                        return NewTexture;

                    case "IA8":
                        NewTexture = new Color[Texture.Length];
                        for (int i = 0; i < (Texture.Length); i += 1)
                        {
                            byte pixel = Texture[i];
                            NewTexture[i] = IA8ToColor(pixel);
                        }
                        return NewTexture;

                    case "RGBA16":
                        NewTexture = new Color[Texture.Length / 2];
                        for (int i = 0; i < (Texture.Length); i += 2)
                        {
                            UInt16 pixel = (UInt16)((Texture[i] << 8) | Texture[i + 1]);
                            NewTexture[i / 2] = RGBA16ToColor(pixel);
                        }
                        return NewTexture;

                    case "IA16":
                        NewTexture = new Color[Texture.Length / 2];
                        for (int i = 0; i < (Texture.Length); i += 2)
                        {
                            UInt16 pixel = (UInt16)((Texture[i] << 8) | Texture[i + 1]);
                            NewTexture[i / 2] = IA16ToColor(pixel);
                        }
                        return NewTexture;

                    case "RGBA32":
                        NewTexture = new Color[Texture.Length / 4];
                        for (int i = 0; i < (Texture.Length); i += 4)
                        {
                            uint pixel = (uint)((Texture[i] << 24) | (Texture[i + 1] << 16) | (Texture[i + 2] << 8) | (Texture[i + 3]));
                            NewTexture[i / 4] = RGBA32ToColor(pixel);
                        }
                        return NewTexture;
                }
            }
        }

        #endregion

        #region Turn Color[] into image

        public static Bitmap ColorArrayToBitmap(Color[] Colors, int Width, int Height)
        {
            // Ensure the array size matches the specified dimensions
            if (Colors.Length != Width * Height)
            {
                throw new ArgumentException("The size of the color array does not match the specified width and height." +
                    "\n\nColor array's width: " + Colors.Length.ToString() +
                    "\nWidth and height product:" + (Width * Height).ToString());
            }

            // Create a new Bitmap with the specified dimensions and pixel format
            Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);

            // Lock the bitmap's bits to directly access pixel data for faster manipulation
            BitmapData bmpData = bitmap.LockBits(
                new Rectangle(0, 0, Width, Height),
                ImageLockMode.WriteOnly,
                bitmap.PixelFormat);

            // Get the address of the first line
            IntPtr ptr = bmpData.Scan0;

            byte[] RGBValues = new byte[Width * Height * 4];

            // Copy the Color array values into the byte array
            for (int i = 0; i < Colors.Length; i++)
            {
                Color color = Colors[i];
                int byteIndex = i * 4;
                RGBValues[byteIndex] = color.B;      // Blue
                RGBValues[byteIndex + 1] = color.G;  // Green
                RGBValues[byteIndex + 2] = color.R;  // Red
                RGBValues[byteIndex + 3] = color.A;  // Alpha
            }

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(RGBValues, 0, ptr, RGBValues.Length);

            // Unlock the bits
            bitmap.UnlockBits(bmpData);

            return bitmap;
        }

        #endregion

        #region Rip texture

        public static Bitmap RipTexture(uint SegAddr, string Format, int Width, int Height)
        {
            long TextureSize = Width * Height;
            byte[] TextureBytes;
            if (TextureSize % 2 != 0)
                throw new ArgumentException("The product of the width and height should be divisible by two.");
            long ScannedAmount;

            switch (Format)
            {
                default: return null;
                case "I4": ScannedAmount = TextureSize / 2; break;
                case "IA4": ScannedAmount = TextureSize / 2; break;
                case "I8": ScannedAmount = TextureSize; break;
                case "IA8": ScannedAmount = TextureSize; break;
                case "RGBA16": ScannedAmount = TextureSize * 2; break;
                case "IA16": ScannedAmount = TextureSize * 2; break;
                case "RGBA32": ScannedAmount = TextureSize * 4; break;
            }

            TextureBytes = Core.SwapEndian(
                Core.ReadBytes(
                    Core.SegmentedToVirtual(SegAddr),
                    ScannedAmount
                ),
            4);

            Color[] DecodedPixels = DecodeTexture(TextureBytes, Format);
            return ColorArrayToBitmap(DecodedPixels, Width, Height);
        }

        #endregion

        #region Remove black borders

        public static void MakeNeighborsTransparent(string ImagePath)
        {
            Bitmap bmp;

            // Step 1: Load → clone → release file handle
            using (Bitmap fileBmp = new Bitmap(ImagePath))
            {
                bmp = new Bitmap(fileBmp.Width, fileBmp.Height, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(fileBmp, 0, 0);
                }
            } // fileBmp disposed HERE — file unlocked

            int width = bmp.Width;
            int height = bmp.Height;
            Rectangle rect = new Rectangle(0, 0, width, height);

            BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int stride = data.Stride;
            int byteCount = stride * height;

            byte[] pixels = new byte[byteCount];
            Marshal.Copy(data.Scan0, pixels, 0, byteCount);

            // Remove any pixels that are almost transparent (<= 4 opaqueness)
            for (int y = 0; y < height; y++)
            {
                int row = y * stride;
                for (int x = 0; x < width; x++)
                {
                    int i = row + x * 4;
                    if (pixels[i + 3] <= 4)
                    {
                        pixels[i + 0] = 0;
                        pixels[i + 1] = 0;
                        pixels[i + 2] = 0;
                        pixels[i + 3] = 0;
                    }
                }
            }

            byte[] original = new byte[pixels.Length];
            Buffer.BlockCopy(pixels, 0, original, 0, pixels.Length);
            Array.Clear(pixels, 0, pixels.Length);

            // Copy pixels and make transparent neighbor pixels
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int i = y * stride + x * 4;

                    if (original[i + 3] != 0)
                    {
                        // Copy original pixel
                        pixels[i + 0] = original[i + 0];
                        pixels[i + 1] = original[i + 1];
                        pixels[i + 2] = original[i + 2];
                        pixels[i + 3] = original[i + 3];

                        // Create neighboring pixels
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            int ny = y + dy;
                            if (ny < 0 || ny >= height) continue;

                            for (int dx = -1; dx <= 1; dx++)
                            {
                                int nx = x + dx;
                                if (nx < 0 || nx >= width) continue;

                                int ni = ny * stride + nx * 4;

                                if (original[ni + 3] == 0)
                                {
                                    pixels[ni + 0] = original[i + 0];
                                    pixels[ni + 1] = original[i + 1];
                                    pixels[ni + 2] = original[i + 2];
                                    pixels[ni + 3] = 1;
                                }
                            }
                        }
                    }
                }
            }

            Marshal.Copy(pixels, 0, data.Scan0, byteCount);
            bmp.UnlockBits(data);

            bmp.Save(ImagePath, ImageFormat.Png);
            bmp.Dispose();
        }

        #endregion
    }
}
