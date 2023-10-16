using System.Drawing.Drawing2D;

namespace Fighting.Controls
{
    public partial class CustomBar : UserControl
    {
        public CustomBar()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public bool Reverse { get; set; }

        private Color _frontColorBright = Color.FromArgb(37, 249, 37);
        public Color FrontColorBright
        {
            get => _frontColorBright;
            set
            {
                _frontColorBright = value;
                FrontPanel.Invalidate();
            }
        }

        private Color _frontColorDark = Color.FromArgb(27, 179, 27);
        public Color FrontColorDark
        {
            get => _frontColorDark;
            set
            {
                _frontColorDark = value;
                FrontPanel.Invalidate();
            }
        }

        private Color _backColorBright = Color.FromArgb(184, 184, 184);
        public Color BackColorBright
        {
            get => _backColorBright;
            set
            {
                _backColorBright = value;
                BackPanel.Invalidate();
            }
        }

        private Color _backColorDark = Color.FromArgb(100, 100, 100);
        public Color BackColorDark
        {
            get => _backColorDark;
            set
            {
                _backColorDark = value;
                BackPanel.Invalidate();
            }
        }

        public float Value
        {
            get
            {
                return TableLayoutPanel.ColumnStyles[Reverse ? 1 : 0].Width;
            }
            set
            {
                TableLayoutPanel.ColumnStyles[0].Width = Reverse ? 100 - value : value;
                TableLayoutPanel.ColumnStyles[1].Width = Reverse ? value : 100 - value;
            }
        }

        private void FrontPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Reverse)
            {
                FrontPanel.BackColor = Color.Transparent;
                return;
            }

            Color frontBright = Reverse ? BackColorBright : FrontColorBright;
            Color frontDark = Reverse ? BackColorDark : FrontColorDark;

            Graphics g = e.Graphics;

            LinearGradientBrush lgb = new LinearGradientBrush(FrontPanel.ClientRectangle, frontBright, frontDark, LinearGradientMode.Vertical);
            ColorBlend cb = new ColorBlend(4);
            cb.Colors = new Color[] { frontBright, frontDark, frontDark, frontBright };
            cb.Positions = new Single[] { 0.0F, 0.3F, 0.7F, 1.0F };
            lgb.InterpolationColors = cb;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Region r = new Region(GetRoundRectagle(FrontPanel.ClientRectangle));
            g.FillRegion(lgb, r);

