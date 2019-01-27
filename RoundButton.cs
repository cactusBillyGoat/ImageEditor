using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Image_Editor
{
    public class RoundButton : Button
    {
        protected override void OnPaint(PaintEventArgs E)
        {
            var gr_path = new GraphicsPath();
            gr_path.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new System.Drawing.Region(gr_path);
            base.OnPaint(E);
        }
    }
}