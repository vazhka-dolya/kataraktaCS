using System.Windows.Forms;

namespace kataraktaCS.Controls.kataraktaPictureBoxUnfiltered
{
    public class kataraktaPictureBoxUnfiltered : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Image != null)
            {
                pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                pe.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                pe.Graphics.DrawImage(Image, ClientRectangle);
            }
            else
            {
                base.OnPaint(pe);
            }
        }
    }
}