            lgb.Dispose();
            g.Dispose();
        }

        private void BackPanel_Paint(object sender, PaintEventArgs e)
        {
            if (!Reverse)
                return;

            Color backBright = Reverse ? FrontColorBright : BackColorBright;
            Color backDark = Reverse ? FrontColorDark : BackColorDark;

            Graphics g = e.Graphics;
            LinearGradientBrush lgb = new LinearGradientBrush(BackPanel.ClientRectangle, backBright, backDark, LinearGradientMode.Vertical);
            ColorBlend cb = new ColorBlend(4);
            cb.Colors = new Color[] { backBright, backDark, backDark, backBright };
            cb.Positions = new Single[] { 0.0F, 0.3F, 0.7F, 1.0F };
            lgb.InterpolationColors = cb;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Region r = new Region(GetRoundRectagle(BackPanel.ClientRectangle));
            g.FillRegion(lgb, r);

            lgb.Dispose();
            g.Dispose();
        }

        private void BackgroundPanel_Paint(object sender, PaintEventArgs e)
        {
            Color backBright = BackColorBright;
            Color backDark = BackColorDark;

            Graphics g = e.Graphics;
            LinearGradientBrush lgb = new LinearGradientBrush(BackgroundPanel.ClientRectangle, backBright, backDark, LinearGradientMode.Vertical);
            ColorBlend cb = new ColorBlend(4);
            cb.Colors = new Color[] { backBright, backDark, backDark, backBright };
            cb.Positions = new Single[] { 0.0F, 0.3F, 0.7F, 1.0F };
            lgb.InterpolationColors = cb;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRoundedRectangle(lgb, 0, 0, BackgroundPanel.Width, BackgroundPanel.Height, 10);

            lgb.Dispose();
            g.Dispose();
        }

        private GraphicsPath GetRoundRectagle(Rectangle bounds)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = bounds.Height;
            if (bounds.Height <= 0) radius = 20;

            if (bounds.Width <= 16)
            {
                float shift = (12 - bounds.Width) * 3.75f + 30;
                path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, radius, radius,
                    0, 90 - shift);
                path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius,
                    90 + shift, 90 - shift);
                path.AddArc(bounds.X, bounds.Y, radius, radius,
                    180, 90 - shift);
                path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius,
                    270 + shift, 90 - shift);
            }
            else
            {
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius,
                            radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90);
            }

            path.CloseAllFigures();
            return path;
        }
    }

    static class GraphicsExtension
    {
        private static GraphicsPath GenerateRoundedRectangle(
            this Graphics graphics,
            RectangleF rectangle,
            float radius)
        {
            float diameter;
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0.0F)
            {
                path.AddRectangle(rectangle);
                path.CloseFigure();
                return path;
            }
            else
            {
                if (radius >= (Math.Min(rectangle.Width, rectangle.Height)) / 2.0)
                    return graphics.GenerateCapsule(rectangle);
                diameter = radius * 2.0F;
                SizeF sizeF = new SizeF(diameter, diameter);
                RectangleF arc = new RectangleF(rectangle.Location, sizeF);
                path.AddArc(arc, 180, 90);
                arc.X = rectangle.Right - diameter;
                path.AddArc(arc, 270, 90);
                arc.Y = rectangle.Bottom - diameter;
                path.AddArc(arc, 0, 90);
                arc.X = rectangle.Left;
                path.AddArc(arc, 90, 90);
                path.CloseFigure();
            }
            return path;
        }
        private static GraphicsPath GenerateCapsule(
            this Graphics graphics,
            RectangleF baseRect)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new GraphicsPath();
            try
            {
                if (baseRect.Width > baseRect.Height)
                {
                    diameter = baseRect.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = baseRect.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (baseRect.Width < baseRect.Height)
                {
                    diameter = baseRect.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = baseRect.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else path.AddEllipse(baseRect);
            }
            catch { path.AddEllipse(baseRect); }
            finally { path.CloseFigure(); }
            return path;
        }

        /// <summary>
        /// Draws a rounded rectangle specified by a pair of coordinates, a width, a height and the radius 
        /// for the arcs that make the rounded edges.
        /// </summary>
        /// <param name="brush">System.Drawing.Pen that determines the color, width and style of the rectangle.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle to draw.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle to draw.</param>
        /// <param name="width">Width of the rectangle to draw.</param>
        /// <param name="height">Height of the rectangle to draw.</param>
        /// <param name="radius">The radius of the arc used for the rounded edges.</param>

        public static void DrawRoundedRectangle(
            this Graphics graphics,
            Pen pen,
            float x,
            float y,
            float width,
            float height,
            float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawPath(pen, path);
            graphics.SmoothingMode = old;
        }

        /// <summary>
        /// Draws a rounded rectangle specified by a pair of coordinates, a width, a height and the radius 
        /// for the arcs that make the rounded edges.
        /// </summary>
        /// <param name="brush">System.Drawing.Pen that determines the color, width and style of the rectangle.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle to draw.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle to draw.</param>
        /// <param name="width">Width of the rectangle to draw.</param>
        /// <param name="height">Height of the rectangle to draw.</param>
        /// <param name="radius">The radius of the arc used for the rounded edges.</param>

        public static void DrawRoundedRectangle(
            this Graphics graphics,
            Pen pen,
            int x,
            int y,
            int width,
            int height,
            int radius)
        {
            graphics.DrawRoundedRectangle(
                pen,
                Convert.ToSingle(x),
                Convert.ToSingle(y),
                Convert.ToSingle(width),
                Convert.ToSingle(height),
                Convert.ToSingle(radius));
        }

        /// <summary>
        /// Fills the interior of a rounded rectangle specified by a pair of coordinates, a width, a height
        /// and the radius for the arcs that make the rounded edges.
        /// </summary>
        /// <param name="brush">System.Drawing.Brush that determines the characteristics of the fill.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle to fill.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle to fill.</param>
        /// <param name="width">Width of the rectangle to fill.</param>
        /// <param name="height">Height of the rectangle to fill.</param>
        /// <param name="radius">The radius of the arc used for the rounded edges.</param>

        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            float x,
            float y,
            float width,
            float height,
            float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath path = graphics.GenerateRoundedRectangle(rectangle, radius);
            SmoothingMode old = graphics.SmoothingMode;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.FillPath(brush, path);
            graphics.SmoothingMode = old;
        }

        /// <summary>
        /// Fills the interior of a rounded rectangle specified by a pair of coordinates, a width, a height
        /// and the radius for the arcs that make the rounded edges.
        /// </summary>
        /// <param name="brush">System.Drawing.Brush that determines the characteristics of the fill.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle to fill.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle to fill.</param>
        /// <param name="width">Width of the rectangle to fill.</param>
        /// <param name="height">Height of the rectangle to fill.</param>
        /// <param name="radius">The radius of the arc used for the rounded edges.</param>

        public static void FillRoundedRectangle(
            this Graphics graphics,
            Brush brush,
            int x,
            int y,
            int width,
            int height,
            int radius)
        {
            graphics.FillRoundedRectangle(
                brush,
                Convert.ToSingle(x),
                Convert.ToSingle(y),
                Convert.ToSingle(width),
                Convert.ToSingle(height),
                Convert.ToSingle(radius));
        }
    }
}
